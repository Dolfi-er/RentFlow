<script setup lang="ts">
  defineProps<{
    label: string
    name: string
    placeholder: string
    tag: string
    type?: string
  }>()

  const inputValue = defineModel<string | number>('inputValue', {
    required: true,
  })

  const emit = defineEmits(['update:inputValue'])

  const onInput = (event: Event) => {
    const target = event.target as HTMLInputElement | HTMLTextAreaElement

    if (!target) return
    emit('update:inputValue', target.value)
  }
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
      v-model="inputValue"
      required
      @input="onInput"
    />
  </div>
</template>
