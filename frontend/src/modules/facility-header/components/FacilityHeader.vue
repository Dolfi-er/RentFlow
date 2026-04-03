<script setup lang="ts">
  import HeadText from '@/shared/components/HeadText.vue'
  import { onMounted, ref } from 'vue'
  import type { TFacilityInfo } from '../types'
  import { fetchFacilityInfo } from '../api'
  import { useRoute } from 'vue-router'

  const facilityInfo = ref<TFacilityInfo>({
    address: '',
    status: '',
  })

  const route = useRoute()
  onMounted(async () => {
    try {
      facilityInfo.value = await fetchFacilityInfo(route.params?.id as string)
    } catch (err) {
      console.log(err)
    }
  })
</script>

<template>
  <div class="flex justify-between">
    <HeadText :title="facilityInfo.address" subtitle="Ваш объект"></HeadText>
    <div class="flex gap-1 items-center">
      <p class="text-[32px] font-vioada font-normal">{{ facilityInfo.status }}</p>
      <button class="size-10 cursor-pointer flex">
        <img src="@/assets/svg/facilities/down-arrow.svg" alt="Down arrow icon" />
      </button>
    </div>
  </div>
</template>
