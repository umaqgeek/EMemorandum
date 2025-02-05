<template>
    <div class="nk-app-root">
        <div class="nk-main">
            <NavbarComponent
                :staffprofile="dataStaffProfile"
                :activeLabel="`memo-list`"
            />
            <div class="nk-wrap">
                <TopNavComponent
                    :staffprofile="dataStaffProfile"
                    :errorStaffProfile="errorStaffProfile"
                />
                <LoadingComponent
                    :loading="loadingStaffProfile || mouLoading"
                />
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
                                                Lists of Memorandum
                                            </h2>
                                        </div>
                                        <div
                                            class="nk-block-head-content"
                                            v-if="isPUU"
                                        >
                                            <ul class="d-flex">
                                                <li>
                                                    <a
                                                        :href="`${publicPath}memo-add`"
                                                        class="btn btn-primary d-none d-md-inline-flex"
                                                        ><span
                                                            class="nk-menu-icon"
                                                            ><em
                                                                class="icon ni ni-plus"
                                                            ></em
                                                        ></span>
                                                        <span>Add New</span>
                                                    </a>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <!-- .nk-block-head-between -->
                                </div>
                                <!-- .nk-block-head -->
                                <div class="nk-block">
                                    <div
                                        v-if="isFiltered"
                                        class="filter-containter"
                                    >
                                        <button
                                            class="btn btn-danger mb-1"
                                            @click="resetFilter"
                                        >
                                            <em class="icon ni ni-cross"></em
                                            >&nbsp; Reset filter
                                        </button>
                                        <input
                                            type="text"
                                            class="form-control mb-3 query-search"
                                            v-model="querySearch"
                                            @keydown.enter="onSearch"
                                            placeholder="Search memorandum here ..."
                                            ref="searchInput"
                                        />
                                        <em
                                            class="icon ni ni-cross-circle clear-search-icon"
                                            @click="clearSearch"
                                        ></em>
                                    </div>
                                    <div
                                        class="btn btn-link"
                                        @click="onFilter"
                                        v-else
                                    >
                                        <em class="icon ni ni-filter"></em
                                        >&nbsp; Filter
                                    </div>
                                    <div class="card">
                                        <TableLite
                                            :columns="moucolumns"
                                            :data="mouData"
                                            :isNoAction="true"
                                        />
                                    </div>
                                    <!-- .card -->
                                </div>
                                <!-- .nk-block -->
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

<!-- JavaScript -->
<script>
import { ref, watch } from "vue";

import ValidateMeComponent from "@/components/ValidateMe.vue";
import NavbarComponent from "@/components/Navbar.vue";
import TopNavComponent from "@/components/TopNav.vue";
import FooterComponent from "@/components/Footer.vue";
import LoadingComponent from "@/components/Loading.vue";
import InfoNotLoggedInComponent from "@/components/InfoNotLoggedIn.vue";
import { useStaffProfile, useGetAllMOU, useLogPageView } from "@/hooks/useAPI";
import TableLite from "@/components/TableLite.vue";
import { shortenText } from "@/utils/func";

