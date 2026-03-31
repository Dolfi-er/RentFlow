<script setup lang="ts">
  import { FacilitiesInfo } from '@/modules/facilities/components'
  import HeadText from '@/shared/components/HeadText.vue'
</script>

<template>
  <div class="flex-1">
    <HeadText
      title="Объекты недвжимости"
      subtitle="Здесь вы можете управлять своей собственностью"
    />
    <FacilitiesInfo />
  </div>
</template>
