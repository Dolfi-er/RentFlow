import { LoginBlock, RegisterBlock } from '@/modules/auth/components'
import { FacilityInfo } from '@/modules/facility/components'
import AuthPage from '@/pages/AuthPage.vue'
import DashboardPage from '@/pages/DashboardPage.vue'
import FacilitiesPage from '@/pages/FacilitiesPage.vue'
import NewFacilityPage from '@/pages/NewFacilityPage.vue'
import FacilityPage from '@/pages/FacilityPage.vue'
import { createRouter, createWebHistory } from 'vue-router'
import { FacilityChats } from '@/modules/chat/component'
import { FacilityDocuments } from '@/modules/documents/components'

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
    path: '/facilities/:id',
    component: FacilityPage,
    props: true,
    children: [
      {
        path: '',
        component: FacilityInfo,
        name: 'facility',
      },
      {
        path: 'chats',
        component: FacilityChats,
        name: 'facility-chats',
      },
      {
        path: 'docs',
        component: FacilityDocuments,
        name: 'facility-docs',
      },
    ],
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
