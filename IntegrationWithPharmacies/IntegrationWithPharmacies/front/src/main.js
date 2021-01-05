import Vue from 'vue'
import router from './router'
import axios from 'axios'
import VueAxios from 'vue-axios'
import App from './App.vue'





Vue.config.productionTip = false
Vue.use(VueAxios, axios)

new Vue({
    router: router,
    render: h => h(App)
}).$mount('#app')