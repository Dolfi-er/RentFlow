<script setup lang="ts">
  import type { TTransaction } from '../types'
  import TransactionsList from './TransactionsList.vue'

  defineProps<{
    transactions?: TTransaction[]
  }>()
</script>

<template>
  <section class="bg-white px-6 pt-6 rounded-[27px] h-77 flex flex-col">
    <h3 class="text-[20px]">Последние транзакции</h3>
    <div
      v-if="!transactions || transactions.length === 0"
      class="flex-1 flex justify-center items-center mb-6"
    >
      <p class="text-[22px] text-[#596269]">Транзакций пока нет</p>
    </div>
    <TransactionsList v-else :transactions="transactions" />
    <div></div>
  </section>
</template>
