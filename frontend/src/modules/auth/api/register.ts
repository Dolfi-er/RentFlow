import api from '@/services/axios'
import type { TRegisterForm } from '../types'

export async function submitRegisterForm(form: TRegisterForm): Promise<void> {
  const { email, surname, name, patronymic, roleId, sex, password, repeatPassword } = form

  if (!Object.values(form).every((value) => value !== '')) {
    throw new Error('Введите все поля')
  }

  if (password !== repeatPassword) {
    throw new Error('Пароли не совпадают')
  }

  await api.post('auth/register', {
    email,
    surname,
    name,
    patronymic,
    roleId,
    sex,
    password,
  })
}
