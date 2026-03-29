<script setup lang="ts">
  import QuestionLogo from '@/assets/svg/nav/QuestionLogo.vue'
  import NavigationList from './NavigationList.vue'
  import NavigationItem from './NavigationItem.vue'
</script>

<template>
  <nav class="bg-white rounded-[54px] px-2 pt-1.5 pb-4 mt-9 flex flex-col items-center gap-32.5">
    <NavigationList />
    <NavigationItem>
      <QuestionLogo />
    </NavigationItem>
  </nav>
</template>
