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
                                            <div class="nk-block-head-content">
                                                <ul
                                                    class="d-flex gap g-2 d-none"
                                                >
                                                    <li
                                                        class="d-none d-md-block"
                                                    >
                                                        <a
                                                            href="./html/user-manage/user-profile.html"
                                                            class="btn btn-soft btn-primary"
                                                            ><em
                                                                class="icon ni ni-user"
                                                            ></em
                                                            ><span
                                                                >Members</span
                                                            ></a
                                                        >
                                                    </li>
                                                    <li
                                                        class="d-none d-md-block"
                                                    >
                                                        <a
                                                            href="./html/user-manage/user-profile.html"
                                                            class="btn btn-soft btn-primary"
                                                            ><em
                                                                class="icon ni ni-user"
                                                            ></em
                                                            ><span>KPI</span></a
                                                        >
                                                    </li>
                                                    <li class="d-md-none">
                                                        <a
                                                            href="./html/user-manage/user-profile.html"
                                                            class="btn btn-soft btn-primary btn-icon"
                                                            ><em
                                                                class="icon ni ni-user"
                                                            ></em
                                                        ></a>
                                                    </li>
                                                </ul>
                                            </div>
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
                                                    <li class="active">
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
                                                    <li>
                                                        <router-link
                                                            to="/memo-edit-kpi"
                                                            class="nk-todo-menu-item"
                                                        >
                                                            <em
                                                                class="icon ni ni-list"
                                                            ></em>
                                                            <span>KPI</span>
                                                        </router-link>
                                                    </li>
                                                </ul>
                                            </div>
                                            <!-- .nk-todo-aside -->
                                            <div class="nk-todo-body card-body">
                                                <form action="#">
                                                    <div class="row g-3">
                                                        <div class="col-lg-12">
                                                            <div
                                                                class="form-group"
                                                            >
                                                                <label
                                                                    for="aboutme"
                                                                    class="form-label"
                                                                    >Project
                                                                    Name</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <textarea
                                                                        class="form-control"
                                                                        id="aboutme"
                                                                        rows="3"
                                                                    >
