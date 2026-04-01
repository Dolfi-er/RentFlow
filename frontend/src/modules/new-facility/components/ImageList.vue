<script setup lang="ts">
  import ImageItem from './ImageItem.vue'

  defineProps<{
    imageUrls: string[]
  }>()
</script>

<template>
  <div class="flex gap-x-4 overflow-x-auto mt-3 pb-2">
    <ImageItem v-for="(imageUrl, index) in imageUrls" :key="index" :image-url="imageUrl" />
  </div>
</template>
