import { createRouter, createWebHistory } from "vue-router";
import LoginView from "@/views/LoginView.vue";
import DashboardView from "@/views/DashboardView.vue";
import MemoListView from "@/views/MemoListView.vue";
import MemoAddView from "@/views/MemoAddView.vue";
import MemoAddMemberView from "@/views/MemoAddMemberView.vue";
import MemoEditView from "@/views/MemoEditView.vue";
import MemoDetailsView from "@/views/MemoDetailsView.vue";

const routes = [
    {
        path: "/",
        component: LoginView,
    },
    {
        path: "/login",
        component: LoginView,
    },
    {
        path: "/dashboard",
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
    {
        path: "/memo-add-Member",
        component: MemoAddMemberView,
    },
    {
        path: "/memo-edit",
        component: MemoEditView,
    },
    {
        path: "/memo-detail",
        component: MemoDetailsView,
    },
];

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes,
});

export default router;
