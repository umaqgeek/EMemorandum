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
                                                <h2>Memorandum KPI Details</h2>
                                            </div>
                                            <!-- .nk-block-head-content -->
                                            <div
                                                class="nk-block-head-content"
                                            ></div>
                                            <!-- .nk-block-head-content -->
                                        </div>
                                        <!-- .nk-block-head-between -->
                                    </div>
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
import { ref } from "vue";
import "vue-toast-notification/dist/theme-sugar.css";

import ValidateMeComponent from "@/components/ValidateMe.vue";
import NavbarComponent from "@/components/Navbar.vue";
import TopNavComponent from "@/components/TopNav.vue";
import FooterComponent from "@/components/Footer.vue";
import LoadingComponent from "@/components/Loading.vue";
import InfoNotLoggedInComponent from "@/components/InfoNotLoggedIn.vue";
import { useStaffProfile } from "@/hooks/useAPI";

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
        const publicPath = ref(process.env.VUE_APP_PUBLIC_PATH);

        const {
            data: dataStaffProfile,
            error: errorStaffProfile,
            loading: loadingStaffProfile,
        } = useStaffProfile();

        const params = new URLSearchParams(window.location.search);
        const kpi_id = params.get("kpi") || "";

        return {
            publicPath,
            dataStaffProfile,
            errorStaffProfile,
            loadingStaffProfile,
            kpi_id,
        };
    },
};
</script>

<style scoped>
.memo-kpi-detail-history-container {
    max-height: 500px;
    overflow-x: auto;
}
</style>
