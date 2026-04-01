import api from '@/services/axios'
import type { TFacilityForm } from '../types'

function checkForm(form: TFacilityForm): boolean {
  if (
    form.address === '' ||
    form.price === null ||
    form.phone === '' ||
    form.description === '' ||
    form.images.length === 0
  ) {
    return false
  }

  return true
}

export async function handleForm(form: TFacilityForm) {
  if (!checkForm(form)) {
    throw new Error('Заполнены не все поля')
  }

  const { address, price, phone, description, images } = form

  const formData = new FormData()

  images.forEach((image) => {
    formData.append('images', image.file)
  })
  formData.append('address', address)
  formData.append('price', String(price))
  formData.append('phone', phone)
  formData.append('descriiption', description)

  const response = await api.post<{ id: string }>('facilities', formData, {
    headers: {
      'Content-Type': 'multipart/form-data',
    },
  })
}
