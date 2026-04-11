import api from '@/services/axios'
import type { TDashboard } from '../types'

export async function fetchDashboard(): Promise<TDashboard> {
  const { data } = await api.get<TDashboard>('dashboard')
  return data
}
