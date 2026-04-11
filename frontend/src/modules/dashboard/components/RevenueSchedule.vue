<script setup lang="ts">
  import { computed } from 'vue'
  import { Bar } from 'vue-chartjs'
  import {
    Chart as ChartJS,
    CategoryScale,
    LinearScale,
    BarElement,
    Title,
    Tooltip,
    type TooltipItem,
  } from 'chart.js'
  import type { TMonthRevenue } from '../types'

  const props = defineProps<{
    revenuePerMonth?: TMonthRevenue[]
  }>()

  ChartJS.register(CategoryScale, LinearScale, BarElement, Title, Tooltip)

  // const monthlyData = [30000, 32500, 33000, 41000, 32800, 33200]
  const monthlyData = computed(() => props.revenuePerMonth?.map((r) => r.revenue) ?? [])

  const monthNames = [
    'Янв',
    'Фев',
    'Мар',
    'Апр',
    'Май',
    'Июн',
    'Июл',
    'Авг',
    'Сен',
    'Окт',
    'Ноя',
    'Дек',
  ]
  const months = computed(() => props.revenuePerMonth?.map((r) => monthNames[r.month - 1]) ?? [])

  const chartData = computed(() => ({
    labels: months.value,
    datasets: [
      {
        data: monthlyData.value,
        backgroundColor: '#5079B2',
        borderRadius: 8,
        borderSkipped: false,
        hoverBackgroundColor: '#072768',
        barPercentage: 0.7,
      },
    ],
  }))

  const chartOptions = {
    responsive: true,
    maintainAspectRatio: false,
    plugins: {
      legend: {
        display: false,
      },
      tooltip: {
        backgroundColor: '#E3E4EA',
        titleColor: '#45515C',
        bodyColor: '#1A1A2E',
        bodyFont: {
          size: 14,
          weight: 'bold' as const,
        },
        padding: 12,
        cornerRadius: 8,
        displayColors: false,
        callbacks: {
          label: (item: TooltipItem<'bar'>) => {
            const value = item.parsed.y
            return `₽${value!.toLocaleString('ru-RU')}`
          },
        },
      },
    },
    scales: {
      x: {
        grid: {
          display: false,
        },
        ticks: {
          color: '#8B8B8B',
          font: {
            size: 14,
          },
        },
      },
      y: {
        beginAtZero: true,
        grid: {
          color: '#E8E8E8',
        },
        ticks: {
          color: '#8B8B8B',
          font: {
            size: 14,
          },
          callback: (value: string | number) => {
            const num = typeof value === 'number' ? value : parseInt(value, 10)
            return `₽${num.toLocaleString('ru-RU')}`
          },
        },
        border: {
          display: false,
        },
      },
    },
  }
</script>

<template>
  <section class="bg-white rounded-[27px] py-6.5 px-6 h-80.5 flex flex-col gap-5">
    <h3 class="text-[20px]">График доходов</h3>
    <div class="flex-1 flex items-center justify-center">
      <p
        v-if="!revenuePerMonth || revenuePerMonth.length === 0"
        class="text-[22px] text-[#596269] mb-6"
      >
        Доходов пока нет
      </p>
      <Bar v-else :data="chartData" :options="chartOptions" />
    </div>
  </section>
</template>
