import Vue from 'vue'
import VueRouter from 'vue-router'
import accountsRoutes from '@/features/Accounts/accounts-routes'

Vue.use(VueRouter)

const routes = [
  ...accountsRoutes,
  {
    path: '*',
    name: 'error404',
    component: () => import('../features/Shared/Error404.vue')
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
