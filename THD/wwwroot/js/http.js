const BASE_API = ''

class Http {
    defaults = {
        noLoading: false,
        noErrorTip: false,
        isTrim: true,
        showErrorMsg: true,
        loadingText: '加载中...',
        headers: {
            'Content-Type': 'application/json',
        },
    }

    _axios = axios.create({
        timeout: 120000
    })

    request(options) {
        if (Object.keys(options).length <= 0) {
            return Promise.reject(new Error('options required object'))
        }
        let {data} = options
        delete options.data
        const newOptions = {...this.defaults, ...options}
        loading.loading(Boolean(newOptions.noLoading), newOptions.loadingText)
        if (data && newOptions.isTrim) {
            data = trim(data)
        }
        newOptions.url = `${BASE_API}${newOptions.url}`
        if (newOptions.method === 'get' || !newOptions.method) {
            newOptions.params = data || {}
            newOptions.params.ts = new Date().getTime()
        } else {
            newOptions.data = data
        }
        newOptions.headers = {
            ...newOptions.headers,
            //token: session.get(TOKEN) || ''
        }
        return this._axios.request(newOptions).then((res) => {
            const resData = res.data;
            if (resData.success) {
                return Promise.resolve(resData.data)
            }
            else {
                return Promise.reject(res)
            }           
        }).catch((err) => {
            const response = err.response;
            if (response) {
                if (response === 404) {
                    $app.$notify.error({
                        title: '出错了',
                        message: '您访问的链接不存在！',
                    })
                } else if (newOptions.showErrorMsg) {
                    const data = response.data;

                    $app.$notify.error({
                        title: '出错了',
                        message: data.message || '请求错误',
                    })
                }
            }
            else if (err.data) {
                $app.$notify.warning({
                    title: '注意',
                    message: err.data.message || '请求错误',
                })
            }
            
            return Promise.reject(err)
        }).finally(() => {
            loading.unloading(Boolean(options.noLoading))
        })
    }

    get(url, param, other) {
        return this.request({
            method: 'get',
            url,
            data: param,
            ...other
        })
    }

    delete(url, data, other) {
        return this.request({
            method: 'delete',
            url,
            data,
            ...other
        })
    }

    post(url, data, other) {
        return this.request({
            method: 'post',
            url,
            data,
            ...other
        })
    }

    put(url, data, other) {
        return this.request({
            method: 'put',
            url,
            data,
            ...other
        })
    }

    upload(url, data, opt = {}) {
        const newOpt = {...this.defaults, ...opt}
        loading.loading(Boolean(newOpt.noLoading))
        return this._axios({
            headers: {'Content-Type': 'multipart/form-data'},
            method: 'post',
            ...opt,
            url,
            data
        }).then(res => {
            if (res.status === 200) {
                const resData = res.data
                if (resData.url.toString().length > 0) {
                    return Promise.resolve(resData.url)
                } else {
                    return Promise.reject(resData)
                }
            }
            return Promise.resolve(res)
        }).catch(err => {
            if (err.response && err.response.status === 404) {
                Toast({
                    message: '您访问的链接不存在！',
                    duration: 2000
                })
            } else if (newOpt.showErrorMsg) {
                Toast({
                    message: err.message || '参数异常',
                    duration: 2000
                })
            }

            return Promise.reject(err)
        }).finally(() => {
            loading.unloading(Boolean(newOpt.noLoading))
        })
    }
}

const http = new Http();