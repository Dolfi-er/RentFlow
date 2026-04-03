<script setup lang="ts">
  import { formatPrice } from '@/shared/utils'

  defineProps<{
    id: string
    imageUrl: string
    address: string
    price: number
    status: string
    description: string
  }>()
</script>

<template>
  <li class="pl-2.5 py-2.5 pr-3.5 bg-white rounded-[27px] flex gap-7 relative">
    <img class="size-60 rounded-[27px] object-cover" :src="imageUrl" alt="Facility image" />
    <div class="flex-1 font-normal">
      <div
        class="flex justify-between items-center font-vioada py-2.75 text-[24px] tracking-[0.08em]"
      >
        <p class="line-clamp-1">{{ address }}</p>
        <div class="flex gap-1 items-center">
          <p>{{ status }}</p>
          <button class="size-8 cursor-pointer">
            <img src="@/assets/svg/facilities/down-arrow.svg" alt="Down arrow icon" />
          </button>
        </div>
      </div>
      <p class="mt-3 text-[18px] tracking-[0.08em] line-clamp-1">₽{{ formatPrice(price) }}/месяц</p>
      <p class="mt-3 max-w-204 line-clamp-4 leading-7">
        {{ description }}
      </p>
      <RouterLink :to="{ name: 'facility', params: { id: id } }">
        <button
          class="absolute right-5 bottom-3 size-12 flex justify-center items-center cursor-pointer rounded-full hover:bg-[#E2E2E2] transition"
        >
          <img src="@/assets/svg/facilities/right-arrow.svg" alt="Right arrow icon" />
        </button>
      </RouterLink>
    </div>
  </li>
</template>
