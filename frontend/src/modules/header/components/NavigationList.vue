<script setup lang="ts">
  import MainPageLogo from '@/assets/svg/nav/MainPageLogo.vue'
  import NavigationItem from './NavigationItem.vue'
  import ChatLogo from '@/assets/svg/nav/ChatLogo.vue'
  import FacilitiesLogo from '@/assets/svg/nav/FacilitiesLogo.vue'
  import UsersLogo from '@/assets/svg/nav/UsersLogo.vue'
  import CalendarLogo from '@/assets/svg/nav/CalendarLogo.vue'
</script>

<template>
  <ul class="flex flex-col gap-2.25">
    <NavigationItem>
      <div class="grid grid-cols-2 gap-0.5">
        <MainPageLogo />
        <MainPageLogo />
        <MainPageLogo />
        <MainPageLogo />
      </div>
    </NavigationItem>
    <NavigationItem>
      <ChatLogo />
    </NavigationItem>
    <NavigationItem>
      <FacilitiesLogo />
    </NavigationItem>
    <NavigationItem>
      <UsersLogo />
    </NavigationItem>
    <NavigationItem>
      <CalendarLogo />
    </NavigationItem>
  </ul>
</template>
