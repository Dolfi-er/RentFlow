<script setup lang="ts">
  defineProps<{
    routerName?: string
    currentRouterName?: string
  }>()
</script>

<template>
  <router-link :to="{ name: routerName }">
    <li
      class="size-15 rounded-full flex items-center justify-center cursor-pointer"
      :class="{ 'bg-[#351303]': routerName !== undefined && routerName === currentRouterName }"
    >
      <a>
        <slot></slot>
      </a>
    </li>
  </router-link>
</template>
