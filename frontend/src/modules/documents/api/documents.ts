import api from '@/services/axios'
import type { TDocument } from '../types'

export async function fecthDocuments(facilityId: string): Promise<TDocument[]> {
  const { data } = await api.get(`facilities/${facilityId}/documents`)
  return data
}
