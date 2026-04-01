<script setup lang="ts">
  import ImageList from './ImageList.vue'
  import imageOne from '@/assets/images/facilities/facility-1.jpg'
  import imageTwo from '@/assets/images/facilities/facility-2.jpg'
</script>

<template>
  <div>
    <div class="flex gap-3">
      <label for="photo" class="text-[20px]">Фото</label>
      <button class="cursor-pointer">
        <img src="@/assets/svg/new-facility/clip.svg" alt="Clip icon" />
      </button>
    </div>
    <ImageList :image-urls="[imageOne, imageTwo, imageOne, imageTwo, imageOne, imageTwo]" />
  </div>
</template>
