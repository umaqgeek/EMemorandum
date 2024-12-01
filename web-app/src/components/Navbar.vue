<template>
    <div class="nk-sidebar nk-sidebar-fixed is-theme" id="sidebar">
        <div class="nk-sidebar-element nk-sidebar-head">
            <div class="nk-sidebar-brand">
                <a :href="`${publicPath}`" class="logo-link">
                    <div class="logo-wrap">
                        <img
                            class="logo-img logo-light"
                            src="../assets/images/LogoUTeM.webp"
                            srcset="../assets/images/LogoUTeM.webp 2x"
                            alt=""
                        />
                        <img
                            class="logo-img logo-dark"
                            src="../assets/images/LogoUTeM.webp"
                            srcset="../assets/images/LogoUTeM.webp 2x"
                            alt=""
                        />
                        <img
                            class="logo-img logo-icon"
                            src="../assets/images/LogoUTeM.webp"
                            srcset="../assets/images/LogoUTeM.webp 2x"
                            alt=""
                        />
                    </div>
                </a>
                <div class="nk-compact-toggle me-n1">
                    <button
                        class="btn btn-md btn-icon text-light btn-no-hover compact-toggle"
                    >
                        <em class="icon off ni ni-chevrons-left"></em>
                        <em class="icon on ni ni-chevrons-right"></em>
                    </button>
                </div>
                <div class="nk-sidebar-toggle me-n1">
                    <button
                        class="btn btn-md btn-icon text-light btn-no-hover sidebar-toggle"
                    >
                        <em class="icon ni ni-arrow-left"></em>
                    </button>
                </div>
            </div>
            <!-- end nk-sidebar-brand -->
        </div>
        <!-- end nk-sidebar-element -->
        <div class="nk-sidebar-element nk-sidebar-body">
            <div class="nk-sidebar-content">
                <div class="nk-sidebar-menu" data-simplebar>
                    <ul class="nk-menu">
                        <li class="nk-menu-heading">
                            <h6 class="overline-title">E-Memorandum (UTeM)</h6>
                        </li>
                        <li
                            :class="[
                                'nk-menu-item',
                                {
                                    active: activeLabel === 'dashboard',
                                },
                            ]"
                        >
                            <a :href="`${publicPath}`" class="nk-menu-link"
                                ><span class="nk-menu-icon"
                                    ><em class="icon ni ni-home"></em
                                ></span>
                                <span class="nk-menu-text">Dashboard</span>
                            </a>
                        </li>
                        <li
                            :class="[
                                'nk-menu-item',
                                { active: activeLabel === 'user-list' },
                            ]"
                            v-if="roles.find((r) => r.code === 'Admin')"
                        >
                            <a
                                :href="`${publicPath}user-list`"
                                class="nk-menu-link"
                                ><span class="nk-menu-icon"
                                    ><em class="icon ni ni-users"></em
                                ></span>
                                <span class="nk-menu-text">Manage User</span>
                            </a>
                        </li>
                        <li
                            :class="[
                                'nk-menu-item',
                                { active: activeLabel === 'memo-list' },
                            ]"
                            v-if="
                                roles.find((r) => r.code === 'Staff') ||
                                roles.find((r) => r.code === 'PTJ')
                            "
                        >
                            <a
                                :href="`${publicPath}memo-list`"
                                class="nk-menu-link"
                                ><span class="nk-menu-icon"
                                    ><em class="icon ni ni-note-add"></em
                                ></span>
                                <span class="nk-menu-text">Memorandums</span>
                            </a>
                        </li>
                        <li
                            :class="[
                                'nk-menu-item',
                                { active: activeLabel === 'report' },
                            ]"
                        >
                            <a
                                :href="`${publicPath}report`"
                                class="nk-menu-link"
                                ><span class="nk-menu-icon"
                                    ><em class="icon ni ni-layers"></em
                                ></span>
                                <span class="nk-menu-text">Reports</span>
                            </a>
                        </li>
                        <!-- <li
                            :class="[
                                'nk-menu-item',
                                { active: activeLabel === 'code-list' },
                            ]"
                            v-if="roles.find((r) => r.code === 'Admin')"
                        >
                            <a
                                :href="`${publicPath}code-list`"
                                class="nk-menu-link"
                                ><span class="nk-menu-icon"
                                    ><em class="icon ni ni-layers"></em
                                ></span>
                                <span class="nk-menu-text">Manage Code</span>
                            </a>
                        </li> -->
                        <!-- <li
                            :class="[
                                'nk-menu-item',
                                { active: activeLabel === 'approval-list' },
                            ]"
                            v-if="roles.find((r) => r.code === 'PTJ')"
                        >
                            <a
                                :href="`${publicPath}approval-list`"
                                class="nk-menu-link"
                                ><span class="nk-menu-icon"
                                    ><em class="icon ni ni-check-round-cut"></em
                                ></span>
                                <span class="nk-menu-text">Approval</span>
                            </a>
                        </li> -->
                        <li class="nk-menu-item">
                            <a href="#" class="nk-menu-link" @click="logout"
                                ><span class="nk-menu-icon"
                                    ><em class="icon ni ni-signout"></em
                                ></span>
                                <span class="nk-menu-text">Log Out</span>
                            </a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import { resetBearerToken } from "@/utils/tokenManagement";

export default {
    name: "NavbarComponent",
    data() {
        return {
            publicPath: process.env.VUE_APP_PUBLIC_PATH,
        };
    },
    props: {
        staffprofile: Object,
        activeLabel: String,
    },
    computed: {
        roles() {
            return this.staffprofile?.roles?.length > 0
                ? this.staffprofile?.roles
                : [];
        },
    },
    methods: {
        logout() {
            resetBearerToken();
        },
    },
};
</script>
