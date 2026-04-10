<script setup lang="ts">
  import TransactionsList from './TransactionsList.vue'
</script>

<template>
  <section class="bg-white px-6 pt-6 rounded-[27px] h-77 flex flex-col">
    <h3 class="text-[20px]">Последние транзакции</h3>
    <TransactionsList />
    <div></div>
  </section>
</template>
