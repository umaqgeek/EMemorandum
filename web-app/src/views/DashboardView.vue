<template>
    <div class="nk-app-root">
        <div class="nk-main">
            <NavbarComponent
                :staffprofile="dataStaffProfile"
                :activeLabel="`dashboard`"
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
                    <div class="container-fluid">
                        <div class="nk-content-inner">
                            <div class="nk-content-body">
                                <div class="row g-gs">
                                    <!-- <div
                                        class="alert alert-danger"
                                        v-if="roles.length <= 0"
                                    >
                                        You are not activated yet!
                                        <br />Please contact your administrator
                                        to activate your account.
                                    </div>
                                    <div
                                        class="col-md-3"
                                        v-if="
                                            roles.find(
                                                (r) => r.code === 'Admin'
                                            )
                                        "
                                    >
                                        <a :href="`${publicPath}user-list`">
                                            <div class="card">
                                                <div
                                                    class="card-body dashboard-card"
                                                >
                                                    <h4 class="mb-3">
                                                        Manage User
                                                    </h4>
                                                    <font-awesome-icon
                                                        icon="fa-solid fa-users"
                                                        size="2x"
                                                    />
                                                </div>
                                            </div>
                                        </a>
                                    </div>
                                    <div
                                        class="col-md-3"
                                        v-if="
                                            roles.find(
                                                (r) => r.code === 'Staff'
                                            ) ||
                                            roles.find((r) => r.code === 'PTJ')
                                        "
                                    >
                                        <a :href="`${publicPath}memo-list`">
                                            <div class="card">
                                                <div
                                                    class="card-body dashboard-card"
                                                >
                                                    <h4 class="mb-3">
                                                        Memorandums
                                                    </h4>
                                                    <font-awesome-icon
                                                        icon="fa-solid fa-file"
                                                        size="2x"
                                                    />
                                                </div>
                                            </div>
                                        </a>
                                    </div>
                                    <div class="col-md-3">
                                        <a :href="`${publicPath}report`">
                                            <div class="card">
                                                <div
                                                    class="card-body dashboard-card"
                                                >
                                                    <h4 class="mb-3">Report</h4>
                                                    <font-awesome-icon
                                                        icon="fa-solid fa-pie-chart"
                                                        size="2x"
                                                    />
                                                </div>
                                            </div>
                                        </a>
                                    </div> -->
                                    <!-- <div
                                        class="col-md-3"
                                        v-if="
                                            roles.find(
                                                (r) => r.code === 'Admin'
                                            )
                                        "
                                    >
                                        <a :href="`${publicPath}code-list`">
                                            <div class="card">
                                                <div
                                                    class="card-body dashboard-card"
                                                >
                                                    <h4 class="mb-3">
                                                        Manage Code
                                                    </h4>
                                                    <font-awesome-icon
                                                        icon="fa-solid fa-gear"
                                                        size="2x"
                                                    />
                                                </div>
                                            </div>
                                        </a>
                                    </div> -->
                                    <!-- <div
                                        class="col-md-3"
                                        v-if="
                                            roles.find((r) => r.code === 'PTJ')
                                        "
                                    >
                                        <a :href="`${publicPath}approval-list`">
                                            <div class="card">
                                                <div
                                                    class="card-body dashboard-card"
                                                >
                                                    <h4 class="mb-3">
                                                        Approval
                                                    </h4>
                                                    <font-awesome-icon
                                                        icon="fa-solid fa-check-to-slot"
                                                        size="2x"
                                                    />
                                                </div>
                                            </div>
                                        </a>
                                    </div> -->
                                </div>
                                <div class="row g-gt mb-3">
                                    <div class="col-md-8">
                                        <div class="card">
                                            <div
                                                class="card-body"
                                                v-if="
                                                    reportCountryMap.data
                                                        .length > 0 && !loading
                                                "
                                            >
                                                <h4>Memorandums by Country</h4>
                                                <VueAGMap
                                                    :data="
                                                        reportCountryMap.data
                                                    "
                                                />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="card">
                                            <div class="card-body">
                                                <h4>Memorandums by Country</h4>
                                                <ChartPieComponent
                                                    v-if="
                                                        reportCountry.series
                                                            ?.length > 0
                                                    "
                                                    :series="
                                                        reportCountry.series
                                                    "
                                                    :labels="
                                                        reportCountry.labels
                                                    "
                                                />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row g-gt mb-3">
                                    <div class="col-md-6">
                                        <div class="card">
                                            <div class="card-body">
                                                <h4>Memorandums by Category</h4>
                                                <VueAGBar
                                                    v-if="
                                                        reportCategory.data
                                                            ?.length > 0
                                                    "
                                                    :data="reportCategory.data"
                                                    title=""
                                                    subtitle=""
                                                />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="card">
                                            <div class="card-body">
                                                <h4>Memorandums by PTJs</h4>
                                                <ChartPieComponent
                                                    v-if="
                                                        reportPTJ.series
                                                            ?.length > 0
                                                    "
                                                    :series="reportPTJ.series"
                                                    :labels="reportPTJ.labels"
                                                />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row g-gt mb-3">
                                    <div class="col-md-6">
                                        <div class="card">
                                            <div class="card-body">
                                                <h4>Memorandums by Status</h4>
                                                <ChartPieComponent
                                                    v-if="
                                                        reportStatus.series
                                                            ?.length > 0
                                                    "
                                                    :series="
                                                        reportStatus.series
                                                    "
                                                    :labels="
                                                        reportStatus.labels
                                                    "
                                                />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="card">
                                            <div class="card-body">
                                                <h4>
                                                    Memorandums Due in 12 Months
                                                </h4>
                                                <ChartPieComponent
                                                    v-if="
                                                        reportDue1Year.series
                                                            ?.length > 0
                                                    "
                                                    :series="
                                                        reportDue1Year.series
                                                    "
                                                    :labels="
                                                        reportDue1Year.labels
                                                    "
                                                />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <FooterComponent />
            </div>
        </div>
    </div>
