<template>
    <cv-dropdown class="locale-switcher" @change="setLocale" :value="activeLocale" :theme="ight-theme">
      <cv-dropdown-item
        v-for="locale in locales"
        :key="locale.id"
        :value="locale"
      >{{ getLanguageString(locale) }}</cv-dropdown-item>
    </cv-dropdown>
</template>

<script>
import Vue from "vue";
import VueCookie from "vue-cookie";
Vue.use(VueCookie);

const localeStrings = {
  en: "English",
  no: "Norsk"
};

Vue.config.lang = VueCookie.get("locale") || "en";

export default {
  props: {
    locales: Array
  },
  data: function() {
    return {
      activeLocale: Vue.config.lang
    };
  },
  methods: {
    setLocale: function(locale) {
      Vue.config.lang = locale;
      this.activeLocale = locale;
      this.$cookie.set("locale", locale);
      this.$i18n.locale = Vue.config.lang;
      this.$emit("change-locale");
    },
    getLanguageString: function(locale) {
      return localeStrings[locale] ?? locale;
    }
  }
};
</script>

<style scoped>
.locale-switcher {
  min-width: 150px;
}
</style>