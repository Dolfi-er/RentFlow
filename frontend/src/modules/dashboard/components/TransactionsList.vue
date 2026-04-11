<script setup lang="ts">
  import type { TTransaction } from '../types'
  import TransactionItem from './TransactionItem.vue'

  defineProps<{
    transactions: TTransaction[]
  }>()
</script>

<template>
  <ul class="mt-5 flex-1 flex flex-col overflow-auto">
    <TransactionItem
      v-for="t in transactions"
      :key="t.id"
      :image-url="t.imageUrl"
      :address="t.address"
      :datetime="t.datetime"
      :price="t.price"
    />
  </ul>
</template>
