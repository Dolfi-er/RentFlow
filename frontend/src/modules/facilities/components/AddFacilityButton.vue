<template>
  <router-link :to="{ name: 'new-facility' }">
    <button
      class="size-12 flex justify-center items-center rounded-full bg-[#351303] cursor-pointer"
    >
      <img src="@/assets/svg/facilities/add-facility.svg" alt="Add facility" />
    </button>
  </router-link>
</template>
