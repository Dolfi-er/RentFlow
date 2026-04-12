<script setup lang="ts">
  import type { TTransaction } from '../types'
  import TransactionItem from './TransactionItem.vue'

  defineProps<{
    transactions: TTransaction[]
  }>()
</script>

<template>
  <ul class="flex flex-col gap-2 flex-1 px-3 pt-5">
    <TransactionItem
      v-for="t in transactions"
      :key="t.id"
      :id="t.id"
      :name="t.name"
      :date="t.date"
      :price="t.price"
      :status="t.status"
    />
  </ul>
</template>
