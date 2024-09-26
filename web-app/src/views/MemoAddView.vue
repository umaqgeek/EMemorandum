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
                                                    Add New Memorandum
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
                                                            to="/memo-add"
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
                                                            to="/memo-add-member"
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
                                                            to="/memo-add-kpi"
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
                                                                    ></textarea>
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
                                                                    for="firstname"
                                                                    class="form-label"
                                                                    >Start
                                                                    Date</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <input
                                                                        type="text"
                                                                        class="form-control"
                                                                        id="firstname"
                                                                        placeholder="First name"
                                                                    />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <div
                                                                class="form-group"
                                                            >
                                                                <label
                                                                    for="lastname"
                                                                    class="form-label"
                                                                    >End
                                                                    Date</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <input
                                                                        type="text"
                                                                        class="form-control"
                                                                        id="lastname"
                                                                        placeholder="Last name"
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
                                                                        placeholder="MoA...."
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
                                                                        placeholder="Select PIC"
                                                                        aria-label="Recipient's username"
                                                                        aria-describedby="button-addon2"
                                                                    />
                                                                    <button
                                                                        class="btn btn-outline-primary"
                                                                        type="button"
                                                                        id="button-addon2"
                                                                        data-bs-toggle="modal"
                                                                        data-bs-target="#exampleModal"
                                                                    >
                                                                        Serach
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
                                                                to="/memo-add-member"
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

        <div
            class="offcanvas offcanvas-end offcanvas-size-lg"
            id="notificationOffcanvas"
        >
            <div class="offcanvas-header border-bottom border-light">
                <h5 class="offcanvas-title" id="offcanvasTopLabel">
                    Recent Notification
                </h5>
                <button
                    type="button"
                    class="btn-close"
                    data-bs-dismiss="offcanvas"
                    aria-label="Close"
                ></button>
            </div>
            <div class="offcanvas-body" data-simplebar>
                <ul class="nk-schedule">
                    <li class="nk-schedule-item">
                        <div class="nk-schedule-item-inner">
                            <div class="nk-schedule-symbol active"></div>
                            <div class="nk-schedule-content">
                                <span class="smaller">2:12 PM</span>
                                <div class="h6">Added 3 New Images</div>
                                <ul class="d-flex flex-wrap gap g-2 py-2">
                                    <li>
                                        <div class="media media-xxl">
                                            <img
                                                src="/assets/images/product/a.jpg"
                                                alt=""
                                                class="img-thumbnail"
                                            />
                                        </div>
                                    </li>
                                    <li>
                                        <div class="media media-xxl">
                                            <img
                                                src="/assets/images/product/b.jpg"
                                                alt=""
                                                class="img-thumbnail"
                                            />
                                        </div>
                                    </li>
                                    <li>
                                        <div class="media media-xxl">
                                            <img
                                                src="/assets/images/product/c.jpg"
                                                alt=""
                                                class="img-thumbnail"
                                            />
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </li>
                    <li class="nk-schedule-item">
                        <div class="nk-schedule-item-inner">
                            <div class="nk-schedule-symbol active"></div>
                            <div class="nk-schedule-content">
                                <span class="smaller">4:23 PM</span>
                                <div class="h6">
                                    Invitation for creative designs pattern
                                </div>
                            </div>
                        </div>
                    </li>
                    <li class="nk-schedule-item">
                        <div class="nk-schedule-item-inner">
                            <div class="nk-schedule-symbol active"></div>
                            <div
                                class="nk-schedule-content nk-schedule-content-no-border"
                            >
                                <span class="smaller">10:30 PM</span>
                                <div class="h6">
                                    Task report - uploaded weekly reports
                                </div>
                                <div class="list-group-dotted mt-3">
                                    <div class="list-group-wrap">
                                        <div class="p-3">
                                            <div class="media-group">
                                                <div class="media rounded-0">
                                                    <img
                                                        src="/assets/images/icon/file-type-pdf.svg"
                                                        alt=""
                                                    />
                                                </div>
                                                <div class="media-text ms-1">
                                                    <a href="#" class="title"
                                                        >Modern Designs
                                                        Pattern</a
                                                    >
                                                    <span class="text smaller"
                                                        >1.6.mb</span
                                                    >
                                                </div>
                                            </div>
                                            <!-- .media-group -->
                                        </div>
                                        <div class="p-3">
                                            <div class="media-group">
                                                <div class="media rounded-0">
                                                    <img
                                                        src="/assets/images/icon/file-type-doc.svg"
                                                        alt=""
                                                    />
                                                </div>
                                                <div class="media-text ms-1">
                                                    <a href="#" class="title"
                                                        >Cpanel Upload
                                                        Guidelines</a
                                                    >
                                                    <span class="text smaller"
                                                        >18kb</span
                                                    >
                                                </div>
                                            </div>
                                            <!-- .media-group -->
                                        </div>
                                        <div class="p-3">
                                            <div class="media-group">
                                                <div class="media rounded-0">
                                                    <img
                                                        src="/assets/images/icon/file-type-code.svg"
                                                        alt=""
                                                    />
                                                </div>
                                                <div class="media-text ms-1">
                                                    <a href="#" class="title"
                                                        >Weekly Finance
                                                        Reports</a
                                                    >
                                                    <span class="text smaller"
                                                        >10mb</span
                                                    >
                                                </div>
                                            </div>
                                            <!-- .media-group -->
                                        </div>
                                    </div>
                                </div>
                                <!-- .list-group-dotted -->
                            </div>
                        </div>
                    </li>
                    <li class="nk-schedule-item">
                        <div class="nk-schedule-item-inner">
                            <div class="nk-schedule-symbol active"></div>
                            <div class="nk-schedule-content">
                                <span class="smaller">3:23 PM</span>
                                <div class="h6">
                                    Assigned you to new database design project
                                </div>
                            </div>
                        </div>
                    </li>
                    <li class="nk-schedule-item">
                        <div class="nk-schedule-item-inner">
                            <div class="nk-schedule-symbol active"></div>
                            <div
                                class="nk-schedule-content nk-schedule-content-no-border flex-grow-1"
                            >
                                <span class="smaller">5:05 PM</span>
                                <div class="h6">
                                    You have received a new order
                                </div>
                                <div class="alert alert-info mt-2" role="alert">
                                    <div class="d-flex">
                                        <em
                                            class="icon icon-lg ni ni-file-code opacity-75"
                                        ></em>
                                        <div
                                            class="ms-2 d-flex flex-wrap flex-grow-1 justify-content-between"
                                        >
                                            <div>
                                                <h6 class="alert-heading mb-0">
                                                    Business Template - UI/UX
                                                    design
                                                </h6>
                                                <span class="smaller"
                                                    >Shared information with
                                                    your team to understand and
                                                    contribute to your
                                                    project.</span
                                                >
                                            </div>
                                            <div class="d-block mt-1">
                                                <a
                                                    href="#"
                                                    class="btn btn-md btn-info"
                                                    ><em
                                                        class="icon ni ni-download"
                                                    ></em
                                                    ><span>Download</span></a
                                                >
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- .alert -->
                            </div>
                        </div>
                    </li>
                    <li class="nk-schedule-item">
                        <div class="nk-schedule-item-inner">
                            <div class="nk-schedule-symbol active"></div>
                            <div class="nk-schedule-content">
                                <span class="smaller">2:45 PM</span>
                                <div class="h6">
                                    Project status updated successfully
                                </div>
                            </div>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <!-- .nk-app-root -->
</template>

<!-- JavaScript -->
<script>
import NavbarComponent from "@/components/Navbar.vue";
import TopNavComponent from "@/components/TopNav.vue";
import TableUserMgtComponent from "@/components/TableUser.vue";

export default {
    name: "MemoAddView",
    components: {
        NavbarComponent,
        TopNavComponent,
        TableUserMgtComponent,
    },
};
</script>
