<script setup lang="ts">
  import { onMounted, ref } from 'vue'
  import AddFacilityButton from './AddFacilityButton.vue'
  import FacilityList from './FacilityList.vue'
  import SearchBlock from './SearchBlock.vue'
  import type { TFacility } from '../types'
  import { fetchFacilities } from '../api'

  const facilities = ref<TFacility[]>([])
  onMounted(async () => {
    try {
      facilities.value = await fetchFacilities()
    } catch (err) {
      console.log(err)
    }
  })
</script>

<template>
  <section>
    <div class="mt-6 flex justify-between items-center">
      <div class="flex justify-between">
        <SearchBlock />
      </div>
      <AddFacilityButton />
    </div>
    <FacilityList v-if="facilities.length > 0" :facilities="facilities" />
    <p v-else class="mt-20 text-center text-[24px]">Пока нет добавленных объектов недвижимости</p>
  </section>
</template>
