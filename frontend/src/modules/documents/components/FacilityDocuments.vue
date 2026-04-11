<script setup lang="ts">
  import LeftLines from '@/shared/components/LeftLines.vue'
  import DocumentList from './DocumentList.vue'
  import { onMounted, ref } from 'vue'
  import type { TDocument } from '../types'
  import { fecthDocuments } from '../api'
  import { useRoute } from 'vue-router'

  const documents = ref<TDocument[]>([])
  const route = useRoute()
  onMounted(async () => {
    try {
      documents.value = await fecthDocuments(route.params.id as string)
    } catch (err) {
      console.log(err)
    }
  })
</script>

<template>
  <section class="bg-white rounded-4xl overflow-hidden flex gap-2">
    <LeftLines first-color="bg-[#5079B2]" second-color="bg-[#072768]" />
    <div v-if="documents.length === 0" class="h-30 flex-1 flex justify-center items-center">
      <p class="text-[18px]">Ещё нет ни одного загруженного документа</p>
    </div>
    <DocumentList v-else :documents="documents" />
    <button
      class="size-15 bg-[#072768] rounded-full flex justify-center items-center cursor-pointer fixed bottom-15 right-15"
    >
      <img src="@/assets/svg/docs/docs.svg" alt="Docs logo" />
    </button>
  </section>
</template>