export default {
    name: "MemoListView",
    components: {
        ValidateMeComponent,
        NavbarComponent,
        TopNavComponent,
        FooterComponent,
        LoadingComponent,
        InfoNotLoggedInComponent,
        TableLite,
    },
    setup() {
        const publicPath = process.env.VUE_APP_PUBLIC_PATH;
        useLogPageView("Memo List");

        const {
            data: dataStaffProfile,
            error: errorStaffProfile,
            loading: loadingStaffProfile,
        } = useStaffProfile();

        // const initDatatable = () => {
        //     window.NioApp.DataTable.init = function () {
        //         window.NioApp.DataTable(".datatable-init");
        //     };
        //     window.NioApp.winLoad(window.NioApp.DataTable.init);
        // };

        const params = new URLSearchParams(window.location.search);
        const query = params.get("q") || "";
        const querySearch = ref(query);
        const isFiltered = ref(query !== "");

        const color = (kod) => {
            if (kod === "01") return "dark";
            if (kod === "02") return "info";
            if (kod === "03") return "warning";
            if (kod === "04") return "success";
            if (kod === "05" || kod === "06" || kod === "07") return "danger";
            return "dark";
        };

        const isAdmin = ref(false);
        const isPUU = ref(false);
        const isPTJ = ref(false);
        const isUS = ref(false);
        const isPIC = ref(false);

        const mouData = ref([]);
        const mouError = ref(null);
        const mouLoading = ref(false);
        const moucolumns = ref([
            "Project Title",
            "Memorandum No.",
            "Type",
            "Scope",
            "PIC",
            "Start Date",
            "End Date",
            // "Price (RM)",
        ]);
        watch(
            () => dataStaffProfile.value,
            (newDataStaffProfile) => {
                if (
                    newDataStaffProfile &&
                    newDataStaffProfile?.roles?.length > 0
                ) {
                    isAdmin.value = newDataStaffProfile?.roles?.find(
                        (r) => r.code === "Admin"
                    )
                        ? true
                        : false;
                    isPUU.value = newDataStaffProfile?.roles?.find(
                        (r) => r.code === "PUU"
                    )
                        ? true
                        : false;
                    isPTJ.value = newDataStaffProfile?.roles?.find(
                        (r) => r.code === "PTJ"
                    )
                        ? true
                        : false;
                    isUS.value = newDataStaffProfile?.roles?.find(
                        (r) => r.code === "US"
                    )
                        ? true
                        : false;

                    const { data: dataAllMOU, loading: loadingAllMOU } =
                        useGetAllMOU(query);
                    mouLoading.value = loadingAllMOU.value;
                    watch(
                        () => dataAllMOU.value,
                        (dataAllMOUs) => {
                            mouData.value = dataAllMOUs?.map((d) => {
                                return {
                                    "Project Title": shortenText(
                                        d.tajukProjek,
                                        100
                                    ),
                                    "Memorandum No.": `<a class="title" href="${publicPath}memo-detail?memo=${
                                        d.noMemo
                                    }">${
                                        d.noMemo
                                    }</a><br /><span class="badge text-bg-${color(
                                        d.status?.kod
                                    )}">${d.status?.status}</span>`,
                                    Type: d.jenis,
                                    Scope: d.scopeButiran,
                                    Staff: d.pic,
                                    "Start Date": d.tarikhMulaDate,
                                    "End Date": d.tarikhTamatDate,
                                    // "Price (RM)": d.nilai?.toFixed(2),
                                };
                            });
                            // initDatatable();
                        },
                        { immediate: true }
                    );
                    watch(
                        () => loadingAllMOU.value,
                        (newLoadingAllMOU) => {
                            mouLoading.value = newLoadingAllMOU;
                        }
                    );
                }
            },
            { immediate: true } // Run the watcher immediately on component mount
        );

        const onFilter = () => {
            isFiltered.value = true;
        };

        return {
            publicPath,
            querySearch,
            isFiltered,
            onFilter,
            dataStaffProfile,
            errorStaffProfile,
            loadingStaffProfile,
            mouData,
            mouError,
            mouLoading,
            moucolumns,
            isAdmin,
            isPUU,
            isPTJ,
            isUS,
            isPIC,
        };
    },
    computed: {},
    methods: {
        resetFilter() {
            location.href = `${this.publicPath}memo-list`;
        },
        onSearch() {
            location.href = `${this.publicPath}memo-list?q=${this.querySearch}`;
        },
        clearSearch() {
            this.querySearch = "";
            this.$nextTick(() => {
                this.$refs.searchInput.focus();
            });
        },
    },
};
</script>

<style scoped>
.filter-containter {
    display: flex;
    flex-direction: row;
    align-items: flex-start;
}
.filter-containter > .query-search {
    width: 20%;
    margin-left: 12px;
}
.clear-search-icon {
    color: rgba(0, 0, 0, 0.5);
    position: relative;
    top: 11px;
    right: 32px;
    font-size: 1.3em;
    z-index: 100;
    cursor: pointer;
}
</style>
