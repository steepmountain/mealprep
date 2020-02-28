<template>
  <cv-modal :visible="showModal" @modal-hidden="$emit('hide')" @primary-click="load">
    <template slot="title">Åpne måltid</template>
    <template slot="content">
      <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, seed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
          <cv-button class="row" size="small" v-for="item in items" v-bind:key="item.id">{{item.name}}</cv-button>
    </template>
    <template slot="secondary-button">Avbryt</template>
    <template slot="primary-button">Åpne</template>
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
  data(){
    return {
      items: []
    }
  },
  mounted: function() {
    let allItems = localStorageService.load();
    allItems.forEach(item => {
      this.items.push(item);
    });
      // load data on mount and show
  }
};
</script>

<style>
</style>
