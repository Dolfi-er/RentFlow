import axios from 'axios'
import { defineStore } from 'pinia'
import { ref } from 'vue'

export const useUserStore = defineStore(
  'user',
  () => {
    const isAuth = ref<boolean>(false)
    const token = ref<string>('')

    function authenticate(accessToken: string) {
      isAuth.value = true
      token.value = accessToken
    }

    async function refresh(): Promise<string> {
      const response = await axios.post<{ value: { token: string } }>(
        'http://localhost:5054/users/auth/refresh',
        {},
        { withCredentials: true },
      )

      token.value = response.data.value.token

      return response.data.value.token
    }

    function exit() {
      isAuth.value = false
      token.value = ''
    }

    return { isAuth, token, authenticate, refresh, exit }
  },
  { persist: true },
)
