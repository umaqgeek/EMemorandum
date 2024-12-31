<template>
    <div class="nk-app-root">
        <div class="nk-main">
            <NavbarComponent
                :staffprofile="dataStaffProfile"
                :activeLabel="`codes`"
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
                        <h1 class="mb-3">Audit Logs</h1>

                        <!-- Filter Input -->
                        <div class="mb-3">
                            <input
                                v-model="filterText"
                                class="form-control"
                                placeholder="Filter by Audit Log"
                            />
                        </div>

                        <!-- Table -->
                        <table class="table table-bordered">
                            <thead>
                                <tr class="alert alert-secondary">
                                    <th @click="sortList('DateTime')">
                                        Date/Time
                                    </th>
                                    <th @click="sortList('User')">Staff</th>
                                    <th @click="sortList('Proses')">Proses</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr
                                    v-for="item in paginatedList"
                                    :key="item?.id"
                                >
                                    <td>{{ item?.dateTime }}</td>
                                    <td>{{ item?.user?.nama }}</td>
                                    <td>{{ item?.proses }}</td>
                                </tr>
                            </tbody>
                        </table>

                        <!-- Pagination -->
                        <nav>
                            <ul class="pagination">
                                <li
                                    class="page-item"
                                    :class="{ disabled: currentPage === 1 }"
                                >
                                    <button class="page-link" @click="prevPage">
                                        Previous
                                    </button>
                                </li>
                                <li
                                    class="page-item"
                                    v-for="page in totalPages"
                                    :key="page"
                                    :class="{ active: page === currentPage }"
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
                                        disabled: currentPage === totalPages,
                                    }"
                                >
                                    <button class="page-link" @click="nextPage">
                                        Next
                                    </button>
                                </li>
                            </ul>
                        </nav>
                    </div>
                </div>
                <FooterComponent />
            </div>
        </div>
    </div>
</template>

<script>
import { ref, watch } from "vue";

import NavbarComponent from "@/components/Navbar.vue";
import TopNavComponent from "@/components/TopNav.vue";
import FooterComponent from "@/components/Footer.vue";
import LoadingComponent from "@/components/Loading.vue";
import InfoNotLoggedInComponent from "@/components/InfoNotLoggedIn.vue";
import { useStaffProfile, useFetchAuditLogs } from "@/hooks/useAPI";

export default {
    name: "AuditLogsView",
    components: {
        LoadingComponent,
        NavbarComponent,
        TopNavComponent,
        FooterComponent,
        InfoNotLoggedInComponent,
    },
    setup() {
        const publicPath = ref(process.env.VUE_APP_PUBLIC_PATH);

        const {
            data: dataStaffProfile,
            error: errorStaffProfile,
            loading: loadingStaffProfile,
        } = useStaffProfile();
        const { data: auditLogs = ref([]), loading: loadingAuditLogs } =
            useFetchAuditLogs();

        const filterText = ref("");
        const currentPage = ref(1);
        const itemsPerPage = ref(100);

        const filteredList = ref([]);
        const paginatedList = ref([]);
        const totalPages = ref(0);

        watch(
            [auditLogs, filterText],
            ([newAuditLogs, newFilterText]) => {
                const filtered =
                    newAuditLogs?.filter(
                        (item) =>
                            item?.proses
                                ?.toLowerCase()
                                .includes(newFilterText.toLowerCase()) ||
                            item?.user?.nama
                                ?.toLowerCase()
                                .includes(newFilterText.toLowerCase()) ||
                            item?.user?.noStaf
                                ?.toLowerCase()
                                .includes(newFilterText.toLowerCase())
                    ) || [];

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

        return {
            publicPath,
            dataStaffProfile,
            errorStaffProfile,
            loading: loadingStaffProfile || loadingAuditLogs,
            filterText,
            auditLogs,
            filteredList,
            paginatedList,
            totalPages,
            currentPage,
            changePage,
            prevPage,
            nextPage,
            sortList,
        };
    },
};
</script>

<style scoped>
.modal {
    background: rgba(0, 0, 0, 0.5);
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    display: flex;
    justify-content: center;
    align-items: center;
}
</style>
