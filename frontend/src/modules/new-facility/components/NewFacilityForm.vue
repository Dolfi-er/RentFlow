<script setup lang="ts">
  import FilesForm from './FilesForm.vue'
  import FormButton from './FormButton.vue'
  import FormInput from './FormInput.vue'
  import type { TFacilityForm } from '../types'
  import { ref } from 'vue'
  import { handleForm } from '../api'

  const facilityForm = ref<TFacilityForm>({
    address: '',
    price: 0,
    phone: '',
    images: [],
    description: '',
  })
</script>

<template>
  <section class="bg-white mt-10 rounded-4xl flex overflow-hidden min-w-0">
    <div class="flex gap-3">
      <div class="w-3 bg-[#351303]"></div>
      <div class="w-3 bg-[#996F51]"></div>
      <div class="w-3 bg-[#351303]"></div>
      <div class="w-3 bg-[#996F51]"></div>
    </div>
    <form
      @submit.prevent="handleForm(facilityForm)"
      class="p-8 flex-1 flex flex-col gap-10 min-w-0"
    >
      <FormInput
        v-model:input-value="facilityForm.address"
        tag="input"
        label="Адрес"
        name="address"
        placeholder="Введите адрес"
        type="text"
      />
      <FormInput
        v-model:input-value="facilityForm.price"
        tag="input"
        label="Цена (₽/месяц)"
        name="price"
        placeholder="Введите цену в рублях"
        type="number"
        min="0"
      />
      <FormInput
        v-model:input-value="facilityForm.phone"
        tag="input"
        label="Контактный телефон"
        name="phone"
        placeholder="Введите контактный телефон"
        type="tel"
      />
      <FilesForm v-model:images="facilityForm.images" />
      <FormInput
        v-model:input-value="facilityForm.description"
        tag="textarea"
        label="Описание"
        name="description"
        placeholder="Введите описание"
        rows="4"
        type="tel"
      />
      <div class="flex gap-8 justify-end">
        <FormButton type="button" @click="$router.back()">Отмена</FormButton>
        <FormButton type="submit">Подтвердить</FormButton>
      </div>
    </form>
  </section>
</template>
