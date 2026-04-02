<script setup lang="ts">
  import { useRoute } from 'vue-router'
  import { TheHeader } from './modules/header/components'
  import { computed } from 'vue'

  const route = useRoute()

  const routesWithoutHeader = ['login', 'register']
  const isHasHeader = computed(() => {
    const currentRouteName = route.name?.toString()

    if (currentRouteName !== undefined) {
      return !routesWithoutHeader.includes(currentRouteName)
    }

    return false
  })
</script>

<template>
  <main :class="['min-h-screen', isHasHeader ? 'bg-[#F7EFE8]' : 'bg-[#351303]']">
    <div :class="['max-w-360 mx-auto', { 'flex gap-13 px-9.5 py-7.5': isHasHeader }]">
      <TheHeader v-if="isHasHeader"></TheHeader>
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
