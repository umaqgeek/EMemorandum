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
                                    <div
                                        class="nk-block-head-between flex-wrap gap g-2"
                                    >
                                        <div class="nk-block-head-content">
                                            <h2 class="nk-block-title">
                                                Lists of Memorandum
                                            </h2>
                                        </div>
                                        <div class="nk-block-head-content">
                                            <ul class="d-flex">
                                                <li>
                                                    <router-link
                                                        to="/memo-add"
                                                        class="btn btn-primary d-none d-md-inline-flex"
                                                        ><span
                                                            class="nk-menu-icon"
                                                            ><em
                                                                class="icon ni ni-plus"
                                                            ></em
                                                        ></span>
                                                        <span>Add New</span>
                                                    </router-link>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <!-- .nk-block-head-between -->
                                </div>
                                <!-- .nk-block-head -->
                                <div class="nk-block">
                                    <div class="card">
                                        <table
                                            class="datatable-init table"
                                            data-nk-container="table-responsive"
                                        >
                                            <thead class="table-light">
                                                <tr>
                                                    <th class="tb-col">
                                                        <span
                                                            class="overline-title"
                                                            >No.</span
                                                        >
                                                    </th>
                                                    <th class="tb-col">
                                                        <span
                                                            class="overline-title"
                                                            >No.
                                                            Memorandum</span
                                                        >
                                                    </th>
                                                    <th class="tb-col">
                                                        <span
                                                            class="overline-title"
                                                            >Skop
                                                            Memorandum</span
                                                        >
                                                    </th>
                                                    <th
                                                        class="tb-col tb-col-xl"
                                                    >
                                                        <span
                                                            class="overline-title"
                                                            >Staff Name</span
                                                        >
                                                    </th>
                                                    <th
                                                        class="tb-col tb-col-xxl"
                                                    >
                                                        <span
                                                            class="overline-title"
                                                            >Start Date</span
                                                        >
                                                    </th>
                                                    <th class="tb-col">
                                                        <span
                                                            class="overline-title"
                                                            >End Date</span
                                                        >
                                                    </th>
                                                    <th class="tb-col">
                                                        <span
                                                            class="overline-title"
                                                            >Price (RM)</span
                                                        >
                                                    </th>
                                                    <th class="tb-col">
                                                        <span
                                                            class="overline-title"
                                                            >Status</span
                                                        >
                                                    </th>
                                                    <th
                                                        class="tb-col tb-col-end"
                                                        data-sortable="false"
                                                    >
                                                        <span
                                                            class="overline-title"
                                                            >Action</span
                                                        >
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td class="tb-col">1</td>
                                                    <td class="tb-col">
                                                        MoA(TP),13.2.2023.010000.007
                                                    </td>
                                                    <td class="tb-col">
                                                        Kerahsiaan
                                                    </td>
                                                    <td class="tb-col">
                                                        <div
                                                            class="media-group"
                                                        >
                                                            <div
                                                                class="media-text"
                                                            >
                                                                <a
                                                                    href="./html/memo/memo-details.html"
                                                                    class="title"
                                                                    >Maryam
                                                                    Heleena</a
                                                                >
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td
                                                        class="tb-col tb-col-xxl"
                                                    >
                                                        25/04/2024
                                                    </td>
                                                    <td
                                                        class="tb-col tb-col-xxl"
                                                    >
                                                        25/04/2026
                                                    </td>
                                                    <td
                                                        class="tb-col tb-col-xxl"
                                                    >
                                                        0.00
                                                    </td>
                                                    <td class="tb-col">
                                                        <span
                                                            class="badge text-bg-warning-soft"
                                                            >Pending</span
                                                        >
                                                    </td>
                                                    <td
                                                        class="tb-col tb-col-end"
                                                    >
                                                        <div class="dropdown">
                                                            <a
                                                                href="#"
                                                                class="btn btn-sm btn-icon btn-zoom me-n1"
                                                                data-bs-toggle="dropdown"
                                                            >
                                                                <em
                                                                    class="icon ni ni-more-v"
                                                                ></em>
                                                            </a>
                                                            <div
                                                                class="dropdown-menu dropdown-menu-sm dropdown-menu-end"
                                                            >
                                                                <div
                                                                    class="dropdown-content py-1"
                                                                >
                                                                    <ul
                                                                        class="link-list link-list-hover-bg-primary link-list-md"
                                                                    >
                                                                        <li>
                                                                            <router-link
                                                                                to="/memo-edit"
                                                                            >
                                                                                <em
                                                                                    class="icon ni ni-edit"
                                                                                ></em
                                                                                ><span
                                                                                    >Edit</span
                                                                                >
                                                                            </router-link>
                                                                        </li>
                                                                        <li>
                                                                            <a
                                                                                href="./html/memo/memo-edit.html"
                                                                                ><em
                                                                                    class="icon ni ni-trash"
                                                                                ></em
                                                                                ><span
                                                                                    >Delete</span
                                                                                ></a
                                                                            >
                                                                        </li>
                                                                        <li>
                                                                            <router-link
                                                                                to="/memo-detail"
                                                                                ><em
                                                                                    class="icon ni ni-eye"
                                                                                ></em
                                                                                ><span
                                                                                    >View
                                                                                    Details</span
                                                                                ></router-link
                                                                            >
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- dropdown -->
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tb-col">2</td>
                                                    <td class="tb-col">
                                                        MoA(TP),13.2.2023.010000.007
                                                    </td>
                                                    <td class="tb-col">
                                                        Kerahsiaan
                                                    </td>
                                                    <td class="tb-col">
                                                        <div
                                                            class="media-group"
                                                        >
                                                            <div
                                                                class="media-text"
                                                            >
                                                                <a
                                                                    href="./html/memo/memo-details.html"
                                                                    class="title"
                                                                    >Maryam
                                                                    Heleena</a
                                                                >
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td
                                                        class="tb-col tb-col-xxl"
                                                    >
                                                        25/04/2024
                                                    </td>
                                                    <td
                                                        class="tb-col tb-col-xxl"
                                                    >
                                                        25/04/2026
                                                    </td>
                                                    <td
                                                        class="tb-col tb-col-xxl"
                                                    >
                                                        0.00
                                                    </td>
                                                    <td class="tb-col">
                                                        <span
                                                            class="badge text-bg-warning-soft"
                                                            >Pending</span
                                                        >
                                                    </td>
                                                    <td
                                                        class="tb-col tb-col-end"
                                                    >
                                                        <div class="dropdown">
                                                            <a
                                                                href="#"
                                                                class="btn btn-sm btn-icon btn-zoom me-n1"
                                                                data-bs-toggle="dropdown"
                                                            >
                                                                <em
                                                                    class="icon ni ni-more-v"
                                                                ></em>
                                                            </a>
                                                            <div
                                                                class="dropdown-menu dropdown-menu-sm dropdown-menu-end"
                                                            >
                                                                <div
                                                                    class="dropdown-content py-1"
                                                                >
                                                                    <ul
                                                                        class="link-list link-list-hover-bg-primary link-list-md"
                                                                    >
                                                                        <li>
                                                                            <router-link
                                                                                to="/memo-edit"
                                                                            >
                                                                                <em
                                                                                    class="icon ni ni-edit"
                                                                                ></em
                                                                                ><span
                                                                                    >Edit</span
                                                                                >
                                                                            </router-link>
                                                                        </li>
                                                                        <li>
                                                                            <a
                                                                                href="./html/memo/memo-edit.html"
                                                                                ><em
                                                                                    class="icon ni ni-trash"
                                                                                ></em
                                                                                ><span
                                                                                    >Delete</span
                                                                                ></a
                                                                            >
                                                                        </li>
                                                                        <li>
                                                                            <router-link
                                                                                to="/memo-detail"
                                                                                ><em
                                                                                    class="icon ni ni-eye"
                                                                                ></em
                                                                                ><span
                                                                                    >View
                                                                                    Details</span
                                                                                ></router-link
                                                                            >
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- dropdown -->
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tb-col">3</td>
                                                    <td class="tb-col">
                                                        MoA(TP),13.2.2023.010000.007
                                                    </td>
                                                    <td class="tb-col">
                                                        Kerahsiaan
                                                    </td>
                                                    <td class="tb-col">
                                                        <div
                                                            class="media-group"
                                                        >
                                                            <div
                                                                class="media-text"
                                                            >
                                                                <a
                                                                    href="./html/memo/memo-details.html"
                                                                    class="title"
                                                                    >Maryam
                                                                    Heleena</a
                                                                >
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td
                                                        class="tb-col tb-col-xxl"
                                                    >
                                                        25/04/2024
                                                    </td>
                                                    <td
                                                        class="tb-col tb-col-xxl"
                                                    >
                                                        25/04/2026
                                                    </td>
                                                    <td
                                                        class="tb-col tb-col-xxl"
                                                    >
                                                        0.00
                                                    </td>
                                                    <td class="tb-col">
                                                        <span
                                                            class="badge text-bg-warning-soft"
                                                            >Pending</span
                                                        >
                                                    </td>
                                                    <td
                                                        class="tb-col tb-col-end"
                                                    >
                                                        <div class="dropdown">
                                                            <a
                                                                href="#"
                                                                class="btn btn-sm btn-icon btn-zoom me-n1"
                                                                data-bs-toggle="dropdown"
                                                            >
                                                                <em
                                                                    class="icon ni ni-more-v"
                                                                ></em>
                                                            </a>
                                                            <div
                                                                class="dropdown-menu dropdown-menu-sm dropdown-menu-end"
                                                            >
                                                                <div
                                                                    class="dropdown-content py-1"
                                                                >
                                                                    <ul
                                                                        class="link-list link-list-hover-bg-primary link-list-md"
                                                                    >
                                                                        <li>
                                                                            <router-link
                                                                                to="/memo-edit"
                                                                            >
                                                                                <em
                                                                                    class="icon ni ni-edit"
                                                                                ></em
                                                                                ><span
                                                                                    >Edit</span
                                                                                >
                                                                            </router-link>
                                                                        </li>
                                                                        <li>
                                                                            <a
                                                                                href="./html/memo/memo-edit.html"
                                                                                ><em
                                                                                    class="icon ni ni-trash"
                                                                                ></em
                                                                                ><span
                                                                                    >Delete</span
                                                                                ></a
                                                                            >
                                                                        </li>
                                                                        <li>
                                                                            <a
                                                                                href="./html/memo/memo-details.html"
                                                                                ><em
                                                                                    class="icon ni ni-eye"
                                                                                ></em
                                                                                ><span
                                                                                    >View
                                                                                    Details</span
                                                                                ></a
                                                                            >
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- dropdown -->
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tb-col">4</td>
                                                    <td class="tb-col">
                                                        MoA(TP),13.2.2023.010000.007
                                                    </td>
                                                    <td class="tb-col">
                                                        Kerahsiaan
                                                    </td>
                                                    <td class="tb-col">
                                                        <div
                                                            class="media-group"
                                                        >
                                                            <div
                                                                class="media-text"
                                                            >
                                                                <a
                                                                    href="./html/memo/memo-details.html"
                                                                    class="title"
                                                                    >Maryam
                                                                    Heleena</a
                                                                >
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td
                                                        class="tb-col tb-col-xxl"
                                                    >
                                                        25/04/2024
                                                    </td>
                                                    <td
                                                        class="tb-col tb-col-xxl"
                                                    >
                                                        25/04/2026
                                                    </td>
                                                    <td
                                                        class="tb-col tb-col-xxl"
                                                    >
                                                        0.00
                                                    </td>
                                                    <td class="tb-col">
                                                        <span
                                                            class="badge text-bg-warning-soft"
                                                            >Pending</span
                                                        >
                                                    </td>
                                                    <td
                                                        class="tb-col tb-col-end"
                                                    >
                                                        <div class="dropdown">
                                                            <a
                                                                href="#"
                                                                class="btn btn-sm btn-icon btn-zoom me-n1"
                                                                data-bs-toggle="dropdown"
                                                            >
                                                                <em
                                                                    class="icon ni ni-more-v"
                                                                ></em>
                                                            </a>
                                                            <div
                                                                class="dropdown-menu dropdown-menu-sm dropdown-menu-end"
                                                            >
                                                                <div
                                                                    class="dropdown-content py-1"
                                                                >
                                                                    <ul
                                                                        class="link-list link-list-hover-bg-primary link-list-md"
                                                                    >
                                                                        <li>
                                                                            <router-link
                                                                                to="/memo-edit"
                                                                            >
                                                                                <em
                                                                                    class="icon ni ni-edit"
                                                                                ></em
                                                                                ><span
                                                                                    >Edit</span
                                                                                >
                                                                            </router-link>
                                                                        </li>
                                                                        <li>
                                                                            <a
                                                                                href="./html/memo/memo-edit.html"
                                                                                ><em
                                                                                    class="icon ni ni-trash"
                                                                                ></em
                                                                                ><span
                                                                                    >Delete</span
                                                                                ></a
                                                                            >
                                                                        </li>
                                                                        <li>
                                                                            <router-link
                                                                                to="/memo-detail"
                                                                                ><em
                                                                                    class="icon ni ni-eye"
                                                                                ></em
                                                                                ><span
                                                                                    >View
                                                                                    Details</span
                                                                                ></router-link
                                                                            >
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- dropdown -->
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tb-col">5</td>
                                                    <td class="tb-col">
                                                        MoA(TP),13.2.2023.010000.007
                                                    </td>
                                                    <td class="tb-col">
                                                        Kerahsiaan
                                                    </td>
                                                    <td class="tb-col">
                                                        <div
                                                            class="media-group"
                                                        >
                                                            <div
                                                                class="media-text"
                                                            >
                                                                <a
                                                                    href="./html/memo/memo-details.html"
                                                                    class="title"
                                                                    >Maryam
                                                                    Heleena</a
                                                                >
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td
                                                        class="tb-col tb-col-xxl"
                                                    >
                                                        25/04/2024
                                                    </td>
                                                    <td
                                                        class="tb-col tb-col-xxl"
                                                    >
                                                        25/04/2026
                                                    </td>
                                                    <td
                                                        class="tb-col tb-col-xxl"
                                                    >
                                                        0.00
                                                    </td>
                                                    <td class="tb-col">
                                                        <span
                                                            class="badge text-bg-warning-soft"
                                                            >Pending</span
                                                        >
                                                    </td>
                                                    <td
                                                        class="tb-col tb-col-end"
                                                    >
                                                        <div class="dropdown">
                                                            <a
                                                                href="#"
                                                                class="btn btn-sm btn-icon btn-zoom me-n1"
                                                                data-bs-toggle="dropdown"
                                                            >
                                                                <em
                                                                    class="icon ni ni-more-v"
                                                                ></em>
                                                            </a>
                                                            <div
                                                                class="dropdown-menu dropdown-menu-sm dropdown-menu-end"
                                                            >
                                                                <div
                                                                    class="dropdown-content py-1"
                                                                >
                                                                    <ul
                                                                        class="link-list link-list-hover-bg-primary link-list-md"
                                                                    >
                                                                        <li>
                                                                            <router-link
                                                                                to="/memo-edit"
                                                                            >
                                                                                <em
                                                                                    class="icon ni ni-edit"
                                                                                ></em
                                                                                ><span
                                                                                    >Edit</span
                                                                                >
                                                                            </router-link>
                                                                        </li>
                                                                        <li>
                                                                            <a
                                                                                href="./html/memo/memo-edit.html"
                                                                                ><em
                                                                                    class="icon ni ni-trash"
                                                                                ></em
                                                                                ><span
                                                                                    >Delete</span
                                                                                ></a
                                                                            >
                                                                        </li>
                                                                        <li>
                                                                            <router-link
                                                                                to="/memo-detail"
                                                                                ><em
                                                                                    class="icon ni ni-eye"
                                                                                ></em
                                                                                ><span
                                                                                    >View
                                                                                    Details</span
                                                                                ></router-link
                                                                            >
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <!-- dropdown -->
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
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
        <div v-if="loading" class="loading">Loading ...</div>
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
import axios from "axios";
import { API_URL } from "@/utils/constants";
import { BEARER_TOKEN } from "@/utils/mocks";

export default {
    name: "MemoListView",
    data() {
        return {
            loading: false,
        };
    },
    mounted() {
        this.validateMe();
    },
    components: {
        NavbarComponent,
        TopNavComponent,
    },
    methods: {
        validateMe() {
            this.loading = true;
            axios
                .post(
                    `${API_URL}/auth/validate-me`,
                    {},
                    {
                        headers: {
                            "Content-Type": "application/json",
                            Authorization: `Bearer ${BEARER_TOKEN}`,
                        },
                    }
                )
                .then((response) => {
                    console.log(response.data);
                })
                .catch((error) => {
                    console.log(error);
                })
                .finally(() => {
                    this.loading = false;
                });
        },
    },
};
</script>
