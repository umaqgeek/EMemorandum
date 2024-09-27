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
                        <li class="nk-menu-item">
                            <a :href="`${publicPath}`" class="nk-menu-link"
                                ><span class="nk-menu-icon"
                                    ><em class="icon ni ni-home"></em
                                ></span>
                                <span class="nk-menu-text">Dashboard</span>
                            </a>
                        </li>
                        <li
                            class="nk-menu-item"
                            v-if="roles.find((r) => r.role === 'Admin')"
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
                            class="nk-menu-item"
                            v-if="roles.find((r) => r.role === 'Admin')"
                        >
                            <a
                                :href="`${publicPath}code-list`"
                                class="nk-menu-link"
                                ><span class="nk-menu-icon"
                                    ><em class="icon ni ni-layers"></em
                                ></span>
                                <span class="nk-menu-text">Manage Code</span>
                            </a>
                        </li>
                        <li
                            class="nk-menu-item"
                            v-if="
                                roles.find((r) => r.role === 'PUU') ||
                                roles.find((r) => r.role === 'PTJ')
                            "
                        >
                            <a
                                :href="`${publicPath}memo-list`"
                                class="nk-menu-link"
                                ><span class="nk-menu-icon"
                                    ><em class="icon ni ni-note-add"></em
                                ></span>
                                <span class="nk-menu-text"
                                    >Manage Memorandum</span
                                >
                            </a>
                        </li>
                        <li
                            class="nk-menu-item"
                            v-if="roles.find((r) => r.role === 'PTJ')"
                        >
                            <a
                                :href="`${publicPath}approval-list`"
                                class="nk-menu-link"
                                ><span class="nk-menu-icon"
                                    ><em class="icon ni ni-check-round-cut"></em
                                ></span>
                                <span class="nk-menu-text">Approval</span>
                            </a>
                        </li>
                    </ul>
                    <!-- .nk-menu -->
                </div>
                <!-- .nk-sidebar-menu -->
            </div>
            <!-- .nk-sidebar-content -->
        </div>
        <!-- .nk-sidebar-element -->
    </div>
    <!-- .nki-sidebar -->
</template>

<script>
export default {
    name: "NavbarComponent",
    data() {
        return {
            publicPath: process.env.VUE_APP_PUBLIC_PATH,
        };
    },
    props: {
        staffprofile: Object,
    },
    computed: {
        roles() {
            return this.staffprofile?.roles?.length > 0
                ? this.staffprofile?.roles
                : [];
        },
    },
    methods: {},
};
</script>
