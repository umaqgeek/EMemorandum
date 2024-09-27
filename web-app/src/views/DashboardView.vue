<template>
    <div class="nk-app-root">
        <div class="nk-main">
            <NavbarComponent :staffprofile="dataStaffprofile" />
            <div class="nk-wrap">
                <TopNavComponent
                    :staffprofile="dataStaffprofile"
                    :errorStaffProfile="errorStaffProfile"
                />
                <LoadingComponent :loading="loading" />
                <div class="nk-content" v-if="errorStaffProfile">
                    <InfoNotLoggedInVue />
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
                                    </div>
                                    <div
                                        class="col-md-3"
                                        v-if="
                                            roles.find(
                                                (r) => r.role === 'PUU'
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
                                                        Manage Memorandum
                                                    </h4>
                                                    <font-awesome-icon
                                                        icon="fa-solid fa-file"
                                                        size="2x"
                                                    />
                                                </div>
                                            </div>
                                        </a>
                                    </div>
                                    <div
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
import NavbarComponent from "@/components/Navbar.vue";
import TopNavComponent from "@/components/TopNav.vue";
import FooterComponent from "@/components/Footer.vue";
import LoadingComponent from "@/components/Loading.vue";
import InfoNotLoggedInVue from "@/components/InfoNotLoggedIn.vue";
import { useStaffProfile } from "@/hooks/useAPI";

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
        InfoNotLoggedInVue,
    },
    setup() {
        const {
            data: dataStaffprofile,
            error: errorStaffProfile,
            loading: loadingStaffProfile,
            refetch,
        } = useStaffProfile();
        return {
            dataStaffprofile,
            errorStaffProfile,
            loading: loadingStaffProfile,
            refetch,
        };
    },
    computed: {
        roles() {
            return this.dataStaffprofile?.roles?.length > 0
                ? this.dataStaffprofile?.roles
                : [];
        },
    },
    methods: {},
};
</script>
