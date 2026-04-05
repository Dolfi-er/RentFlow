<script setup lang="ts">
  defineProps<{
    iconUrl: string
    routerName: string
    currentRouterName?: string
  }>()
</script>

<template>
  <router-link
    :class="[
      'rounded-t-[15px]',
      { 'scale-y-125 origin-bottom ': routerName === currentRouterName },
    ]"
    :to="{ name: routerName }"
  >
    <li
      :class="[
        'w-15 h-12 flex justify-center items-center cursor-pointer',
        { 'scale-y-80': routerName === currentRouterName },
      ]"
    >
      <img :src="iconUrl" alt="Icon" />
    </li>
  </router-link>
</template>
