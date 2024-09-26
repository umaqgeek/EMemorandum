<template>
    <!-- Root @s -->
    <div class="nk-app-root">
        <!-- main @s -->
        <div class="nk-main">
            <NavbarComponent />
            <!-- .nki-sidebar -->
            <!-- sidebar @e -->
            <!-- wrap @s -->
            <div class="nk-wrap">
                <TopNavComponent />
                <!-- header -->
                <!-- content @s -->
                <div class="nk-content">
                    <div class="container">
                        <div class="nk-content-inner">
                            <div class="nk-content-body">
                                <div class="nk-block-head">
                                    <div class="nk-block-head">
                                        <div
                                            class="nk-block-head-between flex-wrap gap g-2 align-items-center"
                                        >
                                            <div class="nk-block-head-content">
                                                <h2 class="nk-block-title">
                                                    Edit Memorandum
                                                </h2>
                                            </div>
                                            <!-- .nk-block-head-content -->
                                            <div
                                                class="nk-block-head-content"
                                            ></div>
                                            <!-- .nk-block-head-content -->
                                        </div>
                                        <!-- .nk-block-head-between -->
                                    </div>
                                    <!-- .nk-block-head -->
                                </div>
                                <!-- .nk-block-head -->
                                <div class="nk-block">
                                    <div class="card">
                                        <div
                                            class="nk-todo"
                                            data-todo-collapse="xl"
                                            id="todoWrap"
                                        >
                                            <div
                                                class="nk-todo-aside"
                                                data-simplebar
                                                id="todoAside"
                                                data-overlay="true"
                                                data-break="xl"
                                            >
                                                <div
                                                    class="nk-todo-aside-header"
                                                ></div>
                                                <ul class="nk-todo-menu pb-3">
                                                    <li>
                                                        <router-link
                                                            to="/memo-edit"
                                                            class="nk-todo-menu-item"
                                                        >
                                                            <em
                                                                class="icon ni ni-info"
                                                            ></em>
                                                            <span
                                                                >Project
                                                                Details</span
                                                            >
                                                        </router-link>
                                                    </li>
                                                    <li>
                                                        <router-link
                                                            to="/memo-edit-member"
                                                            class="nk-todo-menu-item"
                                                        >
                                                            <em
                                                                class="icon ni ni-users"
                                                            ></em>
                                                            <span>Members</span>
                                                        </router-link>
                                                    </li>
                                                    <li class="active">
                                                        <a
                                                            href="#"
                                                            class="nk-todo-menu-item"
                                                        >
                                                            <em
                                                                class="icon ni ni-list"
                                                            ></em>
                                                            <span>KPI</span>
                                                        </a>
                                                    </li>
                                                </ul>
                                            </div>
                                            <!-- .nk-todo-aside -->
                                            <div class="nk-todo-body">
                                                <div class="nk-todo-head">
                                                    <ul class="d-flex">
                                                        <li class="title">
                                                            KPI
                                                        </li>
                                                    </ul>
                                                </div>
                                                <div
                                                    class="nk-todo-list card-body"
                                                >
                                                    <TableKPIComponent />
                                                    <div class="col-lg-12 mt-3">
                                                        <router-link
                                                            to="/memo-list"
                                                            class="btn btn-primary"
                                                        >
                                                            Save
                                                        </router-link>
                                                    </div>
                                                </div>
                                            </div>
                                            <!-- .nk-todo-body -->
                                        </div>
                                        <!-- .nk-todo -->
                                    </div>
                                    <!-- .card -->
                                </div>
                                <!-- .nk-block -->
                                <!-- .nk-block -->
                            </div>
                        </div>
                    </div>
                </div>
                <!-- .nk-content -->
                <!-- include Footer -->
                <div class="nk-footer">
                    <div class="container-fluid">
                        <div class="nk-footer-wrap">
                            <div class="nk-footer-copyright">
                                &copy; 2024 UTeM.
                            </div>
                            <div class="nk-footer-links">
                                <ul class="nav nav-sm"></ul>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- .nk-footer -->
            </div>
            <!-- .nk-wrap -->
        </div>
        <!-- .nk-main -->
    </div>
    <!-- .nk-app-root -->
</template>

<!-- JavaScript -->
<script>
import NavbarComponent from "@/components/Navbar.vue";
import TopNavComponent from "@/components/TopNav.vue";
import TableKPIComponent from "@/components/TableKPI.vue";

export default {
    name: "MemoEditKPIView",
    components: {
        NavbarComponent,
        TopNavComponent,
        TableKPIComponent,
    },
};
</script>
