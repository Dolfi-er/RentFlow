import type { TImageItem } from './image-item.type'

export type TFacilityForm = {
  address: string
  price: number
  phone: string
  images: TImageItem[]
  description: string
}
