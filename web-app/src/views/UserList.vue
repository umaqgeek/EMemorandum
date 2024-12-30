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
                    <InfoNotLoggedInComponent />
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
                                    <TableUserComponent
                                        :users="users"
                                        :isFull="true"
                                    />
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
import TableUserComponent from "@/components/TableUser.vue";
import LoadingComponent from "@/components/Loading.vue";
import InfoNotLoggedInComponent from "@/components/InfoNotLoggedIn.vue";
import {
    useStaffProfile,
    useGetAllStaff,
    useLogPageView,
} from "@/hooks/useAPI";

export default {
    name: "UserListView",
    components: {
        ValidateMeComponent,
        NavbarComponent,
        TopNavComponent,
        FooterComponent,
        TableUserComponent,
        LoadingComponent,
        InfoNotLoggedInComponent,
    },
    setup() {
        useLogPageView("User List");
        const {
            data: dataAllStaff,
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
            errorStaffProfile,
            loading: loadingAllStaff || loadingStaffProfile,
            refetchAllStaff,
            refetchStaffProfile,
        };
    },
    computed: {
        users() {
            if (this.dataAllStaff?.length > 0) {
                return [...this.dataAllStaff].sort((a, b) => {
                    if (a.roles.length > b.roles.length) {
                        return -1;
                    }
                    if (a.roles.length < b.roles.length) {
                        return 1;
                    }
                    return 0;
                });
            }
            return [];
        },
    },
    methods: {},
};
</script>
