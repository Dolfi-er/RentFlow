<script setup lang="ts">
  import ProfileBlock from './ProfileBlock.vue'
  import TheNavigation from './TheNavigation.vue'
</script>

<template>
  <header class="w-19 flex flex-col items-center pt-4">
    <img class="cursor-pointer" src="@/assets/svg/logo.svg" />
    <TheNavigation />
    <ProfileBlock />
  </header>
</template>
