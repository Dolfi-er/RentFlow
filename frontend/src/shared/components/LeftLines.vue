<script setup lang="ts">
  defineProps<{
    firstColor: string
    secondColor: string
  }>()
</script>

<template>
  <div class="flex gap-3">
    <div :class="['w-3', firstColor]"></div>
    <div :class="['w-3', secondColor]"></div>
    <div :class="['w-3', firstColor]"></div>
    <div :class="['w-3', secondColor]"></div>
  </div>
</template>
