<script setup lang="ts">
  import type { TDocument } from '../types'
  import DocumentItem from './DocumentItem.vue'

  defineProps<{
    documents: TDocument[]
  }>()
</script>

<template>
  <ul class="flex flex-col gap-2 flex-1 px-3 pt-5">
    <DocumentItem
      v-for="doc in documents"
      :key="doc.id"
      :id="doc.id"
      :file-url="doc.fileUrl"
      :name="doc.name"
      :description="doc.description"
    />
  </ul>
</template>
