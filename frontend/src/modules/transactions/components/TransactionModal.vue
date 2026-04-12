<script setup lang="ts">
  import LeftLines from '@/shared/components/LeftLines.vue'
  import { ref } from 'vue'
  import type { TTransactionForm } from '../types'
  import { handleForm } from '../api'
  import { useRoute } from 'vue-router'

  const transactionForm = ref<TTransactionForm>({})

  const emit = defineEmits(['close'])
  const close = () => {
    emit('close')
    transactionForm.value = {}
  }

  const route = useRoute()
  async function submitForm() {
    try {
      await handleForm(route.params.id as string, transactionForm.value)
      emit('close')

      transactionForm.value = {}
    } catch (err) {
      console.log(err)
    }
  }
</script>

<template>
  <div class="w-150 bg-white rounded-4xl overflow-hidden flex">
    <LeftLines first-color="bg-[#A1A1A1]" second-color="bg-[#505050]" :column-width="8" />
    <form @submit.prevent="submitForm" class="flex-1 py-5 px-4">
      <div class="flex flex-col gap-4">
        <div class="flex flex-col gap-3">
          <label for="name" class="text-[20px]">Название</label>
          <input
            v-model="transactionForm.name"
            name="name"
            placeholder="Введите название договора"
            class="text-[16px] p-3 bg-[#F5F5F5] rounded-[20px]"
            required
          />
        </div>
        <div class="flex flex-col gap-3">
          <label for="price" class="text-[20px]">Сумма</label>
          <input
            v-model="transactionForm.price"
            name="price"
            type="number"
            min="0"
            placeholder="Введите сумму"
            class="text-[16px] p-3 bg-[#F5F5F5] rounded-[20px]"
            required
          />
        </div>
        <div class="flex flex-col gap-3">
          <label for="date" class="text-[20px]">Дата оплаты</label>
          <input
            v-model="transactionForm.date"
            name="date"
            type="date"
            placeholder="Введите дату оплаты"
            class="text-[16px] p-3 bg-[#F5F5F5] rounded-[20px]"
            required
          />
        </div>

        <div class="flex justify-between text-white mt-8">
          <button
            @click="close"
            type="button"
            class="bg-[#5079B2] rounded-[20px] w-35 py-3 cursor-pointer"
          >
            Отмена
          </button>
          <button class="bg-[#072768] rounded-[20px] w-35 py-3 cursor-pointer" type="submit">
            Сохранить
          </button>
        </div>
      </div>
    </form>
  </div>
</template>
