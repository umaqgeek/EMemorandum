import { createApp } from "vue";
import { library } from "@fortawesome/fontawesome-svg-core";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import {
    faUsers,
    faGear,
    faFile,
    faCheckToSlot,
    faPieChart,
} from "@fortawesome/free-solid-svg-icons";
import VueToast from "vue-toast-notification";
import "vue-toast-notification/dist/theme-sugar.css";

import App from "./App.vue";
import router from "./router";
import store from "./store";
import "./assets/css/styles.css";

// icons
library.add(faUsers);
library.add(faGear);
library.add(faFile);
library.add(faCheckToSlot);
library.add(faPieChart);

createApp(App)
    .use(store)
    .use(router)
    .use(VueToast)
    .component("font-awesome-icon", FontAwesomeIcon)
    .mount("#app");
