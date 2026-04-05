<script setup lang="ts">
  import LeftLines from '@/shared/components/LeftLines.vue'
  import ChatList from './ChatList.vue'
  import Chat from './TheChat.vue'
  import { computed, onMounted, provide, ref } from 'vue'
  import type { TChat } from '../types'
  import { fetchChats } from '../api'
  import { useRoute } from 'vue-router'

  const chats = ref<TChat[]>([])

  const activeChat = computed(() => {
    return chats.value.find((chat) => chat.id === activeChatId.value)
  })
  const activeChatId = ref<string | undefined>()

  const chooseChat = (id: string) => {
    activeChatId.value = id
  }
  provide('chooseChat', chooseChat)

  function addMessage(chatId: string, messageId: string, message: string): void {
    const chat = chats.value.find((chat) => chat.id === chatId)

    if (!chat) return
    chat.messages.unshift({
      id: messageId,
      datetime: new Date().toISOString(),
      message,
      sender: false,
    })
  }
  provide('addMessage', addMessage)

  const route = useRoute()
  onMounted(async () => {
    try {
      chats.value = await fetchChats(route.params?.id as string)

      if (chats.value.length > 0) {
        activeChatId.value = chats.value[0]?.id
      }
    } catch (err) {
      console.log(err)
    }
  })
</script>

<template>
  <section class="bg-white rounded-4xl h-screen overflow-hidden flex gap-2">
    <LeftLines first-color="bg-[#072768]" second-color="bg-[#5079B2]" />
    <div class="flex-1 flex pb-3">
      <ChatList :chats="chats" />
      <Chat
        v-if="activeChat"
        :id="activeChat.id"
        :user="activeChat.user"
        :messages="activeChat.messages"
      />
      <p v-else>Начните новый чат</p>
    </div>
  </section>
</template>
