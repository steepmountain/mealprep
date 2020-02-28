<template>
  <cv-modal :visible="showModal" @modal-hidden="$emit('hide')" @primary-click="sendSave">
    <template slot="title">Lagre måltid</template>
    <template slot="content">
      <cv-text-input v-model="name" placeholder="Navn" />
    </template>
    <template slot="secondary-button">Avbryt</template>
    <template slot="primary-button">Lagre</template>
  </cv-modal>
</template>

<script>
export default {
  props: {
    showModal: Boolean
  },
  data() {
    return {
      name: ""
    };
  },
  methods: {
    sendSave() {
      this.$emit("save", this.name);
    },
  }
};
</script>

<style>
</style>
