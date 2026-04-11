<script setup lang="ts">
  defineProps<{
    category: string
    address: string
    requestText: string
    status: string
  }>()
</script>

<template>
  <li
    class="flex justify-between items-center gap-6 pb-5 pr-1 border-b border-[rgba(0,0,0,0.1)] last:mb-0 last:border-none"
  >
    <div class="flex items-center gap-4 flex-4">
      <div class="flex justify-center items-center size-11 rounded-full bg-[#B8C9E0] shrink-0">
        <img class="size-6" src="@/assets/svg/repair-requests/request.svg" alt="" />
      </div>
      <div class="text-[16px]">
        <p>{{ category }} |</p>
        <p class="line-clamp-1">{{ address }}</p>
      </div>
    </div>
    <div class="flex-2 leading-6 line-clamp-2">{{ requestText }}</div>
    <div class="flex-2 text-[#4C8BE1]">{{ status }}</div>
  </li>
</template>
