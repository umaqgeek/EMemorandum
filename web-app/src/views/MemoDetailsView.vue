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
                    :errorStaffProfile="errorStaffProfile || errorTheMOU"
                />
                <LoadingComponent
                    :loading="loadingStaffProfile || loadingTheMOU"
                />
                <div class="nk-content" v-if="errorStaffProfile">
                    <InfoNotLoggedInComponent />
                </div>
                <div
                    class="nk-content"
                    v-if="!errorStaffProfile && !errorTheMOU"
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
                                                <h2>Memorandum Details</h2>
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
                                        <div class="gap-col">
                                            <ul
                                                class="nav nav-pills nav-pills-border gap g-3"
                                            >
                                                <li class="nav-item">
                                                    <button
                                                        class="nav-link active"
                                                        data-bs-toggle="tab"
                                                        data-bs-target="#tab-1"
                                                        type="button"
                                                    >
                                                        Overview
                                                    </button>
                                                </li>
                                                <li class="nav-item">
                                                    <button
                                                        class="nav-link"
                                                        data-bs-toggle="tab"
                                                        data-bs-target="#tab-2"
                                                        type="button"
                                                    >
                                                        Members
                                                    </button>
                                                </li>
                                                <li class="nav-item">
                                                    <button
                                                        class="nav-link"
                                                        data-bs-toggle="tab"
                                                        data-bs-target="#tab-3"
                                                        type="button"
                                                    >
                                                        KPI
                                                    </button>
                                                </li>
                                            </ul>
                                        </div>
                                        <div class="gap-col">
                                            <ul class="d-flex gap g-2">
                                                <li class="d-none d-md-block">
                                                    <router-link
                                                        to="/memo-edit"
                                                        class="btn btn-soft btn-primary"
                                                    >
                                                        <em
                                                            class="icon ni ni-edit"
                                                        ></em
                                                        ><span
                                                            >Edit
                                                            Memorandum</span
                                                        >
                                                    </router-link>
                                                </li>
                                                <li class="d-md-none">
                                                    <a
                                                        href="./html/user-manage/user-edit.html"
                                                        class="btn btn-soft btn-primary btn-icon"
                                                        ><em
                                                            class="icon ni ni-edit"
                                                        ></em
                                                    ></a>
                                                </li>
                                            </ul>
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
                                                                    Details
                                                                </h4>
                                                                <ul
                                                                    class="list-group list-group-borderless small"
                                                                >
                                                                    <li
                                                                        class="list-group-item"
                                                                    >
                                                                        <span
                                                                            class="title fw-medium w-100 d-inline-block"
                                                                            >No.
                                                                            Memorandum:</span
                                                                        >
                                                                        <span
                                                                            class="text"
                                                                            >{{
                                                                                dataTheMOU?.noMemo
                                                                            }}
                                                                        </span>
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
                                                                        <span
                                                                            class="text"
                                                                            >{{
                                                                                getNama(
                                                                                    dataTheMOU?.picGelaran,
                                                                                    dataTheMOU?.pic
                                                                                )
                                                                            }}</span
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
                                                                                dataTheMOU?.tarikhMulaDate
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
                                                                                dataTheMOU?.tarikhTamatDate
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
                                                                            >Document:</span
                                                                        >
                                                                        <em
                                                                            class="icon ni ni-file-download icon-lg"
                                                                        ></em
                                                                        >&nbsp;
                                                                        <a
                                                                            :href="`${publicPath}${dataTheMOU?.path}`"
                                                                            target="_blank"
                                                                            >{{
                                                                                dataTheMOU?.path
                                                                            }}</a
                                                                        >
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
                                                                    Project
                                                                    Title
                                                                </h4>
                                                                <p>
                                                                    {{
                                                                        dataTheMOU?.tajukProjek
                                                                    }}
                                                                </p>
                                                            </div>
                                                            <!-- .bio-block -->
                                                        </div>
                                                        <!-- .card-body -->
                                                        <div class="card-body">
                                                            <div
                                                                class="bio-block"
                                                            >
                                                                <h4
                                                                    class="bio-block-title"
                                                                >
                                                                    Recent
                                                                    Activities
                                                                    &amp;
                                                                    History
                                                                </h4>
                                                                <ul
                                                                    class="nk-schedule mt-4"
                                                                >
                                                                    <li
                                                                        class="nk-schedule-item"
                                                                        v-for="(
                                                                            hist,
                                                                            hIndex
                                                                        ) in dataTheMOU?.history"
                                                                        v-bind:key="
                                                                            hIndex +
                                                                            hist?.Created_At
                                                                        "
                                                                    >
                                                                        <div
                                                                            class="nk-schedule-item-inner"
                                                                        >
                                                                            <div
                                                                                :class="[
                                                                                    'nk-schedule-symbol',
                                                                                    {
                                                                                        active:
                                                                                            hIndex ===
                                                                                            0,
                                                                                    },
                                                                                ]"
                                                                            ></div>
                                                                            <div
                                                                                :class="[
                                                                                    'nk-schedule-content',
                                                                                    {
                                                                                        'nk-schedule-content-no-border flex-grow-1':
                                                                                            hIndex ===
                                                                                            0,
                                                                                    },
                                                                                ]"
                                                                            >
                                                                                <span
                                                                                    class="smaller"
                                                                                    >{{
                                                                                        hist.created_At
                                                                                    }}</span
                                                                                >
                                                                                <div
                                                                                    :class="[
                                                                                        {
                                                                                            'alert alert-info ':
                                                                                                hIndex ===
                                                                                                0,
                                                                                        },
                                                                                    ]"
                                                                                    role="alert"
                                                                                >
                                                                                    {{
                                                                                        hist.description
                                                                                    }}
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </li>
                                                                </ul>
                                                            </div>
                                                            <!-- .bio-block -->
                                                        </div>
                                                        <!-- .card-body -->
                                                    </div>
                                                    <!-- .card-content -->
                                                </div>
                                                <!-- .card-row -->
                                            </div>
                                            <!-- .card -->
                                        </div>
                                        <!-- .tab-pane -->
                                        <div
                                            class="tab-pane"
                                            id="tab-2"
                                            tabindex="1"
                                        >
                                            <div class="card card-gutter-md">
                                                <div
                                                    class="card-row card-row-lg col-sep col-sep-lg"
                                                >
                                                    tab 2
                                                </div>
                                            </div>
                                        </div>
                                        <div
                                            class="tab-pane"
                                            id="tab-3"
                                            tabindex="2"
                                        >
                                            <div class="card card-gutter-md">
                                                <div
                                                    class="card-row card-row-lg col-sep col-sep-lg"
                                                >
                                                    tab 3
                                                </div>
                                            </div>
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

