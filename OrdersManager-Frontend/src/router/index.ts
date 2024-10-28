import { createRouter, createWebHistory } from 'vue-router'
import authRoutes from './authRoutes';
import LoginView from '@/views/LoginView.vue';
import OrdersView from '@/views/OrdersView.vue';

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/login',
      name: 'login',
      component: LoginView,
    },
    {
      path: '/orders',
      name: 'orders',
      component: OrdersView,
    },
  ]
})

router.beforeEach(authRoutes);

export default router;
