<template>
    <div class="nk-app-root">
        <div class="nk-main">
            <NavbarComponent
                :staffprofile="dataStaffProfile"
                :activeLabel="`report`"
            />
            <div class="nk-wrap">
                <TopNavComponent
                    :staffprofile="dataStaffProfile"
                    :errorStaffProfile="errorStaffProfile"
                />
                <LoadingComponent :loading="loading" />
                <div
                    class="nk-content"
                    v-if="errorStaffProfile || errorMouSelectData"
                >
                    <InfoNotLoggedInComponent />
                </div>
                <div
                    class="nk-content"
                    v-if="!errorStaffProfile && !errorMouSelectData"
                >
                    <div class="container-fluid">
                        <div class="nk-content-inner">
                            <div class="nk-content-body">
                                <div class="row g-gs">
                                    <div class="col-md-8">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div
                                                    class="alert alert-info mb-2"
                                                    v-if="isFiltered()"
                                                >
                                                    The list is filtered.
                                                </div>
                                                <button
                                                    class="btn btn-success"
                                                    @click="toggleFilter"
                                                >
                                                    <em
                                                        class="icon ni ni-filter"
                                                    ></em
                                                    >&nbsp; Filter
                                                </button>
                                            </div>
                                        </div>
                                        <div class="row mt-3" v-if="isFilter">
                                            <div class="col-md-12">
                                                <h3>Filter By:</h3>
                                            </div>
                                            <div class="col-md-6">
                                                <multiselect
                                                    :allow-empty="false"
                                                    v-model="Country"
                                                    :options="countries"
                                                    placeholder="Select a Country"
                                                    label="name"
                                                    track-by="name"
                                                ></multiselect>
                                            </div>
                                            <div class="col-md-6">
                                                <multiselect
                                                    :allow-empty="false"
                                                    v-model="KodInd"
                                                    :options="
                                                        industryCategories
                                                    "
                                                    placeholder="Select a Industry Category"
                                                    label="industryCategory"
                                                    track-by="industryCategory"
                                                ></multiselect>
                                            </div>
                                        </div>
                                        <div class="row mt-1" v-if="isFilter">
                                            <div class="col-md-6">
                                                <multiselect
                                                    :allow-empty="false"
                                                    v-model="KodPTJ"
                                                    :options="PTJs"
                                                    placeholder="Select a PTJ"
                                                    label="namaPBU"
                                                    track-by="namaPBU"
                                                ></multiselect>
                                            </div>
                                            <div class="col-md-6">
                                                <multiselect
                                                    :allow-empty="false"
                                                    v-model="KodKategori"
                                                    :options="categories"
                                                    placeholder="Select a Category"
                                                    label="butiran"
                                                    track-by="butiran"
                                                ></multiselect>
                                            </div>
                                        </div>
                                        <div class="row mt-1" v-if="isFilter">
                                            <div class="col-md-6">
                                                <multiselect
                                                    :allow-empty="false"
                                                    v-model="KodJenis"
                                                    :options="types"
                                                    placeholder="Select a Type"
                                                    label="butiran"
                                                    track-by="butiran"
                                                ></multiselect>
                                            </div>
                                        </div>
                                        <div class="row mt-3" v-if="isFilter">
                                            <div class="col-md-6">
                                                <button
                                                    class="btn btn-primary"
                                                    @click="onSearch"
                                                >
                                                    <em
                                                        class="icon ni ni-search"
                                                    ></em
                                                    >&nbsp; Search
                                                </button>
                                                &nbsp;
                                                <button
                                                    class="btn btn-secondary"
                                                    @click="onClearSearch"
                                                >
                                                    <em
                                                        class="icon ni ni-cross"
                                                    ></em
                                                    >&nbsp; Clear
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="offset-1 col-md-3">
                                        <button
                                            class="btn-print btn btn-primary me-3"
                                            @click="onPrint"
                                        >
                                            <em class="icon ni ni-printer"></em>
                                            &nbsp;PRINT
                                        </button>
                                        <button
                                            class="btn-print btn btn-secondary"
                                            disabled="true"
                                        >
                                            <em
                                                class="icon ni ni-download"
                                            ></em>
                                            &nbsp;EXPORT
                                        </button>
                                    </div>
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
                                                <div class="mt-4">
                                                    <h2>MEMORANDUM REPORTS</h2>
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
                                            <tbody v-else>
                                                <tr>
                                                    <td
                                                        colspan="11"
                                                        v-if="
                                                            reportDetailsLoading
                                                        "
                                                    >
                                                        Loading ...
                                                    </td>
                                                    <td colspan="11" v-else>
                                                        - No Data -
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
                <FooterComponent />
            </div>
        </div>
    </div>
</template>

<!-- JavaScript -->
<script>
import { ref, watch } from "vue";
import Multiselect from "vue-multiselect";
import "vue-multiselect/dist/vue-multiselect.min.css";

import NavbarComponent from "@/components/Navbar.vue";
import TopNavComponent from "@/components/TopNav.vue";
import FooterComponent from "@/components/Footer.vue";
import LoadingComponent from "@/components/Loading.vue";
import InfoNotLoggedInComponent from "@/components/InfoNotLoggedIn.vue";
import {
    useStaffProfile,
    useReportDetails,
    useGetMOUSelectData,
} from "@/hooks/useAPI";
import { getBearerToken } from "@/utils/tokenManagement";

