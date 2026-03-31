<script setup lang="ts">
  import FacilitiesInfo from '@/modules/facilities/components/FacilitiesInfo.vue'
  import HeadText from '@/shared/components/HeadText.vue'
</script>

<template>
  <div>
    <HeadText
      title="Объекты недвжимости"
      subtitle="Здесь вы можете управлять своей собственностью"
    />
    <FacilitiesInfo />
  </div>
</template>
