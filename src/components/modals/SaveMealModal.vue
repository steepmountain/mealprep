<template>
  <cv-modal :visible="showModal" @modal-hidden="$emit('hide')" @primary-click="sendSave">
    <template slot="title">Lagre måltid</template>
    <template slot="content">
      <div class="body">
        <cv-inline-notification
          kind="warning"
          sub-title="Oppskriften lagres kun lokalt i nettleseren din. Ved tømming av cache vil informasjonen forsvinne"
        ></cv-inline-notification>
        <cv-text-input v-model="name" placeholder="Navn" />
        <div v-if="saveState == SaveStates.Success">Lagret!</div>
        <div v-if="saveState == SaveStates.Failure">Noe gikk galt.</div>
      </div>
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
.body {
  text-align: left !important;
}
</style>
