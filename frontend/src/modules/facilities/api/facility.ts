import api from '@/services/axios'
import type { TFacility } from '../types'

export async function fetchFacilities(): Promise<TFacility[]> {
  const { data } = await api.get<TFacility[]>('/facilities')

  return data
}
