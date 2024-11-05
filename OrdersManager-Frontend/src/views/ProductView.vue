<script setup lang="ts">
import api from '@/api';
import { onMounted, ref } from 'vue';
import type { ProductType } from '@/models/Product';
import { formatCurrency } from '@/utils/formatCurrency';

type ProductViewProps = {
  id: string;
};

const props = defineProps<ProductViewProps>();
const productId = props.id;

const product = ref<ProductType>();
const isLoading = ref(false);

onMounted(async () => {
  console.log('Buscando produto...');

  try {
    isLoading.value = true;
    const productResult = await api.get<ProductType>(`/product/${productId}`);

    console.log({ productResult }, '[Product]');

    product.value = productResult.data;
  } catch (error) {
    alert("Falha ao buscar produto");

    console.error({ error }, 'Falha ao buscar produto');
  } finally {
    isLoading.value = false;
  }
});

</script>

<template fluid>
  <div class="product-page">
    Product {{ props.id }}

    <br/>
    <br/>

    <div v-if="isLoading">
      Loading...
    </div>
    <div v-else-if="!isLoading && Boolean(product)" class="product-info">
      <div>
        Nome: {{ product!.name }}
      </div>
      
      <div>
        Valor: {{ formatCurrency(product!.price) }}
      </div>

      <div v-if="product!.imageUrl">
        <img :src="product?.imageUrl">
      </div>
      <div v-else>Sem imagem</div>
    </div>
  </div>
  
</template>


<style scoped>
.product-page {
  display: flex;
  flex-direction: column;
}

.product-info {
  display: flex;
  flex-direction: column;
}
</style>