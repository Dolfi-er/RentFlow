import DashboardPage from '@/pages/DashboardPage.vue'
import FacilitiesPage from '@/pages/FacilitiesPage.vue'
import { createRouter, createWebHistory } from 'vue-router'

const routes = [
  {
    path: '/',
    component: DashboardPage,
    name: 'dashboard',
  },
  {
    path: '/facilities',
    component: FacilitiesPage,
    name: 'facilities',
  },
]

const router = createRouter({
  history: createWebHistory(),
  routes,
})

export default router
