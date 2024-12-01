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
                <div class="nk-header-tools header-top-right">
                    <div class="header-search-container">
                        <SearchInput />
                    </div>
                    <div
                        class="header-top-right-name"
                        v-if="!errorStaffProfile"
                    >
                        <div>{{ getGelaran }} {{ staffprofile?.nama }}</div>
                        <h6>{{ staffprofile?.noStaf }} {{ rolesStr }}</h6>
                    </div>
                    <ul class="nk-quick-nav ms-2">
                        <li class="dropdown" v-if="!errorStaffProfile">
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
                                                {{ staffprofile?.nama }}
                                            </div>
                                            <span class="sub-text">{{
                                                staffprofile?.email
                                            }}</span>
                                            <div class="lead-text">
                                                ({{ staffprofile?.jGiliran }})
                                            </div>
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
import { onMounted } from "vue";

import SearchInput from "@/components/SearchInput.vue";

import { resetBearerToken, setBearerToken } from "@/utils/tokenManagement";

export default {
    name: "TopNavComponent",
    data() {
        return {
            publicPath: process.env.VUE_APP_PUBLIC_PATH,
        };
    },
    props: {
        staffprofile: Object,
        errorStaffProfile: String,
    },
    components: {
        SearchInput,
    },
    setup() {
        onMounted(() => {
            const params = new URLSearchParams(window.location.search);
            const newSsusrid =
                params.get("UsrLogin") ||
                params.get("usrLogin") ||
                params.get("ssusrid");
            const callbackRoute = params.get("callback") || "";

            if (newSsusrid) {
                setBearerToken(newSsusrid);
                location.href = `${process.env.VUE_APP_PUBLIC_PATH}${callbackRoute}`;
            }
        });
    },
    computed: {
        getGelaran() {
            return this.staffprofile?.gelaran?.toLowerCase()?.includes("tiada")
                ? ""
                : this.staffprofile?.gelaran;
        },
        isActivated() {
            return this.staffprofile?.roles?.length > 0;
        },
        rolesStr() {
            if (this.staffprofile?.roles?.length > 1) {
                return this.staffprofile?.roles
                    ?.filter((r) => r.code != "Staff")
                    ?.map((r) => r.role)
                    .join(" | ");
            }
            return "Staff";
        },
    },
    methods: {
        logout() {
            resetBearerToken();
        },
    },
};
</script>

<style scoped>
.header-top-right {
    display: flex;
    align-items: center;
}

.header-top-right-name {
    text-align: right;
}

.header-search-container {
    margin-right: 16px;
}
</style>
