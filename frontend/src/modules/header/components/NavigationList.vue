<script setup lang="ts">
  import MainPageLogo from '@/assets/svg/nav/MainPageLogo.vue'
  import NavigationItem from './NavigationItem.vue'
  import ChatLogo from '@/assets/svg/nav/ChatLogo.vue'
  import FacilitiesLogo from '@/assets/svg/nav/FacilitiesLogo.vue'
  import UsersLogo from '@/assets/svg/nav/UsersLogo.vue'
  import CalendarLogo from '@/assets/svg/nav/CalendarLogo.vue'
  import { useRoute } from 'vue-router'
  import { computed } from 'vue'

  const route = useRoute()
  const currentRouterName = computed(() => route.name?.toString())
</script>

<template>
  <ul class="flex flex-col gap-2.25">
    <NavigationItem router-name="dashboard" :current-router-name="currentRouterName">
      <div class="grid grid-cols-2 gap-0.5">
        <MainPageLogo v-for="n in 4" :key="n" :is-active="currentRouterName === 'dashboard'" />
      </div>
    </NavigationItem>
    <NavigationItem router-name="" :current-router-name="currentRouterName">
      <ChatLogo :is-active="currentRouterName === 'chats'" />
    </NavigationItem>
    <NavigationItem router-name="facilities" :current-router-name="currentRouterName">
      <FacilitiesLogo :is-active="currentRouterName === 'facilities'" />
    </NavigationItem>
    <NavigationItem router-name="" :current-router-name="currentRouterName">
      <UsersLogo :is-active="currentRouterName === 'users'" />
    </NavigationItem>
    <NavigationItem router-name="" :current-router-name="currentRouterName">
      <CalendarLogo :is-active="currentRouterName === 'calendar'" />
    </NavigationItem>
  </ul>
</template>
