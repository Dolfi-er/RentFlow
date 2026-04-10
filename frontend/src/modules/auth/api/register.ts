import api from '@/services/axios'
import type { TRegisterForm } from '../types'

export async function submitRegisterForm(form: TRegisterForm): Promise<void> {
  const { email, fullName, phoneNumber, roleId, password, repeatPassword } = form

  if (!Object.values(form).every((value) => value !== '')) {
    throw new Error('Введите все поля')
  }

  if (password !== repeatPassword) {
    throw new Error('Пароли не совпадают')
  }

  const fullNameArray = fullName.split(' ')

  await api.post('users/auth/registr', {
    email,
    surname: fullNameArray[0] ?? null,
    name: fullNameArray[1] ?? null,
    patronymic: fullNameArray[2] ?? null,
    phoneNumber,
    roleId,
    password,
  })
}
