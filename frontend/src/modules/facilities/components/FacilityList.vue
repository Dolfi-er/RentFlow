<script setup lang="ts">
  import FacilityItem from './FacilityItem.vue'
  import facilityOne from '@/assets/images/facilities/facility-1.jpg'
  import facilityTwo from '@/assets/images/facilities/facility-2.jpg'
</script>

<template>
  <ul class="mt-5 flex flex-col gap-7">
    <FacilityItem
      :image-url="facilityOne"
      address="Ленина 1, кв. 14"
      description="Lorem ipsum dolor sit amet consectetur adipisicing elit. Similique nihil recusandae quae?
        Provident totam quidem odio magni aut voluptates repudiandae fuga tenetur voluptatum in,
        soluta eligendi deleniti sit ex? Eius! Lorem ipsum dolor sit amet, consectetur adipisicing
        elit. Optio ex doloremque officia soluta accusantium rerum dolores voluptatibus amet porro
        illo, at ullam dolor facere minima possimus quis aut corrupti eaque? Lorem ipsum dolor sit
        amet consectetur adipisicing elit. Ipsam enim aliquam cumque veritatis fuga vel tenetur
        animi eveniet pariatur? Sequi exercitationem odit unde cum nemo fugiat in corrupti
        blanditiis quos. Lorem ipsum dolor sit amet consectetur adipisicing elit. Facere voluptatem
        ipsam officia expedita fuga nemo quos doloribus quo magnam excepturi! Repellat, praesentium?
        Illo voluptatum dicta saepe eum repudiandae asperiores quis? Lorem ipsum dolor sit amet
        consectetur adipisicing elit. Ad optio deserunt, corrupti officia enim quaerat aliquid!
        Distinctio, quibusdam doloremque sequi mollitia dolorem officia neque amet, delectus quia
        aliquid consequuntur voluptas?"
      status="Сдаётся"
      :price="30000"
    />
    <FacilityItem
      :image-url="facilityTwo"
      address="Ленина 1, кв. 14"
      description="Lorem ipsum dolor sit amet consectetur adipisicing elit. Similique nihil recusandae quae?
        Provident totam quidem odio magni aut voluptates repudiandae fuga tenetur voluptatum in,
        soluta eligendi deleniti sit ex? Eius! Lorem ipsum dolor sit amet, consectetur adipisicing
        elit. Optio ex doloremque officia soluta accusantium rerum dolores voluptatibus amet porro
        illo, at ullam dolor facere minima possimus quis aut corrupti eaque? Lorem ipsum dolor sit
        amet consectetur adipisicing elit. Ipsam enim aliquam cumque veritatis fuga vel tenetur
        animi eveniet pariatur? Sequi exercitationem odit unde cum nemo fugiat in corrupti
        blanditiis quos. Lorem ipsum dolor sit amet consectetur adipisicing elit. Facere voluptatem
        ipsam officia expedita fuga nemo quos doloribus quo magnam excepturi! Repellat, praesentium?
        Illo voluptatum dicta saepe eum repudiandae asperiores quis? Lorem ipsum dolor sit amet
        consectetur adipisicing elit. Ad optio deserunt, corrupti officia enim quaerat aliquid!
        Distinctio, quibusdam doloremque sequi mollitia dolorem officia neque amet, delectus quia
        aliquid consequuntur voluptas?"
      status="Сдаётся"
      :price="30000"
    />
  </ul>
</template>
