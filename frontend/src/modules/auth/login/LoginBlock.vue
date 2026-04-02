<script setup lang="ts">
  import FormInput from '../FormInput.vue'
</script>

<template>
  <form @submit.prevent>
    <h2 class="font-vioada text-[36px] mt-5 tracking-[0.01em]">С возвращением</h2>
    <p class="text-[20px] font-normal mt-3">
      Настало время управлять своей судьбой вместе с
      <span class="font-bold text-[#313957]">RentFlow!</span>
    </p>
    <div class="mt-8 flex flex-col gap-4">
      <FormInput label="Почта" name="email" placeholder="example@email.com" type="email" />
      <FormInput
        label="Пароль"
        name="password"
        placeholder="Минимум 8 символов"
        type="password"
        minlength="8"
      />
    </div>
    <a href="" class="font-roboto font-normal text-[#5079B2] flex justify-end text-[16px] mt-5"
      >Забыли пароль?</a
    >
    <button
      class="w-full bg-[#072768] py-3.5 text-[18px] text-white rounded-xl font-normal mt-4.5 cursor-pointer hover:bg-[#072157] transition"
    >
      Войти
    </button>
    <p class="font-normal text-[18px] text-[#313957] mt-7 text-center">
      Нет аккаунта?
      <span class="text-[#5079B2]">
        <RouterLink :to="{ name: 'register' }"><a href="">Зарегистрируйтесь</a></RouterLink>
      </span>
    </p>
  </form>
</template>
