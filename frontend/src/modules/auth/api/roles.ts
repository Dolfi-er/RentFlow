import api from '@/services/axios'
import type { TRole } from '../types'

export async function fetchRoles(): Promise<TRole[]> {
  const { data } = await api.get<{ value: TRole[] }>('users/role')
  return data.value
}
