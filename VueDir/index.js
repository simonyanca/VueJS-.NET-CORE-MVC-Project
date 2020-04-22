import Vue from 'vue'
import axios from 'axios'
import VueRouter from 'vue-router'
import Market1 from './market1.vue'
Vue.config.productionTip = false
Vue.use(VueRouter)
const routes = [
    {
        path: '/Market1',
        component: Market1,
        props: {

        }
    }
]
const router = new VueRouter({
    routes,
    mode: 'history'
})

new Vue({
    el: '#app',
    router
})
