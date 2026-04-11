<script setup lang="ts">
  import { Doughnut } from 'vue-chartjs'
  import { Chart as ChartJS, ArcElement, Tooltip, Legend } from 'chart.js'
  import type { TObjectByStatus } from '../types'
  import { computed } from 'vue'

  const { objectsByStatus } = defineProps<{
    objectsByStatus?: TObjectByStatus[]
  }>()
  const allObjectsCount = computed(() =>
    objectsByStatus?.reduce((sum, current) => sum + current.count, 0),
  )

  ChartJS.register(ArcElement, Tooltip, Legend)

  const chartData = computed(() => ({
    labels: objectsByStatus?.map((o) => o.status) ?? [],
    datasets: [
      {
        data: objectsByStatus?.map((o) => o.count) ?? [],
        backgroundColor: ['#072768', '#B34D4D', '#B8C9E0', '#5079B2'],
        borderWidth: 3,
      },
    ],
  }))

  const chartOptions = {
    responsive: true,
    maintainAspectRatio: false,
    cutout: '55%',
    plugins: {
      legend: {
        position: 'right' as const,
        align: 'center' as const,
        labels: {
          padding: 28,
          usePointStyle: true,
          pointStyle: 'circle',
          font: {
            size: 14,
          },
        },
      },
    },
  }
</script>

<template>
  <section class="bg-white rounded-[27px] py-5 px-6 h-80.5 flex flex-col">
    <div class="flex justify-between items-center">
      <h3 class="text-[20px]">Недвижимость</h3>
      <RouterLink :to="{ name: 'facilities' }">
        <a
          class="text-[16px] text-[#596269] tracking-[0.03em] cursor-pointer hover:underline underline-offset-3 transition-all"
          >Детали</a
        >
      </RouterLink>
    </div>
    <div
      v-if="!objectsByStatus || objectsByStatus.length === 0"
      class="flex-1 flex justify-center items-center mb-6"
    >
      <p class="text-[20px] text-[#596269] text-center">Объектов недвижимости пока нет</p>
    </div>
    <div v-else class="relative flex flex-1 items-center min-h-0">
      <Doughnut :data="chartData" :options="chartOptions" />
      <div class="absolute left-[29%] pointer-events-none">
        <span class="text-2xl font-semibold text-[#201F23]">{{ allObjectsCount }}</span>
      </div>
    </div>
  </section>
</template>
