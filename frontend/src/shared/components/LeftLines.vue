<script setup lang="ts">
  const { columnWidth = 12 } = defineProps<{
    columnWidth?: number
    firstColor: string
    secondColor: string
  }>()
</script>

<template>
  <div
    :class="['flex']"
    :style="{
      gap: columnWidth + 'px',
    }"
  >
    <div
      :class="[firstColor]"
      :style="{
        width: columnWidth + 'px',
      }"
    ></div>
    <div
      :class="[secondColor]"
      :style="{
        width: columnWidth + 'px',
      }"
    ></div>
    <div
      :class="[firstColor]"
      :style="{
        width: columnWidth + 'px',
      }"
    ></div>
    <div
      :class="[secondColor]"
      :style="{
        width: columnWidth + 'px',
      }"
    ></div>
  </div>
</template>
