import LoginView from '@/views/LoginView.vue';
import OrdersView from '@/views/OrdersView.vue';
import { createRouter, createWebHistory } from 'vue-router'

export const routes = {
  login: '/login',
  orders: '/orders',
};

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: routes.login,
      name: 'login',
      component: LoginView,
    },
    {
      path: routes.orders,
      name: 'orders',
      component: OrdersView,
    },
  ]
});

export default router;
