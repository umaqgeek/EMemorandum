<template>
    <div class="nk-app-root">
        <div class="nk-main">
            <NavbarComponent
                :staffprofile="dataStaffProfile"
                :activeLabel="`user-list`"
            />
            <div class="nk-wrap">
                <TopNavComponent
                    :staffprofile="dataStaffProfile"
                    :errorStaffProfile="errorStaffProfile"
                />
                <LoadingComponent
                    :loading="
                        loadingStaffProfile || loadingOneStaff || loadingUpdate
                    "
                />
                <div class="nk-content" v-if="errorStaffProfile">
                    <InfoNotLoggedInComponent />
                </div>
                <div class="nk-content" v-if="!errorStaffProfile">
                    <div class="container">
                        <div class="nk-content-inner">
                            <div class="nk-content-body">
                                <div class="nk-block-head">
                                    <div class="nk-block-head">
                                        <div
                                            class="nk-block-head-between flex-wrap gap g-2 align-items-center"
                                        >
                                            <div class="nk-block-head-content">
                                                <div
                                                    class="d-flex flex-column flex-md-row align-items-md-center"
                                                >
                                                    <div
                                                        class="mt-3 mt-md-0 ms-md-3"
                                                    >
                                                        <h3 class="title mb-1">
                                                            {{ getGelaran }}
                                                            {{
                                                                dataOneStaff?.nama
                                                            }}
                                                        </h3>
                                                    </div>
                                                </div>
                                            </div>
                                            <!-- .nk-block-head-content -->
                                            <div class="nk-block-head-content">
                                                <ul class="d-flex gap g-2">
                                                    <li
                                                        class="d-none d-md-block"
                                                    >
                                                        <!-- CTA button  -->
                                                    </li>
                                                </ul>
                                            </div>
                                            <!-- .nk-block-head-content -->
                                        </div>
                                        <!-- .nk-block-head-between -->
                                    </div>
                                    <!-- .nk-block-head -->
                                </div>
                                <!-- .nk-block-head -->
                                <div class="nk-block">
                                    <div class="card card-gutter-md">
                                        <div class="card-body">
                                            <div class="bio-block">
                                                <h4
                                                    class="bio-block-title mb-4"
                                                >
                                                    Staff Profile
                                                </h4>
                                                <form action="#">
                                                    <div class="row g-3">
                                                        <div class="col-lg-5">
                                                            <label
                                                                for="firstname"
                                                                class="form-label"
                                                                >Full
                                                                Name</label
                                                            >
                                                            <div>
                                                                {{ nama }}
                                                            </div>
                                                            <hr />
                                                            <label
                                                                for="firstname"
                                                                class="form-label"
                                                                >Position</label
                                                            >
                                                            <div>
                                                                {{ position }}
                                                            </div>
                                                            <hr />
                                                            <label
                                                                for="email"
                                                                class="form-label"
                                                                >Email
                                                                address</label
                                                            >
                                                            <div>
                                                                {{ email }}
                                                            </div>
                                                            <hr />
                                                            <label
                                                                for="company"
                                                                class="form-label"
                                                                >Office</label
                                                            >
                                                            <div>
                                                                {{ nPejabat }}
                                                            </div>
                                                        </div>
                                                        <div
                                                            class="col-lg-6 offset-1"
                                                        >
                                                            <label
                                                                for="email"
                                                                class="form-label"
                                                                >Status</label
                                                            >
                                                            <div
                                                                class="form-check form-switch"
                                                            >
                                                                <span
                                                                    class="badge text-bg-success-soft"
                                                                    v-if="
                                                                        isActive
                                                                    "
                                                                    >Active</span
                                                                >
                                                                <span
                                                                    class="badge text-bg-danger-soft"
                                                                    v-else
                                                                    >Inactive</span
                                                                >
                                                            </div>
                                                            <div
                                                                class="form-group"
                                                            >
                                                                <label
                                                                    class="form-label"
                                                                    >Roles</label
                                                                >
                                                                <div
                                                                    class="form-check"
                                                                >
                                                                    <em
                                                                        class="icon ni ni-check-round"
                                                                        v-if="
                                                                            isEachRoles.PUU
                                                                        "
                                                                    ></em>
                                                                    <em
                                                                        class="icon ni ni-na"
                                                                        v-else
                                                                    ></em>
                                                                    <label
                                                                        class="form-check-label"
                                                                        for="flexCheckPUU"
                                                                    >
                                                                        PUU
                                                                    </label>
                                                                </div>
                                                                <div
                                                                    class="form-check"
                                                                >
                                                                    <em
                                                                        class="icon ni ni-check-round"
                                                                        v-if="
                                                                            isEachRoles.US
                                                                        "
                                                                    ></em>
                                                                    <em
                                                                        class="icon ni ni-na"
                                                                        v-else
                                                                    ></em>
                                                                    <label
                                                                        class="form-check-label"
                                                                        for="flexCheckUS"
                                                                    >
                                                                        Urusetia
                                                                        /
                                                                        Secretariat
                                                                    </label>
                                                                </div>
                                                                <div
                                                                    class="form-check"
                                                                >
                                                                    <em
                                                                        class="icon ni ni-check-round"
                                                                        v-if="
                                                                            isEachRoles.PTJ
                                                                        "
                                                                    ></em>
                                                                    <em
                                                                        class="icon ni ni-na"
                                                                        v-else
                                                                    ></em>
                                                                    <label
                                                                        class="form-check-label"
                                                                        for="flexCheckPTJ"
                                                                    >
                                                                        Ketua
                                                                        PTJ
                                                                    </label>
                                                                </div>
                                                                <div
                                                                    class="form-check"
                                                                >
                                                                    <em
                                                                        class="icon ni ni-check-round"
                                                                        v-if="
                                                                            isEachRoles.Admin
                                                                        "
                                                                    ></em>
                                                                    <em
                                                                        class="icon ni ni-na"
                                                                        v-else
                                                                    ></em>
                                                                    <label
                                                                        class="form-check-label"
                                                                        for="flexCheckAdmin"
                                                                    >
                                                                        Administrator
                                                                    </label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div
                                                        class="alert alert-danger mt-4"
                                                        v-if="errorOneStaff"
                                                    >
                                                        {{ errorOneStaff }}
                                                    </div>
                                                </form>
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
        <ValidateMeComponent />
    </div>
