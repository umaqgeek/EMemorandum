<template>
    <div class="nk-header nk-header-fixed">
        <div class="container-fluid">
            <div class="nk-header-wrap">
                <div class="nk-header-logo ms-n1">
                    <div class="nk-navbar-toggle me-2"></div>
                </div>
                <nav class="nk-header-menu nk-navbar">
                    <ul class="nk-nav"></ul>
                </nav>
                <div class="nk-header-tools">
                    <ul class="nk-quick-nav ms-2">
                        <li class="dropdown">
                            <a href="#" data-bs-toggle="dropdown">
                                <div class="d-sm-none">
                                    <div class="media media-md media-circle">
                                        <img
                                            src="../assets/images/avatar/a.jpg"
                                            alt=""
                                            class="img-thumbnail"
                                        />
                                    </div>
                                </div>
                                <div class="d-none d-sm-block">
                                    <div class="media media-circle">
                                        <img
                                            src="../assets/images/avatar/a.jpg"
                                            alt=""
                                            class="img-thumbnail"
                                        />
                                    </div>
                                </div>
                            </a>
                            <div class="dropdown-menu dropdown-menu-md">
                                <div
                                    class="dropdown-content dropdown-content-x-lg py-3 border-bottom border-light"
                                    v-show="!loading && !error"
                                >
                                    <div class="media-group">
                                        <div
                                            class="media media-xl media-middle media-circle"
                                        >
                                            <img
                                                src="../assets/images/avatar/a.jpg"
                                                alt=""
                                                class="img-thumbnail"
                                            />
                                        </div>
                                        <div class="media-text">
                                            <div class="lead-text">
                                                {{ getGelaran }}
                                                {{ data?.nama }}
                                            </div>
                                            <span class="sub-text">{{
                                                data?.email
                                            }}</span>
                                            <div
                                                class="alert alert-danger mt-2"
                                                v-if="!isActivated"
                                            >
                                                Inactive
                                            </div>
                                            <div
                                                class="alert alert-success mt-2"
                                                v-if="isActivated"
                                            >
                                                Active
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <LoadingComponent :loading="loading || error" />
                                <div
                                    class="dropdown-content dropdown-content-x-lg py-3 border-bottom border-light"
                                >
                                    <ul class="link-list">
                                        <li>
                                            <router-link to="/PUU/dashboard">
                                                <em
                                                    class="icon ni ni-user-alt"
                                                ></em>
                                                <span>PUU</span>
                                            </router-link>
                                        </li>
                                        <li>
                                            <router-link to="/PTJ/dashboard">
                                                <em
                                                    class="icon ni ni-user-alt"
                                                ></em>
                                                <span>PTJ</span>
                                            </router-link>
                                        </li>
                                        <li>
                                            <router-link to="/">
                                                <em
                                                    class="icon ni ni-user-alt"
                                                ></em>
                                                <span>Admin</span>
                                            </router-link>
                                        </li>
                                    </ul>
                                </div>
                                <div
                                    class="dropdown-content dropdown-content-x-lg py-3"
                                >
                                    <ul class="link-list">
                                        <li>
                                            <a href="#" v-on:click="logout">
                                                <em
                                                    class="icon ni ni-signout"
                                                ></em>
                                                <span>Log Out</span>
                                            </a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>
                <!-- .nk-header-tools -->
            </div>
            <!-- .nk-header-wrap -->
        </div>
        <!-- .container-fliud -->
    </div>
</template>

<script>
import LoadingComponent from "@/components/Loading.vue";
import { resetBearerToken } from "@/utils/mocks";
import { useStaffProfile } from "@/hooks/useAPI";

export default {
    name: "TopNavComponent",
    components: {
        LoadingComponent,
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
        getGelaran() {
            return this.data?.gelaran?.toLowerCase()?.includes("tiada")
                ? ""
                : this.data?.gelaran;
        },
        isActivated() {
            return this.data?.roles?.length > 0;
        },
    },
    methods: {
        logout() {
            resetBearerToken();
        },
    },
};
</script>
