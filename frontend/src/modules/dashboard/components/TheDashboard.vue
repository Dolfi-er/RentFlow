<script setup lang="ts">
  import DashboardInfo from './DashboardInfo.vue'
  import allObjectsSvg from '@/assets/svg/dashboard/all-objects.svg'
  import rentedObjectsSvg from '@/assets/svg/dashboard/rented-objects.svg'
  import revenueSvg from '@/assets/svg/dashboard/revenue.svg'
  import RevenueSchedule from './RevenueSchedule.vue'
  import FacilitiesDetails from './FacilitiesDetails.vue'
  import LastTransactions from './LastTransactions.vue'
  import RepairRequests from './RepairRequests.vue'
  import { onMounted, ref } from 'vue'
  import type { TDashboard } from '../types'
  import { fetchDashboard } from '../api'
  import { formatThousands } from '@/shared/utils'

  const dashboard = ref<TDashboard>()

  onMounted(async () => {
    try {
      dashboard.value = await fetchDashboard()
    } catch (err) {
      console.log(err)
    }
  })
</script>

<template>
  <div class="mt-6.5">
    <div class="grid grid-cols-3 gap-3">
      <DashboardInfo
        :logo-url="allObjectsSvg"
        title="Всего объектов"
        :value="String(dashboard?.objects.currentMonth)"
        :month-ago-value="String(dashboard?.objects.lastMonth)"
        bg-color="bg-[#072768]"
        icon-color="bg-[#B8C9E0]"
      />
      <DashboardInfo
        :logo-url="rentedObjectsSvg"
        title="Сданных"
        :value="String(dashboard?.rentedObjects.currentMonth)"
        :month-ago-value="String(dashboard?.rentedObjects.lastMonth)"
        bg-color="bg-[#351303]"
        icon-color="bg-[#967566]"
      />
      <DashboardInfo
        :logo-url="revenueSvg"
        title="Доход"
        :value="formatThousands(dashboard?.revenue.currentMonth)"
        :month-ago-value="formatThousands(dashboard?.revenue.lastMonth)"
        bg-color="bg-[#996F51]"
        icon-color="bg-[#DCC9BC]"
      />
    </div>
    <div class="flex gap-3 mt-6">
      <RevenueSchedule :revenue-per-month="dashboard?.revenuePerMonth" class="basis-2/3" />
      <FacilitiesDetails class="basis-1/3" :objects-by-status="dashboard?.objectsByStatus" />
    </div>
    <div class="flex gap-3 mt-8">
      <LastTransactions :transactions="dashboard?.lastTransactions" class="basis-23/50" />
      <RepairRequests :requests="dashboard?.requests" class="basis-27/50" />
    </div>
  </div>
</template>
