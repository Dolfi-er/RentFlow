<script setup lang="ts">
  defineProps<{
    title: string
    subtitle: string
  }>()
</script>

<template>
  <div>
    <h1 class="text-[32px]">{{ title }}</h1>
    <h2 class="font-normal text-[20px] tracking-[0.03em]">{{ subtitle }}</h2>
  </div>
</template>
