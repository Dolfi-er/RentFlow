<script setup lang="ts">
  import FacilityHeader from '@/modules/facility-header/components/FacilityHeader.vue'
  import FacilityNavList from '@/modules/facility-nav/components/FacilityNavList.vue'
</script>

<template>
  <section class="flex-1 min-w-0">
    <FacilityHeader />
    <FacilityNavList />
    <RouterView></RouterView>
  </section>
</template>
