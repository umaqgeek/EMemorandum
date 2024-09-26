import { createApp } from "vue";
import { library } from "@fortawesome/fontawesome-svg-core";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import {
    faUsers,
    faGear,
    faFile,
    faCheckToSlot,
} from "@fortawesome/free-solid-svg-icons";

import App from "./App.vue";
import router from "./router";
import store from "./store";
import "./assets/css/styles.css";

// icons
library.add(faUsers);
library.add(faGear);
library.add(faFile);
library.add(faCheckToSlot);

createApp(App)
    .use(store)
    .use(router)
    .component("font-awesome-icon", FontAwesomeIcon)
    .mount("#app");
