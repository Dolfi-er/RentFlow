import axios from 'axios'

const API_URL = 'http://localhost:6967'

const api = axios.create({
  baseURL: API_URL,
  withCredentials: true,
})

export default api
