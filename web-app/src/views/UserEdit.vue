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
                                                <div
                                                    class="d-flex flex-column flex-md-row align-items-md-center"
                                                >
                                                    <div
                                                        class="media media-huge media-circle"
                                                    >
                                                        <img
                                                            src="../assets/images/avatar/a.jpg"
                                                            class="img-thumbnail"
                                                            alt=""
                                                        />
                                                    </div>
                                                    <div
                                                        class="mt-3 mt-md-0 ms-md-3"
                                                    >
                                                        <h3 class="title mb-1">
                                                            Khalid Ibrahim
                                                        </h3>
                                                        <span class="small"
                                                            >IT Support</span
                                                        >
                                                    </div>
                                                </div>
                                            </div>
                                            <!-- .nk-block-head-content -->
                                            <div class="nk-block-head-content">
                                                <ul class="d-flex gap g-2">
                                                    <li
                                                        class="d-none d-md-block"
                                                    >
                                                        <!-- CTA button  -->
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
                                    <div class="card card-gutter-md">
                                        <div class="card-body">
                                            <div class="bio-block">
                                                <h4
                                                    class="bio-block-title mb-4"
                                                >
                                                    Edit Profile
                                                </h4>
                                                <form action="#">
                                                    <div class="row g-3">
                                                        <div class="col-lg-6">
                                                            <div
                                                                class="form-group"
                                                            >
                                                                <label
                                                                    for="firstname"
                                                                    class="form-label"
                                                                    >First
                                                                    Name</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <input
                                                                        class="form-control"
                                                                        type="text"
                                                                        value="Khalid"
                                                                        aria-label="readonly input"
                                                                        readonly
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
                                                                    >Last
                                                                    Name</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <input
                                                                        class="form-control"
                                                                        type="text"
                                                                        value="Ibrahim"
                                                                        aria-label="readonly input"
                                                                        readonly
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
                                                                    >Email
                                                                    address</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <input
                                                                        class="form-control"
                                                                        type="text"
                                                                        value="khalid@utem.edu.my"
                                                                        aria-label="readonly input"
                                                                        readonly
                                                                    />
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
                                                                    >username</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <input
                                                                        class="form-control"
                                                                        type="text"
                                                                        value="-"
                                                                        aria-label="readonly input"
                                                                        readonly
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
                                                                    >Tel
                                                                    Number</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <input
                                                                        class="form-control"
                                                                        type="text"
                                                                        value="+60123456789"
                                                                        aria-label="readonly input"
                                                                        readonly
                                                                    />
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
                                                                    >Alamat</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <input
                                                                        class="form-control"
                                                                        type="text"
                                                                        value="-"
                                                                        aria-label="readonly input"
                                                                        readonly
                                                                    />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <div
                                                                class="form-group"
                                                            >
                                                                <label
                                                                    class="form-label"
                                                                    >Roles</label
                                                                >
                                                                <div
                                                                    class="form-check"
                                                                >
                                                                    <input
                                                                        class="form-check-input"
                                                                        type="checkbox"
                                                                        value=""
                                                                        id="flexCheckDefault"
                                                                    />
                                                                    <label
                                                                        class="form-check-label"
                                                                        for="flexCheckDefault"
                                                                    >
                                                                        PUU
                                                                    </label>
                                                                </div>
                                                                <div
                                                                    class="form-check"
                                                                >
                                                                    <input
                                                                        class="form-check-input"
                                                                        type="checkbox"
                                                                        value=""
                                                                        id="flexCheckDefault"
                                                                    />
                                                                    <label
                                                                        class="form-check-label"
                                                                        for="flexCheckDefault"
                                                                    >
                                                                        PTJ
                                                                    </label>
                                                                </div>
                                                                <div
                                                                    class="form-check"
                                                                >
                                                                    <input
                                                                        class="form-check-input"
                                                                        type="checkbox"
                                                                        value=""
                                                                        id="flexCheckDefault"
                                                                    />
                                                                    <label
                                                                        class="form-check-label"
                                                                        for="flexCheckDefault"
                                                                    >
                                                                        Administrator
                                                                    </label>
                                                                </div>
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <select
                                                                        class="js-select"
                                                                        multiple
                                                                        data-search="true"
                                                                        data-sort="false"
                                                                    >
                                                                        <option
                                                                            value=""
                                                                        >
                                                                            Select
                                                                            Roles
                                                                        </option>
                                                                        <option
                                                                            value="1"
                                                                        >
                                                                            PTJ
                                                                        </option>
                                                                        <option
                                                                            value="2"
                                                                        >
                                                                            PUU
                                                                        </option>
                                                                        <option
                                                                            value="3"
                                                                        >
                                                                            Administrator
                                                                        </option>
                                                                    </select>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <label
                                                                for="email"
                                                                class="form-label"
                                                                >Status</label
                                                            >
                                                            <div
                                                                class="form-check form-switch"
                                                            >
                                                                <input
                                                                    class="form-check-input"
                                                                    type="checkbox"
                                                                    value=""
                                                                    id="flexSwitchDefault"
                                                                />
                                                                <label
                                                                    class="form-check-label"
                                                                    for="flexSwitchDefault"
                                                                >
                                                                    Inactive/Active
                                                                </label>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-12">
                                                            <router-link
                                                                to="/user-list"
                                                                class="btn btn-primary"
                                                            >
                                                                Update Profile
                                                            </router-link>
                                                        </div>
                                                    </div>
                                                </form>
                                            </div>
                                            <!-- .bio-block -->
                                        </div>
                                        <!-- .card-body -->
                                    </div>
                                    <!-- .card -->
                                </div>
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
                                                src="../assets/images/product/a.jpg"
                                                alt=""
                                                class="img-thumbnail"
                                            />
                                        </div>
                                    </li>
                                    <li>
                                        <div class="media media-xxl">
                                            <img
                                                src="../assets/images/product/b.jpg"
                                                alt=""
                                                class="img-thumbnail"
                                            />
                                        </div>
                                    </li>
                                    <li>
                                        <div class="media media-xxl">
                                            <img
                                                src="../assets/images/product/c.jpg"
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
                                                        src="../assets/images/icon/file-type-pdf.svg"
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
                                                        src="../assets/images/icon/file-type-doc.svg"
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
                                                        src="../assets/images/icon/file-type-code.svg"
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
import "../assets/js/bundle.js";
// import "../assets/js/scripts.js";
// import "../assets/js/data-tables/data-tables.js";

import NavbarComponent from "@/components/Navbar.vue";
import TopNavComponent from "@/components/TopNav.vue";

export default {
    name: "MemoAddView",
    components: {
        NavbarComponent,
        TopNavComponent,
    },
};
</script>