</template>

<!-- JavaScript -->
<script>
import { ref, watch } from "vue";

import NavbarComponent from "@/components/Navbar.vue";
import TopNavComponent from "@/components/TopNav.vue";
import FooterComponent from "@/components/Footer.vue";
import LoadingComponent from "@/components/Loading.vue";
import InfoNotLoggedInComponent from "@/components/InfoNotLoggedIn.vue";
import {
    useStaffProfile,
    useReportByCategory,
    useReportByDue1Year,
    useReportByPTJ,
    useReportByCountryMap,
    useReportByCountry,
    useReportByStatus,
} from "@/hooks/useAPI";
import ChartPieComponent from "@/components/ChartPie.vue";
import VueAGMap from "@/components/ChartAGMap.vue";
import VueAGBar from "@/components/ChartAGBar.vue";

export default {
    name: "DashboardView",
    data() {
        return {
            publicPath: process.env.VUE_APP_PUBLIC_PATH,
        };
    },
    components: {
        LoadingComponent,
        NavbarComponent,
        TopNavComponent,
        FooterComponent,
        InfoNotLoggedInComponent,
        ChartPieComponent,
        VueAGMap,
        VueAGBar,
    },
    setup() {
        const {
            data: dataStaffProfile,
            error: errorStaffProfile,
            loading: loadingStaffProfile,
            refetch,
        } = useStaffProfile();

        const reportCategory = ref({
            data: [],
        });
        const { data: dataReportCategory, loading: loadingReportCategory } =
            useReportByCategory();
        watch(
            () => dataReportCategory.value,
            (newDataReportCategory) => {
                reportCategory.value = {
                    data: [...newDataReportCategory],
                };
            }
        );

        const reportCountry = ref({
            labels: [],
            series: [],
        });
        const { data: dataReportCountry, loading: loadingReportCountry } =
            useReportByCountry();
        watch(
            () => dataReportCountry.value,
            (newDataReportCountry) => {
                reportCountry.value = {
                    labels: [...newDataReportCountry?.labels],
                    series: [...newDataReportCountry?.data],
                };
            }
        );

        const reportCountryMap = ref({
            data: [],
        });
        const { data: dataReportCountryMap, loading: loadingReportCountryMap } =
            useReportByCountryMap();
        watch(
            () => dataReportCountryMap.value,
            (newDataReportCountryMap) => {
                reportCountryMap.value = {
                    data: [...newDataReportCountryMap],
                };
            }
        );

        const reportStatus = ref({
            labels: [],
            series: [],
        });
        const { data: dataReportStatus, loading: loadingReportStatus } =
            useReportByStatus();
        watch(
            () => dataReportStatus.value,
            (newDataReportStatus) => {
                reportStatus.value = {
                    labels: [...newDataReportStatus?.labels],
                    series: [...newDataReportStatus?.data],
                };
            }
        );

        const reportDue1Year = ref({
            labels: [],
            series: [],
        });
        const { data: dataReportDue1Year, loading: loadingReportDue1Year } =
            useReportByDue1Year();
        watch(
            () => dataReportDue1Year.value,
            (newDataReportDue1Year) => {
                reportDue1Year.value = {
                    labels: [...newDataReportDue1Year?.labels],
                    series: [...newDataReportDue1Year?.data],
                };
            }
        );

        const reportPTJ = ref({
            labels: [],
            series: [],
        });
        const { data: dataReportPTJ, loading: loadingReportPTJ } =
            useReportByPTJ();
        watch(
            () => dataReportPTJ.value,
            (newDataReportPTJ) => {
                reportPTJ.value = {
                    labels: [...newDataReportPTJ?.labels],
                    series: [...newDataReportPTJ?.data],
                };
            }
        );

        return {
            dataStaffProfile,
            errorStaffProfile,
            loading:
                loadingStaffProfile ||
                loadingReportCategory ||
                loadingReportDue1Year ||
                loadingReportPTJ ||
                loadingReportCountry ||
                loadingReportCountryMap ||
                loadingReportStatus,
            refetch,
            reportCategory,
            reportDue1Year,
            reportPTJ,
            reportCountry,
            reportCountryMap,
            reportStatus,
        };
    },
    computed: {
        roles() {
            return this.dataStaffProfile?.roles?.length > 0
                ? this.dataStaffProfile?.roles
                : [];
        },
    },
    methods: {},
};
</script>
