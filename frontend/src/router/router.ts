import { LoginBlock, RegisterBlock } from '@/modules/auth'
import AuthPage from '@/pages/AuthPage.vue'
import DashboardPage from '@/pages/DashboardPage.vue'
import FacilitiesPage from '@/pages/FacilitiesPage.vue'
import NewFacilityPage from '@/pages/NewFacilityPage.vue'
import { createRouter, createWebHistory } from 'vue-router'

const routes = [
  {
    path: '/',
    component: DashboardPage,
    name: 'dashboard',
  },
  {
    path: '/auth',
    component: AuthPage,
    children: [
      {
        path: 'register',
        component: RegisterBlock,
        name: 'register',
      },
      {
        path: 'login',
        component: LoginBlock,
        name: 'login',
      },
    ],
  },
  {
    path: '/facilities',
    component: FacilitiesPage,
    name: 'facilities',
  },
  {
    path: '/new-facility',
    component: NewFacilityPage,
    name: 'new-facility',
  },
]

const router = createRouter({
  history: createWebHistory(),
  routes,
})

export default router
