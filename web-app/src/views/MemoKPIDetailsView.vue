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
                    :errorStaffProfile="
                        errorStaffProfile || errorTheMOU || errorSaveComment
                    "
                />
                <LoadingComponent
                    :loading="
                        loadingStaffProfile ||
                        loadingTheMOU ||
                        loadingSaveComment
                    "
                />
                <div class="nk-content" v-if="errorStaffProfile">
                    <InfoNotLoggedInComponent />
                </div>
                <div
                    class="nk-content"
                    v-if="
                        !errorStaffProfile && !errorTheMOU && !errorSaveComment
                    "
                >
                    <div class="container">
                        <div class="nk-content-inner">
                            <div class="nk-content-body">
                                <div class="nk-block-head">
                                    <div class="nk-block-head">
                                        <div
                                            class="nk-block-head-between flex-wrap gap g-2 align-items-start"
                                        >
                                            <div class="nk-block-head-content">
                                                <h2>KPI Details</h2>
                                            </div>
                                            <!-- .nk-block-head-content -->
                                            <div
                                                class="nk-block-head-content"
                                            ></div>
                                            <!-- .nk-block-head-content -->
                                        </div>
                                        <!-- .nk-block-head-between -->
                                    </div>
                                    <!-- .nk-block-head -->
                                    <div class="nk-block-head-between gap g-2">
                                        <div
                                            class="gap-col memo-kpi-detail-breadcrumb-container"
                                        >
                                            <div>
                                                <h5>Memorandum No.</h5>
                                                <a
                                                    :href="`${publicPath}memo-detail?memo=${dataTheMOU?.noMemo}&tab=3`"
                                                    >MoU.3.4.2024.020000.001</a
                                                >
                                            </div>
                                            <div class="ms-4 me-4">
                                                <em
                                                    class="icon ni ni-chevrons-right"
                                                ></em>
                                            </div>
                                            <div>
                                                <h5>KPI</h5>
                                                <a
                                                    :href="`${publicPath}kpi-view?kpi=${dataTheMOU?.kpI_ID}`"
                                                    >(ID:
                                                    {{ dataTheMOU?.kpI_ID }})
                                                    {{ dataTheMOU?.kpi }} ({{
                                                        dataTheMOU?.kod
                                                    }})</a
                                                >
                                            </div>
                                        </div>
                                    </div>
                                    <!-- .nk-block-head-between -->
                                </div>
                                <!-- .nk-block-head -->
                                <div class="nk-block">
                                    <div class="tab-content" id="myTabContent">
                                        <div
                                            class="tab-pane show active"
                                            id="tab-1"
                                            tabindex="0"
                                        >
                                            <div class="card card-gutter-md">
                                                <div
                                                    class="card-row card-row-lg col-sep col-sep-lg"
                                                >
                                                    <div class="card-aside">
                                                        <div class="card-body">
                                                            <div
                                                                class="bio-block"
                                                            >
                                                                <h4
                                                                    class="bio-block-title"
                                                                >
                                                                    Memorandum
                                                                </h4>
                                                                <ul
                                                                    class="list-group list-group-borderless small"
                                                                >
                                                                    <li
                                                                        class="list-group-item"
                                                                    >
                                                                        <span
                                                                            class="title fw-medium w-100 d-inline-block"
                                                                            >Status:</span
                                                                        >
                                                                        <span
                                                                            :class="`badge text-bg-${color(
                                                                                dataTheMOU
                                                                                    ?.status
                                                                                    ?.kod
                                                                            )}`"
                                                                            >{{
                                                                                dataTheMOU
                                                                                    ?.status
                                                                                    ?.status
                                                                            }}</span
                                                                        >
                                                                    </li>
                                                                    <li
                                                                        class="list-group-item"
                                                                    >
                                                                        <span
                                                                            class="title fw-medium w-100 d-inline-block"
                                                                            >Memorandum
                                                                            No.:</span
                                                                        >
                                                                        <h4
                                                                            class="text"
                                                                        >
                                                                            {{
                                                                                dataTheMOU?.noMemo
                                                                            }}
                                                                        </h4>
                                                                    </li>
                                                                    <li
                                                                        class="list-group-item"
                                                                    >
                                                                        <span
                                                                            class="title fw-medium w-100 d-inline-block"
                                                                            >Category
                                                                            of
                                                                            Memorandum:</span
                                                                        >
                                                                        <span
                                                                            class="text"
                                                                            >{{
                                                                                dataTheMOU?.kategori
                                                                            }}</span
                                                                        >
                                                                    </li>
                                                                    <li
                                                                        class="list-group-item"
                                                                    >
                                                                        <span
                                                                            class="title fw-medium w-100 d-inline-block"
                                                                            >Type
                                                                            of
                                                                            Memorandum:</span
                                                                        >
                                                                        <span
                                                                            class="text"
                                                                            >{{
                                                                                dataTheMOU?.jenis
                                                                            }}</span
                                                                        >
                                                                    </li>
                                                                    <li
                                                                        class="list-group-item"
                                                                    >
                                                                        <span
                                                                            class="title fw-medium w-100 d-inline-block"
                                                                            >Memorandum
                                                                            Scope:</span
                                                                        >
                                                                        <span
                                                                            class="text"
                                                                            >{{
                                                                                dataTheMOU?.scopeButiran
                                                                            }}</span
                                                                        >
                                                                    </li>
                                                                    <li
                                                                        class="list-group-item"
                                                                    >
                                                                        <span
                                                                            class="title fw-medium w-100 d-inline-block"
                                                                            >PIC:</span
                                                                        >
                                                                        <a
                                                                            :href="`${publicPath}user-view?s=${dataTheMOU?.noStafPIC}`"
                                                                            class="btn-link"
                                                                            >{{
                                                                                getNama(
                                                                                    dataTheMOU?.picGelaran,
                                                                                    dataTheMOU?.pic
                                                                                )
                                                                            }}</a
                                                                        >
                                                                    </li>
                                                                    <li
                                                                        class="list-group-item"
                                                                    >
                                                                        <span
                                                                            class="title fw-medium w-40 d-inline-block"
                                                                            >Start
                                                                            Date:</span
                                                                        >
                                                                        <span
                                                                            class="text"
                                                                            >{{
                                                                                dataTheMOU?.mouTarikhMulaDate
                                                                            }}</span
                                                                        >
                                                                    </li>
                                                                    <li
                                                                        class="list-group-item"
                                                                    >
                                                                        <span
                                                                            class="title fw-medium w-40 d-inline-block"
                                                                            >End
                                                                            Date:</span
                                                                        >
                                                                        <span
                                                                            class="text"
                                                                            >{{
                                                                                dataTheMOU?.mouTarikhTamatDate
                                                                            }}</span
                                                                        >
                                                                    </li>
                                                                    <li
                                                                        class="list-group-item"
                                                                    >
                                                                        <span
                                                                            class="title fw-medium w-40 d-inline-block"
                                                                            >Price
                                                                            (RM):</span
                                                                        >
                                                                        <span
                                                                            class="text"
                                                                            >{{
                                                                                dataTheMOU?.nilai?.toFixed(
                                                                                    2
                                                                                )
                                                                            }}</span
                                                                        >
                                                                    </li>
                                                                    <li
                                                                        class="list-group-item"
                                                                    >
                                                                        <span
                                                                            class="title fw-medium w-100 d-inline-block"
                                                                            >PTJ:</span
                                                                        >
                                                                        <span
                                                                            class="text"
                                                                            >{{
                                                                                dataTheMOU?.ptjNama
                                                                            }}</span
                                                                        >
                                                                    </li>
                                                                    <li
                                                                        class="list-group-item"
                                                                    >
                                                                        <span
                                                                            class="title fw-medium w-100 d-inline-block"
                                                                            >PBU:</span
                                                                        >
                                                                        <span
                                                                            class="text"
                                                                            >{{
                                                                                dataTheMOU?.subPTJNama
                                                                            }}</span
                                                                        >
                                                                    </li>
                                                                    <li
                                                                        class="list-group-item"
                                                                        v-if="
                                                                            dataTheMOU?.path
                                                                        "
                                                                    >
                                                                        <span
                                                                            class="title fw-medium w-100 d-inline-block"
                                                                            >Document:</span
                                                                        >
                                                                        <a
                                                                            :href="`${publicPath}${dataTheMOU?.path}`"
                                                                            target="_blank"
                                                                            >{{
                                                                                dataTheMOU?.namaDok
                                                                            }}</a
                                                                        >
                                                                        <div
                                                                            class="d-block mt-1"
                                                                        >
                                                                            <a
                                                                                :href="`${publicPath}${dataTheMOU?.path}`"
                                                                                target="_blank"
                                                                                class="btn btn-md btn-info"
                                                                                ><em
                                                                                    class="icon ni ni-download"
                                                                                ></em
                                                                                ><span
                                                                                    >Download</span
                                                                                ></a
                                                                            >
                                                                        </div>
                                                                    </li>
                                                                </ul>
                                                            </div>
                                                            <!-- .bio-block -->
                                                        </div>
                                                        <!-- .card-body -->
                                                    </div>
                                                    <div
                                                        class="card-content col-sep w-100"
                                                    >
                                                        <div class="card-body">
                                                            <div
                                                                class="bio-block"
                                                            >
                                                                <h4
                                                                    class="bio-block-title"
                                                                >
                                                                    KPI
                                                                </h4>
                                                                <h5>
                                                                    (ID:
                                                                    {{
                                                                        dataTheMOU?.kpI_ID
                                                                    }})
                                                                    {{
                                                                        dataTheMOU?.kpi
                                                                    }}
                                                                    ({{
                                                                        dataTheMOU?.kod
                                                                    }})
                                                                </h5>
                                                                <p>
                                                                    {{
                                                                        dataTheMOU?.penerangan ||
                                                                        "-"
                                                                    }}
                                                                </p>
                                                            </div>
                                                            <!-- .bio-block -->
                                                        </div>
                                                        <!-- .card-body -->
                                                        <div
                                                            class="card-body memo-kpi-detail-history-container"
                                                        >
                                                            <div
                                                                class="bio-block"
                                                            >
                                                                <h4
                                                                    class="bio-block-title"
                                                                >
                                                                    KPI Progress
                                                                </h4>
                                                                <ul
                                                                    class="nk-schedule mt-4"
                                                                >
                                                                    <li
                                                                        class="nk-schedule-item"
                                                                    >
                                                                        <div
                                                                            class="nk-schedule-item-inner"
                                                                        >
                                                                            <div
                                                                                class="nk-schedule-symbol"
                                                                            ></div>
                                                                            <div
                                                                                class="nk-schedule-content flex-grow-1"
                                                                            >
                                                                                <span
                                                                                    class="smaller"
                                                                                >
                                                                                    25
                                                                                    Oct.
                                                                                    2024
                                                                                </span>
                                                                                <div
                                                                                    role="alert"
                                                                                >
                                                                                    <p>
                                                                                        description
                                                                                    </p>
                                                                                </div>
                                                                                <a
                                                                                    class="smaller"
                                                                                    >by
                                                                                    Umar
                                                                                </a>
                                                                            </div>
                                                                        </div>
                                                                    </li>
                                                                </ul>
                                                            </div>
                                                            <!-- .bio-block -->
                                                        </div>
                                                    </div>
                                                    <!-- .card-content -->
                                                </div>
                                                <!-- .card-row -->
                                            </div>
                                            <!-- .card -->
                                        </div>
                                    </div>
                                    <!-- .tab-content -->
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
// import { useToast } from "vue-toast-notification";
import "vue-toast-notification/dist/theme-sugar.css";

import ValidateMeComponent from "@/components/ValidateMe.vue";
import NavbarComponent from "@/components/Navbar.vue";
import TopNavComponent from "@/components/TopNav.vue";
import FooterComponent from "@/components/Footer.vue";
import LoadingComponent from "@/components/Loading.vue";
import InfoNotLoggedInComponent from "@/components/InfoNotLoggedIn.vue";
import { useStaffProfile, useGetOneMOUKPI } from "@/hooks/useAPI";

export default {
    name: "MemoKPIDetailsView",
    components: {
        ValidateMeComponent,
        NavbarComponent,
        TopNavComponent,
        FooterComponent,
        LoadingComponent,
        InfoNotLoggedInComponent,
    },
    setup() {
        // const $toast = useToast();
        const publicPath = ref(process.env.VUE_APP_PUBLIC_PATH);

        const {
            data: dataStaffProfile,
            error: errorStaffProfile,
            loading: loadingStaffProfile,
        } = useStaffProfile();

        const params = new URLSearchParams(window.location.search);
        const kpiId = params.get("kpi") || "";

        const isAdmin = ref(false);
        const isPUU = ref(false);
        const isPTJ = ref(false);
        const isPIC = ref(false);
        const isMember = ref(false);
        const loadingTheMOU = ref(true);
        const dataTheMOU = ref(null);
        const errorTheMOU = ref(null);
        const loadingSaveComment = ref(false);
        const errorSaveComment = ref(null);

        const membersCols = ref(["Name", "Roles", "Status"]);
        const members = ref([]);
        const membersTitle = ref("");

        const kpisCols = ref([
            "KPI",
            "Description",
            // "Notes",
            "Amount (RM)",
            "Date From",
            "Date To",
        ]);
        const kpis = ref([]);
        const kpisTitle = ref("");

        const getNama = (gelaran, nama) => {
            return (
                (gelaran?.toLowerCase()?.includes("tiada") ? "" : gelaran) +
                " " +
                nama
            );
        };

        watch(
            () => dataStaffProfile.value,
            (newDataStaffProfile) => {
                if (
                    newDataStaffProfile &&
                    newDataStaffProfile?.roles?.length > 0
                ) {
                    isAdmin.value = newDataStaffProfile?.roles?.find(
                        (r) => r.role === "Admin"
                    )
                        ? true
                        : false;
                    isPUU.value = newDataStaffProfile?.roles?.find(
                        (r) => r.role === "PUU"
                    )
                        ? true
                        : false;
                    isPTJ.value = newDataStaffProfile?.roles?.find(
                        (r) => r.role === "PTJ"
                    )
                        ? true
                        : false;

                    const {
                        data: dataMOU,
                        loading: loadingMOU,
                        error: errorMOU,
                    } = useGetOneMOUKPI(kpiId);

                    watch(
                        () => loadingMOU.value,
                        (newLoadingMOU) => {
                            loadingTheMOU.value = newLoadingMOU;
                        }
                    );
                    watch(
                        () => dataMOU.value,
                        (newDataMOU) => {
                            dataTheMOU.value = newDataMOU;
                            isPIC.value = newDataMOU?.isPIC;
                        }
                    );
                    watch(
                        () => errorMOU.value,
                        (newErrorMOU) => {
                            if (newErrorMOU) {
                                location.href = `${publicPath.value}memo-list`;
                            }
                        }
                    );
                }
            },
            { immediate: true } // Run the watcher immediately on component mount
        );

        const color = (kod) => {
            if (kod === "01") return "dark";
            if (kod === "02") return "info";
            if (kod === "03") return "success";
            if (kod === "04") return "warning";
            if (kod === "05") return "danger";
            return "dark";
        };

        return {
            publicPath,
            dataStaffProfile,
            errorStaffProfile,
            loadingStaffProfile,
            isAdmin,
            isPUU,
            isPTJ,
            isPIC,
            isMember,
            loadingTheMOU,
            dataTheMOU,
            errorTheMOU,
            membersCols,
            members,
            membersTitle,
            kpisCols,
            kpis,
            kpisTitle,
            getNama,
            loadingSaveComment,
            errorSaveComment,
            color,
        };
    },
};
</script>

<style scoped>
.memo-kpi-detail-history-container {
    max-height: 500px;
    overflow-x: auto;
}
.memo-kpi-detail-breadcrumb-container {
    display: flex;
    flex-direction: row;
    align-items: center;
}
</style>
