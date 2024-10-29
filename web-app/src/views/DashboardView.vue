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
                                    <div
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
                                                (r) => r.role === 'Admin'
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
                                                (r) => r.role === 'Staff'
                                            ) ||
                                            roles.find((r) => r.role === 'PTJ')
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
                                    </div>
                                    <!-- <div
                                        class="col-md-3"
                                        v-if="
                                            roles.find(
                                                (r) => r.role === 'Admin'
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
                                            roles.find((r) => r.role === 'PTJ')
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
                                <div class="row g-gs mt-3">
                                    <div class="col-md-4">
                                        <div class="card">
                                            <div class="card-body">
                                                <h4>Memorandums by Category</h4>
                                                <ChartPieComponent
                                                    v-if="
                                                        reportCategory.series
                                                            ?.length > 0
                                                    "
                                                    :series="
                                                        reportCategory.series
                                                    "
                                                    :labels="
                                                        reportCategory.labels
                                                    "
                                                />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
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
                                    <div class="col-md-4">
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
} from "@/hooks/useAPI";
import ChartPieComponent from "@/components/ChartPie.vue";

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
    },
    setup() {
        const {
            data: dataStaffProfile,
            error: errorStaffProfile,
            loading: loadingStaffProfile,
            refetch,
        } = useStaffProfile();

        const reportCategory = ref({
            labels: [],
            series: [],
        });
        const { data: dataReportCategory, loading: loadingReportCategory } =
            useReportByCategory();
        watch(
            () => dataReportCategory.value,
            (newDataReportCategory) => {
                reportCategory.value = {
                    labels: [...newDataReportCategory?.labels],
                    series: [...newDataReportCategory?.data],
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
                loadingReportPTJ,
            refetch,
            reportCategory,
            reportDue1Year,
            reportPTJ,
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
