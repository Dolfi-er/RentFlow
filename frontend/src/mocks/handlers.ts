import { http, HttpResponse } from 'msw'

const API_URL = 'http://localhost:6967'

export const handlers = [
  http.post(`${API_URL}/facilities`, () => {
    return HttpResponse.json({
      id: '4039d50b-b7b8-4ccb-b58d-b82f36653f42',
    })
  }),

  http.get(`${API_URL}/facilities`, () => {
    return HttpResponse.json([
      {
        id: '4039d50b-b7b8-4ccb-b58d-b82f36653f42',
        imageUrl:
          'https://img.freepik.com/premium-photo/modern-minimalistic-interior-design-light-bright-monochrome-room-with-black-white-furniture-clean-white-walls-huge-windows_267786-4897.jpg?semt=ais_hybrid',
        address: 'г. Москва, ул. Ленина, д. 10, кв. 14',
        price: 80000,
        status: 'Сдаётся',
        description:
          'Сдается светлая и абсолютно чистая студия (или 1-комнатная) в современном жилом комплексе. Идеальное пространство для одного или пары, ценящих комфорт и функциональность. В квартире сделан качественный ремонт (или свежий косметический) с использованием экологичных материалов:',
      },
      {
        id: '377a08ba-193a-465e-9a0c-8158957f70c9',
        imageUrl:
          'https://img.freepik.com/premium-photo/photo-room-modern-style-light-color_321831-4341.jpg?semt=ais_hybrid&w=740&q=80',
        address: 'г. Москва, ул. Пушкина, д. 12, кв. 123',
        price: 45000,
        status: 'Сдаётся',
        description:
          'Сдается светлая и абсолютно чистая студия (или 1-комнатная) в современном жилом комплексе. Идеальное пространство для одного или пары, ценящих комфорт и функциональность. В квартире сделан качественный ремонт (или свежий косметический) с использованием экологичных материалов:',
      },
    ])
  }),
]
