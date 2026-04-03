import api from '@/services/axios'
import type { TFacilityInfo } from '../types'

export async function fetchFacilityInfo(id: string): Promise<TFacilityInfo> {
  const { data } = await api.get<TFacilityInfo>(`facilities/${id}`)
  return data
}
