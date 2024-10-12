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
                                        <div class="nk-block-head-content">
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
                                    <div class="card">
                                        <TableLite
                                            :columns="moucolumns"
                                            :data="mouData"
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
import { useStaffProfile, useGetAllMOU, useGetMyMOU } from "@/hooks/useAPI";
import TableLite from "@/components/TableLite.vue";

export default {
    name: "MemoListView",
    data() {
        return {
            publicPath: process.env.VUE_APP_PUBLIC_PATH,
        };
    },
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

        const mouData = ref([]);
        const mouError = ref(null);
        const mouLoading = ref(false);
        const moucolumns = ref([
            "Memorandum No.",
            "Scope",
            "Staff",
            "Start Date",
            "End Date",
            "Price (RM)",
            "Status",
        ]);
        watch(
            () => dataStaffProfile.value,
            (newDataStaffProfile) => {
                if (
                    newDataStaffProfile &&
                    newDataStaffProfile?.roles?.length > 0
                ) {
                    const isAdmin = newDataStaffProfile?.roles?.find(
                        (r) => r.role === "Admin"
                    )
                        ? true
                        : false;
                    const isPUU = newDataStaffProfile?.roles?.find(
                        (r) => r.role === "PUU"
                    )
                        ? true
                        : false;
                    if (isAdmin || isPUU) {
                        const { data: dataAllMOU, loading: loadingAllMOU } =
                            useGetAllMOU();
                        mouLoading.value = loadingAllMOU.value;
                        watch(
                            () => dataAllMOU.value,
                            (dataAllMOUs) => {
                                mouData.value = dataAllMOUs?.map((d) => {
                                    return {
                                        noMemo: d.noMemo,
                                        scopeButiran: d.scopeButiran,
                                        pic: d.pic,
                                        tarikhMulaDate: d.tarikhMulaDate,
                                        tarikhTamatDate: d.tarikhTamatDate,
                                        nilai: d.nilai?.toFixed(2),
                                        status: `<span class="badge text-bg-dark">${d.status?.status}</span>`,
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
                    } else {
                        const { data: dataMyMOU, loading: loadingMyMOU } =
                            useGetMyMOU();
                        mouLoading.value = loadingMyMOU.value;
                        watch(
                            () => dataMyMOU.value,
                            (dataMyMOUs) => {
                                mouData.value = dataMyMOUs?.map((d) => {
                                    return {
                                        noMemo: d.noMemo,
                                        scopeButiran: d.scopeButiran,
                                        pic: d.pic,
                                        tarikhMulaDate: d.tarikhMulaDate,
                                        tarikhTamatDate: d.tarikhTamatDate,
                                        nilai: d.nilai?.toFixed(2),
                                        status: `<span class="badge text-bg-dark">${d.status?.status}</span>`,
                                    };
                                });
                                // initDatatable();
                            },
                            { immediate: true }
                        );
                        watch(
                            () => loadingMyMOU.value,
                            (newLoadingMyMOU) => {
                                mouLoading.value = newLoadingMyMOU;
                            }
                        );
                    }
                }
            },
            { immediate: true } // Run the watcher immediately on component mount
        );

        return {
            dataStaffProfile,
            errorStaffProfile,
            loadingStaffProfile,
            mouData,
            mouError,
            mouLoading,
            moucolumns,
        };
    },
    computed: {},
    methods: {},
};
</script>
