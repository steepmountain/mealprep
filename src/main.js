import Vue from 'vue'
import App from './App.vue'
import 'carbon-components/css/carbon-components.css';
import CarbonComponentsVue from '@carbon/vue/src/index';
Vue.use(CarbonComponentsVue);

Vue.config.productionTip = false
document.title = 'Eatprayprogram.no | Prep That Meal'
new Vue({
  render: h => h(App),
}).$mount('#app')
