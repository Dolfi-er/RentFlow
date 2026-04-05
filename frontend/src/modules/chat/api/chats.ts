import api from '@/services/axios'
import type { TChat } from '../types'

export async function fetchChats(id: string): Promise<TChat[]> {
  const { data } = await api.get<TChat[]>(`facilities/${id}/chats`)
  return data
}

export async function sendMessage(chatId: string, message: string): Promise<string> {
  const { data } = await api.post<{ id: string }>(`chats/${chatId}`, { message })
  return data.id
}
