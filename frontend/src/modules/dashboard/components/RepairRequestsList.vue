<script setup lang="ts">
  import type { TRequest } from '../types'
  import RepairRequestsItem from './RepairRequestsItem.vue'

  defineProps<{
    requests: TRequest[]
  }>()
</script>

<template>
  <ul class="mt-5 flex-1 flex flex-col gap-5 overflow-auto">
    <RepairRequestsItem
      v-for="r in requests"
      :key="r.id"
      :category="r.category"
      :address="r.address"
      :request-text="r.name"
      :status="r.status"
    />
  </ul>
</template>
