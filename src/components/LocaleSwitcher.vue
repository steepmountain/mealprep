<template>
  <div>
    <cv-button kind="secondary" v-for="locale in notActiveLocales" :key="locale.id" :value="locale" @click="setLocale(locale)"> 
      {{ getLanguageString(locale) }}
      <span class="flag" :lang="locale"></span>
    </cv-button>
  </div>
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
  computed: {
    notActiveLocales() {
      return this.locales.filter(element => element != this.activeLocale );
    }
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

.flag {
  max-width: 20px;
  height: 14px;
  width: 18px;
  display: inline-block;
  margin-left: .3rem;
}

.flag:lang(no) {
  background: url("../assets/no_flag.svg");
  background-size: cover;
}

.flag:lang(en) {
  background: url("../assets/us_flag.svg");
  background-size: cover;
}
</style>