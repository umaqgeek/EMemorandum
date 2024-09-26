<template>
    <div class="sidebar" :class="{ collapsed: isCollapsed }">
        <div class="sidebar-header">
            <img
                src="../assets/images/LogoUTeM.webp"
                alt="Logo"
                class="sidebar-logo"
            />
            <button class="toggle-btn" v-on:click="toggleSidebar">
                &#10094;
            </button>
        </div>
        <div class="sidebar-menu">
            <h3 class="sidebar-title">APPLICATIONS</h3>
            <ul class="nk-menu">
                <li class="nk-menu-heading">
                    <h6 class="overline-title">Applications</h6>
                </li>
                <li class="nk-menu-item">
                    <router-link to="/" class="nk-menu-link"
                        ><span class="nk-menu-icon"
                            ><em class="icon ni ni-home"></em
                        ></span>
                        <span class="nk-menu-text">Dashboard</span>
                    </router-link>
                </li>
                <li
                    class="nk-menu-item"
                    v-if="roles.find((r) => r.role === 'Admin')"
                >
                    <router-link to="/user-list" class="nk-menu-link"
                        ><span class="nk-menu-icon"
                            ><em class="icon ni ni-users"></em
                        ></span>
                        <span class="nk-menu-text">Manage User</span>
                    </router-link>
                </li>
                <li
                    class="nk-menu-item"
                    v-if="roles.find((r) => r.role === 'Admin')"
                >
                    <router-link to="/code-list" class="nk-menu-link"
                        ><span class="nk-menu-icon"
                            ><em class="icon ni ni-layers"></em
                        ></span>
                        <span class="nk-menu-text">Manage Code</span>
                    </router-link>
                </li>
                <li
                    class="nk-menu-item"
                    v-if="
                        roles.find((r) => r.role === 'PUU') ||
                        roles.find((r) => r.role === 'PTJ')
                    "
                >
                    <router-link to="/memo-list" class="nk-menu-link"
                        ><span class="nk-menu-icon"
                            ><em class="icon ni ni-note-add"></em
                        ></span>
                        <span class="nk-menu-text">Manage Memorandum</span>
                    </router-link>
                </li>
                <li
                    class="nk-menu-item"
                    v-if="roles.find((r) => r.role === 'PTJ')"
                >
                    <router-link to="/approval-list" class="nk-menu-link"
                        ><span class="nk-menu-icon"
                            ><em class="icon ni ni-check-round-cut"></em
                        ></span>
                        <span class="nk-menu-text">Approval</span>
                    </router-link>
                </li>
            </ul>
        </div>
    </div>
</template>

<script>
export default {
    name: "NavbarComponent",
    props: {
        staffprofile: Object,
        isCollapsed: Boolean,
    },
    computed: {
        roles() {
            return this.staffprofile?.roles?.length > 0
                ? this.staffprofile?.roles
                : [];
        },
    },
    methods: {
        toggleSidebar() {
            this.$emit("toggleSidebar");
        },
    },
};
</script>

<style scoped>
/* Sidebar styles */
.sidebar {
    height: 100vh;
    width: 250px;
    background-color: #1a1a2e;
    color: #fff;
    position: fixed;
    transition: width 0.3s ease;
    overflow: hidden;
}

.sidebar-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 15px;
}

.sidebar-logo {
    max-width: 80px;
}

.toggle-btn {
    background: none;
    border: none;
    color: #fff;
    font-size: 20px;
    cursor: pointer;
}

.sidebar-menu {
    padding: 15px;
}

.sidebar-title {
    font-size: 12px;
    color: #aaa;
    margin-bottom: 10px;
}

.sidebar ul {
    list-style: none;
    padding: 0;
}

.sidebar ul li {
    margin-bottom: 15px;
}

.sidebar ul li a {
    display: flex;
    align-items: center;
    color: #fff;
    text-decoration: none;
    padding: 10px;
    border-radius: 5px;
    transition: background-color 0.3s ease;
}

.sidebar ul li a:hover {
    background-color: #3e3e52;
}

.sidebar ul li a i {
    margin-right: 10px;
}

/* Collapsed sidebar */
.sidebar.collapsed {
    width: 80px;
}

/* Sidebar icon placeholders */
.icon-home::before {
    content: "\1f3e0";
    /* Unicode for house icon */
}

.icon-user::before {
    content: "\1f464";
    /* Unicode for user icon */
}

.icon-code::before {
    content: "\1f4bb";
    /* Unicode for laptop icon */
}

.icon-memo::before {
    content: "\1f4c4";
    /* Unicode for document icon */
}

.icon-check::before {
    content: "\2714";
    /* Unicode for check mark */
}
</style>
