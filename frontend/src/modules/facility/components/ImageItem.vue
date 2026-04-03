<script setup lang="ts">
  defineProps<{
    imageUrl: string
  }>()
</script>

<template>
  <div class="size-57.5 shrink-0">
    <img :src="imageUrl" class="w-full h-full object-cover rounded-3xl" />
  </div>
</template>
