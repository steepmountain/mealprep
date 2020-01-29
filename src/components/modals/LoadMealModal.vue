<template>
  <cv-modal :visible="showModal" @modal-hidden="$emit('hide')">
    <template slot="title">Åpne måltid</template>
    <template slot="content">
      <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, seed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
    </template>
    <template slot="secondary-button">Avbryt</template>
    <template slot="primary-button">Åpne</template>
  </cv-modal>
</template>

<script>
export default {
  props: {
      showModal: Boolean
  },
  methods: {
      // https://stackoverflow.com/a/43762443 
      // load data
  }
};
</script>

<style>
</style>
