<script setup lang="ts">
  import { TheHeader } from './modules/header/components'
</script>

<template>
  <main class="min-h-screen bg-[#F7EFE8]">
    <div class="max-w-360 mx-auto flex gap-13 px-9.5 py-7.5">
      <TheHeader></TheHeader>
      <RouterView></RouterView>
    </div>
  </main>
</template>

<style>
  body {
    font-family: 'Montserrat', sans-serif;
    font-weight: 500;
    font-size: 14px;
  }
</style>
