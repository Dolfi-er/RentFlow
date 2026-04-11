<script setup lang="ts">
  import type { TRequest } from '../types'
  import RepairRequestsList from './RepairRequestsList.vue'

  defineProps<{
    requests?: TRequest[]
  }>()
</script>

<template>
  <section class="bg-white rounded-[27px] h-77 px-6 pt-6 flex flex-col">
    <div class="flex justify-between items-center">
      <h3 class="text-[20px]">Заявки на ремонт</h3>
      <a
        class="text-[16px] text-[#596269] tracking-[0.03em] cursor-pointer hover:underline underline-offset-3 transition-all"
        >Все</a
      >
    </div>
    <div
      v-if="!requests || requests.length === 0"
      class="flex-1 flex justify-center items-center mb-6"
    >
      <p class="text-[22px] text-[#596269]">Заявок на ремонт пока нет</p>
    </div>
    <RepairRequestsList v-else :requests="requests" />
  </section>
</template>
