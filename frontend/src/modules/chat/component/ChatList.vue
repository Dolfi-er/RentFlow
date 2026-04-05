<script setup lang="ts">
  import type { TChatInfo } from '../types'
  import ChatItem from './ChatItem.vue'

  defineProps<{
    chats: TChatInfo[]
  }>()
</script>

<template>
  <ul class="w-60 flex flex-col gap-2 bg-[#072768] mt-4 rounded-[20px] p-2 overflow-y-auto">
    <ChatItem v-for="chat in chats" :key="chat.id" :id="chat.id" :user="chat.user" />
  </ul>
</template>
