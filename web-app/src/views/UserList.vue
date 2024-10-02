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
                <LoadingComponent :loading="loading" />
                <div class="nk-content" v-if="errorStaffProfile">
                    <InfoNotLoggedInVue />
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
                                                Manage Users
                                            </h2>
                                        </div>
                                    </div>
                                </div>
                                <div class="nk-block">
                                    <TableUserMgtComponent :users="users" />
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

<script>
import ValidateMeComponent from "@/components/ValidateMe.vue";
import NavbarComponent from "@/components/Navbar.vue";
import TopNavComponent from "@/components/TopNav.vue";
import FooterComponent from "@/components/Footer.vue";
import TableUserMgtComponent from "@/components/TableUser.vue";
import LoadingComponent from "@/components/Loading.vue";
import { useStaffProfile, useGetAllStaff } from "@/hooks/useAPI";

export default {
    name: "UserListView",
    components: {
        ValidateMeComponent,
        NavbarComponent,
        TopNavComponent,
        FooterComponent,
        TableUserMgtComponent,
        LoadingComponent,
    },
    setup() {
        const {
            data: dataAllStaff,
            error: errorAllStaff,
            loading: loadingAllStaff,
            refetch: refetchAllStaff,
        } = useGetAllStaff();
        const {
            data: dataStaffProfile,
            error: errorStaffProfile,
            loading: loadingStaffProfile,
            refetch: refetchStaffProfile,
        } = useStaffProfile();
        return {
            dataAllStaff,
            dataStaffProfile,
            error: errorAllStaff || errorStaffProfile,
            loading: loadingAllStaff || loadingStaffProfile,
            refetchAllStaff,
            refetchStaffProfile,
        };
    },
    computed: {
        users() {
            return this.dataAllStaff?.length > 0 ? this.dataAllStaff : [];
        },
    },
    methods: {},
};
</script>
