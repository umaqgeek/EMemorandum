import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import "./assets/css/style.css";
import "./assets/css/styles.css";
import "./assets/js/data-tables/data-tables.js";

createApp(App).use(store).use(router).mount("#app");
