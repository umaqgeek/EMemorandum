<template>
    <nav class="top-navbar">
        <h1 class="navbar-title">Application Title</h1>
    </nav>
</template>

<script>
import { resetBearerToken } from "@/utils/mocks";

export default {
    name: "TopNavComponent",
    props: {
        staffprofile: Object,
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
    },
    methods: {
        logout() {
            resetBearerToken();
        },
    },
};
</script>

<style scoped>
/* Top navbar styles */
.top-navbar {
    height: 60px;
    background-color: #3e3e52;
    color: #fff;
    display: flex;
    align-items: center;
    padding: 0 20px;
    position: fixed;
    top: 0;
    left: 0;
    right: 0;
}

.navbar-title {
    font-size: 18px;
}
</style>