Development of an IoT-Based Smart Energy Monitoring System for UTeM Campus</textarea
                                                                    >
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-4">
                                                            <div
                                                                class="form-group"
                                                            >
                                                                <label
                                                                    for="city"
                                                                    class="form-label"
                                                                    >Category of
                                                                    Memorandum</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <select
                                                                        class="form-select"
                                                                        id="country"
                                                                        data-search="true"
                                                                        data-sort="false"
                                                                    >
                                                                        <option
                                                                            value=""
                                                                        >
                                                                            Select
                                                                            Options
                                                                        </option>
                                                                        <option
                                                                            selected
                                                                            value="1"
                                                                        >
                                                                            Energy
                                                                            Efficiency
                                                                            and
                                                                            IoT
                                                                            Technology
                                                                        </option>
                                                                        <option
                                                                            value="2"
                                                                        >
                                                                            Canada
                                                                        </option>
                                                                        <option
                                                                            value="3"
                                                                        >
                                                                            Usa
                                                                        </option>
                                                                        <option
                                                                            value="4"
                                                                        >
                                                                            Aus
                                                                        </option>
                                                                    </select>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-4">
                                                            <div
                                                                class="form-group"
                                                            >
                                                                <label
                                                                    for="country"
                                                                    class="form-label"
                                                                    >Type of
                                                                    Memorandum</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <select
                                                                        class="form-select"
                                                                        id="country"
                                                                        data-search="true"
                                                                        data-sort="false"
                                                                    >
                                                                        <option
                                                                            value=""
                                                                        >
                                                                            Select
                                                                            Options
                                                                        </option>
                                                                        <option
                                                                            selected
                                                                            value="1"
                                                                        >
                                                                            Development
                                                                            and
                                                                            Implementation
                                                                        </option>
                                                                        <option
                                                                            value="2"
                                                                        >
                                                                            Canada
                                                                        </option>
                                                                        <option
                                                                            value="3"
                                                                        >
                                                                            Usa
                                                                        </option>
                                                                        <option
                                                                            value="4"
                                                                        >
                                                                            Aus
                                                                        </option>
                                                                    </select>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-4">
                                                            <div
                                                                class="form-group"
                                                            >
                                                                <label
                                                                    for="postalcode"
                                                                    class="form-label"
                                                                    >Memorandum
                                                                    Scope</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <select
                                                                        class="form-select"
                                                                        id="country"
                                                                        data-search="true"
                                                                        data-sort="false"
                                                                    >
                                                                        <option
                                                                            value=""
                                                                        >
                                                                            Select
                                                                            Options
                                                                        </option>
                                                                        <option
                                                                            selected
                                                                            value="1"
                                                                        >
                                                                            Install
                                                                            IoT
                                                                            energy
                                                                            meters
                                                                            in
                                                                            UTeM
                                                                            buildings
                                                                        </option>
                                                                        <option
                                                                            value="2"
                                                                        >
                                                                            Canada
                                                                        </option>
                                                                        <option
                                                                            value="3"
                                                                        >
                                                                            Usa
                                                                        </option>
                                                                        <option
                                                                            value="4"
                                                                        >
                                                                            Aus
                                                                        </option>
                                                                    </select>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <div
                                                                class="form-group"
                                                            >
                                                                <label
                                                                    for="datePicker1"
                                                                    class="form-label"
                                                                    >Start
                                                                    Date</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <input
                                                                        placeholder="dd/mm/yyyy"
                                                                        type="text"
                                                                        class="form-control js-datepicker"
                                                                        data-title="Text"
                                                                        data-today-btn="true"
                                                                        data-clear-btn="true"
                                                                        autocomplete="off"
                                                                        id="datePicker1"
                                                                        value="12/03/2024"
                                                                    />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <div
                                                                class="form-group"
                                                            >
                                                                <label
                                                                    for="datePicker1"
                                                                    class="form-label"
                                                                    >End
                                                                    Date</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <input
                                                                        placeholder="dd/mm/yyyy"
                                                                        type="text"
                                                                        class="form-control js-datepicker"
                                                                        data-title="Text"
                                                                        data-today-btn="true"
                                                                        data-clear-btn="true"
                                                                        autocomplete="off"
                                                                        id="datePicker1"
                                                                        value="23/04/2024"
                                                                    />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <div
                                                                class="form-group"
                                                            >
                                                                <label
                                                                    for="email"
                                                                    class="form-label"
                                                                    >PTJ</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <select
                                                                        class="form-select"
                                                                        id="country"
                                                                        data-search="true"
                                                                        data-sort="false"
                                                                    >
                                                                        <option
                                                                            value=""
                                                                        >
                                                                            Select
                                                                            Options
                                                                        </option>
                                                                        <option
                                                                            value="1"
                                                                        >
                                                                            Germany
                                                                        </option>
                                                                        <option
                                                                            value="2"
                                                                        >
                                                                            Canada
                                                                        </option>
                                                                        <option
                                                                            value="3"
                                                                        >
                                                                            Usa
                                                                        </option>
                                                                        <option
                                                                            value="4"
                                                                        >
                                                                            Aus
                                                                        </option>
                                                                    </select>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <div
                                                                class="form-group"
                                                            >
                                                                <label
                                                                    for="company"
                                                                    class="form-label"
                                                                    >PBU</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <select
                                                                        class="form-select"
                                                                        id="country"
                                                                        data-search="true"
                                                                        data-sort="false"
                                                                    >
                                                                        <option
                                                                            value=""
                                                                        >
                                                                            Select
                                                                            Options
                                                                        </option>
                                                                        <option
                                                                            value="1"
                                                                        >
                                                                            Germany
                                                                        </option>
                                                                        <option
                                                                            value="2"
                                                                        >
                                                                            Canada
                                                                        </option>
                                                                        <option
                                                                            value="3"
                                                                        >
                                                                            Usa
                                                                        </option>
                                                                        <option
                                                                            value="4"
                                                                        >
                                                                            Aus
                                                                        </option>
                                                                    </select>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-12">
                                                            <div
                                                                class="form-group"
                                                            >
                                                                <label
                                                                    for="address"
                                                                    class="form-label"
                                                                    >Memorandum
                                                                    Registration
                                                                    No.</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <input
                                                                        type="text"
                                                                        class="form-control"
                                                                        id="address"
                                                                        placeholder=""
                                                                        value="UTeM-EN-1024"
                                                                    />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-12">
                                                            <div
                                                                class="form-group"
                                                            >
                                                                <label
                                                                    for="address"
                                                                    class="form-label"
                                                                    >Responsible
                                                                    PIC</label
                                                                >
                                                                <div
                                                                    class="input-group"
                                                                >
                                                                    <input
                                                                        type="text"
                                                                        class="form-control"
                                                                        aria-label="Recipient's username"
                                                                        aria-describedby="button-addon2"
                                                                        value="Dr. Ahmad Zulkifli"
                                                                    />
                                                                    <button
                                                                        class="btn btn-outline-primary"
                                                                        type="button"
                                                                        id="button-addon2"
                                                                        data-bs-toggle="modal"
                                                                        data-bs-target="#exampleModal"
                                                                    >
                                                                        Search
                                                                        Members
                                                                    </button>
                                                                </div>
                                                                <div
                                                                    class="modal fade"
                                                                    id="exampleModal"
                                                                    tabindex="-1"
                                                                    aria-labelledby="exampleModalLabel"
                                                                    aria-hidden="true"
                                                                >
                                                                    <div
                                                                        class="modal-dialog modal-lg"
                                                                    >
                                                                        <div
                                                                            class="modal-content"
                                                                        >
                                                                            <div
                                                                                class="modal-header"
                                                                            >
                                                                                <h5
                                                                                    class="modal-title"
                                                                                    id="exampleModalLabel"
                                                                                >
                                                                                    Responsible
                                                                                    PIC
                                                                                </h5>
                                                                                <button
                                                                                    type="button"
                                                                                    class="btn-close"
                                                                                    data-bs-dismiss="modal"
                                                                                    aria-label="Close"
                                                                                ></button>
                                                                            </div>
                                                                            <div
                                                                                class="modal-body"
                                                                            >
                                                                                <TableUserMgtComponent />
                                                                            </div>
                                                                            <div
                                                                                class="modal-footer"
                                                                            >
                                                                                <button
                                                                                    type="button"
                                                                                    class="btn btn-sm btn-secondary"
                                                                                    data-bs-dismiss="modal"
                                                                                >
                                                                                    Close
                                                                                </button>
                                                                                <button
                                                                                    type="button"
                                                                                    class="btn btn-sm btn-primary"
                                                                                >
                                                                                    Save
                                                                                    changes
                                                                                </button>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-12">
                                                            <router-link
                                                                to="/memo-list"
                                                                class="btn btn-secondary"
                                                            >
                                                                Save
                                                            </router-link>
                                                            &nbsp;
                                                            <router-link
                                                                to="/memo-edit-member"
                                                                class="btn btn-primary"
                                                            >
                                                                Next
                                                            </router-link>
                                                        </div>
                                                    </div>
                                                </form>
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
import TableUserMgtComponent from "@/components/TableUser.vue";

export default {
    name: "MemoEditView",
    components: {
        NavbarComponent,
        TopNavComponent,
        TableUserMgtComponent,
    },
};
</script>
