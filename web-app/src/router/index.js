import { createRouter, createWebHistory } from "vue-router";
import HomeView from "../views/HomeView.vue";
import AboutView from "../views/AboutView.vue";
import HahaView from "../views/Haha.vue";

const routes = [
    {
        path: "/",
        component: HomeView,
    },
    {
        path: "/about",
        component: AboutView,
    },
    {
        path: "/haha-umar",
        component: HahaView,
    },
];

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes,
});

export default router;
