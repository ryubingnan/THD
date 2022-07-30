
class Loading {
    constructor() {
        this._count = 0
        this._timer = 0
        this.LoadingThreshold = 300
        this.loadingInstance = null
    }

    loading(noLoading) {
        if (noLoading) {
            return
        }
        this._count++
        if (this._count === 1) {
            this._timer = window.setTimeout(() => this._loading(), this.LoadingThreshold)
        }
    }

    unloading(noLoading) {
        if (noLoading) {
            return
        }
        this._count--
        if (this._count <= 0) {
            clearTimeout(this._timer)
            this._count = 0
            if (this._count === 0) {
                this.loadingInstance && this.loadingInstance.close()
            }
        }
    }

    _loading() {
        if (this._count > 0) {
            this.loadingInstance = $app.$loading({ fullscreen: true, text: '拼命加载中...', background: 'rgba(0,0,0,0.5)' })
        }
    }
}

const loading = new Loading()
