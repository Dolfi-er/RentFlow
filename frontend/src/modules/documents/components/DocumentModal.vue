<script setup lang="ts">
  import LeftLines from '@/shared/components/LeftLines.vue'
  import { ref } from 'vue'
  import type { TDocumentForm } from '../types'
  import { handleForm } from '../api'
  import { useRoute } from 'vue-router'

  const fileInput = ref<HTMLInputElement | null>(null)
  const triggerFileInput = (): void => {
    fileInput.value?.click()
  }

  const documentForm = ref<TDocumentForm>({})
  const handleFile = (event: Event): void => {
    const target = event.target as HTMLInputElement
    if (!target.files) return

    documentForm.value.file = target.files[0]

    target.value = ''
  }

  const emit = defineEmits(['close'])
  const close = () => {
    emit('close')
    documentForm.value = {}
  }

  const route = useRoute()
  async function submitForm() {
    try {
      await handleForm(route.params.id as string, documentForm.value)
      emit('close')

      documentForm.value = {}
    } catch (err) {
      console.log(err)
    }
  }
</script>

<template>
  <div class="w-150 bg-white rounded-4xl overflow-hidden flex">
    <LeftLines first-color="bg-[#5079B2]" second-color="bg-[#072768]" :column-width="8" />
    <form @submit.prevent="submitForm" class="flex-1 py-5 px-4">
      <div class="flex flex-col gap-4">
        <div class="flex flex-col gap-3">
          <label for="name" class="text-[20px]">Название</label>
          <input
            v-model="documentForm.name"
            name="name"
            placeholder="Введите название договора"
            class="text-[16px] p-3 bg-[#F5F5F5] rounded-[20px]"
            required
          />
        </div>
        <div class="flex flex-col gap-3">
          <label for="description" class="text-[20px]">Описание</label>
          <input
            v-model="documentForm.description"
            name="description"
            placeholder="Введите описание договора"
            class="text-[16px] p-3 bg-[#F5F5F5] rounded-[20px]"
            required
          />
        </div>
        <div class="flex flex-col gap-3">
          <div class="flex gap-3">
            <label for="file" class="text-[20px]">Файл</label>
            <input ref="fileInput" type="file" class="hidden" @change="handleFile" />
          </div>
          <button
            type="button"
            @click="triggerFileInput"
            class="size-40 rounded-3xl bg-[#F5F5F5] flex justify-center items-center text-[#8e8e8e] text-[16px] cursor-pointer p-2"
          >
            <p class="truncate">
              {{ !documentForm.file ? 'Добавить файл ' : documentForm.file.name }}
            </p>
          </button>
        </div>
        <div class="flex justify-between text-white mt-8">
          <button
            @click="close"
            type="button"
            class="bg-[#996F51] rounded-[20px] w-35 py-3 cursor-pointer"
          >
            Отмена
          </button>
          <button class="bg-[#351303] rounded-[20px] w-35 py-3 cursor-pointer" type="submit">
            Сохранить
          </button>
        </div>
      </div>
    </form>
  </div>
</template>
