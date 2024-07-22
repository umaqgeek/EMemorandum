<template>
    <!-- Root @s -->
    <div class="nk-app-root">
        <!-- main @s -->
        <div class="nk-main">
            <div class="nk-sidebar nk-sidebar-fixed is-theme" id="sidebar">
                <div class="nk-sidebar-element nk-sidebar-head">
                    <div class="nk-sidebar-brand">
                        <a href="./html/index.html" class="logo-link">
                            <div class="logo-wrap">
                                <img
                                    class="logo-img logo-light"
                                    src="../assets/images/LogoUTeM.webp"
                                    srcset="../assets/images/LogoUTeM.webp 2x"
                                    alt=""
                                />
                                <img
                                    class="logo-img logo-dark"
                                    src="../assets/images/LogoUTeM.webp"
                                    srcset="../assets/images/LogoUTeM.webp 2x"
                                    alt=""
                                />
                                <img
                                    class="logo-img logo-icon"
                                    src="../assets/images/LogoUTeM.webp"
                                    srcset="../assets/images/LogoUTeM.webp 2x"
                                    alt=""
                                />
                            </div>
                        </a>
                        <div class="nk-compact-toggle me-n1">
                            <button
                                class="btn btn-md btn-icon text-light btn-no-hover compact-toggle"
                            >
                                <em class="icon off ni ni-chevrons-left"></em>
                                <em class="icon on ni ni-chevrons-right"></em>
                            </button>
                        </div>
                        <div class="nk-sidebar-toggle me-n1">
                            <button
                                class="btn btn-md btn-icon text-light btn-no-hover sidebar-toggle"
                            >
                                <em class="icon ni ni-arrow-left"></em>
                            </button>
                        </div>
                    </div>
                    <!-- end nk-sidebar-brand -->
                </div>
                <!-- end nk-sidebar-element -->
                <div class="nk-sidebar-element nk-sidebar-body">
                    <div class="nk-sidebar-content">
                        <div class="nk-sidebar-menu" data-simplebar>
                            <ul class="nk-menu">
                                <li class="nk-menu-heading">
                                    <h6 class="overline-title">Applications</h6>
                                </li>
                                <li class="nk-menu-item">
                                    <a
                                        href="./html/memo/memo-list.html"
                                        class="nk-menu-link"
                                    >
                                        <span class="nk-menu-icon"
                                            ><em
                                                class="icon ni ni-chat-circle"
                                            ></em
                                        ></span>
                                        <span class="nk-menu-text"
                                            >Memorandum</span
                                        >
                                    </a>
                                </li>
                            </ul>
                            <!-- .nk-menu -->
                        </div>
                        <!-- .nk-sidebar-menu -->
                    </div>
                    <!-- .nk-sidebar-content -->
                </div>
                <!-- .nk-sidebar-element -->
            </div>
            <!-- .nki-sidebar -->
            <!-- sidebar @e -->
            <!-- wrap @s -->
            <div class="nk-wrap">
                <div class="nk-header nk-header-fixed">
                    <div class="container-fluid">
                        <div class="nk-header-wrap">
                            <div class="nk-header-logo ms-n1">
                                <div class="nk-sidebar-toggle">
                                    <button
                                        class="btn btn-sm btn-icon btn-zoom sidebar-toggle d-sm-none"
                                    >
                                        <em class="icon ni ni-menu"></em>
                                    </button>
                                    <button
                                        class="btn btn-md btn-icon btn-zoom sidebar-toggle d-none d-sm-inline-flex"
                                    >
                                        <em class="icon ni ni-menu"></em>
                                    </button>
                                </div>
                                <div class="nk-navbar-toggle me-2">
                                    <button
                                        class="btn btn-sm btn-icon btn-zoom navbar-toggle d-sm-none"
                                    >
                                        <em class="icon ni ni-menu-right"></em>
                                    </button>
                                    <button
                                        class="btn btn-md btn-icon btn-zoom navbar-toggle d-none d-sm-inline-flex"
                                    >
                                        <em class="icon ni ni-menu-right"></em>
                                    </button>
                                </div>
                                <a href="./html/index.html" class="logo-link">
                                    <div class="logo-wrap">
                                        <img
                                            class="logo-img logo-light"
                                            src="../assets/images/LogoUTeM.webp"
                                            srcset="
                                                ../assets/images/LogoUTeM.webp 2x
                                            "
                                            alt=""
                                        />
                                        <img
                                            class="logo-img logo-dark"
                                            src="../assets/images/LogoUTeM.webp"
                                            srcset="
                                                ../assets/images/LogoUTeM.webp 2x
                                            "
                                            alt=""
                                        />
                                        <img
                                            class="logo-img logo-icon"
                                            src="../assets/images/LogoUTeM.webp"
                                            srcset="
                                                ../assets/images/LogoUTeM.webp 2x
                                            "
                                            alt=""
                                        />
                                    </div>
                                </a>
                            </div>
                            <nav class="nk-header-menu nk-navbar">
                                <ul class="nk-nav"></ul>
                            </nav>
                            <div class="nk-header-tools">
                                <ul class="nk-quick-nav ms-2">
                                    <li class="dropdown">
                                        <button
                                            class="btn btn-icon btn-sm btn-zoom d-sm-none"
                                            data-bs-toggle="dropdown"
                                            data-bs-auto-close="outside"
                                        >
                                            <em class="icon ni ni-search"></em>
                                        </button>
                                        <button
                                            class="btn btn-icon btn-md btn-zoom d-none d-sm-inline-flex"
                                            data-bs-toggle="dropdown"
                                            data-bs-auto-close="outside"
                                        >
                                            <em class="icon ni ni-search"></em>
                                        </button>
                                        <div
                                            class="dropdown-menu dropdown-menu-lg"
                                        >
                                            <div
                                                class="dropdown-content dropdown-content-x-lg py-1"
                                            >
                                                <div class="search-inline">
                                                    <div
                                                        class="form-control-wrap flex-grow-1"
                                                    >
                                                        <input
                                                            placeholder="Type Query"
                                                            type="text"
                                                            class="form-control-plaintext"
                                                        />
                                                    </div>
                                                    <em
                                                        class="icon icon-sm ni ni-search"
                                                    ></em>
                                                </div>
                                            </div>
                                            <div
                                                class="dropdown-divider m-0"
                                            ></div>
                                            <div
                                                class="dropdown-content dropdown-content-x-lg py-3"
                                            >
                                                <div
                                                    class="dropdown-title pb-2"
                                                >
                                                    <h5 class="title">
                                                        Recent searches
                                                    </h5>
                                                </div>
                                                <ul
                                                    class="dropdown-list gap gy-2"
                                                >
                                                    <li>
                                                        <div
                                                            class="media-group"
                                                        >
                                                            <div
                                                                class="media media-md media-middle media-circle text-bg-light"
                                                            >
                                                                <em
                                                                    class="icon ni ni-clock"
                                                                ></em>
                                                            </div>
                                                            <div
                                                                class="media-text"
                                                            >
                                                                <div
                                                                    class="lead-text"
                                                                >
                                                                    Styled
                                                                    Doughnut
                                                                    Chart
                                                                </div>
                                                                <span
                                                                    class="sub-text"
                                                                    >1 days
                                                                    ago</span
                                                                >
                                                            </div>
                                                            <div
                                                                class="media-action media-action-end"
                                                            >
                                                                <button
                                                                    class="btn btn-md btn-zoom btn-icon me-n1"
                                                                >
                                                                    <em
                                                                        class="icon ni ni-trash"
                                                                    ></em>
                                                                </button>
                                                            </div>
                                                        </div>
                                                    </li>
                                                    <li>
                                                        <div
                                                            class="media-group"
                                                        >
                                                            <div
                                                                class="media media-md media-middle media-circle text-bg-light"
                                                            >
                                                                <em
                                                                    class="icon ni ni-clock"
                                                                ></em>
                                                            </div>
                                                            <div
                                                                class="media-text"
                                                            >
                                                                <div
                                                                    class="lead-text"
                                                                >
                                                                    Custom
                                                                    Select Input
                                                                </div>
                                                                <span
                                                                    class="sub-text"
                                                                    >07
                                                                    Aug</span
                                                                >
                                                            </div>
                                                            <div
                                                                class="media-action media-action-end"
                                                            >
                                                                <button
                                                                    class="btn btn-md btn-zoom btn-icon me-n1"
                                                                >
                                                                    <em
                                                                        class="icon ni ni-trash"
                                                                    ></em>
                                                                </button>
                                                            </div>
                                                        </div>
                                                    </li>
                                                    <li>
                                                        <div
                                                            class="media-group"
                                                        >
                                                            <div
                                                                class="media media-md media-middle media-circle text-bg-light"
                                                            >
                                                                <img
                                                                    src="../assets/images/avatar/a.jpg"
                                                                    alt=""
                                                                />
                                                            </div>
                                                            <div
                                                                class="media-text"
                                                            >
                                                                <div
                                                                    class="lead-text"
                                                                >
                                                                    Sharon
                                                                    Walker
                                                                </div>
                                                                <span
                                                                    class="sub-text"
                                                                    >Admin</span
                                                                >
                                                            </div>
                                                            <div
                                                                class="media-action media-action-end"
                                                            >
                                                                <button
                                                                    class="btn btn-md btn-zoom btn-icon me-n1"
                                                                >
                                                                    <em
                                                                        class="icon ni ni-trash"
                                                                    ></em>
                                                                </button>
                                                            </div>
                                                        </div>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <button
                                            class="btn btn-icon btn-sm btn-zoom d-sm-none"
                                            data-bs-toggle="offcanvas"
                                            data-bs-target="#notificationOffcanvas"
                                        >
                                            <em class="icon ni ni-bell"></em>
                                        </button>
                                        <button
                                            class="btn btn-icon btn-md btn-zoom d-none d-sm-inline-flex"
                                            data-bs-toggle="offcanvas"
                                            data-bs-target="#notificationOffcanvas"
                                        >
                                            <em class="icon ni ni-bell"></em>
                                        </button>
                                    </li>
                                    <li class="dropdown">
                                        <a href="#" data-bs-toggle="dropdown">
                                            <div class="d-sm-none">
                                                <div
                                                    class="media media-md media-circle"
                                                >
                                                    <img
                                                        src="../assets/images/avatar/a.jpg"
                                                        alt=""
                                                        class="img-thumbnail"
                                                    />
                                                </div>
                                            </div>
                                            <div class="d-none d-sm-block">
                                                <div class="media media-circle">
                                                    <img
                                                        src="../assets/images/avatar/a.jpg"
                                                        alt=""
                                                        class="img-thumbnail"
                                                    />
                                                </div>
                                            </div>
                                        </a>
                                        <div
                                            class="dropdown-menu dropdown-menu-md"
                                        >
                                            <div
                                                class="dropdown-content dropdown-content-x-lg py-3 border-bottom border-light"
                                            >
                                                <div class="media-group">
                                                    <div
                                                        class="media media-xl media-middle media-circle"
                                                    >
                                                        <img
                                                            src="../assets/images/avatar/a.jpg"
                                                            alt=""
                                                            class="img-thumbnail"
                                                        />
                                                    </div>
                                                    <div class="media-text">
                                                        <div class="lead-text">
                                                            Wesley Burland
                                                        </div>
                                                        <span class="sub-text"
                                                            >Owner &
                                                            Founder</span
                                                        >
                                                    </div>
                                                </div>
                                            </div>
                                            <div
                                                class="dropdown-content dropdown-content-x-lg py-3 border-bottom border-light"
                                            >
                                                <ul class="link-list">
                                                    <li>
                                                        <a
                                                            href="./html/profile.html"
                                                            ><em
                                                                class="icon ni ni-user"
                                                            ></em>
                                                            <span
                                                                >My
                                                                Profile</span
                                                            ></a
                                                        >
                                                    </li>
                                                    <li>
                                                        <a
                                                            href="./html/user-manage/user-cards.html"
                                                            ><em
                                                                class="icon ni ni-contact"
                                                            ></em>
                                                            <span
                                                                >My
                                                                Contacts</span
                                                            ></a
                                                        >
                                                    </li>
                                                    <li>
                                                        <a
                                                            href="./html/profile-edit.html"
                                                            ><em
                                                                class="icon ni ni-setting-alt"
                                                            ></em>
                                                            <span
                                                                >Account
                                                                Settings</span
                                                            ></a
                                                        >
                                                    </li>
                                                </ul>
                                            </div>
                                            <div
                                                class="dropdown-content dropdown-content-x-lg py-3"
                                            >
                                                <ul class="link-list">
                                                    <li>
                                                        <a href="#"
                                                            ><em
                                                                class="icon ni ni-signout"
                                                            ></em>
                                                            <span
                                                                >Log Out</span
                                                            ></a
                                                        >
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                            <!-- .nk-header-tools -->
                        </div>
                        <!-- .nk-header-wrap -->
                    </div>
                    <!-- .container-fliud -->
                </div>
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
                                                <ul class="d-flex gap g-2">
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
                                    <div class="card card-gutter-md">
                                        <div class="card-body">
                                            <div class="bio-block">
                                                <h4
                                                    class="bio-block-title mb-4"
                                                >
                                                    Memorandum
                                                </h4>
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
                                                                        class="js-select"
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
                                                                        class="js-select"
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
                                                                        class="js-select"
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
                                                                        class="js-select"
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
                                                                        class="js-select"
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
                                                                    class="form-control-wrap"
                                                                >
                                                                    <input
                                                                        type="text"
                                                                        class="form-control"
                                                                        id="address"
                                                                        placeholder="Search.."
                                                                    />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-12">
                                                            <button
                                                                class="btn btn-primary"
                                                                type="submit"
                                                            >
                                                                Save
                                                            </button>
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

export default {
    name: "MemoAddView",
};
</script>
