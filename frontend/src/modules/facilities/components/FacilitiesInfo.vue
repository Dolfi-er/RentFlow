<script setup lang="ts">
  import AddFacilityButton from './AddFacilityButton.vue'
  import FacilityList from './FacilityList.vue'
  import SearchBlock from './SearchBlock.vue'
</script>

<template>
  <section>
    <div class="mt-6 flex justify-between items-center">
      <div class="flex justify-between">
        <SearchBlock />
      </div>
      <AddFacilityButton />
    </div>
    <FacilityList />
  </section>
</template>
