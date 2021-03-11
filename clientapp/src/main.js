import Vue from 'vue'
import App from './App.vue'
import 'carbon-components/css/carbon-components.css';
import CarbonComponentsVue from '@carbon/vue/src/index';
import { i18n } from "./localization.js"
import VueInlineLoading from 'vue-inline-loading';

Vue.use(CarbonComponentsVue);
Vue.use(VueInlineLoading);

Vue.config.productionTip = false
document.title = 'Eatprayprogram.no | Prep That Meal'
new Vue({
    i18n,
    render: h => h(App),
}).$mount('#app')