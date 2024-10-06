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
                <LoadingComponent :loading="loadingStaffProfile" />
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
                                        <table
                                            :data="data"
                                            class="datatable-init table"
                                            data-nk-container="table-responsive"
                                        >
                                            <thead class="table-light">
                                                <tr>
                                                    <th class="tb-col">
                                                        <span
                                                            class="overline-title"
                                                            >No.</span
                                                        >
                                                    </th>
                                                    <th class="tb-col">
                                                        <span
                                                            class="overline-title"
                                                            >No.
                                                            Memorandum</span
                                                        >
                                                    </th>
                                                    <th class="tb-col">
                                                        <span
                                                            class="overline-title"
                                                            >Skop
                                                            Memorandum</span
                                                        >
                                                    </th>
                                                    <th
                                                        class="tb-col tb-col-xl"
                                                    >
                                                        <span
                                                            class="overline-title"
                                                            >Staff Name</span
                                                        >
                                                    </th>
                                                    <th
                                                        class="tb-col tb-col-xxl"
                                                    >
                                                        <span
                                                            class="overline-title"
                                                            >Start Date</span
                                                        >
                                                    </th>
                                                    <th class="tb-col">
                                                        <span
                                                            class="overline-title"
                                                            >End Date</span
                                                        >
                                                    </th>
                                                    <th class="tb-col">
                                                        <span
                                                            class="overline-title"
                                                            >Price (RM)</span
                                                        >
                                                    </th>
                                                    <th class="tb-col">
                                                        <span
                                                            class="overline-title"
                                                            >Status</span
                                                        >
                                                    </th>
                                                    <th
                                                        class="tb-col tb-col-end"
                                                        data-sortable="false"
                                                    >
                                                        <span
                                                            class="overline-title"
                                                            >Action</span
                                                        >
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr
                                                    v-for="(
                                                        mou, mouIndex
                                                    ) in mouData?.value"
                                                    v-bind:key="mouIndex"
                                                >
                                                    <td class="tb-col">
                                                        {{ mouIndex + 1 }}.
                                                    </td>
                                                    <td class="tb-col">
                                                        {{ mou?.noMemo }}
                                                    </td>
                                                    <td class="tb-col">
                                                        {{ mou?.scopeButiran }}
                                                    </td>
                                                    <td class="tb-col">
                                                        <div
                                                            class="media-group"
                                                        >
                                                            <div
                                                                class="media-text"
                                                            >
                                                                <a
                                                                    href="#"
                                                                    class="title"
                                                                    >{{
                                                                        mou?.pic
                                                                    }}</a
                                                                >
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td
                                                        class="tb-col tb-col-xxl"
                                                    >
                                                        {{
                                                            mou?.tarikhMulaDate
                                                        }}
                                                    </td>
                                                    <td
                                                        class="tb-col tb-col-xxl"
                                                    >
                                                        {{
                                                            mou?.tarikhTamatDate
                                                        }}
                                                    </td>
                                                    <td
                                                        class="tb-col tb-col-xxl"
                                                    >
                                                        {{
                                                            mou?.nilai?.toFixed(
                                                                2
                                                            )
                                                        }}
                                                    </td>
                                                    <td class="tb-col">
                                                        <ChipStatusComponent
                                                            :status="
                                                                mou?.status
                                                            "
                                                        />
                                                    </td>
                                                    <td
                                                        class="tb-col tb-col-end"
                                                    >
                                                        <div class="dropdown">
                                                            <a
                                                                href="#"
                                                                class="btn btn-sm btn-icon btn-zoom me-n1"
                                                                data-bs-toggle="dropdown"
                                                            >
                                                                <em
                                                                    class="icon ni ni-more-v"
                                                                ></em>
                                                            </a>
                                                            <div
                                                                class="dropdown-menu dropdown-menu-sm dropdown-menu-end"
                                                            >
                                                                <div
                                                                    class="dropdown-content py-1"
                                                                >
                                                                    <ul
                                                                        class="link-list link-list-hover-bg-primary link-list-md"
                                                                    >
                                                                        <li>
                                                                            <router-link
                                                                                to="/memo-edit"
                                                                            >
                                                                                <em
                                                                                    class="icon ni ni-edit"
                                                                                ></em
                                                                                ><span
                                                                                    >Edit</span
                                                                                >
                                                                            </router-link>
                                                                        </li>
                                                                        <li>
                                                                            <router-link
                                                                                to="/memo-detail"
                                                                                ><em
                                                                                    class="icon ni ni-eye"
                                                                                ></em
                                                                                ><span
                                                                                    >View
                                                                                    Details</span
                                                                                ></router-link
                                                                            >
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- dropdown -->
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
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
import ChipStatusComponent from "@/components/ChipStatus.vue";
import { useStaffProfile, useGetAllMOU, useGetMyMOU } from "@/hooks/useAPI";

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
        ChipStatusComponent,
    },
    setup() {
        const {
            data: dataStaffProfile,
            error: errorStaffProfile,
            loading: loadingStaffProfile,
        } = useStaffProfile();

        const mouData = ref(null);
        const mouError = ref(null);
        const mouLoading = ref(false);
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
                        const {
                            data: dataAllMOU,
                            error: errorAllMOU,
                            loading: loadingAllMOU,
                        } = useGetAllMOU();
                        mouData.value = dataAllMOU;
                        mouError.value = errorAllMOU;
                        mouLoading.value = loadingAllMOU;
                    } else {
                        const {
                            data: dataMyMOU,
                            error: errorMyMOU,
                            loading: loadingMyMOU,
                        } = useGetMyMOU();
                        mouData.value = dataMyMOU;
                        mouError.value = errorMyMOU;
                        mouLoading.value = loadingMyMOU;
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
        };
    },
    computed: {},
    methods: {},
};
</script>
