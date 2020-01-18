<template>
  <div className="container">
    <Header aria-label="IBM Platform Name">
      <HeaderName href="#" prefix="IBM">
        [Platform]
      </HeaderName>
      <HeaderGlobalBar>
        <HeaderGlobalAction aria-label="Search">
          <Search20 />
        </HeaderGlobalAction>
        <HeaderGlobalAction aria-label="Notifications" >
          <Notification20 />
        </HeaderGlobalAction>
        <HeaderGlobalAction aria-label="App Switcher" >
          <AppSwitcher20 />
        </HeaderGlobalAction>
      </HeaderGlobalBar>
    </Header>
  </div>
</template>

<script>
import Search20 from "@carbon/icons-react/lib/search/20";
import Notification20 from "@carbon/icons-react/lib/notification/20";
import AppSwitcher20 from "@carbon/icons-react/lib/app-switcher/20";
import {
  Header,
  HeaderName,
  HeaderGlobalAction,
  HeaderGlobalBar
} from "carbon-components-react/lib/components/UIShell";

import "./style.css";
export default {
};
</script>

<style>
</style>
