<script setup lang="ts">
  defineProps<{
    isOpen: boolean
  }>()
</script>

<template>
  <div v-show="isOpen" class="fixed inset-0 bg-[rgba(0,0,0,0.5)] flex justify-center items-center">
    <slot></slot>
  </div>
</template>
