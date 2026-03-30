<script setup lang="ts">
  import RepairRequestsItem from './RepairRequestsItem.vue'

  import waterSupplyLogo from '@/assets/svg/repair-requests/water-supply.svg'
  import electricityLogo from '@/assets/svg/repair-requests/electricity.svg'
  import conditionerLogo from '@/assets/svg/repair-requests/conditioner.svg'
</script>

<template>
  <ul class="mt-5 flex-1 flex flex-col gap-5 overflow-auto">
    <RepairRequestsItem
      :logo-url="waterSupplyLogo"
      type="Водопровод"
      address="Ленина 1, Кв 3"
      request-text="Течёт кухонный кран"
      status="Открыта"
      status-color="text-[#4C8BE1]"
    />
    <RepairRequestsItem
      :logo-url="electricityLogo"
      type="Электричество"
      address="Ленина 1, Кв 3"
      request-text="Искрит розетка"
      status="Назначен мастер"
      status-color="text-[#DFBF29]"
    />
    <RepairRequestsItem
      :logo-url="conditionerLogo"
      type="Кондиционер"
      address="Ленина 1, Кв 3"
      request-text="Кондиционер капает"
      status="Закрыта"
      status-color="text-[#569D6B]"
    />
  </ul>
</template>
