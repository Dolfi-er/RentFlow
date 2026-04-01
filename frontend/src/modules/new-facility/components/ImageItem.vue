<script setup lang="ts">
  import { inject } from 'vue'

  defineProps<{
    index: number
    imageUrl: string
  }>()

  const remove = inject<(index: number) => void>('removeImage')
</script>

<template>
  <div class="relative size-57.5 shrink-0">
    <img :src="imageUrl" class="w-full h-full object-cover rounded-3xl" />

    <button
      @click="() => remove?.(index)"
      class="absolute top-0.75 right-0.75 bg-[#4A4848] text-white rounded-full size-6 flex items-center justify-center text-[14px] hover:bg-[#212020] cursor-pointer transition"
    >
      ✕
    </button>
  </div>
</template>
