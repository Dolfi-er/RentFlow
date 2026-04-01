<script setup lang="ts">
  import ImageList from './ImageList.vue'
  import type { TImageItem } from '../types'
  import { provide, ref } from 'vue'

  const images = defineModel<TImageItem[]>('images', {
    required: true,
  })

  const fileInput = ref<HTMLInputElement | null>(null)
  const triggerFileInput = (): void => {
    fileInput.value?.click()
  }

  const handleFiles = (event: Event): void => {
    const target = event.target as HTMLInputElement
    if (!target.files) return

    const files: File[] = Array.from(target.files)

    files.forEach((file) => {
      images.value.push({
        file,
        url: URL.createObjectURL(file),
      })
    })

    target.value = ''
  }

  const removeImage = (index: number): void => {
    const image = images.value[index]
    if (!image) return

    URL.revokeObjectURL(image.url)
    images.value.splice(index, 1)
  }
  provide('removeImage', removeImage)
</script>

<template>
  <div>
    <div class="flex gap-3">
      <label for="photo" class="text-[20px]">Фото</label>
      <button @click="triggerFileInput" type="button" class="cursor-pointer">
        <img src="@/assets/svg/new-facility/clip.svg" alt="Clip icon" />
      </button>
      <input
        ref="fileInput"
        type="file"
        multiple
        accept=".png,.jpg,.jpeg,.webp"
        class="hidden"
        @change="handleFiles"
      />
    </div>
    <div v-if="images.length > 0">
      <ImageList :image-urls="images.map((image) => image.url)" @remove-image="removeImage" />
    </div>
    <button
      v-else
      @click="triggerFileInput"
      class="size-57.5 rounded-3xl bg-[#F5F5F5] flex justify-center items-center text-[#8e8e8e] text-[18px] cursor-pointer mt-3"
    >
      Добавить фото
    </button>
  </div>
</template>