import ValidateMeComponent from "@/components/ValidateMe.vue";
import NavbarComponent from "@/components/Navbar.vue";
import TopNavComponent from "@/components/TopNav.vue";
import FooterComponent from "@/components/Footer.vue";
import LoadingComponent from "@/components/Loading.vue";
import InfoNotLoggedInComponent from "@/components/InfoNotLoggedIn.vue";
import { useStaffProfile, useGetOneMOU } from "@/hooks/useAPI";
// import TableLite from "@/components/TableLite.vue";

export default {
    name: "MemoDetailsView",
    components: {
        ValidateMeComponent,
        NavbarComponent,
        TopNavComponent,
        FooterComponent,
        LoadingComponent,
        InfoNotLoggedInComponent,
        // TableLite,
    },
    setup() {
        const publicPath = ref(process.env.VUE_APP_PUBLIC_PATH);

        const {
            data: dataStaffProfile,
            error: errorStaffProfile,
            loading: loadingStaffProfile,
        } = useStaffProfile();

        const params = new URLSearchParams(window.location.search);
        const noMemo = params.get("memo") || "";

        const isAdmin = ref(false);
        const isPUU = ref(false);
        const loadingTheMOU = ref(true);
        const dataTheMOU = ref(null);
        const errorTheMOU = ref(null);

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

                    const {
                        data: dataMOU,
                        loading: loadingMOU,
                        error: errorMOU,
                    } = useGetOneMOU(noMemo);

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

        return {
            publicPath,
            dataStaffProfile,
            errorStaffProfile,
            loadingStaffProfile,
            isAdmin,
            isPUU,
            loadingTheMOU,
            dataTheMOU,
            errorTheMOU,
        };
    },
    methods: {
        getNama(gelaran, nama) {
            return (
                (gelaran?.toLowerCase()?.includes("tiada") ? "" : gelaran) +
                " " +
                nama
            );
        },
    },
};
</script>
