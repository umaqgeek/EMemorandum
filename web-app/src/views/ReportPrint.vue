<template>
    <div class="nk-app-root">
        <div class="nk-main">
            <div class="nk-wrap">
                <LoadingComponent :loading="loading" />
                <div class="nk-content" v-if="errorStaffProfile">
                    <InfoNotLoggedInComponent />
                </div>
                <div class="nk-content" v-if="!errorStaffProfile">
                    <div class="container-fluid">
                        <div class="nk-content-inner">
                            <div class="nk-content-body">
                                <div class="row g-gs">
                                    <div class="col-md-12">
                                        <div
                                            class="report-print-title-container"
                                        >
                                            <img
                                                class="mb-3 report-print-title-logo"
                                                src="assets/images/LogoJawiUTeM_blue-02.png"
                                                width="300px"
                                            />
                                            <div
                                                class="report-print-title-right-container"
                                            >
                                                <div class="report-print-title">
                                                    UNIVERSITI TEKNIKAL MALAYSIA
                                                    MELAKA
                                                </div>
                                                <div
                                                    class="report-print-address"
                                                >
                                                    PEJABAT PENASIHAT
                                                    UNDANG-UNDANG<br />
                                                    HANG TUAH JAYA, 76100 DURIAN
                                                    TUNGGAL, MELAKA, MALAYSIA
                                                </div>
                                            </div>
                                        </div>
                                        <table class="table table-bordered">
                                            <thead>
                                                <tr>
                                                    <th>NO.</th>
                                                    <th>COUNTRY</th>
                                                    <th>INDUSTRY CATEGORY</th>
                                                    <th>FACULTY/PTJ</th>
                                                    <th>PIC</th>
                                                    <th>CATEGORY</th>
                                                    <th>TYPE</th>
                                                    <th>START DATE</th>
                                                    <th>END DATE</th>
                                                    <th>DURATION</th>
                                                    <th>STATUS</th>
                                                </tr>
                                            </thead>
                                            <tbody
                                                v-if="reportDetails.length > 0"
                                            >
                                                <tr
                                                    v-for="reportDetail in reportDetails"
                                                    v-bind:key="reportDetail.no"
                                                >
                                                    <td>
                                                        {{ reportDetail.no }}.
                                                    </td>
                                                    <td>
                                                        {{
                                                            reportDetail.country?.name?.toUpperCase()
                                                        }}
                                                    </td>
                                                    <td>
                                                        {{
                                                            reportDetail.industryCategory?.industryCategory?.toUpperCase()
                                                        }}
                                                    </td>
                                                    <td>
                                                        {{
                                                            reportDetail.facultyPTJ?.toUpperCase()
                                                        }}
                                                    </td>
                                                    <td>
                                                        {{
                                                            getNama(
                                                                reportDetail.picGelaran?.toUpperCase(),
                                                                reportDetail.pic?.toUpperCase()
                                                            )
                                                        }}
                                                    </td>
                                                    <td>
                                                        {{
                                                            reportDetail.category
                                                        }}
                                                    </td>
                                                    <td>
                                                        {{ reportDetail.type }}
                                                    </td>
                                                    <td>
                                                        {{
                                                            reportDetail.startDate
                                                        }}
                                                    </td>
                                                    <td>
                                                        {{
                                                            reportDetail.endDate
                                                        }}
                                                    </td>
                                                    <td>
                                                        {{
                                                            reportDetail.duration
                                                        }}
                                                    </td>
                                                    <td>
                                                        {{
                                                            reportDetail.status
                                                        }}
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<!-- JavaScript -->
<script>
import { ref, watch } from "vue";

import LoadingComponent from "@/components/Loading.vue";
import InfoNotLoggedInComponent from "@/components/InfoNotLoggedIn.vue";
import { useStaffProfile, useReportDetails } from "@/hooks/useAPI";

export default {
    name: "ReportPrint",
    data() {
        return {
            publicPath: process.env.VUE_APP_PUBLIC_PATH,
        };
    },
    components: {
        LoadingComponent,
        InfoNotLoggedInComponent,
    },
    setup() {
        const {
            data: dataStaffProfile,
            error: errorStaffProfile,
            loading: loadingStaffProfile,
        } = useStaffProfile();

        const reportDetails = ref([]);
        const { data: dataReportDetails, loading: loadingReportDetails } =
            useReportDetails();
        watch(
            () => dataReportDetails.value,
            (newDataReportDetails) => {
                reportDetails.value = newDataReportDetails;

                setTimeout(() => {
                    window.print();
                }, 500);
            }
        );

        const getNama = (gelaran, nama) => {
            return (
                (gelaran?.toLowerCase()?.includes("tiada") ? "" : gelaran) +
                " " +
                nama
            );
        };

        return {
            dataStaffProfile,
            errorStaffProfile,
            loading: loadingStaffProfile || loadingReportDetails,
            reportDetails,
            getNama,
        };
    },
    computed: {
        roles() {
            return this.dataStaffProfile?.roles?.length > 0
                ? this.dataStaffProfile?.roles
                : [];
        },
    },
};
</script>

<style scoped>
table thead th {
    background-color: lightgrey;
}
.report-print-title-container {
    display: flex;
    flex-direction: row;
}
.report-print-title-logo {
    margin-right: 50px;
}
.report-print-title-right-container {
    display: flex;
    flex-direction: column;
    justify-content: center;
}
.report-print-title {
    font-size: 2em;
    font-weight: bold;
}
</style>

<style>
@media print {
    /* Hide everything except the table */
    .nk-main .nk-sidebar,
    .nk-main .nk-footer,
    .nk-main .nk-header,
    .btn-print {
        display: none !important;
        width: 0px;
        visibility: hidden !important;
    }

    .nk-main .nk-content-body {
        display: block !important;
        position: relative;
    }

    table {
        display: table;
        width: 100%;
        border-collapse: collapse;
    }

    table th {
        background-color: grey;
        color: white;
    }

    table,
    th,
    td {
        border: 1px solid black;
        border-collapse: collapse;
        padding: 10px;
        text-align: left;
    }
}
</style>
