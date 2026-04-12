<script setup lang="ts">
  import LeftLines from '@/shared/components/LeftLines.vue'
  import TransactionList from './TransactionList.vue'
  import { onMounted, ref } from 'vue'
  import type { TTransaction } from '../types'
  import { fecthTransactions } from '../api'
  import { useRoute } from 'vue-router'
  import TheModal from '@/shared/components/TheModal.vue'
  import TransactionModal from './TransactionModal.vue'

  const transactions = ref<TTransaction[]>([])
  const route = useRoute()
  onMounted(async () => {
    try {
      transactions.value = await fecthTransactions(route.params.id as string)
    } catch (err) {
      console.log(err)
    }
  })

  const isModalOpen = ref<boolean>(false)
  const openModal = () => {
    isModalOpen.value = true
  }

  const closeModal = () => {
    isModalOpen.value = false
  }
</script>

<template>
  <section class="bg-white rounded-4xl overflow-hidden flex gap-2">
    <LeftLines first-color="bg-[#A1A1A1]" second-color="bg-[#505050]" />
    <div v-if="transactions.length === 0" class="h-30 flex-1 flex justify-center items-center">
      <p class="text-[18px]">Ещё нет ни одного загруженного документа</p>
    </div>
    <TransactionList v-else :transactions="transactions" />
    <button
      @click="openModal"
      v-show="!isModalOpen"
      class="size-15 bg-[#505050] rounded-full flex justify-center items-center cursor-pointer fixed bottom-15 right-15"
    >
      <img src="@/assets/svg/docs/docs.svg" alt="Docs logo" />
    </button>
    <TheModal :is-open="isModalOpen">
      <TransactionModal @close="closeModal" />
    </TheModal>
  </section>
</template>
