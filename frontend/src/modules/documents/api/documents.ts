import api from '@/services/axios'
import type { TDocument, TDocumentForm } from '../types'

export async function fecthDocuments(facilityId: string): Promise<TDocument[]> {
  const { data } = await api.get(`facilities/${facilityId}/documents`)
  return data
}

export async function handleForm(facilityId: string, form: TDocumentForm): Promise<void> {
  const { name, description, file } = form

  if (!name || !description || !file) {
    throw new Error('Заполнены не все поля')
  }

  const formData = new FormData()

  formData.append('name', name)
  formData.append('description', description)
  formData.append('file', file)

  await api.post(`facilities/${facilityId}/documents`, formData, {
    headers: {
      'Content-Type': 'multipart/form-data',
    },
  })
}
