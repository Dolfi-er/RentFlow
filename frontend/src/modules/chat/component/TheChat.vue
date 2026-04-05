<script setup lang="ts">
  import type { TMessage } from '../types'
  import InputField from './InputField.vue'
  import MessageList from './MessageList.vue'

  defineProps<{
    id: string
    user: string
    messages: TMessage[]
  }>()
</script>

<template>
  <div class="flex-1 pt-5 px-3 flex flex-col">
    <p class="text-center text-[24px] mb-2">{{ user }}</p>
    <div class="flex-1 bg-[#AABEDA] rounded-[20px] flex flex-col justify-end overflow-y-auto">
      <MessageList :messages="messages" />
      <InputField :chat-id="id" />
    </div>
  </div>
</template>
