<script setup lang="ts">
  import { inject, ref } from 'vue'
  import { sendMessage } from '../api'
  import { useRoute } from 'vue-router'

  const { chatId } = defineProps<{
    chatId: string
  }>()
  const inputValue = ref<string>('')

  const route = useRoute()
  const addMessage =
    inject<(chatId: string, messageId: string, message: string) => void>('addMessage')
  async function handleMessage() {
    try {
      const message = inputValue.value
      if (message.length === 0) return

      const messageId = await sendMessage(route.params?.id as string, message)
      addMessage?.(chatId, messageId, message)

      inputValue.value = ''
    } catch (err) {
      console.log(err)
    }
  }
</script>

<template>
  <div
    class="bg-white shadow-[5px_4px_20px_rgba(0,0,0,0.13)] flex gap-2 py-1 pl-6 rounded-[30px] mx-8 mb-8"
  >
    <input
      v-model="inputValue"
      type="text"
      class="text-[16px] flex-1 outline-none"
      placeholder="Напишите ваше сообщение"
    />
    <button @click="handleMessage" class="cursor-pointer">
      <img src="@/assets/svg/chat/send.svg" alt="Send icon" />
    </button>
  </div>
</template>
