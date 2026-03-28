import { http, HttpResponse } from 'msw'

export const handlers = [
  http.get('http://localhost:6967/test', () => {
    return HttpResponse.json({
      message: 'Hello, world!',
    })
  }),
]
