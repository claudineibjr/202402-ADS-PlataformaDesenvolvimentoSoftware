<script setup lang="ts">
import TextInput from '@/components/TextInput.vue';
import router, { routes } from '@/router';
import { ref } from 'vue'

const email = ref("");
const password = ref("");

function submit() {
  console.log({ email: email.value, password: password.value }, 'Parâmetros do login');
  if (true) {
    router.replace(routes.orders);
  }
}
</script>

<template>
  <form>
    <TextInput label="Nome de usuário" type="email" v-model="email" id="email" />
    <TextInput label="Senha" type="password" v-model="password" id="password" />

    <button type="button" class="btn btn-primary" @click="submit">Entrar</button>
  </form>  
</template>