export default {
    name: "ReportView",
    data() {
        return {
            userId: getBearerToken(),
        };
    },
    components: {
        LoadingComponent,
        NavbarComponent,
        TopNavComponent,
        FooterComponent,
        InfoNotLoggedInComponent,
        Multiselect,
    },
    setup() {
        const publicPath = ref(process.env.VUE_APP_PUBLIC_PATH);

        const {
            data: dataStaffProfile,
            error: errorStaffProfile,
            loading: loadingStaffProfile,
            refetch,
        } = useStaffProfile();

        const {
            data: dataMouSelectData,
            error: errorMouSelectData,
            loading: loadingMouSelectData,
        } = useGetMOUSelectData();

        const params = new URLSearchParams(window.location.search);

        const isFilter = ref(false);
        const Country = ref("");
        const KodInd = ref("");
        const KodPTJ = ref("");
        const KodKategori = ref("");
        const KodJenis = ref("");

        const reportDetails = ref([]);
        const reportDetailsLoading = ref(true);

        const countries = ref([]);
        const categories = ref([]);
        const types = ref([]);
        const scopes = ref([]);
        const PTJs = ref([]);
        const industryCategories = ref([]);
        const fields = ref([]);
        watch(
            () => dataMouSelectData.value,
            (dataMouSelectDataUpdated) => {
                countries.value = dataMouSelectDataUpdated?.countries || [];
                categories.value = dataMouSelectDataUpdated?.kategoriMemo || [];
                types.value = dataMouSelectDataUpdated?.jenisMemo || [];
                scopes.value = dataMouSelectDataUpdated?.scopeMemo || [];
                PTJs.value = dataMouSelectDataUpdated?.ptj || [];
                industryCategories.value =
                    dataMouSelectDataUpdated?.industryCategories || [];
                fields.value = dataMouSelectDataUpdated?.fields || [];

                if (params.get("country")) {
                    Country.value = countries.value.find(
                        (_) => _.code == params.get("country")
                    );
                }
                if (params.get("industry")) {
                    KodInd.value = industryCategories.value.find(
                        (_) => _.kodInd == params.get("industry")
                    );
                }
                if (params.get("ptj")) {
                    KodPTJ.value = PTJs.value.find(
                        (_) => _.kodPBU == params.get("ptj")
                    );
                }
                if (params.get("category")) {
                    KodKategori.value = categories.value.find(
                        (_) => _.kod == params.get("category")
                    );
                }
                if (params.get("type")) {
                    KodJenis.value = types.value.find(
                        (_) => _.kod == params.get("type")
                    );
                }

                const {
                    data: dataReportDetails,
                    loading: loadingReportDetails,
                } = useReportDetails(
                    Country.value?.code || "",
                    KodInd.value?.kodInd || "",
                    KodPTJ.value?.kodPBU || "",
                    KodKategori.value?.kod || "",
                    KodJenis.value?.kod || ""
                );
                watch(
                    () => loadingReportDetails.value,
                    (newLoadingReportDetails) => {
                        reportDetailsLoading.value = newLoadingReportDetails;
                    }
                );
                watch(
                    () => dataReportDetails.value,
                    (newDataReportDetails) => {
                        reportDetails.value = newDataReportDetails;
                    }
                );
            }
        );

        const goToSearch = () => {
            location.href = `${publicPath.value}report?country=${
                Country.value?.code || ""
            }&industry=${KodInd.value?.kodInd || ""}&ptj=${
                KodPTJ.value?.kodPBU || ""
            }&category=${KodKategori.value?.kod || ""}&type=${
                KodJenis.value?.kod || ""
            }`;
        };

        const onSearch = () => {
            if (!isFilter.value) return;
            goToSearch();
        };

        const onClearSearch = () => {
            Country.value = null;
            KodInd.value = null;
            KodPTJ.value = null;
            KodKategori.value = null;
            KodJenis.value = null;
            goToSearch();
        };

        const getNama = (gelaran, nama) => {
            return (
                (gelaran?.toLowerCase()?.includes("tiada") ? "" : gelaran) +
                " " +
                nama
            );
        };

        const toggleFilter = () => {
            isFilter.value = !isFilter.value;
        };

        const onPrint = () => {
            const countryInner = Country.value?.code || "";
            const industryInner = KodInd.value?.kodInd || "";
            const ptjInner = KodPTJ.value?.kodPBU || "";
            const categoryInner = KodKategori.value?.kod || "";
            const typeInner = KodJenis.value?.kod || "";
            location.href = `${publicPath.value}report-print?country=${countryInner}&industry=${industryInner}&ptj=${ptjInner}&category=${categoryInner}&type=${typeInner}`;
        };

        const isFiltered = () => {
            if (
                Country.value?.code ||
                KodInd.value?.kodInd ||
                KodPTJ.value?.kodPBU ||
                KodKategori.value?.kod ||
                KodJenis.value?.kod
            ) {
                return true;
            }
            return false;
        };

        return {
            publicPath,
            dataStaffProfile,
            errorStaffProfile,
            loading:
                loadingStaffProfile ||
                reportDetailsLoading ||
                loadingMouSelectData,
            reportDetailsLoading,
            refetch,
            reportDetails,
            getNama,
            dataMouSelectData,
            errorMouSelectData,
            isFilter,
            toggleFilter,
            countries,
            industryCategories,
            categories,
            PTJs,
            types,
            Country,
            KodInd,
            KodPTJ,
            KodKategori,
            KodJenis,
            isFiltered,
            onSearch,
            onClearSearch,
            onPrint,
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
