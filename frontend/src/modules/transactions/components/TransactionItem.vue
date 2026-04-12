<script setup lang="ts">
  import { formatISODate } from '@/shared/utils'

  defineProps<{
    id: string
    name: string
    date: string
    price: number
    status: string
  }>()
</script>

<template>
  <li class="flex items-center font-normal h-24 border-b last:border-none pb-2">
    <div class="size-10 bg-[#A1A1A1] rounded-full flex justify-center items-center mr-3 flex-none">
      <img class="size-7" src="@/assets/svg/facility-nav/transactions.svg" alt="Transactions svg" />
    </div>
    <div class="basis-3/7 border-x h-full flex justify-center items-center px-2">
      <p class="text-[17px] text-center line-clamp-2">{{ name }}</p>
    </div>
    <div class="basis-2/7 border-r h-full flex justify-center items-center px-2">
      <p class="text-[16px] text-center line-clamp-2">{{ formatISODate(date) }}</p>
    </div>
    <div class="basis-1/7 border-r h-full flex justify-center items-center px-2">
      <p class="text-[16px] text-center line-clamp-2">{{ status }}</p>
    </div>
    <div class="basis-1/7 h-full flex justify-center items-center">
      <p class="text-[18px] text-center line-clamp-2">
        <span class="font-medium">{{ price }}</span
        >₽
      </p>
    </div>
  </li>
</template>
