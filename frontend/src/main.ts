import { createApp } from 'vue'
import App from './App.vue'
import pinia from './services/pinia'

async function enableMocking() {
  if (import.meta.env.VITE_API_MOCKING === 'true') {
    const { worker } = await import('./mocks/browser')

    return worker.start()
  }
}

enableMocking().then(() => {
  createApp(App).use(pinia).mount('#app')
})
