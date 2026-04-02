<script setup lang="ts">
  defineProps<{
    label: string
    name: string
    placeholder: string
    type: string
  }>()
</script>

<template>
  <div class="flex flex-col gap-2 text-[16px] font-normal font-roboto">
    <label :for="name">{{ label }}</label>
    <input
      :name="name"
      :type="type"
      :placeholder="placeholder"
      v-bind="$attrs"
      required
      class="bg-white rounded-xl px-3 py-2.75 border border-[#D4D7E3]"
    />
  </div>
</template>
