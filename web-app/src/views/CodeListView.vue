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
                                                Manage Code
                                            </h2>
                                        </div>
                                        <div class="nk-block-head-content">
                                            <ul class="d-flex">
                                                <li>
                                                    <button
                                                        to="/memo-add"
                                                        class="btn btn-primary d-none d-md-inline-flex"
                                                        data-bs-toggle="modal"
                                                        data-bs-target="#addCode"
                                                    >
                                                        <span
                                                            class="nk-menu-icon"
                                                            ><em
                                                                class="icon ni ni-plus"
                                                            ></em
                                                        ></span>
                                                        <span>Add New</span>
                                                    </button>
                                                    <AddCodeComponent />
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                    <!-- .nk-block-head-between -->
                                </div>
                                <!-- .nk-block-head -->
                                <div class="nk-block">
                                    <div class="card">
                                        <div class="row p-3">
                                            <div class="col-md-2">
                                                <div class="form-group">
                                                    <div
                                                        class="form-control-wrap"
                                                    >
                                                        <input
                                                            type="text"
                                                            class="form-control"
                                                            id="exampleFormControlInputText1"
                                                            placeholder="Search.."
                                                        />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <table
                                            :data="data"
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
                                                            >Name</span
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
                                                        Type of Memorandum
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
                                                                            <a
                                                                                data-bs-toggle="modal"
                                                                                data-bs-target="#editCode"
                                                                            >
                                                                                <em
                                                                                    class="icon ni ni-edit"
                                                                                ></em
                                                                                ><span
                                                                                    >Edit</span
                                                                                >
                                                                            </a>
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
                                                        Category of Memorandum
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
                                                                            <a
                                                                                data-bs-toggle="modal"
                                                                                data-bs-target="#editCode"
                                                                            >
                                                                                <em
                                                                                    class="icon ni ni-edit"
                                                                                ></em
                                                                                ><span
                                                                                    >Edit</span
                                                                                >
                                                                            </a>
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
                                                        Scope of Memorandum
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
                                                                            <a
                                                                                data-bs-toggle="modal"
                                                                                data-bs-target="#editCode"
                                                                            >
                                                                                <em
                                                                                    class="icon ni ni-edit"
                                                                                ></em
                                                                                ><span
                                                                                    >Edit</span
                                                                                >
                                                                            </a>
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
                                                        List of PTJ
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
                                                                            <a
                                                                                data-bs-toggle="modal"
                                                                                data-bs-target="#editCode"
                                                                            >
                                                                                <em
                                                                                    class="icon ni ni-edit"
                                                                                ></em
                                                                                ><span
                                                                                    >Edit</span
                                                                                >
                                                                            </a>
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

        <EditCodeComponent />
        <ValidateMeComponent />
    </div>
    <!-- .nk-app-root -->
</template>

<!-- JavaScript -->
<script>
import NavbarComponent from "@/components/Navbar.vue";
import TopNavComponent from "@/components/TopNav.vue";
import AddCodeComponent from "@/components/AddCodeModal.vue";
import EditCodeComponent from "@/components/EditCodeModal.vue";
import DataTable from "datatables.net-vue3";
import DataTablesCore from "datatables.net";

DataTable.use(DataTablesCore);

export default {
    name: "CodeListView",
    components: {
        NavbarComponent,
        TopNavComponent,
        AddCodeComponent,
        EditCodeComponent,
    },
};
</script>
