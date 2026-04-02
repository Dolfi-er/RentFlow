import api from '@/services/axios'
import type { TLoginForm } from '../types'

export async function submitLoginForm(form: TLoginForm): Promise<void> {
  const { email, password } = form

  if (email === '' || password === '') {
    throw new Error('Введите все поля')
  }

  await api.post('auth/login', form)
}
