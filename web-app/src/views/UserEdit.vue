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
                        loadingStaffProfile ||
                        loadingOneStaff ||
                        loadingUpdate ||
                        loadingMouSelectData
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
                                                        <span class="small"
                                                            >{{ noStaf }} |
                                                            {{ rolesStr }}</span
                                                        >
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
                                                            <div class="mb-4">
                                                                {{ nama }}
                                                            </div>
                                                            <label
                                                                for="firstname"
                                                                class="form-label"
                                                                >Position</label
                                                            >
                                                            <div class="mb-4">
                                                                {{ position }}
                                                            </div>
                                                            <label
                                                                for="email"
                                                                class="form-label"
                                                                >Email
                                                                address</label
                                                            >
                                                            <div class="mb-4">
                                                                {{ email }}
                                                            </div>
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
                                                                <input
                                                                    class="form-check-input"
                                                                    type="checkbox"
                                                                    v-model="
                                                                        isActive
                                                                    "
                                                                    id="flexSwitchDefault"
                                                                />
                                                                <label
                                                                    class="form-check-label"
                                                                    for="flexSwitchDefault"
                                                                >
                                                                    Inactive/Active
                                                                </label>
                                                            </div>
                                                            <div
                                                                class="form-group"
                                                                v-if="isActive"
                                                            >
                                                                <label
                                                                    class="form-label"
                                                                    >Roles</label
                                                                >
                                                                <div
                                                                    class="form-check"
                                                                >
                                                                    <input
                                                                        class="form-check-input"
                                                                        type="checkbox"
                                                                        v-model="
                                                                            isEachRoles.PUU
                                                                        "
                                                                        id="flexCheckPUU"
                                                                    />
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
                                                                    <input
                                                                        class="form-check-input"
                                                                        type="checkbox"
                                                                        v-model="
                                                                            isEachRoles.US
                                                                        "
                                                                        id="flexCheckUS"
                                                                    />
                                                                    <label
                                                                        class="form-check-label"
                                                                        for="flexCheckUS"
                                                                    >
                                                                        Urusetia
                                                                        /
                                                                        Secretariat
                                                                    </label>
                                                                    <multiselect
                                                                        :multiple="
                                                                            true
                                                                        "
                                                                        v-model="
                                                                            PUU_JenisMemoKods
                                                                        "
                                                                        :options="
                                                                            types
                                                                        "
                                                                        placeholder="Select a Type"
                                                                        label="butiran"
                                                                        track-by="butiran"
                                                                    ></multiselect>
                                                                </div>
                                                                <div
                                                                    class="form-check"
                                                                >
                                                                    <input
                                                                        class="form-check-input"
                                                                        type="checkbox"
                                                                        v-model="
                                                                            isEachRoles.PTJ
                                                                        "
                                                                        id="flexCheckPTJ"
                                                                    />
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
                                                                    <input
                                                                        class="form-check-input"
                                                                        type="checkbox"
                                                                        v-model="
                                                                            isEachRoles.Admin
                                                                        "
                                                                        id="flexCheckAdmin"
                                                                    />
                                                                    <label
                                                                        class="form-check-label"
                                                                        for="flexCheckAdmin"
                                                                    >
                                                                        Administrator
                                                                    </label>
                                                                </div>
                                                            </div>
                                                            <div class="mt-5">
                                                                <a
                                                                    href="#"
                                                                    v-on:click="
                                                                        updateRoles
                                                                    "
                                                                    class="btn btn-primary"
                                                                >
                                                                    Update
                                                                    Profile
                                                                </a>
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
import Multiselect from "vue-multiselect";
import "vue-multiselect/dist/vue-multiselect.min.css";

import ValidateMeComponent from "@/components/ValidateMe.vue";
import NavbarComponent from "@/components/Navbar.vue";
import TopNavComponent from "@/components/TopNav.vue";
import FooterComponent from "@/components/Footer.vue";
import LoadingComponent from "@/components/Loading.vue";
import InfoNotLoggedInComponent from "@/components/InfoNotLoggedIn.vue";
import {
    useStaffProfile,
    useGetOneStaff,
    useAssignStaffRoles,
    useGetMOUSelectData,
    useLogPageView,
} from "@/hooks/useAPI";

export default {
    name: "UserEditView",
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
        Multiselect,
    },
    setup() {
        useLogPageView("User Edit");
        const {
            data: dataStaffProfile,
            error: errorStaffProfile,
            loading: loadingStaffProfile,
            refetch: refetchStaffProfile,
        } = useStaffProfile();

        const { data: dataMouSelectData, loading: loadingMouSelectData } =
            useGetMOUSelectData();

        const types = ref([]);
        const PUU_JenisMemoKods = ref([]);
        watch(
            () => dataMouSelectData.value,
            (dataMouSelectDataUpdated) => {
                types.value = dataMouSelectDataUpdated?.jenisMemo || [];
            }
        );

        const route = useRoute();
        const noStaf = route?.query?.s;
        const {
            data: dataOneStaff,
            error: errorOneStaff,
            loading: loadingOneStaff,
            refetch: refetchOneStaff,
        } = useGetOneStaff(noStaf);
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
                            (r) => r.role === "Admin"
                        )
                            ? true
                            : false,
                        PUU: dataOneStaffUpdated?.roles?.find(
                            (r) => r.role === "PUU"
                        )
                            ? true
                            : false,
                        PTJ: dataOneStaffUpdated?.roles?.find(
                            (r) => r.role === "PTJ"
                        )
                            ? true
                            : false,
                        US: dataOneStaffUpdated?.roles?.find(
                            (r) => r.role === "US"
                        )
                            ? true
                            : false,
                    };
                    PUU_JenisMemoKods.value =
                        dataOneStaffUpdated?.roles_Secretariats;
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
            loadingMouSelectData,
            types,
            PUU_JenisMemoKods,
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
    methods: {
        updateRoles() {
            this.loadingUpdate = true;
            let newRoles = [];
            if (this.isEachRoles.Admin) {
                newRoles.push("Admin");
            }
            if (this.isEachRoles.PUU) {
                newRoles.push("PUU");
            }
            if (this.isEachRoles.US) {
                newRoles.push("US");
            }
            if (this.isEachRoles.PTJ) {
                newRoles.push("PTJ");
            }
            if (this.isActive) {
                newRoles.push("Staff");
            } else {
                newRoles = [];
            }
            const rolesSecretariats = this.PUU_JenisMemoKods?.map((k) => k.kod);
            const { loading } = useAssignStaffRoles(
                this.noStaf,
                newRoles,
                rolesSecretariats
            );
            this.loadingUpdate = loading.value;

            var self = this;
            watch(
                () => loading.value, // Watch the `data` reactive property
                (newLoading) => {
                    self.loadingUpdate = newLoading;
                    if (newLoading == false) {
                        this.$toast.open({
                            message: "Staff profile updated.",
                            type: "success",
                            position: "top-right",
                        });
                    }
                }
            );
        },
    },
};
</script>
