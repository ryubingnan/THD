var app;
var $app;

function createVueApp(AttributeBindingApp, element = '#app') {
    app = Vue.createApp(AttributeBindingApp)

    $app = app.config.globalProperties;
    $app.$http = http;

    app.use(ElementPlus, { locale: zhCn })

    // 保持在最后一行
    app.mount(element)
    return app;
}

window.addEventListener('unhandledrejection', (event) => {
    event.preventDefault()
})
