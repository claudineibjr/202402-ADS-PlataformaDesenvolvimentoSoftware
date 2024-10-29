<script setup lang="ts">
import api from '@/api';
import TextInput from '@/components/TextInput.vue';
import router, { routes } from '@/router';
import { onMounted, ref } from 'vue'

const email = ref("");
const password = ref("");

type SignInResult = string;

async function submit() {
  const signInParameters = { email: email.value, password: password.value };
  
  console.log({ signInParameters }, 'Parâmetros do login');

  try {
    const signInResult = await api.post<SignInResult>('/auth/signIn', signInParameters);
    
    window.localStorage.setItem("AUTH_TOKEN", signInResult.data);

    router.replace(routes.orders);
  } catch (error) {
    alert("Falha no login");

    console.error({ error }, 'Falha no login');
  }
}

onMounted(() => {
  const token = window.localStorage.getItem("AUTH_TOKEN");

  const isAuthenticated = Boolean(token);
  if (isAuthenticated) {
    router.replace(routes.orders);
  }
});
</script>

<template>
  <form>
    <TextInput label="Nome de usuário" type="email" v-model="email" id="email" />
    <TextInput label="Senha" type="password" v-model="password" id="password" />

    <button type="button" class="btn btn-primary" @click="submit">Entrar</button>
  </form>  
</template>
