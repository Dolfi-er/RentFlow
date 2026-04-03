<script setup lang="ts">
  import FacilityNavItem from './FacilityNavItem.vue'
  import infoSvg from '@/assets/svg/facility-nav/info.svg'
  import chatSvg from '@/assets/svg/facility-nav/chat.svg'
  import requestSvg from '@/assets/svg/facility-nav/request.svg'
  import docsSvg from '@/assets/svg/facility-nav/docs.svg'
</script>

<template>
  <ul class="mt-8 ml-29 flex gap-3">
    <FacilityNavItem :icon-url="infoSvg" class="bg-[#351303]" />
    <FacilityNavItem :icon-url="chatSvg" class="bg-[#072768]" />
    <FacilityNavItem :icon-url="requestSvg" class="bg-[#996F51]" />
    <FacilityNavItem :icon-url="docsSvg" class="bg-[#5079B2]" />
  </ul>
</template>
