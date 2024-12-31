<template>
    <div class="nk-app-root">
        <div class="nk-main">
            <NavbarComponent
                :staffprofile="dataStaffProfile"
                :activeLabel="`codes`"
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
                                <div class="row g-gs mb-3">
                                    <div class="col-md-12 mb-4">
                                        <h2>Manage Codes/Utilities</h2>
                                    </div>
                                    <div class="col-md-3">
                                        <a :href="`${publicPath}manage-fields`">
                                            <div class="card">
                                                <div
                                                    class="card-body dashboard-card"
                                                >
                                                    <h4 class="mb-3">
                                                        Manage Fields
                                                    </h4>
                                                    <em
                                                        class="icon ni ni-setting"
                                                    ></em>
                                                </div>
                                            </div>
                                        </a>
                                    </div>
                                    <div class="col-md-3">
                                        <a
                                            :href="`${publicPath}manage-ind-cats`"
                                        >
                                            <div class="card">
                                                <div
                                                    class="card-body dashboard-card"
                                                >
                                                    <h4 class="mb-3">
                                                        Manage Industry
                                                        Categories
                                                    </h4>
                                                    <em
                                                        class="icon ni ni-setting"
                                                    ></em>
                                                </div>
                                            </div>
                                        </a>
                                    </div>
                                    <div class="col-md-3">
                                        <a :href="`${publicPath}manage-types`">
                                            <div class="card">
                                                <div
                                                    class="card-body dashboard-card"
                                                >
                                                    <h4 class="mb-3">
                                                        Manage Types
                                                    </h4>
                                                    <em
                                                        class="icon ni ni-setting"
                                                    ></em>
                                                </div>
                                            </div>
                                        </a>
                                    </div>
                                    <div class="col-md-3">
                                        <a
                                            :href="`${publicPath}manage-categories`"
                                        >
                                            <div class="card">
                                                <div
                                                    class="card-body dashboard-card"
                                                >
                                                    <h4 class="mb-3">
                                                        Manage Categories
                                                    </h4>
                                                    <em
                                                        class="icon ni ni-setting"
                                                    ></em>
                                                </div>
                                            </div>
                                        </a>
                                    </div>
                                    <div class="col-md-3">
                                        <a :href="`${publicPath}manage-scopes`">
                                            <div class="card">
                                                <div
                                                    class="card-body dashboard-card"
                                                >
                                                    <h4 class="mb-3">
                                                        Manage Scopes
                                                    </h4>
                                                    <em
                                                        class="icon ni ni-setting"
                                                    ></em>
                                                </div>
                                            </div>
                                        </a>
                                    </div>
                                    <div class="col-md-3">
                                        <a :href="`${publicPath}manage-kpis`">
                                            <div class="card">
                                                <div
                                                    class="card-body dashboard-card"
                                                >
                                                    <h4 class="mb-3">
                                                        Manage KPIs
                                                    </h4>
                                                    <em
                                                        class="icon ni ni-setting"
                                                    ></em>
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

<script>
import NavbarComponent from "@/components/Navbar.vue";
import TopNavComponent from "@/components/TopNav.vue";
import FooterComponent from "@/components/Footer.vue";
import LoadingComponent from "@/components/Loading.vue";
import InfoNotLoggedInComponent from "@/components/InfoNotLoggedIn.vue";
import { useStaffProfile } from "@/hooks/useAPI";

export default {
    name: "CodesDashboardView",
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
        } = useStaffProfile();
        return {
            dataStaffProfile,
            errorStaffProfile,
            loading: loadingStaffProfile,
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
