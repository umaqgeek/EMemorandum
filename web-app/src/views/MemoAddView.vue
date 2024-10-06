<template>
    <div class="nk-app-root">
        <div class="nk-main">
            <NavbarComponent
                :staffprofile="dataStaffProfile"
                :activeLabel="`memo-list`"
            />
            <div class="nk-wrap">
                <TopNavComponent
                    :staffprofile="dataStaffProfile"
                    :errorStaffProfile="errorStaffProfile"
                />
                <LoadingComponent
                    :loading="loadingStaffProfile || loadingMouSelectData"
                />
                <div class="nk-content" v-if="errorStaffProfile">
                    <InfoNotLoggedInComponent />
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
                                                <h2 class="nk-block-title">
                                                    Add New Memorandum
                                                </h2>
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
                                                    <li
                                                        :class="[
                                                            {
                                                                active:
                                                                    menuNo ===
                                                                    1,
                                                            },
                                                        ]"
                                                        @click="() => onMenu(1)"
                                                    >
                                                        <a
                                                            href="#"
                                                            class="nk-todo-menu-item"
                                                        >
                                                            <em
                                                                class="icon ni ni-info"
                                                            ></em>
                                                            <span
                                                                >Project
                                                                Details</span
                                                            >
                                                        </a>
                                                    </li>
                                                    <li
                                                        :class="[
                                                            {
                                                                active:
                                                                    menuNo ===
                                                                    2,
                                                            },
                                                        ]"
                                                        @click="() => onMenu(2)"
                                                    >
                                                        <a
                                                            href="#"
                                                            class="nk-todo-menu-item"
                                                        >
                                                            <em
                                                                class="icon ni ni-users"
                                                            ></em>
                                                            <span>Members</span>
                                                        </a>
                                                    </li>
                                                    <li
                                                        :class="[
                                                            {
                                                                active:
                                                                    menuNo ===
                                                                    3,
                                                            },
                                                        ]"
                                                        @click="() => onMenu(3)"
                                                    >
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
                                            <div class="nk-todo-body card-body">
                                                <form action="#">
                                                    <div
                                                        class="row g-3"
                                                        :style="{
                                                            display:
                                                                menuNo === 1
                                                                    ? 'flex'
                                                                    : 'none',
                                                        }"
                                                    >
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
                                                                    <input
                                                                        type="text"
                                                                        class="form-control"
                                                                        placeholder="Eg.: Memorandum Persefahaman X dan K"
                                                                        v-model="
                                                                            form
                                                                                .form1
                                                                                .TajukProjek
                                                                        "
                                                                    />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-4">
                                                            <div
                                                                class="form-group"
                                                            >
                                                                <label
                                                                    for="KodKategori"
                                                                    class="form-label"
                                                                    >Category of
                                                                    Memorandum</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <select
                                                                        class="form-select"
                                                                        id="KodKategori"
                                                                        data-search="true"
                                                                        data-sort="false"
                                                                        v-model="
                                                                            KodKategori
                                                                        "
                                                                    >
                                                                        <option
                                                                            value=""
                                                                        >
                                                                            -
                                                                            Select
                                                                            Category
                                                                            -
                                                                        </option>
                                                                        <option
                                                                            v-for="cat in categories"
                                                                            v-bind:key="
                                                                                cat.kod
                                                                            "
                                                                            :value="
                                                                                cat.kod
                                                                            "
                                                                        >
                                                                            {{
                                                                                cat.butiran
                                                                            }}
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
                                                                    for="KodJenis"
                                                                    class="form-label"
                                                                    >Type of
                                                                    Memorandum</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <select
                                                                        class="form-select"
                                                                        id="KodJenis"
                                                                        data-search="true"
                                                                        data-sort="false"
                                                                        v-model="
                                                                            KodJenis
                                                                        "
                                                                    >
                                                                        <option
                                                                            value=""
                                                                        >
                                                                            -
                                                                            Select
                                                                            Type
                                                                            -
                                                                        </option>
                                                                        <option
                                                                            v-for="t in types"
                                                                            v-bind:key="
                                                                                t.kod
                                                                            "
                                                                            :value="
                                                                                t.kod
                                                                            "
                                                                        >
                                                                            {{
                                                                                t.butiran
                                                                            }}
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
                                                                    for="KodScope"
                                                                    class="form-label"
                                                                    >Memorandum
                                                                    Scope</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <select
                                                                        class="form-select"
                                                                        id="KodScope"
                                                                        data-search="true"
                                                                        data-sort="false"
                                                                        v-model="
                                                                            form
                                                                                .form1
                                                                                .KodScope
                                                                        "
                                                                    >
                                                                        <option
                                                                            value=""
                                                                        >
                                                                            -
                                                                            Select
                                                                            Scope
                                                                            -
                                                                        </option>
                                                                        <option
                                                                            v-for="s in scopes"
                                                                            v-bind:key="
                                                                                s.kod
                                                                            "
                                                                            :value="
                                                                                s.kod
                                                                            "
                                                                        >
                                                                            {{
                                                                                s.butiran
                                                                            }}
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
                                                                    for="TarikhMula"
                                                                    class="form-label"
                                                                    >Start
                                                                    Date</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <input
                                                                        type="date"
                                                                        class="form-control"
                                                                        id="TarikhMula"
                                                                        placeholder="First name"
                                                                        v-model="
                                                                            form
                                                                                .form1
                                                                                .TarikhMula
                                                                        "
                                                                    />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <div
                                                                class="form-group"
                                                            >
                                                                <label
                                                                    for="TarikhTamat"
                                                                    class="form-label"
                                                                    >End
                                                                    Date</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <input
                                                                        type="date"
                                                                        class="form-control"
                                                                        id="TarikhTamat"
                                                                        placeholder="Last name"
                                                                        v-model="
                                                                            form
                                                                                .form1
                                                                                .TarikhTamat
                                                                        "
                                                                    />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <div
                                                                class="form-group"
                                                            >
                                                                <label
                                                                    for="KodPTJ"
                                                                    class="form-label"
                                                                    >PTJ</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <select
                                                                        class="form-select"
                                                                        id="KodPTJ"
                                                                        data-search="true"
                                                                        data-sort="false"
                                                                        v-model="
                                                                            KodPTJ
                                                                        "
                                                                    >
                                                                        <option
                                                                            value=""
                                                                        >
                                                                            -
                                                                            Select
                                                                            PTJ
                                                                            -
                                                                        </option>
                                                                        <option
                                                                            v-for="p in PTJs"
                                                                            v-bind:key="
                                                                                p.id
                                                                            "
                                                                            :value="
                                                                                p.kodPTJ
                                                                            "
                                                                        >
                                                                            {{
                                                                                p.nama
                                                                            }}
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
                                                                    for="KodPTJSub"
                                                                    class="form-label"
                                                                    >PBU</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <select
                                                                        class="form-select"
                                                                        id="KodPTJSub"
                                                                        data-search="true"
                                                                        data-sort="false"
                                                                        v-model="
                                                                            form
                                                                                .form1
                                                                                .KodPTJSub
                                                                        "
                                                                    >
                                                                        <option
                                                                            value=""
                                                                        >
                                                                            -
                                                                            Select
                                                                            PBU
                                                                            -
                                                                        </option>
                                                                        <option
                                                                            v-for="p in PBUs"
                                                                            v-bind:key="
                                                                                p.id
                                                                            "
                                                                            :value="
                                                                                p.kodSubPTJ
                                                                            "
                                                                        >
                                                                            {{
                                                                                p.nama
                                                                            }}
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
                                                                    for="NoMemo"
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
                                                                        id="NoMemo"
                                                                        placeholder="Eg.: MoA(P).1.2.2024.101010.001"
                                                                        v-model="
                                                                            NoMemo
                                                                        "
                                                                        readonly
                                                                    />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-12">
                                                            <div
                                                                class="form-group"
                                                            >
                                                                <label
                                                                    for="MS01_NoStaf"
                                                                    class="form-label"
                                                                    >Responsible
                                                                    PIC</label
                                                                >
                                                                <div
                                                                    class="input-group"
                                                                >
                                                                    <input
                                                                        type="hidden"
                                                                        v-model="
                                                                            form
                                                                                .form1
                                                                                .MS01_NoStaf
                                                                        "
                                                                    />
                                                                    <input
                                                                        type="text"
                                                                        class="form-control"
                                                                        placeholder="Search PIC in here ..."
                                                                        aria-label="Recipient's username"
                                                                        aria-describedby="button-addon2"
                                                                        v-model="
                                                                            staffPIC
                                                                        "
                                                                        readonly
                                                                    />
                                                                    <button
                                                                        class="btn btn-outline-primary"
                                                                        type="button"
                                                                        id="button-addon2"
                                                                        data-bs-toggle="modal"
                                                                        data-bs-target="#searchMembersModal"
                                                                    >
                                                                        Search
                                                                        Members
                                                                    </button>
                                                                </div>
                                                                <div
                                                                    class="btn btn-link"
                                                                    v-on:click="
                                                                        assignYourselfPIC
                                                                    "
                                                                >
                                                                    Assign
                                                                    yourself
                                                                </div>
                                                                <div
                                                                    class="modal fade"
                                                                    id="searchMembersModal"
                                                                    tabindex="-1"
                                                                    aria-labelledby="searchMembersModalLabel"
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
                                                                                    id="searchMembersModalLabel"
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
                                                                                <TableUserComponent
                                                                                    :users="
                                                                                        allStaffSimple
                                                                                    "
                                                                                    tableType="memoPICs"
                                                                                    @handleChoosePIC="
                                                                                        handleChoosePIC
                                                                                    "
                                                                                />
                                                                            </div>
                                                                            <div
                                                                                class="modal-footer"
                                                                            >
                                                                                <button
                                                                                    id="closeBtnPICs"
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
                                                        <div class="col-lg-6">
                                                            <div
                                                                class="form-group"
                                                            >
                                                                <label
                                                                    for="NamaDok"
                                                                    class="form-label"
                                                                    >Upload a
                                                                    document</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <input
                                                                        class="form-control"
                                                                        type="file"
                                                                        @change="
                                                                            handleFileUpload
                                                                        "
                                                                    />
                                                                    <div
                                                                        class="btn btn-link"
                                                                        v-if="
                                                                            filePath
                                                                        "
                                                                    >
                                                                        File:&nbsp;
                                                                        <a
                                                                            :href="
                                                                                filePath
                                                                            "
                                                                            target="_blank"
                                                                            >{{
                                                                                filePath
                                                                            }}</a
                                                                        >
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <div
                                                                class="form-group"
                                                            >
                                                                <label
                                                                    for="Nilai"
                                                                    class="form-label"
                                                                    >Value (Eg.:
                                                                    1234 = RM
                                                                    1,234)</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <input
                                                                        class="form-control"
                                                                        type="number"
                                                                        v-model="
                                                                            form
                                                                                .form1
                                                                                .Nilai
                                                                        "
                                                                    />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div
                                                        class="row g-3"
                                                        :style="{
                                                            display:
                                                                menuNo === 2
                                                                    ? 'flex'
                                                                    : 'none',
                                                        }"
                                                    >
                                                        <TableUserComponent />
                                                    </div>

                                                    <div
                                                        class="row g-3"
                                                        :style="{
                                                            display:
                                                                menuNo === 3
                                                                    ? 'flex'
                                                                    : 'none',
                                                        }"
                                                    >
                                                        <TableKPIComponent />
                                                    </div>

                                                    <div class="row mt-3 g-3">
                                                        <div class="col-lg-12">
                                                            <a
                                                                v-if="
                                                                    menuNo !== 1
                                                                "
                                                                href="#"
                                                                class="btn btn-primary"
                                                                @click="onBack"
                                                            >
                                                                Back
                                                            </a>
                                                            &nbsp;
                                                            <a
                                                                v-if="
                                                                    menuNo !== 3
                                                                "
                                                                href="#"
                                                                class="btn btn-primary"
                                                                @click="onNext"
                                                            >
                                                                Next
                                                            </a>
                                                            &nbsp;
                                                            <a
                                                                v-if="
                                                                    menuNo === 3
                                                                "
                                                                href="#"
                                                                class="btn btn-secondary"
                                                                disabled="true"
                                                                @click="onSave"
                                                            >
                                                                Save
                                                            </a>
                                                        </div>
                                                    </div>
                                                </form>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <FooterComponent />
            </div>
        </div>
        <ValidateMeComponent />
    </div>
