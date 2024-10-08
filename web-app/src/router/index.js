import { createRouter, createWebHistory } from "vue-router";
// all
// import LoginView from "@/views/LoginView.vue";
import DashboardView from "@/views/DashboardView.vue";
import MemoListView from "@/views/MemoListView.vue";
import MemoAddView from "@/views/MemoAddView.vue";
import MemoAddMemberView from "@/views/MemoAddMemberView.vue";
import MemoAddKPIView from "@/views/MemoAddKPIView.vue";
import MemoEditView from "@/views/MemoEditView.vue";
import MemoEditMemberView from "@/views/MemoEditMemberView.vue";
import MemoEditKPIView from "@/views/MemoEditKPIView.vue";
import MemoDetailsView from "@/views/MemoDetailsView.vue";
import ApprovalListView from "@/views/ApprovalListView.vue";
import ApprovalDetailsView from "@/views/ApprovalDetailsView.vue";
// admin
import UserListView from "@/views/UserList.vue";
import UserEditView from "@/views/UserEdit.vue";
import CodeListView from "@/views/CodeListView.vue";
// import adminDashboardView from "@/views/DashboardView.vue";
// import adminMemoListView from "@/views/MemoListView.vue";
// import adminMemoAddView from "@/views/MemoAddView.vue";
// import adminMemoAddMemberView from "@/views/MemoAddMemberView.vue";
// import adminMemoEditView from "@/views/MemoEditView.vue";
// import adminMemoDetailsView from "@/views/MemoDetailsView.vue";
// import adminApprovalListView from "@/views/ApprovalListView.vue";
// import adminApprovalDetailsView from "@/views/ApprovalDetailsView.vue";
// PUU
// import PUULoginView from "@/views/PUU/LoginView.vue";
// import PUUDashboardView from "@/views/DashboardViewPUU.vue";
// import PUUMemoListView from "@/views/PUU/MemoListView.vue";
// import PUUMemoAddView from "@/views/PUU/MemoAddView.vue";
// import PUUMemoAddMemberView from "@/views/PUU/MemoAddMemberView.vue";
// import PUUMemoEditView from "@/views/PUU/MemoEditView.vue";
// import PUUMemoDetailsView from "@/views/PUU/MemoDetailsView.vue";
// import PUUApprovalListView from "@/views/PUU/ApprovalListView.vue";
// import PUUApprovalDetailsView from "@/views/PUU/ApprovalDetailsView.vue";
// PTJ
// import PTJLoginView from "@/views/PTJ/LoginView.vue";
// import PTJDashboardView from "@/views/DashboardViewPTJ.vue";
// import PTJMemoListView from "@/views/PTJ/MemoListView.vue";
// import PTJMemoAddView from "@/views/PTJ/MemoAddView.vue";
// import PTJMemoAddMemberView from "@/views/PTJ/MemoAddMemberView.vue";
// import PTJMemoEditView from "@/views/PTJ/MemoEditView.vue";
// import PTJMemoDetailsView from "@/views/PTJ/MemoDetailsView.vue";
// import PTJApprovalListView from "@/views/PTJ/ApprovalListView.vue";
// import PTJApprovalDetailsView from "@/views/PTJ/ApprovalDetailsView.vue";
// Not Found placeholder view page
import NotFoundView from "@/views/NotFoundView.vue";

const routes = [
    {
        path: "/",
        component: DashboardView,
    },
    {
        path: "/user-list",
        component: UserListView,
    },
    {
        path: "/user-edit",
        component: UserEditView,
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
        path: "/:pathMatch(.*)*",
        component: NotFoundView, // Your custom 404 page component
        // redirect to a root view page
        redirect: process.env.VUE_APP_PUBLIC_PATH,
    },
];

const routesOld = [
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
    {
        path: "/approval-list",
        component: ApprovalListView,
    },
    {
        path: "/approval-detail",
        component: ApprovalDetailsView,
    },
    // // admin
    {
        path: "/user-list",
        component: UserListView,
    },
    {
        path: "/user-edit",
        component: UserEditView,
    },
    {
        path: "/code-list",
        component: CodeListView,
    },
    {
        path: "/memo-add-kpi",
        component: MemoAddKPIView,
    },

    {
        path: "/memo-edit-member",
        component: MemoEditMemberView,
    },
    {
        path: "/memo-edit-kpi",
        component: MemoEditKPIView,
    },
    // {
    //     path: "/login",
    //     component: adminLoginView,
    // },
    // {
    //     path: "/dashboard",
    //     component: adminDashboardView,
    // },
    // {
    //     path: "/memo-list",
    //     component: adminMemoListView,
    // },
    // {
    //     path: "/memo-add",
    //     component: adminMemoAddView,
    // },
    // {
    //     path: "/memo-add-Member",
    //     component: adminMemoAddMemberView,
    // },
    // {
    //     path: "/memo-edit",
    //     component: adminMemoEditView,
    // },
    // {
    //     path: "/memo-detail",
    //     component: adminMemoDetailsView,
    // },
    // {
    //     path: "/approval-list",
    //     component: adminApprovalListView,
    // },
    // {
    //     path: "/approval-detail",
    //     component: adminApprovalDetailsView,
    // },
    // // PUU
    // {
    //     path: "/",
    //     component: PUULoginView,
    // },
    // {
    //     path: "/login",
    //     component: PUULoginView,
    // },
    // {
    //     path: "/PUU/dashboard",
    //     component: PUUDashboardView,
    // },
    // {
    //     path: "/memo-list",
    //     component: PUUMemoListView,
    // },
    // {
    //     path: "/memo-add",
    //     component: PUUMemoAddView,
    // },
    // {
    //     path: "/memo-add-Member",
    //     component: PUUMemoAddMemberView,
    // },
    // {
    //     path: "/memo-edit",
    //     component: PUUMemoEditView,
    // },
    // {
    //     path: "/memo-detail",
    //     component: PUUMemoDetailsView,
    // },
    // {
    //     path: "/approval-list",
    //     component: PUUApprovalListView,
    // },
    // {
    //     path: "/approval-detail",
    //     component: PUUApprovalDetailsView,
    // },
    // // PTJ
    // {
    //     path: "/PTJ/login",
    //     component: PTJLoginView,
    // },
    // {
    //     path: "/PTJ/dashboard",
    //     component: PTJDashboardView,
    // },
    // {
    //     path: "/PTJ/memo-list",
    //     component: PTJMemoListView,
    // },
    // {
    //     path: "/PTJ/memo-add",
    //     component: PTJMemoAddView,
    // },
    // {
    //     path: "/PTJ/memo-add-Member",
    //     component: PTJMemoAddMemberView,
    // },
    // {
    //     path: "/PTJ/memo-edit",
    //     component: PTJMemoEditView,
    // },
    // {
    //     path: "/PTJ/memo-detail",
    //     component: PTJMemoDetailsView,
    // },
    // {
    //     path: "/PTJ/approval-list",
    //     component: PTJApprovalListView,
    // },
    // {
    //     path: "/PTJ/approval-detail",
    //     component: PTJApprovalDetailsView,
    // },
    // Catch-all route for undefined routes
    {
        path: "/:pathMatch(.*)*",
        component: NotFoundView, // Your custom 404 page component
        // redirect to a root view page
        redirect: process.env.VUE_APP_PUBLIC_PATH,
    },
];
console.log("routesOld", routesOld);

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes,
});

export default router;
