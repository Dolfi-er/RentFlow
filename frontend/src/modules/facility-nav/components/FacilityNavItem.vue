<script setup lang="ts">
  defineProps<{
    iconUrl: string
  }>()
</script>

<template>
  <li class="w-15 h-12 rounded-t-[15px] flex justify-center items-center cursor-pointer">
    <img :src="iconUrl" alt="Icon" />
  </li>
</template>
