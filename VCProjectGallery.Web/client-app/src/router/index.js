import Vue from 'vue'
import VueRouter from 'vue-router'
import accountsRoutes from '@/features/Accounts/accounts-routes'
import projectsRoutes from '@/features/Projects/projects-routes'

Vue.use(VueRouter)

const routes = [
  ...accountsRoutes,
  ...projectsRoutes,
  {
    path: '/',
    redirect: '/login'
  },
  {
    path: '*',
    name: 'error404',
    component: () => import('../features/Shared/views/Error404.vue')
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
