<script setup lang="ts">
  import type { TFacility } from '../types'
  import FacilityItem from './FacilityItem.vue'

  defineProps<{
    facilities: TFacility[]
  }>()
</script>

<template>
  <ul class="mt-5 flex flex-col gap-7">
    <FacilityItem
      v-for="f in facilities"
      :key="f.id"
      :id="f.id"
      :address="f.address"
      :image-url="f.imageUrl"
      :price="f.price"
      :status="f.status"
      :description="f.description"
    />
  </ul>
</template>
