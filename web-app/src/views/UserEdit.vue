<template>
    <div class="nk-app-root">
        <div class="nk-main">
            <NavbarComponent :staffprofile="dataStaffProfile" />
            <div class="nk-wrap">
                <TopNavComponent
                    :staffprofile="dataStaffProfile"
                    :errorStaffProfile="errorStaffProfile"
                />
                <LoadingComponent
                    :loading="loadingStaffProfile || loadingOneStaff"
                />
                <div class="nk-content" v-if="errorStaffProfile">
                    <InfoNotLoggedInVue />
                </div>
                <div class="nk-content" v-if="!errorStaffProfile">
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
                                                            {{ getGelaran }}
                                                            {{
                                                                dataOneStaff?.nama
                                                            }}
                                                        </h3>
                                                        <span class="small">{{
                                                            rolesStr
                                                        }}</span>
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
                                                        <div class="col-lg-12">
                                                            <div
                                                                class="form-group"
                                                            >
                                                                <label
                                                                    for="firstname"
                                                                    class="form-label"
                                                                    >Full
                                                                    Name</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <input
                                                                        class="form-control"
                                                                        type="text"
                                                                        :value="
                                                                            nama
                                                                        "
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
                                                                        :value="
                                                                            email
                                                                        "
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
                                                                    >Staff
                                                                    No.</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <input
                                                                        class="form-control"
                                                                        type="text"
                                                                        :value="
                                                                            noStaf
                                                                        "
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
                                                                    >Phone
                                                                    No.</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <input
                                                                        class="form-control"
                                                                        type="text"
                                                                        :value="
                                                                            noTelBimbit
                                                                        "
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
                                                                    >Office</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <input
                                                                        class="form-control"
                                                                        type="text"
                                                                        :value="
                                                                            nPejabat
                                                                        "
                                                                        aria-label="readonly input"
                                                                        readonly
                                                                    />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-12">
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
                                                                    v-model="
                                                                        isActive
                                                                    "
                                                                    @change="
                                                                        handleChangeStatus
                                                                    "
                                                                    id="flexSwitchDefault"
                                                                />
                                                                <label
                                                                    class="form-check-label"
                                                                    for="flexSwitchDefault"
                                                                >
                                                                    Inactive/Active
                                                                </label>
                                                            </div>
                                                            <div
                                                                class="form-group"
                                                                v-if="isActive"
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
                                                                        id="flexCheckPUU"
                                                                    />
                                                                    <label
                                                                        class="form-check-label"
                                                                        for="flexCheckPUU"
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
                                                                        id="flexCheckPTJ"
                                                                    />
                                                                    <label
                                                                        class="form-check-label"
                                                                        for="flexCheckPTJ"
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
                                                                        id="flexCheckAdmin"
                                                                    />
                                                                    <label
                                                                        class="form-check-label"
                                                                        for="flexCheckAdmin"
                                                                    >
                                                                        Administrator
                                                                    </label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-12">
                                                            <a
                                                                href="/user-list"
                                                                class="btn btn-primary"
                                                            >
                                                                Update Profile
                                                            </a>
                                                        </div>
                                                    </div>
                                                    <div
                                                        class="alert alert-danger mt-4"
                                                        v-if="errorOneStaff"
                                                    >
                                                        {{ errorOneStaff }}
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
                <FooterComponent />
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
        <ValidateMeComponent />
    </div>
    <!-- .nk-app-root -->
</template>

<!-- JavaScript -->
<script>
import { useRoute } from "vue-router";
import ValidateMeComponent from "@/components/ValidateMe.vue";
import NavbarComponent from "@/components/Navbar.vue";
import TopNavComponent from "@/components/TopNav.vue";
import FooterComponent from "@/components/Footer.vue";
import LoadingComponent from "@/components/Loading.vue";
import { useStaffProfile, useGetOneStaff } from "@/hooks/useAPI";

export default {
    name: "MemoAddView",
    components: {
        ValidateMeComponent,
        NavbarComponent,
        TopNavComponent,
        FooterComponent,
        LoadingComponent,
    },
    setup() {
        const {
            data: dataStaffProfile,
            error: errorStaffProfile,
            loading: loadingStaffProfile,
            refetch: refetchStaffProfile,
        } = useStaffProfile();

        const route = useRoute();
        const noStaf = route?.query?.s;
        const {
            data: dataOneStaff,
            error: errorOneStaff,
            loading: loadingOneStaff,
            refetch: refetchOneStaff,
        } = useGetOneStaff(noStaf);
        const roles =
            dataOneStaff?.roles?.length > 0 ? dataOneStaff?.roles : [];

        return {
            dataStaffProfile,
            dataOneStaff,
            errorOneStaff,
            errorStaffProfile,
            loadingOneStaff,
            loadingStaffProfile,
            refetchStaffProfile,
            refetchOneStaff,
            noStaf,
            roles,
        };
    },
    computed: {
        isActive() {
            return this.dataOneStaff?.roles?.length > 0;
        },
        getGelaran() {
            return this.dataOneStaff?.gelaran?.toLowerCase()?.includes("tiada")
                ? ""
                : this.dataOneStaff?.gelaran;
        },
        isActivated() {
            return this.dataOneStaff?.roles?.length > 0;
        },
        rolesStr() {
            return this.dataOneStaff?.roles?.length > 0
                ? this.dataOneStaff?.roles?.map((r) => r.role).join(" | ")
                : "Not Activated Yet";
        },
        nama() {
            return this.dataOneStaff?.nama;
        },
        email() {
            return this.dataOneStaff?.email;
        },
        noTelBimbit() {
            return this.dataOneStaff?.noTelBimbit || "-";
        },
        nPejabat() {
            return this.dataOneStaff?.nPejabat;
        },
    },
};
</script>
