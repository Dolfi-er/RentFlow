<script setup lang="ts">
  import { inject } from 'vue'

  defineProps<{
    id: string
    user: string
  }>()

  const chooseChat = inject<(id: string) => void>('chooseChat')
</script>

<template>
  <li
    @click="chooseChat?.(id)"
    class="h-14 flex items-center bg-white rounded-[20px] pl-4 pr-2 shrink-0 cursor-pointer"
  >
    <p class="text-[16px] truncate">{{ user }}</p>
  </li>
</template>
