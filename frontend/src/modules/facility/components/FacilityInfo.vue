<script setup lang="ts">
  import LeftLines from '@/shared/components/LeftLines.vue'
  import ImageList from './ImageList.vue'
  import { onMounted, ref } from 'vue'
  import type { TFacility } from '../types'
  import { fetchFacility } from '../api'
  import { useRoute } from 'vue-router'
  import { formatPrice } from '@/shared/utils'

  const facility = ref<TFacility>({
    address: '',
    price: 0,
    phone: '',
    images: [],
    description: '',
  })

  const route = useRoute()
  onMounted(async () => {
    try {
      facility.value = await fetchFacility(route.params?.id as string)
    } catch (err) {
      console.log(err)
    }
  })
</script>

<template>
  <div class="bg-white rounded-4xl overflow-hidden flex">
    <LeftLines first-color="bg-[#351303]" second-color="bg-[#996F51]" />
    <div class="flex-1 p-8 flex flex-col gap-10 min-w-0">
      <div class="flex flex-col gap-2 text-[20px]">
        <p>Адрес</p>
        <p class="font-normal">{{ facility.address }}</p>
      </div>
      <div class="flex flex-col gap-2 text-[20px]">
        <p>Цена (₽/месяц)</p>
        <p class="font-normal">{{ formatPrice(facility.price) }}</p>
      </div>
      <div class="flex flex-col gap-2 text-[20px]">
        <p>Контактный телефон</p>
        <p class="font-normal">{{ facility.phone }}</p>
      </div>
      <div class="flex flex-col gap-2 text-[20px]">
        <p>Фото</p>
        <ImageList :image-urls="facility.images" />
      </div>
      <div class="flex flex-col gap-2 text-[20px]">
        <p>Описание</p>
        <p class="font-normal leading-[150%]">
          {{ facility.description }}
        </p>
      </div>
    </div>
  </div>
</template>
