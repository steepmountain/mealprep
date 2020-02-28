<template>
  <cv-modal :visible="showModal" @modal-hidden="$emit('hide')" @primary-click="sendSave">
    <template slot="title">Lagre måltid</template>
    <template slot="content">
      <cv-text-input v-model="name" placeholder="Navn" />
      <div v-if="saveState == SaveStates.Success">Lagret!</div>
      <div v-if="saveState == SaveStates.Failure">Noe gikk galt.</div>
    </template>
    <template slot="secondary-button">Avbryt</template>
    <template slot="primary-button">Lagre</template>
  </cv-modal>
</template>

<script>
import { SaveStates } from "../../classes/SaveStates";

export default {
  props: {
    showModal: Boolean
  },
  data() {
    return {
      name: "",
      SaveStates: SaveStates,
      saveState: SaveStates.Uninitialized
    };
  },
  methods: {
    sendSave() {
      this.$emit("save", this.name);
    },
    setSaveResult(result) {
      this.saveState = result;
    }
  }
};
</script>

<style>
</style>
