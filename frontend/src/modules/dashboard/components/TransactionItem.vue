<script setup lang="ts">
  import { formatISOToDateAndTimeString } from '@/shared/utils'

  defineProps<{
    imageUrl: string
    address: string
    datetime: string
    price: number
  }>()
</script>

<template>
  <li
    class="flex justify-between items-center gap-2 pb-5 pr-1 mb-5 border-b border-[rgba(0,0,0,0.1)] last:mb-0 last:border-none"
  >
    <div class="flex gap-5 items-center">
      <img class="size-14.5 rounded-full" :src="imageUrl" alt="Facility image" />
      <div class="flex flex-col gap-1.5">
        <p class="text-[16px] line-clamp-1">{{ address }}</p>
        <p class="text-[12px] text-[#8f8e96]">{{ formatISOToDateAndTimeString(datetime) }}</p>
      </div>
    </div>
    <p class="text-[20px] text-[#072768] font-semibold">₽{{ price }}</p>
  </li>
</template>
