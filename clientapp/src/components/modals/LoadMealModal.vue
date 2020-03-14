<template>
  <cv-modal :visible="showModal" @modal-hidden="$emit('hide')" @modal-shown="show">
    <template slot="title">{{ $t('openMeal') }}</template>
    <template slot="content">
      <div class="body">
        <cv-loading v-if="!loaded" :overlay="false"></cv-loading>

        <div v-if="loaded && this.items.length == 0"> {{ $t('noSavedMeals') }}</div>

        <div v-if="loaded">
          <div class="button-list-item" v-for="item in items" v-bind:key="item.id">
            <cv-button @click="$emit('load-recipe', item)" size="small">{{item.name}}</cv-button>
            <cv-button @click="$emit('remove-recipe', item.index)" kind="danger" size="small">
              {{ $t('remove') }}
              <Delete16 class="bx--btn__icon" />
            </cv-button>
          </div>
        </div>
      </div>
    </template>
    <template slot="secondary-button">{{ $t('cancel') }}</template>
  </cv-modal>
</template>

<script>
import LocalStorageService from "../../services/LocalStorageService";
import Delete16 from "@carbon/icons-vue/es/delete/16";

const localStorageIndex = "recipes";
const localStorageService = new LocalStorageService(localStorageIndex);

export default {
  props: {
    showModal: Boolean
  },
  data() {
    return {
      items: [],
      loaded: false
    };
  },
  components: {
    Delete16
  },
  methods: {
    show() {
      this.items = [];
      let allItems = localStorageService.load();
      allItems.forEach(item => {
        this.items.push(item);
      });
      this.loaded = true;
    }
  }
};
</script>

<style scoped>
.body {
  text-align: left !important;
}

.button-list-item {
  margin: 10px;
}

.recipe-name {
  font-size: 1.2rem;
  margin-left: 0.5rem;
}
</style>
