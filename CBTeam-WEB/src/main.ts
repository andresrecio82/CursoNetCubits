import 'primevue/resources/themes/lara-light-green/theme.css'
import '/node_modules/primeflex/primeflex.css'

import PrimeVue from 'primevue/config';
import { createApp } from 'vue'
import router from './router'
import App from  './App.vue'


const app = createApp(App)

app.use(router)
app.use(PrimeVue)

app.mount('#app')