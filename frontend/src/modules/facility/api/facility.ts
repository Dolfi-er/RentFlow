import api from '@/services/axios'
import type { TFacility } from '../types'

export async function fetchFacility(id: string): Promise<TFacility> {
  const { data } = await api.get<TFacility>(`facilities/${id}`)

  return data
}
