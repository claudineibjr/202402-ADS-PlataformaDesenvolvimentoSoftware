<script setup lang="ts">
import OrdersTableHeader from '@/components/OrdersTableHeader.vue';
import OrdersTableItem from '@/components/OrdersTableItem.vue';
import type { OrderType } from '@/models/Order';

const orders: OrderType[] = [
  {
    "id": "82792d8a-c37b-419e-85f6-60aac56f6b97",
    "customer": {
      "name": "Ana Pereira",
    },
    "orderDate": new Date("2024-10-28T18:28:16.37105"),
    "products": [
      {
        "product": {
          "id": "Trakinas",
          "name": "Biscuits Recheado Trakinas",
          "price": 4.5,
        },
        "quantity": 5
      },
      {
        "product": {
          "id": "Marilan",
          "name": "Biscoito Integral Marilan",
          "price": 5.5,
        },
        "quantity": 3
      },
      {
        "product": {
          "id": "Coca_Cola",
          "name": "Coca-Cola",
          "price": 5
        },
        "quantity": 1
      }
    ],
    "totalAmount": 44
  },
  {
    "id": "dc100f38-70ce-4c40-9cf0-ef14a708cad7",
    "customer": {
      "name": "Ana Pereira",
    },
    "orderDate": new Date("2024-10-28T18:28:38.634609"),
    "products": [
      {
        "product": {
          "id": "Nivea",
          "name": "Nivea Condicionador",
          "price": 10.5,
        },
        "quantity": 2
      },
      {
        "product": {
          "id": "Fanta",
          "name": "Fanta Laranja",
          "price": 5
        },
        "quantity": 3
      }
    ],
    "totalAmount": 36
  },
  {
    "id": "ef4b249d-5267-455f-81bf-1ddb62d60294",
    "customer": {
      "name": "Ana Pereira"
    },
    "orderDate": new Date("2024-10-28T18:28:50.463012"),
    "products": [
      {
        "product": {
          "id": "Club_Social",
          "name": "Club Social Biscoito Salgado",
          "price": 3.5
        },
        "quantity": 10
      }
    ],
    "totalAmount": 35
  }
];

</script>

<template fluid>
  <div class="orders-list">
    <h1>Pedidos</h1>

    <br/>

    <table class="table table-striped table-hover">
      <OrdersTableHeader />
      <tbody>
        <tr v-for="order in orders" v-bind:key="order.id">
          <OrdersTableItem :order="order" />
        </tr>
      </tbody>
    </table>
  </div>
  
</template>


<style scoped>
.orders-list {
  width: 100%;
  margin: 0 auto;
  padding: 0;
  text-align: center;
}
</style>