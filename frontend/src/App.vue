<script setup lang="ts">
  import { TheHeader } from './modules/header/components'
  import DashboardPage from './pages/DashboardPage.vue'
</script>

<template>
  <main class="min-h-screen bg-[#F7EFE8]">
    <div class="max-w-360 mx-auto flex gap-13 px-9.5 py-7.5">
      <TheHeader></TheHeader>
      <DashboardPage class="flex-1" />
    </div>
  </main>
  <!-- <RouterView></RouterView> -->
</template>

<style>
  body {
    font-family: 'Montserrat', sans-serif;
    font-weight: 500;
    font-size: 14px;
  }
</style>
