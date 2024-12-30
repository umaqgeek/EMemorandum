import { createRouter, createWebHistory } from "vue-router";

import DashboardView from "@/views/DashboardView.vue";
import ReportView from "@/views/ReportView.vue";
import ReportPrint from "@/views/ReportPrint.vue";
import MemoListView from "@/views/MemoListView.vue";
import MemoAddView from "@/views/MemoAddView.vue";
import MemoAddMemberView from "@/views/MemoAddMemberView.vue";
import MemoAddKPIView from "@/views/MemoAddKPIView.vue";
import MemoEditView from "@/views/MemoEditView.vue";
import MemoEditMemberView from "@/views/MemoEditMemberView.vue";
import MemoEditKPIView from "@/views/MemoEditKPIView.vue";
import MemoDetailsView from "@/views/MemoDetailsView.vue";
import MemoKPIDetailsView from "@/views/MemoKPIDetailsView.vue";
import ApprovalListView from "@/views/ApprovalListView.vue";
import ApprovalDetailsView from "@/views/ApprovalDetailsView.vue";
import UserListView from "@/views/UserList.vue";
import UserEditView from "@/views/UserEdit.vue";
import UserViewView from "@/views/UserView.vue";
import CodeListView from "@/views/CodeListView.vue";
import NotFoundView from "@/views/NotFoundView.vue";
import CodesDashboardView from "@/views/CodesDashboardView.vue";
import ManageFieldsView from "@/views/ManageFieldsView.vue";
import ManageIndustryCategoriesView from "@/views/ManageIndustryCategoriesView.vue";
import ManageJenisMemosView from "@/views/ManageJenisMemosView.vue";
import ManageKategoriMemosView from "@/views/ManageKategoriMemosView.vue";

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
        path: "/user-view",
        component: UserViewView,
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
        path: "/memo-edit",
        component: MemoEditView,
    },
    {
        path: "/memo-detail",
        component: MemoDetailsView,
    },
    {
        path: "/kpi-view",
        component: MemoKPIDetailsView,
    },
    {
        path: "/codes",
        component: CodesDashboardView,
    },
    {
        path: "/manage-fields",
        component: ManageFieldsView,
    },
    {
        path: "/manage-ind-cats",
        component: ManageIndustryCategoriesView,
    },
    {
        path: "/manage-types",
        component: ManageJenisMemosView,
    },
    {
        path: "/manage-categories",
        component: ManageKategoriMemosView,
    },
    {
        path: "/report",
        component: ReportView,
    },
    {
        path: "/report-print",
        component: ReportPrint,
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
