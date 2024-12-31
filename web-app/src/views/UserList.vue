<template>
    <div class="nk-app-root">
        <div class="nk-main">
            <NavbarComponent
                :staffprofile="dataStaffProfile"
                :activeLabel="`user-list`"
            />
            <div class="nk-wrap">
                <TopNavComponent
                    :staffprofile="dataStaffProfile"
                    :errorStaffProfile="errorStaffProfile"
                />
                <LoadingComponent :loading="loading" />
                <div class="nk-content" v-if="errorStaffProfile">
                    <InfoNotLoggedInComponent />
                </div>
                <div class="nk-content" v-if="!errorStaffProfile">
                    <div class="container">
                        <div class="nk-content-inner">
                            <div class="nk-content-body">
                                <div class="nk-block-head">
                                    <div
                                        class="nk-block-head-between flex-wrap gap g-2"
                                    >
                                        <div class="nk-block-head-content">
                                            <h2 class="nk-block-title">
                                                Manage Users
                                            </h2>
                                        </div>
                                    </div>
                                </div>
                                <div class="nk-block">
                                    <!-- Filter Input -->
                                    <div class="mb-3">
                                        <input
                                            v-model="filterText"
                                            class="form-control"
                                            placeholder="Filter by Name, PTJ, Roles, and Status"
                                        />
                                    </div>

                                    <!-- Table -->
                                    <table class="table table-bordered">
                                        <thead>
                                            <tr class="alert alert-secondary">
                                                <th @click="sortList('nama')">
                                                    Staff
                                                </th>
                                                <th @click="sortList('roles')">
                                                    Roles
                                                </th>
                                                <th @click="sortList('status')">
                                                    Status
                                                </th>
                                                <th>Actions</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr
                                                v-for="item in paginatedList"
                                                :key="item?.noStaf"
                                            >
                                                <td>
                                                    <a
                                                        :href="`${publicPath}user-edit?s=${item.noStaf}`"
                                                        class="title"
                                                        >{{ getNama(item) }}</a
                                                    >
                                                    <div class="small text">
                                                        {{ item.nPejabat }}
                                                    </div>
                                                </td>
                                                <td
                                                    v-html="
                                                        item.roles?.length > 0
                                                            ? item.roles
                                                                  ?.length > 1
                                                                ? item.roles
                                                                      ?.filter(
                                                                          (r) =>
                                                                              r.code !=
                                                                              'Staff'
                                                                      )
                                                                      .map(
                                                                          (r) =>
                                                                              r.role
                                                                      )
                                                                      ?.join(
                                                                          ',<br />'
                                                                      )
                                                                : 'Staff'
                                                            : '-'
                                                    "
                                                ></td>
                                                <td>
                                                    <span
                                                        class="badge text-bg-danger-soft"
                                                        v-if="
                                                            item.roles
                                                                ?.length <= 0
                                                        "
                                                        >Inactive</span
                                                    >
                                                    <span
                                                        class="badge text-bg-success"
                                                        v-if="
                                                            item.roles?.length >
                                                                0 &&
                                                            item.roles?.find(
                                                                (r) =>
                                                                    r.code ===
                                                                    'Staff'
                                                            )
                                                        "
                                                        >Active</span
                                                    >
                                                </td>
                                                <td>
                                                    <button
                                                        class="btn btn-sm btn-primary me-2"
                                                        @click="
                                                            () => onSelect(item)
                                                        "
                                                    >
                                                        Select
                                                    </button>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>

                                    <!-- Pagination -->
                                    <nav>
                                        <ul class="pagination">
                                            <li
                                                class="page-item"
                                                :class="{
                                                    disabled: currentPage === 1,
                                                }"
                                            >
                                                <button
                                                    class="page-link"
                                                    @click="prevPage"
                                                >
                                                    Previous
                                                </button>
                                            </li>
                                            <li
                                                class="page-item"
                                                v-for="page in totalPages"
                                                :key="page"
                                                :class="{
                                                    active:
                                                        page === currentPage,
                                                }"
                                            >
                                                <button
                                                    class="page-link"
                                                    @click="changePage(page)"
                                                >
                                                    {{ page }}
                                                </button>
                                            </li>
                                            <li
                                                class="page-item"
                                                :class="{
                                                    disabled:
                                                        currentPage ===
                                                        totalPages,
                                                }"
                                            >
                                                <button
                                                    class="page-link"
                                                    @click="nextPage"
                                                >
                                                    Next
                                                </button>
                                            </li>
                                        </ul>
                                    </nav>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <FooterComponent />
            </div>
        </div>
        <ValidateMeComponent />
    </div>