</template>

<!-- JavaScript -->
<script>
import { ref, watch } from "vue";
import { useRoute } from "vue-router";

import ValidateMeComponent from "@/components/ValidateMe.vue";
import NavbarComponent from "@/components/Navbar.vue";
import TopNavComponent from "@/components/TopNav.vue";
import FooterComponent from "@/components/Footer.vue";
import LoadingComponent from "@/components/Loading.vue";
import InfoNotLoggedInComponent from "@/components/InfoNotLoggedIn.vue";
import { useStaffProfile, useGetOneStaffSimple } from "@/hooks/useAPI";

export default {
    name: "UserViewView",
    data() {
        return {
            loadingUpdate: false,
        };
    },
    components: {
        ValidateMeComponent,
        NavbarComponent,
        TopNavComponent,
        FooterComponent,
        LoadingComponent,
        InfoNotLoggedInComponent,
    },
    setup() {
        const {
            data: dataStaffProfile,
            error: errorStaffProfile,
            loading: loadingStaffProfile,
            refetch: refetchStaffProfile,
        } = useStaffProfile();

        const route = useRoute();
        const noStaf = route?.query?.s;
        const {
            data: dataOneStaff,
            error: errorOneStaff,
            loading: loadingOneStaff,
            refetch: refetchOneStaff,
        } = useGetOneStaffSimple(noStaf);
        const roles =
            dataOneStaff?.roles?.length > 0 ? dataOneStaff?.roles : [];

        const isActive = ref(false); // Define reactive state for the checkbox
        const isEachRoles = ref({
            Admin: false,
            PUU: false,
            PTJ: false,
            US: false,
        });
        watch(
            () => dataOneStaff.value, // Watch the `dataOneStaff` reactive property
            (dataOneStaffUpdated) => {
                if (
                    dataOneStaffUpdated &&
                    dataOneStaffUpdated?.roles?.length > 0
                ) {
                    isActive.value = dataOneStaffUpdated?.roles?.length > 0; // Set `isActive` based on API data
                    isEachRoles.value = {
                        Admin: dataOneStaffUpdated?.roles?.find(
                            (r) => r.code === "Admin"
                        )
                            ? true
                            : false,
                        PUU: dataOneStaffUpdated?.roles?.find(
                            (r) => r.code === "PUU"
                        )
                            ? true
                            : false,
                        PTJ: dataOneStaffUpdated?.roles?.find(
                            (r) => r.code === "PTJ"
                        )
                            ? true
                            : false,
                        US: dataOneStaffUpdated?.roles?.find(
                            (r) => r.code === "US"
                        )
                            ? true
                            : false,
                    };
                }
            }
        );

        return {
            dataStaffProfile,
            dataOneStaff,
            errorOneStaff,
            errorStaffProfile,
            loadingOneStaff,
            loadingStaffProfile,
            refetchStaffProfile,
            refetchOneStaff,
            noStaf,
            roles,
            isActive,
            isEachRoles,
        };
    },
    computed: {
        getGelaran() {
            return this.dataOneStaff?.gelaran?.toLowerCase()?.includes("tiada")
                ? ""
                : this.dataOneStaff?.gelaran;
        },
        rolesStr() {
            return this.dataOneStaff?.roles?.length > 0
                ? this.dataOneStaff?.roles?.map((r) => r.role).join(" | ")
                : "Not Activated Yet";
        },
        nama() {
            return this.dataOneStaff?.nama;
        },
        email() {
            return this.dataOneStaff?.email;
        },
        noTelBimbit() {
            return this.dataOneStaff?.noTelBimbit || "-";
        },
        nPejabat() {
            return this.dataOneStaff?.nPejabat;
        },
        position() {
            return this.dataOneStaff?.jGiliran;
        },
    },
    methods: {},
};
</script>

<style scoped>
.form-check .icon.ni {
    font-size: 2em;
}

.form-check .icon.ni-check-round {
    color: green;
}

.form-check .icon.ni-na {
    color: rgba(255, 0, 0, 0.3);
}

.form-check .badge {
    font-size: 1.5em;
}
</style>
