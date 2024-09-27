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
                                            class="nk-block-head-between flex-wrap gap g-2 align-items-start"
                                        >
                                            <div class="nk-block-head-content">
                                                <h2>Memorandum Details</h2>
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
                                    <div class="nk-block-head-between gap g-2">
                                        <div class="gap-col">
                                            <ul
                                                class="nav nav-pills nav-pills-border gap g-3"
                                            >
                                                <li class="nav-item">
                                                    <button
                                                        class="nav-link active"
                                                        data-bs-toggle="tab"
                                                        data-bs-target="#tab-1"
                                                        type="button"
                                                    >
                                                        Overview
                                                    </button>
                                                </li>
                                                <li class="nav-item">
                                                    <button
                                                        class="nav-link"
                                                        type="button"
                                                    >
                                                        Members
                                                    </button>
                                                </li>
                                                <li class="nav-item">
                                                    <button
                                                        class="nav-link"
                                                        type="button"
                                                    >
                                                        KPI
                                                    </button>
                                                </li>
                                            </ul>
                                        </div>
                                        <div class="gap-col">
                                            <ul class="d-flex gap g-2">
                                                <li class="d-none d-md-block">
                                                    <router-link
                                                        to="/approval-list"
                                                        class="btn btn-soft btn-danger"
                                                        ><span>Reject</span>
                                                    </router-link>
                                                </li>
                                                <li class="d-none d-md-block">
                                                    <router-link
                                                        to="/approval-list"
                                                        class="btn btn-soft btn-primary"
                                                    >
                                                        <span>Approve</span>
                                                    </router-link>
                                                </li>
                                                <li class="d-none">
                                                    <a
                                                        href="./html/user-manage/user-edit.html"
                                                        class="btn btn-soft btn-primary btn-icon"
                                                    >
                                                    </a>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <!-- .nk-block-head-between -->
                                </div>
                                <!-- .nk-block-head -->
                                <div class="nk-block">
                                    <div class="tab-content" id="myTabContent">
                                        <div
                                            class="tab-pane show active"
                                            id="tab-1"
                                            tabindex="0"
                                        >
                                            <div class="card card-gutter-md">
                                                <div
                                                    class="card-row card-row-lg col-sep col-sep-lg"
                                                >
                                                    <div class="card-aside">
                                                        <div class="card-body">
                                                            <div
                                                                class="bio-block"
                                                            >
                                                                <h4
                                                                    class="bio-block-title"
                                                                >
                                                                    Details
                                                                </h4>
                                                                <ul
                                                                    class="list-group list-group-borderless small"
                                                                >
                                                                    <li
                                                                        class="list-group-item"
                                                                    >
                                                                        <span
                                                                            class="title fw-medium w-40 d-inline-block"
                                                                            >No.
                                                                            Memorandum:</span
                                                                        >
                                                                        <span
                                                                            class="text"
                                                                            >MoA(TP),13.2.2023.010000.007
                                                                        </span>
                                                                    </li>
                                                                    <li
                                                                        class="list-group-item"
                                                                    >
                                                                        <span
                                                                            class="title fw-medium w-40 d-inline-block"
                                                                            >Skop
                                                                            Memorandum:</span
                                                                        >
                                                                        <span
                                                                            class="text"
                                                                            >Kerahsiaan</span
                                                                        >
                                                                    </li>
                                                                    <li
                                                                        class="list-group-item"
                                                                    >
                                                                        <span
                                                                            class="title fw-medium w-40 d-inline-block"
                                                                            >Staff
                                                                            Name:</span
                                                                        >
                                                                        <span
                                                                            class="text"
                                                                            >Florenza
                                                                            Desporte</span
                                                                        >
                                                                    </li>
                                                                    <li
                                                                        class="list-group-item"
                                                                    >
                                                                        <span
                                                                            class="title fw-medium w-40 d-inline-block"
                                                                            >Start
                                                                            Date</span
                                                                        >
                                                                        <span
                                                                            class="text"
                                                                            >25
                                                                            Dec
                                                                            2021</span
                                                                        >
                                                                    </li>
                                                                    <li
                                                                        class="list-group-item"
                                                                    >
                                                                        <span
                                                                            class="title fw-medium w-40 d-inline-block"
                                                                            >End
                                                                            Date</span
                                                                        >
                                                                        <span
                                                                            class="text"
                                                                            >24
                                                                            Dec
                                                                            2021</span
                                                                        >
                                                                    </li>
                                                                    <li
                                                                        class="list-group-item"
                                                                    >
                                                                        <span
                                                                            class="title fw-medium w-40 d-inline-block"
                                                                            >Price
                                                                            (RM):</span
                                                                        >
                                                                        <span
                                                                            class="text"
                                                                            >0.00</span
                                                                        >
                                                                    </li>
                                                                </ul>
                                                            </div>
                                                            <!-- .bio-block -->
                                                        </div>
                                                        <!-- .card-body -->
                                                    </div>
                                                    <div
                                                        class="card-content col-sep"
                                                    >
                                                        <div class="card-body">
                                                            <div
                                                                class="bio-block"
                                                            >
                                                                <h4
                                                                    class="bio-block-title"
                                                                >
                                                                    Project
                                                                    Title
                                                                </h4>
                                                                <p>
                                                                    Mauris
                                                                    varius
                                                                    tellus vitae
                                                                    tristique
                                                                    sagittis.
                                                                    Sed aliquet,
                                                                    est nec
                                                                    auctor
                                                                    aliquet,
                                                                    orci ex
                                                                    vestibulum
                                                                    ex, non
                                                                    pharetra
                                                                    lacus erat
                                                                    ac nulla.
                                                                </p>
                                                                <p>
                                                                    Sed
                                                                    vulputate,
                                                                    ligula eget
                                                                    mollis
                                                                    auctor,
                                                                    lectus elit
                                                                    feugiat
                                                                    urna, eget
                                                                    euismod
                                                                    turpis
                                                                    lectus sed
                                                                    ex. Orci
                                                                    varius
                                                                    natoque
                                                                    penatibus et
                                                                    magnis dis
                                                                    parturient
                                                                    montes,
                                                                    nascetur
                                                                    ridiculus
                                                                    mus. Nunc ut
                                                                    velit
                                                                    finibus,
                                                                    scelerisque
                                                                    sapien
                                                                    vitae,
                                                                    pharetra
                                                                    est. Nunc
                                                                    accumsan
                                                                    ligula
                                                                    vehicula
                                                                    scelerisque
                                                                    vulputate.
                                                                    Lorem ipsum
                                                                    dolor sit,
                                                                    amet
                                                                    consectetur
                                                                    adipisicing
                                                                    elit.
                                                                    Deleniti,
                                                                    dolore?
                                                                </p>
                                                            </div>
                                                            <!-- .bio-block -->
                                                        </div>
                                                        <!-- .card-body -->
                                                        <div class="card-body">
                                                            <div
                                                                class="bio-block"
                                                            >
                                                                <h4
                                                                    class="bio-block-title"
                                                                >
                                                                    Recent
                                                                    Activity
                                                                </h4>
                                                                <ul
                                                                    class="nk-schedule mt-4"
                                                                >
                                                                    <li
                                                                        class="nk-schedule-item"
                                                                    >
                                                                        <div
                                                                            class="nk-schedule-item-inner"
                                                                        >
                                                                            <div
                                                                                class="nk-schedule-symbol active"
                                                                            ></div>
                                                                            <div
                                                                                class="nk-schedule-content"
                                                                            >
                                                                                <span
                                                                                    class="smaller"
                                                                                    >2:12
                                                                                    PM</span
                                                                                >
                                                                                <div
                                                                                    class="h6"
                                                                                >
                                                                                    Added
                                                                                    3
                                                                                    New
                                                                                    Images
                                                                                </div>
                                                                                <ul
                                                                                    class="d-flex flex-wrap gap g-2 py-2"
                                                                                >
                                                                                    <li>
                                                                                        <div
                                                                                            class="media media-xxl"
                                                                                        >
                                                                                            <img
                                                                                                src="../assets/images/product/a.jpg"
                                                                                                alt=""
                                                                                                class="img-thumbnail"
                                                                                            />
                                                                                        </div>
                                                                                    </li>
                                                                                    <li>
                                                                                        <div
                                                                                            class="media media-xxl"
                                                                                        >
                                                                                            <img
                                                                                                src="../assets/images/product/b.jpg"
                                                                                                alt=""
                                                                                                class="img-thumbnail"
                                                                                            />
                                                                                        </div>
                                                                                    </li>
                                                                                    <li>
                                                                                        <div
                                                                                            class="media media-xxl"
                                                                                        >
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
                                                                    <li
                                                                        class="nk-schedule-item"
                                                                    >
                                                                        <div
                                                                            class="nk-schedule-item-inner"
                                                                        >
                                                                            <div
                                                                                class="nk-schedule-symbol active"
                                                                            ></div>
                                                                            <div
                                                                                class="nk-schedule-content"
                                                                            >
                                                                                <span
                                                                                    class="smaller"
                                                                                    >4:23
                                                                                    PM</span
                                                                                >
                                                                                <div
                                                                                    class="h6"
                                                                                >
                                                                                    Invitation
                                                                                    for
                                                                                    creative
                                                                                    designs
                                                                                    pattern
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </li>
                                                                    <li
                                                                        class="nk-schedule-item"
                                                                    >
                                                                        <div
                                                                            class="nk-schedule-item-inner"
                                                                        >
                                                                            <div
                                                                                class="nk-schedule-symbol active"
                                                                            ></div>
                                                                            <div
                                                                                class="nk-schedule-content nk-schedule-content-no-border"
                                                                            >
                                                                                <span
                                                                                    class="smaller"
                                                                                    >10:30
                                                                                    PM</span
                                                                                >
                                                                                <div
                                                                                    class="h6"
                                                                                >
                                                                                    Task
                                                                                    report
                                                                                    -
                                                                                    uploaded
                                                                                    weekly
                                                                                    reports
                                                                                </div>
                                                                                <div
                                                                                    class="list-group-dotted mt-3"
                                                                                >
                                                                                    <div
                                                                                        class="list-group-wrap"
                                                                                    >
                                                                                        <div
                                                                                            class="p-3"
                                                                                        >
                                                                                            <div
                                                                                                class="media-group"
                                                                                            >
                                                                                                <div
                                                                                                    class="media rounded-0"
                                                                                                >
                                                                                                    <img
                                                                                                        src="../assets/images/icon/file-type-pdf.svg"
                                                                                                        alt=""
                                                                                                    />
                                                                                                </div>
                                                                                                <div
                                                                                                    class="media-text ms-1"
                                                                                                >
                                                                                                    <a
                                                                                                        href="#"
                                                                                                        class="title"
                                                                                                        >Modern
                                                                                                        Designs
                                                                                                        Pattern</a
                                                                                                    >
                                                                                                    <span
                                                                                                        class="text smaller"
                                                                                                        >1.6.mb</span
                                                                                                    >
                                                                                                </div>
                                                                                            </div>
                                                                                            <!-- .media-group -->
                                                                                        </div>
                                                                                        <div
                                                                                            class="p-3"
                                                                                        >
                                                                                            <div
                                                                                                class="media-group"
                                                                                            >
                                                                                                <div
                                                                                                    class="media rounded-0"
                                                                                                >
                                                                                                    <img
                                                                                                        src="../assets/images/icon/file-type-doc.svg"
                                                                                                        alt=""
                                                                                                    />
                                                                                                </div>
                                                                                                <div
                                                                                                    class="media-text ms-1"
                                                                                                >
                                                                                                    <a
                                                                                                        href="#"
                                                                                                        class="title"
                                                                                                        >cPanel
                                                                                                        Upload
                                                                                                        Guidelines</a
                                                                                                    >
                                                                                                    <span
                                                                                                        class="text smaller"
                                                                                                        >18kb</span
                                                                                                    >
                                                                                                </div>
                                                                                            </div>
                                                                                            <!-- .media-group -->
                                                                                        </div>
                                                                                        <div
                                                                                            class="p-3"
                                                                                        >
                                                                                            <div
                                                                                                class="media-group"
                                                                                            >
                                                                                                <div
                                                                                                    class="media rounded-0"
                                                                                                >
                                                                                                    <img
                                                                                                        src="../assets/images/icon/file-type-code.svg"
                                                                                                        alt=""
                                                                                                    />
                                                                                                </div>
                                                                                                <div
                                                                                                    class="media-text ms-1"
                                                                                                >
                                                                                                    <a
                                                                                                        href="#"
                                                                                                        class="title"
                                                                                                        >Weekly
                                                                                                        Finance
                                                                                                        Reports</a
                                                                                                    >
                                                                                                    <span
                                                                                                        class="text smaller"
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
                                                                    <li
                                                                        class="nk-schedule-item"
                                                                    >
                                                                        <div
                                                                            class="nk-schedule-item-inner"
                                                                        >
                                                                            <div
                                                                                class="nk-schedule-symbol active"
                                                                            ></div>
                                                                            <div
                                                                                class="nk-schedule-content nk-schedule-content-no-border flex-grow-1"
                                                                            >
                                                                                <span
                                                                                    class="smaller"
                                                                                    >5:05
                                                                                    PM</span
                                                                                >
                                                                                <div
                                                                                    class="h6"
                                                                                >
                                                                                    You
                                                                                    have
                                                                                    upload
                                                                                    new
                                                                                    memorandum
                                                                                </div>
                                                                                <div
                                                                                    class="alert alert-info mt-2"
                                                                                    role="alert"
                                                                                >
                                                                                    <div
                                                                                        class="d-flex"
                                                                                    >
                                                                                        <em
                                                                                            class="icon icon-lg ni ni-file-code opacity-75"
                                                                                        ></em>
                                                                                        <div
                                                                                            class="ms-2 d-flex flex-wrap flex-grow-1 justify-content-between"
                                                                                        >
                                                                                            <div>
                                                                                                <h6
                                                                                                    class="alert-heading mb-0"
                                                                                                >
                                                                                                    Memorandum
                                                                                                    -
                                                                                                    Final
                                                                                                    v2
                                                                                                </h6>
                                                                                                <span
                                                                                                    class="smaller"
                                                                                                    >Hak
                                                                                                    milik
                                                                                                    kerajaan
                                                                                                    UTeM.</span
                                                                                                >
                                                                                            </div>
                                                                                            <div
                                                                                                class="d-block mt-1"
                                                                                            >
                                                                                                <a
                                                                                                    href="#"
                                                                                                    class="btn btn-md btn-info"
                                                                                                    ><em
                                                                                                        class="icon ni ni-download"
                                                                                                    ></em
                                                                                                    ><span
                                                                                                        >Download</span
                                                                                                    ></a
                                                                                                >
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                                <!-- .alert -->
                                                                            </div>
                                                                        </div>
                                                                    </li>
                                                                </ul>
                                                            </div>
                                                            <!-- .bio-block -->
                                                        </div>
                                                        <!-- .card-body -->
                                                        <div class="card-body">
                                                            <div
                                                                class="bio-block"
                                                            >
                                                                <h4
                                                                    class="bio-block-title"
                                                                >
                                                                    Comments
                                                                </h4>
                                                                <div
                                                                    class="js-quill"
                                                                    data-toolbar="minimal"
                                                                    data-placeholder="Write some awesome text"
                                                                ></div>

                                                                <div
                                                                    class="form-group"
                                                                >
                                                                    <div
                                                                        class="form-control-wrap"
                                                                    >
                                                                        <textarea
                                                                            placeholder="Write your review"
                                                                            class="form-control"
                                                                            id="exampleFormControlTextarea8"
                                                                            rows="3"
                                                                        ></textarea>
                                                                    </div>
                                                                </div>
                                                                <div
                                                                    class="mt-3"
                                                                >
                                                                    <ul
                                                                        class="d-flex gap g-2 justify-content-end"
                                                                    >
                                                                        <li
                                                                            class="d-none d-md-block"
                                                                        >
                                                                            <router-link
                                                                                to="/approval-list"
                                                                                class="btn btn-soft btn-danger"
                                                                                ><span
                                                                                    >Reject</span
                                                                                >
                                                                            </router-link>
                                                                        </li>
                                                                        <li
                                                                            class="d-none d-md-block"
                                                                        >
                                                                            <router-link
                                                                                to="/approval-list"
                                                                                class="btn btn-soft btn-primary"
                                                                            >
                                                                                <span
                                                                                    >Approve</span
                                                                                >
                                                                            </router-link>
                                                                        </li>
                                                                        <li
                                                                            class="d-none"
                                                                        >
                                                                            <a
                                                                                href="./html/user-manage/user-edit.html"
                                                                                class="btn btn-soft btn-primary btn-icon"
                                                                            >
                                                                            </a>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- .card-content -->
                                                </div>
                                                <!-- .card-row -->
                                            </div>
                                            <!-- .card -->
                                        </div>
                                        <!-- .tab-pane -->
                                    </div>
                                    <!-- .tab-content -->
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
        <!-- Modal -->
        <div
            class="modal fade"
            id="addUserModal"
            tabindex="-1"
            aria-labelledby="addUserModalLabel"
            aria-hidden="true"
        >
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="addUserModalLabel">
                            Add User
                        </h4>
                        <button
                            type="button"
                            class="btn-close"
                            data-bs-dismiss="modal"
                            aria-label="Close"
                        ></button>
                    </div>
                    <!-- .modal-header -->
                    <div class="modal-body">
                        <form action="#">
                            <div class="row g-3">
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label
                                            for="firstname"
                                            class="form-label"
                                            >First Name</label
                                        >
                                        <div class="form-control-wrap">
                                            <input
                                                type="text"
                                                class="form-control"
                                                placeholder="First name"
                                            />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label for="lastname" class="form-label"
                                            >Last Name</label
                                        >
                                        <div class="form-control-wrap">
                                            <input
                                                type="text"
                                                class="form-control"
                                                placeholder="Last name"
                                            />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label for="email" class="form-label"
                                            >Email Address</label
                                        >
                                        <div class="form-control-wrap">
                                            <input
                                                type="text"
                                                class="form-control"
                                                placeholder="Email address"
                                            />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group">
                                        <label for="status" class="form-label"
                                            >Status</label
                                        >
                                        <div class="form-control-wrap">
                                            <select
                                                class="js-select"
                                                data-search="true"
                                                data-sort="false"
                                            >
                                                <option value="">
                                                    Select a status
                                                </option>
                                                <option value="1">
                                                    Pending
                                                </option>
                                                <option value="2">
                                                    Active
                                                </option>
                                                <option value="3">
                                                    Inactive
                                                </option>
                                            </select>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label for="role" class="form-label"
                                            >Role</label
                                        >
                                        <div class="form-control-wrap">
                                            <select
                                                class="js-select"
                                                data-search="true"
                                                data-sort="false"
                                            >
                                                <option value="">
                                                    Select a role
                                                </option>
                                                <option value="1">
                                                    Administrator
                                                </option>
                                                <option value="2">
                                                    Developer
                                                </option>
                                                <option value="3">
                                                    Analyst
                                                </option>
                                                <option value="4">
                                                    Support
                                                </option>
                                                <option value="5">Trial</option>
                                            </select>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="d-flex gap g-2">
                                        <div class="gap-col">
                                            <button
                                                class="btn btn-primary"
                                                type="submit"
                                            >
                                                Add User
                                            </button>
                                        </div>
                                        <div class="gap-col">
                                            <button
                                                type="button"
                                                class="btn border-0"
                                                data-bs-dismiss="modal"
                                            >
                                                Discard
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </form>
                    </div>
                    <!-- .modal-body -->
                </div>
            </div>
        </div>
        <!-- .modal -->
    </div>
    <!-- .nk-app-root -->
</template>

<!-- JavaScript -->
<script>
import NavbarComponent from "@/components/Navbar.vue";
import TopNavComponent from "@/components/TopNav.vue";

export default {
    name: "MemoDetailsView",
    components: {
        NavbarComponent,
        TopNavComponent,
    },
};
</script>
