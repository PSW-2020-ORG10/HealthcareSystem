import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import Registration from '../views/Registration.vue'
import Report from '../views/Report.vue'
import ActionsAndBenefits from '../views/ActionsAndBenefits.vue'
import MedicineSpecification from '../views/MedicineSpecification.vue'
import MedicineAvailability from '../views/MedicineAvailability.vue'
import SharingPrescription from '../views/SharingPrescription.vue'
Vue.use(VueRouter)



const routes = [
    {
        path: '/',
        name: 'Home',
        component: Home
    },
    {
        path: '/registration',
        name: 'Registration',
        component: Registration,
    },
    {
        path: '/report',
        name: 'Report',
        component: Report,
    },
    {
        path: '/actionsAndBenefits',
        name: 'ActionsAndBenefits',
        component: ActionsAndBenefits,
    },
    {
        path: '/specification',
        name: 'MedicineSpecification',
        component: MedicineSpecification,
    },
    {
        path: '/availability',
        name: 'MedicineAvailability',
        component: MedicineAvailability,
    },
    {
        path: '/sharingPrescription',
        name: 'SharingPrescription',
        component: SharingPrescription,
    }

]

const router = new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes
})

export default router