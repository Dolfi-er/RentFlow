<script setup lang="ts">
  defineProps<{
    label: string
    name: string
    placeholder: string
    tag: string
    type?: string
  }>()
</script>

<template>
  <div class="flex flex-col gap-3">
    <label :for="name" class="text-[20px]">
      {{ label }}
    </label>

    <component
      :is="tag"
      :name="name"
      :type="tag === 'input' ? type : undefined"
      :placeholder="placeholder"
      v-bind="$attrs"
      class="text-[16px] p-3 bg-[#F5F5F5] rounded-[20px]"
    />
  </div>
</template>
