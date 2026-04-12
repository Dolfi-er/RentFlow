<script setup lang="ts">
  import FacilityNavItem from './FacilityNavItem.vue'
  import infoSvg from '@/assets/svg/facility-nav/info.svg'
  import chatSvg from '@/assets/svg/facility-nav/chat.svg'
  import requestSvg from '@/assets/svg/facility-nav/request.svg'
  import docsSvg from '@/assets/svg/facility-nav/docs.svg'
  import transactionsSvg from '@/assets/svg/facility-nav/transactions.svg'
  import { useRoute } from 'vue-router'
  import { computed } from 'vue'

  const route = useRoute()
  const currentRouterName = computed(() => route.name?.toString())
</script>

<template>
  <ul class="mt-8 ml-29 flex gap-3">
    <FacilityNavItem
      :icon-url="infoSvg"
      router-name="facility"
      :current-router-name="currentRouterName"
      class="bg-[#351303]"
    />
    <FacilityNavItem
      :icon-url="chatSvg"
      router-name="facility-chats"
      :current-router-name="currentRouterName"
      class="bg-[#072768]"
    />
    <FacilityNavItem
      :icon-url="requestSvg"
      router-name=""
      :current-router-name="currentRouterName"
      class="bg-[#996F51]"
    />
    <FacilityNavItem
      :icon-url="docsSvg"
      router-name="facility-docs"
      :current-router-name="currentRouterName"
      class="bg-[#5079B2]"
    />
    <FacilityNavItem
      :icon-url="transactionsSvg"
      router-name="facility-transactions"
      :current-router-name="currentRouterName"
      class="bg-[#A1A1A1]"
    />
  </ul>
</template>
