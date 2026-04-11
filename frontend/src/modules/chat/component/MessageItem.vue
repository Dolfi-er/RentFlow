<script setup lang="ts">
  import { formatISOToTimeAndDateString } from '@/shared/utils'

  defineProps<{
    id: string
    datetime: string
    message: string
    sender: boolean
  }>()
</script>

<template>
  <li :class="['w-108.5', !sender ? 'self-end' : 'self-start']">
    <div
      :class="[
        'rounded-t-[25px] px-5 py-4 text-[16px]',
        !sender
          ? 'bg-[#072768] rounded-bl-[25px] text-white font-normal'
          : 'bg-white rounded-br-[25px] text-[#505050]',
      ]"
    >
      {{ message }}
    </div>
    <p
      :class="[
        '  text-white text-[16px] font-source  opacity-80',
        !sender ? 'text-start ml-3 ' : 'text-end mr-3 ',
      ]"
    >
      {{ formatISOToTimeAndDateString(datetime) }}
    </p>
  </li>
</template>
