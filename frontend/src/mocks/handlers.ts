import { http, HttpResponse } from 'msw'

const API_URL = 'http://localhost:6967'

export const handlers = [
  http.post(`${API_URL}/facilities`, () => {
    return HttpResponse.json({
      id: '4039d50b-b7b8-4ccb-b58d-b82f36653f42',
    })
  }),
]
