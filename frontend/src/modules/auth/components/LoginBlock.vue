<script setup lang="ts">
  import FormInput from './FormInput.vue'
  import type { TLoginForm } from '../types'
  import { ref } from 'vue'
  import { submitLoginForm } from '../api'
  import { AxiosError } from 'axios'
  import FormButton from './FormButton.vue'
  import { useRouter } from 'vue-router'
  import { useUserStore } from '@/shared/stores'

  const loginForm = ref<TLoginForm>({
    login: '',
    password: '',
  })

  const router = useRouter()
  const error = ref<string | null>(null)
  async function handleLoginForm() {
    try {
      const accessToken = await submitLoginForm(loginForm.value)

      const userStore = useUserStore()
      userStore.authenticate(accessToken)

      router.push({ name: 'dashboard' })
    } catch (err) {
      if (err instanceof AxiosError) {
        error.value = err.response?.data.errorMessage
      }
    }
  }
</script>

<template>
  <form @submit.prevent="handleLoginForm">
    <h2 class="font-vioada text-[36px] mt-5 tracking-[0.01em]">С возвращением</h2>
    <p class="text-[20px] font-normal mt-3">
      Настало время управлять своей судьбой вместе с
      <span class="font-bold text-[#313957]">RentFlow!</span>
    </p>
    <div class="mt-8 flex flex-col gap-4">
      <FormInput label="Логин" name="login" placeholder="" type="text" v-model="loginForm.login" />
      <FormInput
        label="Пароль"
        name="password"
        placeholder="Минимум 8 символов"
        type="password"
        minlength="8"
        v-model="loginForm.password"
      />
    </div>
    <p v-if="error" class="mt-6 text-[18px] text-center font-roboto font-normal text-[#cc1616]">
      Неверный логин или пароль
    </p>
    <a href="" class="font-roboto font-normal text-[#5079B2] flex justify-end text-[16px] mt-5"
      >Забыли пароль?</a
    >
    <FormButton class="mt-4.5">Войти</FormButton>
    <p class="font-normal text-[16px] text-[#313957] mt-7 text-center">
      Нет аккаунта?
      <span class="text-[#5079B2]">
        <RouterLink :to="{ name: 'register' }"><a href="">Зарегистрируйтесь</a></RouterLink>
      </span>
    </p>
  </form>
</template>
