<script setup lang="ts">
  defineProps<{
    logoUrl: string
    title: string
    value?: string
    monthAgoValue?: string
    bgColor: string
    iconColor: string
  }>()
</script>

<template>
  <section :class="['h-43 rounded-[27px] pt-7 px-7', bgColor]">
    <div class="flex gap-4 items-center">
      <div :class="['rounded-full size-12 flex items-center justify-center', iconColor]">
        <img :src="logoUrl" />
      </div>
      <p class="text-white text-[20px] w-33.5 leading-6">{{ title }}</p>
    </div>
    <div class="flex gap-3.5 items-center text-white font-normal mt-4">
      <p class="text-[36px]">{{ value }}</p>
      <p class="tracking-[0.03em] text-[16px] pt-0.75">В прошлый месяц {{ monthAgoValue }}</p>
    </div>
  </section>
</template>
