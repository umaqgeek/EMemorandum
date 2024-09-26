<template>
    <div class="nk-app-root">
        <div class="nk-main">
            <NavbarComponent :staffprofile="data" />
            <div class="nk-wrap">
                <TopNavComponent :staffprofile="data" />
                <LoadingComponent :loading="loading || error" />
                <div class="nk-content">
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
                                        <a href="/user-list">
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
                                        <a href="/code-list">
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
                                        <a href="/memo-list">
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
                                        <a href="/approval-list">
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
import { useStaffProfile } from "@/hooks/useAPI";

export default {
    name: "DashboardView",
    components: {
        LoadingComponent,
        NavbarComponent,
        TopNavComponent,
        FooterComponent,
    },
    setup() {
        const { data, error, loading, refetch } = useStaffProfile();
        return {
            data,
            error,
            loading,
            refetch,
        };
    },
    computed: {
        roles() {
            return this.data?.roles?.length > 0 ? this.data?.roles : [];
        },
    },
    methods: {},
};
</script>
