<template>
  <cv-modal :visible="showModal" @modal-hidden="$emit('hide')" @primary-click="sendSave">
    <template slot="title">{{ $t('saveMeal') }}</template>
    <template slot="content">
      <div class="body">
        <cv-inline-notification kind="warning" :sub-title="saveMealToastMessage"></cv-inline-notification>
        <cv-text-input v-model="name" :placeholder="namePlaceholder" />
        <div v-if="saveState == SaveStates.Success">{{ $t('saved') }}</div>
        <div v-if="saveState == SaveStates.Failure">{{ $t('somethingWentWrong') }}</div>
      </div>
    </template>
    <template slot="secondary-button">{{ $t('cancel') }}</template>
    <template slot="primary-button">{{ $t('save') }}</template>
  </cv-modal>
</template>

<script>
import { SaveStates } from "../../models/SaveStates";

export default {
  props: {
    showModal: Boolean
  },
  data() {
    return {
      name: "",
      SaveStates: SaveStates,
      saveState: SaveStates.Uninitialized,
    };
  },
  computed: {
    namePlaceholder() {
      return this.$t("name");
    },
    saveMealToastMessage() {
      return this.$t("saveMealToastMessage");
    }
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
