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
                                    <div class="col-xxl-12">
                                        <div>
                                            <img
                                                class="mb-3"
                                                src="assets/images/LogoJawiUTeM_blue-02.png"
                                                width="300px"
                                            />
                                        </div>
                                        <button
                                            class="btn-print btn btn-success mb-3"
                                            @click="onPrint"
                                        >
                                            PRINT
                                        </button>
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
                                            <tbody>
                                                <tr>
                                                    <td>1.</td>
                                                    <td>MALAYSIA</td>
                                                    <td>INDUSTRY COMPUTER</td>
                                                    <td>FTKM</td>
                                                    <td>
                                                        PROFESSOR MADYA DR. LIEW
                                                        PAY JUN
                                                    </td>
                                                    <td>MoU</td>
                                                    <td>Kerahsian</td>
                                                    <td>31/12/2024</td>
                                                    <td>31/12/2025</td>
                                                    <td>1 YEAR</td>
                                                    <td>ACTIVE</td>
                                                </tr>
                                                <tr>
                                                    <td>2.</td>
                                                    <td>MALAYSIA</td>
                                                    <td>INDUSTRY AUTOMOTIF</td>
                                                    <td>FKP</td>
                                                    <td>
                                                        TS. DR. MAIZATUL ALICE
                                                        BINTI MEOR SAID
                                                    </td>
                                                    <td>MoA(TP)</td>
                                                    <td>Akademik</td>
                                                    <td>10/12/2024</td>
                                                    <td>5/5/2025</td>
                                                    <td>6 MONTHS</td>
                                                    <td>ACTIVE</td>
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
// import { watch } from "vue";

import NavbarComponent from "@/components/Navbar.vue";
import TopNavComponent from "@/components/TopNav.vue";
import FooterComponent from "@/components/Footer.vue";
import LoadingComponent from "@/components/Loading.vue";
import InfoNotLoggedInComponent from "@/components/InfoNotLoggedIn.vue";
import { useStaffProfile } from "@/hooks/useAPI";

export default {
    name: "ReportView",
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
    },
    setup() {
        const {
            data: dataStaffProfile,
            error: errorStaffProfile,
            loading: loadingStaffProfile,
            refetch,
        } = useStaffProfile();
        return {
            dataStaffProfile,
            errorStaffProfile,
            loading: loadingStaffProfile,
            refetch,
        };
    },
    computed: {
        roles() {
            return this.dataStaffProfile?.roles?.length > 0
                ? this.dataStaffProfile?.roles
                : [];
        },
    },
    methods: {
        onPrint() {
            window.print();
        },
    },
};
</script>

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
