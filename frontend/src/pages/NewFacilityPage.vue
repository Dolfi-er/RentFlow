<script setup lang="ts">
  import { NewFacilityForm } from '@/modules/new-facility/components'
  import HeadText from '@/shared/components/HeadText.vue'
</script>

<template>
  <div class="flex-1 min-w-0">
    <HeadText title="Новый объект недвижимости" subtitle="Добавьте новый объект для управления" />
    <NewFacilityForm />
  </div>
</template>
