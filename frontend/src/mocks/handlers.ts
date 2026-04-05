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

  http.post(`${API_URL}/auth/login`, () => {
    return HttpResponse.json(
      {},
      {
        status: 201,
      },
    )
  }),

  http.post(`${API_URL}/auth/register`, () => {
    return HttpResponse.json(
      {},
      {
        status: 201,
      },
    )
  }),

  http.get(`${API_URL}/roles`, () => {
    return HttpResponse.json([
      {
        id: '721f7090-461e-43a4-a60f-f1219860605b',
        name: 'Арендодатель',
      },
      {
        id: '03900f31-dddf-4d7f-98e8-cd3134f4b591',
        name: 'Арендатор',
      },
    ])
  }),

  http.get<{ id: string }>(`${API_URL}/facilities/:id`, () => {
    return HttpResponse.json({
      address: 'Ленина 1, кв 14',
      price: 80000,
      phone: '+7-999-000-00-00',
      status: 'Сдаётся',
      description:
        'Сдается светлая и абсолютно чистая студия (или 1-комнатная) в современном жилом комплексе. Идеальное пространство для одного или пары, ценящих комфорт и функциональность. В квартире сделан качественный ремонт (или свежий косметический) с использованием экологичных материалов',
      images: [
        'https://img.freepik.com/premium-photo/photo-room-modern-style-light-color_321831-4341.jpg?semt=ais_hybrid&w=740&q=80',
        'https://img.freepik.com/premium-photo/modern-minimalistic-interior-design-light-bright-monochrome-room-with-black-white-furniture-clean-white-walls-huge-windows_267786-4897.jpg?semt=ais_hybrid',
        'https://img.freepik.com/premium-photo/photo-room-modern-style-light-color_321831-4341.jpg?semt=ais_hybrid&w=740&q=80',
        'https://img.freepik.com/premium-photo/modern-minimalistic-interior-design-light-bright-monochrome-room-with-black-white-furniture-clean-white-walls-huge-windows_267786-4897.jpg?semt=ais_hybrid',
        'https://img.freepik.com/premium-photo/photo-room-modern-style-light-color_321831-4341.jpg?semt=ais_hybrid&w=740&q=80',
        'https://img.freepik.com/premium-photo/modern-minimalistic-interior-design-light-bright-monochrome-room-with-black-white-furniture-clean-white-walls-huge-windows_267786-4897.jpg?semt=ais_hybrid',
        'https://img.freepik.com/premium-photo/photo-room-modern-style-light-color_321831-4341.jpg?semt=ais_hybrid&w=740&q=80',
        'https://img.freepik.com/premium-photo/modern-minimalistic-interior-design-light-bright-monochrome-room-with-black-white-furniture-clean-white-walls-huge-windows_267786-4897.jpg?semt=ais_hybrid',
      ],
    })
  }),

  http.get<{ id: string }>(`${API_URL}/facilities/:id/chats`, () => {
    return HttpResponse.json([
      {
        id: '721f7090-461e-43a4-a60f-f1219860605b',
        user: 'Иванов Иван',
        messages: [
          {
            id: '721f7090-461e-43a4-a60f-f1219860605b',
            datetime: '2026-04-04T16:00',
            message:
              'Lorem ipsum dolor sit amet consectetur adipisicing elit. Doloribus recusandae a amet autem culpa atque repellendus magni maiores unde, excepturi provident obcaecati, cupiditate nonimpedit laudantium quaerat! Sit, fugit modi.',
            sender: false,
          },
          {
            id: '721f7090-461e-23a4-a60f-f1219860605b',
            datetime: '2026-04-04T15:53',
            message:
              'Lorem ipsum dolor sit amet consectetur adipisicing elit. Doloribus recusandae a amet autem culpa atque repellendus magni maiores unde, excepturi provident obcaecati, cupiditate nonimpedit laudantium quaerat! Sit, fugit modi.',
            sender: false,
          },
          {
            id: '721f7090-461e-43b4-a60f-f1219860605b',
            datetime: '2026-04-04T15:50',
            message:
              'Lorem ipsum dolor sit amet consectetur adipisicing elit. Doloribus recusandae a amet autem culpa atque repellendus magni maiores unde, excepturi provident obcaecati, cupiditate nonimpedit laudantium quaerat! Sit, fugit modi.',
            sender: true,
          },
          {
            id: '731f7090-461e-43b4-a60f-f1219860605b',
            datetime: '2026-04-04T15:12',
            message:
              'Lorem ipsum dolor sit amet consectetur adipisicing elit. Doloribus recusandae a amet autem culpa atque repellendus magni maiores unde, excepturi provident obcaecati, cupiditate nonimpedit laudantium quaerat! Sit, fugit modi.',
            sender: true,
          },
        ],
      },
      {
        id: '721f7090-461e-43a4-a60f-f1219863605b',
        user: 'Александров Александр',
        messages: [
          {
            id: '721f7390-461e-43b4-a60f-f1219860605b',
            datetime: '2026-08-15T08:16',
            message: 'Здравствуйте, Елена! Да, всё хорошо',
            sender: true,
          },
          {
            id: '731f7390-461e-43b4-a60f-f1219860605b',
            datetime: '2026-08-15T08:15',
            message: 'Иван, здравствуйте! У Вас всё в порядке?',
            sender: false,
          },
        ],
      },
    ])
  }),

  http.post<{ id: string }>(`${API_URL}/chats/:id`, () => {
    return HttpResponse.json({
      id: crypto.randomUUID(),
    })
  }),
]
