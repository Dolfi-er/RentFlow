<script setup lang="ts">
  import type { TMessage } from '../types'
  import MessageItem from './MessageItem.vue'

  defineProps<{
    messages: TMessage[]
  }>()
</script>

<template>
  <ul class="flex-1 flex flex-col-reverse gap-4 overflow-y-auto overscroll-contain p-8">
    <MessageItem
      v-for="message in messages"
      :key="message.id"
      :id="message.id"
      :datetime="message.datetime"
      :message="message.message"
      :sender="message.sender"
    />
  </ul>
</template>
