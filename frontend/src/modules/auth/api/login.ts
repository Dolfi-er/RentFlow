import api from '@/services/axios'
import type { TLoginForm } from '../types'

export async function submitLoginForm(form: TLoginForm): Promise<string> {
  const { login, password } = form

  if (login === '' || password === '') {
    throw new Error('Введите все поля')
  }

  const { data } = await api.post<{ value: { token: string } }>('users/auth/login', form)
  return data.value.token
}
