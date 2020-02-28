<template>
  <cv-modal
    :visible="showModal"
    @modal-hidden="$emit('hide')"
    @modal-shown="show"
  >
    <template slot="title">Åpne måltid</template>
    <template slot="content">
      <div class="body">
        <cv-loading v-if="!loaded" :overlay="false"></cv-loading>

        <div v-if="loaded && this.items.length == 0">Du har ingen lagrede måltid.</div>

        <div v-if="loaded">
          <div class="row" v-for="item in items" v-bind:key="item.id">
            <cv-button @click="$emit('load-recipe', item)" size="small">Åpne</cv-button>
            <span class="recipe-name">{{item.name}}</span><hr>
            {{item}}
          </div>
        </div>
      </div>
    </template>
    <template slot="secondary-button">Avbryt</template>
  </cv-modal>
</template>

<script>
import LocalStorageService from "../../services/LocalStorageService";

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

.body .row {
  margin: 10px;
}

.recipe-name {
  font-size: 1.2rem;
  margin-left: 0.5rem;
}
</style>
