import { http, HttpResponse } from 'msw'

const API_URL = 'http://localhost:5054'

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

  http.post(`${API_URL}/users/auth/login`, () => {
    return HttpResponse.json(
      {
        value: {
          token: '',
        },
      },
      {
        status: 201,
      },
    )
  }),

  http.post(`${API_URL}/users/auth/registr`, () => {
    return HttpResponse.json(
      {},
      {
        status: 201,
      },
    )
  }),

  http.get(`${API_URL}/users/role`, () => {
    return HttpResponse.json({
      value: [
        {
          id: '721f7090-461e-43a4-a60f-f1219860605b',
          name: 'Арендодатель',
        },
        {
          id: '03900f31-dddf-4d7f-98e8-cd3134f4b591',
          name: 'Арендатор',
        },
      ],
    })
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

  http.get(`${API_URL}/dashboard`, () => {
    return HttpResponse.json({
      objects: {
        currentMonth: 15,
        lastMonth: 12,
      },
      rentedObjects: {
        currentMonth: 10,
        lastMonth: 12,
      },
      revenue: {
        currentMonth: 270000,
        lastMonth: 300000,
      },
      revenuePerMonth: [
        {
          month: 11,
          revenue: 30000,
        },
        {
          month: 12,
          revenue: 14000,
        },
        {
          month: 1,
          revenue: 0,
        },
        {
          month: 2,
          revenue: 80000,
        },
        {
          month: 3,
          revenue: 65000,
        },
        {
          month: 4,
          revenue: 72000,
        },
      ],
      objectsByStatus: [
        {
          status: 'Сдаётся',
          count: 5,
        },
        {
          status: 'Не сдаётся',
          count: 3,
        },
      ],
      lastTransactions: [
        {
          id: '952053dc-07cb-4fed-8a76-8fc7b0d6e088',
          imageUrl:
            'https://www.shutterstock.com/image-photo/cozy-historical-home-florida-on-600nw-2709891397.jpg',
          address: '123 Maple Avenue SpringField',
          datetime: '2024-09-12T09:29',
          price: 30000,
        },
        {
          id: 'b4d7144c-69ec-49ea-a321-b5159f5fb859',
          imageUrl:
            'https://www.shutterstock.com/image-photo/cozy-historical-home-florida-on-600nw-2709891397.jpg',
          address:
            '123 Maple Avenue SpringField 23 Maple Avenue SpringField 23 Maple Avenue SpringField',
          datetime: '2024-09-12T09:29',
          price: 20,
        },
      ],
      requests: [
        {
          id: '28ba1d5b-3996-4360-98bb-d9929c19b039',
          category: 'Водопровод',
          address: '123 Maple Avenue SpringField',
          name: 'Течёт кухонный кран',
          status: 'Открыта',
        },
        {
          id: '755149bf-ce7d-4525-bca7-aee767bfd034',
          category: 'Электричество',
          address: 'улица Ленина, д.1, кв.3 улица Ленина, д.1, кв.3',
          name: 'Искрит розетка',
          status: 'Назначен мастер',
        },
        {
          id: '755149bf-ce7d-4525-bca7-aee767bfd034',
          category: 'Кондиционер',
          address: 'улица Ленина, д.1, кв.3',
          name: 'Кондиционер капает Кондиционер капает Кондиционер капаетКондиционер капает',
          status: 'Закрыт',
        },
      ],
    })
  }),
  http.get<{ id: string }>(`${API_URL}/facilities/:id/documents`, () => {
    return HttpResponse.json([
      {
        id: '0976b7f3-3717-4f8c-aa7f-74edf79d8925',
        fileUrl: '',
        name: 'Договор',
        description: 'Договоре об аренде от 11.04.2026г',
      },
    ])
  }),
  http.post<{ id: string }>(`${API_URL}/facilities/:id/documents`, () => {
    return HttpResponse.json({}, { status: 201 })
  }),
]
