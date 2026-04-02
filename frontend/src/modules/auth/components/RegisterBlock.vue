<script setup lang="ts">
  import { onMounted, ref } from 'vue'
  import FormInput from './FormInput.vue'
  import { fetchRoles, submitRegisterForm } from '../api'
  import type { TRegisterForm, TRole } from '../types'
  import FormButton from './FormButton.vue'
  import { AxiosError } from 'axios'
  import { useRouter } from 'vue-router'

  const roles = ref<TRole[]>([])
  onMounted(async () => {
    try {
      roles.value = await fetchRoles()
    } catch (err) {
      console.log(err)
    }
  })

  const registerForm = ref<TRegisterForm>({
    email: '',
    surname: '',
    name: '',
    roleId: '',
    sex: 'Мужской',
    password: '',
    repeatPassword: '',
  })

  const router = useRouter()
  const error = ref<string | null>(null)
  async function handleRegisterForm() {
    try {
      await submitRegisterForm(registerForm.value)

      router.push({ name: 'login' })
    } catch (err) {
      if (err instanceof AxiosError) {
        error.value = err.response?.data.message
      } else if (err instanceof Error) {
        error.value = err.message
      }
    }
  }
</script>

<template>
  <form @submit.prevent="handleRegisterForm">
    <h2 class="font-vioada text-[36px] mt-5 tracking-[0.01em]">Регистрация</h2>
    <div class="mt-8 flex flex-col gap-4">
      <FormInput
        label="Фамилия"
        name="surname"
        placeholder="Фамилия"
        type="text"
        v-model="registerForm.surname"
      />
      <FormInput
        label="Имя"
        name="name"
        placeholder="Имя"
        type="text"
        v-model="registerForm.name"
      />
      <FormInput
        label="Отчество"
        name="patronymic"
        placeholder="Отчество"
        type="text"
        v-model="registerForm.patronymic"
      />
      <div class="flex flex-col gap-2 text-[16px] font-normal font-roboto w-[50%]">
        <label for="sex">Пол</label>
        <select
          name="sex"
          required
          v-model="registerForm.sex"
          class="bg-white rounded-xl px-3 py-2.75 border border-[#D4D7E3]"
        >
          <option value="Мужской">Мужской</option>
          <option value="Женский">Женский</option>
        </select>
      </div>
    </div>
    <div class="bg-[#CFDFE2] h-0.5 my-8"></div>
    <div class="flex flex-col gap-4">
      <div class="flex flex-col gap-2 text-[16px] font-normal font-roboto">
        <label for="role">Роль</label>
        <select
          name="role"
          class="bg-white rounded-xl px-3 py-2.75 border border-[#D4D7E3]"
          v-model="registerForm.roleId"
        >
          <option v-for="role in roles" :key="role.id" :value="role.id">{{ role.name }}</option>
        </select>
      </div>
    </div>
    <div class="mt-12 flex flex-col gap-4">
      <FormInput
        label="Почта"
        name="email"
        placeholder="example@email.com"
        type="email"
        v-model="registerForm.email"
      />
      <FormInput
        label="Пароль"
        name="password"
        placeholder="Минимум 8 символов"
        type="password"
        minlength="8"
        v-model="registerForm.password"
      />
      <FormInput
        label="Повторите пароль"
        name="repeat-password"
        placeholder="Минимум 8 символов"
        type="password"
        minlength="8"
        v-model="registerForm.repeatPassword"
      />
    </div>
    <p v-if="error" class="mt-6 text-[18px] text-center font-roboto font-normal text-[#cc1616]">
      {{ error }}
    </p>
    <FormButton class="mt-10">Зарегистрироваться</FormButton>
  </form>
</template>
