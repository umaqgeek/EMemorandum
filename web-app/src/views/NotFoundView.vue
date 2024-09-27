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
                <div class="nk-content">
                    <InfoNotLoggedInVue />
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
    name: "NotFoundView",
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
    computed: {},
    methods: {},
};
</script>
