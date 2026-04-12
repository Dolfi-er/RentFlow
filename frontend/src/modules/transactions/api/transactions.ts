import api from '@/services/axios'
import type { TTransaction, TTransactionForm } from '../types'

export async function fecthTransactions(facilityId: string): Promise<TTransaction[]> {
  const { data } = await api.get(`facilities/${facilityId}/transactions`)
  return data
}

export async function handleForm(facilityId: string, form: TTransactionForm): Promise<void> {
  const { name, date, price } = form

  if (!name || !date || !price) {
    throw new Error('Заполнены не все поля')
  }

  await api.post(`facilities/${facilityId}/transactions`, form)
}
