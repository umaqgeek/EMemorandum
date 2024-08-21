import { createRouter, createWebHistory } from "vue-router";
import DashboardView from "@/views/DashboardView.vue";
import MemoListView from "@/views/MemoListView.vue";
import MemoAddView from "@/views/MemoAddView.vue";

const routes = [
    {
        path: "/",
        component: DashboardView,
    },
    {
        path: "/memo-list",
        component: MemoListView,
    },
    {
        path: "/memo-add",
        component: MemoAddView,
    },
];

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes,
});

export default router;
