<script setup lang="ts">
  import DashboardInfo from './DashboardInfo.vue'
  import allObjectsSvg from '@/assets/svg/dashboard/all-objects.svg'
  import rentedObjectsSvg from '@/assets/svg/dashboard/rented-objects.svg'
  import revenueSvg from '@/assets/svg/dashboard/revenue.svg'
</script>

<template>
  <div class="grid grid-cols-3 gap-3 mt-6.5">
    <DashboardInfo
      :logo-url="allObjectsSvg"
      title="Всего объектов"
      value="15"
      month-ago-value="12"
      bg-color="bg-[#072768]"
      icon-color="bg-[#B8C9E0]"
    />
    <DashboardInfo
      :logo-url="rentedObjectsSvg"
      title="Сданных"
      value="10"
      month-ago-value="12"
      bg-color="bg-[#351303]"
      icon-color="bg-[#967566]"
    />
    <DashboardInfo
      :logo-url="revenueSvg"
      title="Доход"
      value="₽300т."
      month-ago-value="₽270т."
      bg-color="bg-[#996F51]"
      icon-color="bg-[#DCC9BC]"
    />
  </div>
</template>
