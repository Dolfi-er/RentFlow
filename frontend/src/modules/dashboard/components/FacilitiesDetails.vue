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
    <div class="relative flex flex-1 items-center min-h-0">
      <Doughnut :data="chartData" :options="chartOptions" />
      <div class="absolute left-[28%] pointer-events-none">
        <span class="text-2xl font-semibold text-[#201F23]">15</span>
      </div>
    </div>
  </section>
</template>

<script setup lang="ts">
  import { Doughnut } from 'vue-chartjs'
  import { Chart as ChartJS, ArcElement, Tooltip, Legend } from 'chart.js'

  ChartJS.register(ArcElement, Tooltip, Legend)

  const chartData = {
    labels: ['Сдаются', 'Просрочено', 'Ремонт', 'Не сдаются'],
    datasets: [
      {
        data: [7, 1, 3, 4],
        backgroundColor: ['#072768', '#B34D4D', '#B8C9E0', '#5079B2'],
        borderWidth: 3,
      },
    ],
  }

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
