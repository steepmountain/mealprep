import Vue from 'vue'
import VueI18n from 'vue-i18n'
import VueCookie from "vue-cookie";

Vue.use(VueI18n)
Vue.use(VueCookie);

function loadLocaleMessages() {
    const locales = require.context('./localization', true, /[A-Za-z0-9-_,\s]+\.json$/i);
    const messages = {};
    locales.keys().forEach(key => {
        const matched = key.match(/([A-Za-z0-9-_]+)\./i);
        if (matched && matched.length > 1) {
            const locale = matched[1];
            messages[locale] = locales(key);
        }
    })
    return messages;
}

function getLocale() {
    let locale = VueCookie.get("locale") || "en";
    Vue.config.lang = locale;
    return locale;
}

export const i18n = new VueI18n({
    locale: getLocale(),
    fallbackLocale: 'en',
    messages: loadLocaleMessages()
})