</template>

<script>
import { ref, watch } from "vue";

import ValidateMeComponent from "@/components/ValidateMe.vue";
import NavbarComponent from "@/components/Navbar.vue";
import TopNavComponent from "@/components/TopNav.vue";
import FooterComponent from "@/components/Footer.vue";
import LoadingComponent from "@/components/Loading.vue";
import InfoNotLoggedInComponent from "@/components/InfoNotLoggedIn.vue";
import {
    useStaffProfile,
    useGetAllStaff,
    useLogPageView,
} from "@/hooks/useAPI";

export default {
    name: "UserListView",
    components: {
        ValidateMeComponent,
        NavbarComponent,
        TopNavComponent,
        FooterComponent,
        LoadingComponent,
        InfoNotLoggedInComponent,
    },
    setup() {
        const publicPath = ref(process.env.VUE_APP_PUBLIC_PATH);
        useLogPageView("User List");
        const {
            data: dataStaffProfile,
            error: errorStaffProfile,
            loading: loadingStaffProfile,
            refetch: refetchStaffProfile,
        } = useStaffProfile();

        const {
            data: dataAllStaff,
            loading: loadingAllStaff,
            refetch: refetchAllStaff,
        } = useGetAllStaff();

        const filterText = ref("");
        const currentPage = ref(1);
        const itemsPerPage = ref(100);
        const filteredList = ref([]);
        const orifilteredList = ref([]);
        const paginatedList = ref([]);
        const totalPages = ref(0);

        watch(
            [dataAllStaff, filterText],
            ([newDataAllStaff, newFilterText]) => {
                const orifiltered = newDataAllStaff || [];
                const filtered =
                    newDataAllStaff?.filter(
                        (item) =>
                            item?.nama
                                ?.toLowerCase()
                                .includes(newFilterText.toLowerCase()) ||
                            item?.gelaran
                                ?.toLowerCase()
                                .includes(newFilterText.toLowerCase()) ||
                            item?.roles
                                ?.map((r) => r.role)
                                ?.join(",")
                                ?.toLowerCase()
                                .includes(newFilterText.toLowerCase())
                    ) || [];

                orifilteredList.value = orifiltered;
                filteredList.value = filtered;

                const start = (currentPage.value - 1) * itemsPerPage.value;
                paginatedList.value = filtered.slice(
                    start,
                    start + itemsPerPage.value
                );
                totalPages.value = Math.ceil(
                    filtered.length / itemsPerPage.value
                );
            },
            { immediate: true }
        );

        const changePage = (page) => {
            currentPage.value = page;
            const start = (page - 1) * itemsPerPage.value;
            paginatedList.value = filteredList.value.slice(
                start,
                start + itemsPerPage.value
            );
        };

        const prevPage = () => {
            if (currentPage.value > 1) currentPage.value--;
        };

        const nextPage = () => {
            if (currentPage.value < totalPages.value) currentPage.value++;
        };

        const sortColumn = ref(null);
        const sortOrder = ref(1);
        const sortList = (column) => {
            if (sortColumn.value === column) {
                sortOrder.value *= -1;
            } else {
                sortColumn.value = column;
                sortOrder.value = 1;
            }
        };

        const onSelect = (item) => {
            location.href = `${publicPath.value}user-edit?s=${item.noStaf}`;
        };

        return {
            publicPath,
            dataAllStaff,
            dataStaffProfile,
            errorStaffProfile,
            loading: loadingAllStaff || loadingStaffProfile,
            refetchAllStaff,
            refetchStaffProfile,
            filterText,
            filteredList,
            paginatedList,
            totalPages,
            currentPage,
            changePage,
            prevPage,
            nextPage,
            sortList,
            onSelect,
        };
    },
    computed: {
        users() {
            if (this.dataAllStaff?.length > 0) {
                return [...this.dataAllStaff].sort((a, b) => {
                    if (a.roles.length > b.roles.length) {
                        return -1;
                    }
                    if (a.roles.length < b.roles.length) {
                        return 1;
                    }
                    return 0;
                });
            }
            return [];
        },
    },
    methods: {
        getNama(user) {
            return (
                (user.gelaran?.toLowerCase()?.includes("tiada")
                    ? ""
                    : user.gelaran) +
                " " +
                user.nama
            );
        },
    },
};
</script>