</template>

<!-- JavaScript -->
<script>
import { watch, ref } from "vue";

import ValidateMeComponent from "@/components/ValidateMe.vue";
import NavbarComponent from "@/components/Navbar.vue";
import TopNavComponent from "@/components/TopNav.vue";
import FooterComponent from "@/components/Footer.vue";
import LoadingComponent from "@/components/Loading.vue";
import InfoNotLoggedInComponent from "@/components/InfoNotLoggedIn.vue";
import TableUserComponent from "@/components/TableUser.vue";
import TableKPIComponent from "@/components/TableKPI.vue";
import { getBearerToken } from "@/utils/tokenManagement";
import {
    useStaffProfile,
    useGetMOUSelectData,
    useMouGenerateNoMemo,
    useGetAllStaffSimple,
    useHandleFileUpload,
} from "@/hooks/useAPI";

export default {
    name: "MemoAddView",
    data() {
        return {
            menuNo: 1,
            staffPIC: "",
            form: {
                form1: {
                    TajukProjek: "",
                    KodScope: "",
                    TarikhMula: "",
                    TarikhTamat: "",
                    KodPTJSub: "",
                    NoSiri: 0,
                    Tahun: 2024,
                    NamaDok: "",
                    Path: "",
                    Nilai: "0",
                    MS01_NoStaf: "",
                },
                form2: {
                    members: [],
                },
                form3: {
                    kpis: [],
                },
            },
        };
    },
    components: {
        ValidateMeComponent,
        NavbarComponent,
        TopNavComponent,
        FooterComponent,
        LoadingComponent,
        InfoNotLoggedInComponent,
        TableUserComponent,
        TableKPIComponent,
    },
    setup() {
        const {
            data: dataStaffProfile,
            error: errorStaffProfile,
            loading: loadingStaffProfile,
        } = useStaffProfile();

        const {
            data: dataMouSelectData,
            error: errorMouSelectData,
            loading: loadingMouSelectData,
        } = useGetMOUSelectData();

        const categories = ref([]);
        const types = ref([]);
        const scopes = ref([]);
        const PTJs = ref([]);
        const PBUs = ref([]);
        watch(
            () => dataMouSelectData.value,
            (dataMouSelectDataUpdated) => {
                categories.value = dataMouSelectDataUpdated?.kategoriMemo || [];
                types.value = dataMouSelectDataUpdated?.jenisMemo || [];
                scopes.value = dataMouSelectDataUpdated?.scopeMemo || [];
                PTJs.value = dataMouSelectDataUpdated?.subPTJ || [];
                PBUs.value = dataMouSelectDataUpdated?.subPTJ || [];
            }
        );

        const KodKategori = ref("");
        const KodJenis = ref("");
        const KodPTJ = ref("");
        const NoMemo = ref("");
        watch(
            [KodKategori, KodJenis, KodPTJ],
            ([newKodKategori, newKodJenis, newKodPTJ]) => {
                if (newKodKategori && newKodJenis && newKodPTJ) {
                    const { data: dataNoMemo } = useMouGenerateNoMemo({
                        KodKategori: newKodKategori,
                        KodJenis: newKodJenis,
                        KodPTJ: newKodPTJ,
                    });

                    watch(
                        () => dataNoMemo.value,
                        (newDataNoMemo) => {
                            NoMemo.value = newDataNoMemo?.noMemo;
                        }
                    );
                }
            }
        );

        const { data: dataAllStaffSimple } = useGetAllStaffSimple();
        const allStaffSimple = ref([]);
        watch(
            () => dataAllStaffSimple.value,
            (newDataAllStaffSimple) => {
                allStaffSimple.value = newDataAllStaffSimple;
            }
        );

        const filePath = ref("");
        const handleFileUpload = async (event) => {
            const file = event.target.files[0]; // Get the selected file
            if (!file) return;

            // Use FormData to send the file to the server
            const formData = new FormData();
            formData.append("file", file);

            const {
                data: dataHandleUpload,
                loading: loadingHandleUpload,
                error: errorHandleUpload,
            } = useHandleFileUpload(formData);
            watch(
                [dataHandleUpload, loadingHandleUpload, errorHandleUpload],
                ([
                    newDataHandleUpload,
                    newLoadingHandleUpload,
                    newErrorHandleUpload,
                ]) => {
                    if (newLoadingHandleUpload == false) {
                        filePath.value =
                            newDataHandleUpload?.filePath ??
                            newErrorHandleUpload;
                    }
                }
            );
        };

        return {
            dataStaffProfile,
            errorStaffProfile,
            loadingStaffProfile,
            dataMouSelectData,
            errorMouSelectData,
            loadingMouSelectData,
            categories,
            types,
            scopes,
            PTJs,
            PBUs,
            KodKategori,
            KodJenis,
            KodPTJ,
            NoMemo,
            allStaffSimple,
            filePath,
            handleFileUpload,
        };
    },
    computed: {},
    methods: {
        handleChoosePIC(user) {
            const gelaran = user?.gelaran?.toLowerCase()?.includes("tiada")
                ? ""
                : user?.gelaran;
            this.staffPIC = `${gelaran} ${user?.nama} (${user?.noStaf} | ${user?.email})`;
            this.form.form1.MS01_NoStaf = user?.noStaf;
            document.getElementById("closeBtnPICs").click();
        },
        assignYourselfPIC() {
            const gelaran = this.dataStaffProfile?.gelaran
                ?.toLowerCase()
                ?.includes("tiada")
                ? ""
                : this.dataStaffProfile?.gelaran;
            this.staffPIC = `${gelaran} ${
                this.dataStaffProfile?.nama
            } (${getBearerToken()} | ${this.dataStaffProfile?.email})`;
            this.form.form1.MS01_NoStaf = getBearerToken();
        },
        onMenu(mNo) {
            this.menuNo = mNo;
        },
        onNext() {
            this.menuNo = this.menuNo + 1 > 3 ? 1 : this.menuNo + 1;
        },
        onBack() {
            this.menuNo = this.menuNo - 1 <= 0 ? 3 : this.menuNo - 1;
        },
        onSave() {
            const finalForm = {
                ...this.form,
                form1: {
                    ...this.form.form1,
                    NoMemo: this.NoMemo,
                    KodKategori: this.KodKategori,
                    KodJenis: this.KodJenis,
                    KodPTJ: this.KodPTJ,
                    NamaDok: this.filePath,
                    Path: this.filePath,
                },
            };
            console.log(finalForm);
        },
    },
};
</script>
