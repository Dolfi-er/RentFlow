<script setup lang="ts">
  defineProps<{
    id: string
    fileUrl: string
    name: string
    description: string
  }>()
</script>

<template>
  <li class="flex items-center font-normal h-24 border-b last:border-none pb-2">
    <div class="size-10 bg-[#5079B2] rounded-full flex justify-center items-center mr-3 flex-none">
      <img class="size-7" src="@/assets/svg/facility-nav/docs.svg" alt="Docs svg" />
    </div>
    <div class="basis-2/7 border-x h-full flex justify-center items-center px-2">
      <p class="text-[17px] text-center line-clamp-2">{{ name }}</p>
    </div>
    <div class="basis-3/7 border-r h-full flex justify-center items-center px-2">
      <p class="text-[16px] text-center line-clamp-2">{{ description }}</p>
    </div>
    <div class="basis-1/7 border-r h-full flex justify-center items-center">
      <button class="w-25 rounded-[15px] py-1.5 bg-[#072768] text-white cursor-pointer">
        <a :href="fileUrl" download>Скачать</a>
      </button>
    </div>
    <div class="basis-1/7 flex flex-col justify-center items-center gap-2">
      <button class="w-25 rounded-[15px] py-1.5 bg-[#351303] text-white cursor-pointer">
        Изменить
      </button>
      <button class="w-25 rounded-[15px] py-1.5 bg-[#996F51] text-white cursor-pointer">
        Удалить
      </button>
    </div>
  </li>
</template>
