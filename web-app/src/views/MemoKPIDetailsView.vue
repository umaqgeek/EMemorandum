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
                    :errorStaffProfile="
                        errorStaffProfile || errorTheMOUKPI || errorSaveEvidence
                    "
                />
                <LoadingComponent
                    :loading="
                        loadingStaffProfile ||
                        loadingTheMOUKPI ||
                        loadingSaveEvidence
                    "
                />
                <div class="nk-content" v-if="errorStaffProfile">
                    <InfoNotLoggedInComponent />
                </div>
                <div
                    class="nk-content"
                    v-if="
                        !errorStaffProfile &&
                        !errorTheMOUKPI &&
                        !errorSaveEvidence
                    "
                >
                    <div class="container">
                        <div class="nk-content-inner">
                            <div class="nk-content-body">
                                <div class="nk-block-head">
                                    <div class="nk-block-head">
                                        <div
                                            class="nk-block-head-between flex-wrap gap g-2 align-items-start"
                                        >
                                            <div class="nk-block-head-content">
                                                <h2>KPI Details</h2>
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
                                        <div
                                            class="gap-col memo-kpi-detail-breadcrumb-container"
                                        >
                                            <div>
                                                <h5>Memorandum No.</h5>
                                                <a
                                                    :href="`${publicPath}memo-detail?memo=${dataTheMOUKPI?.noMemo}&tab=3`"
                                                    >MoU.3.4.2024.020000.001</a
                                                >
                                            </div>
                                            <div class="ms-4 me-4">
                                                <em
                                                    class="icon ni ni-chevrons-right"
                                                ></em>
                                            </div>
                                            <div>
                                                <h5>KPI</h5>
                                                <a
                                                    :href="`${publicPath}kpi-view?kpi=${dataTheMOUKPI?.kpI_ID}`"
                                                    >(ID:
                                                    {{ dataTheMOUKPI?.kpI_ID }})
                                                    {{ dataTheMOUKPI?.kpi }} ({{
                                                        dataTheMOUKPI?.kod
                                                    }})</a
                                                >
                                            </div>
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
                                                                    Memorandum
                                                                </h4>
                                                                <ul
                                                                    class="list-group list-group-borderless small"
                                                                >
                                                                    <li
                                                                        class="list-group-item"
                                                                    >
                                                                        <span
                                                                            class="title fw-medium w-100 d-inline-block"
                                                                            >Status:</span
                                                                        >
                                                                        <span
                                                                            :class="`badge text-bg-${color(
                                                                                dataTheMOUKPI
                                                                                    ?.status
                                                                                    ?.kod
                                                                            )}`"
                                                                            >{{
                                                                                dataTheMOUKPI
                                                                                    ?.status
                                                                                    ?.status
                                                                            }}</span
                                                                        >
                                                                    </li>
                                                                    <li
                                                                        class="list-group-item"
                                                                    >
                                                                        <span
                                                                            class="title fw-medium w-100 d-inline-block"
                                                                            >Memorandum
                                                                            No.:</span
                                                                        >
                                                                        <h4
                                                                            class="text"
                                                                        >
                                                                            {{
                                                                                dataTheMOUKPI?.noMemo
                                                                            }}
                                                                        </h4>
                                                                    </li>
                                                                    <li
                                                                        class="list-group-item"
                                                                    >
                                                                        <span
                                                                            class="title fw-medium w-100 d-inline-block"
                                                                            >Category
                                                                            of
                                                                            Memorandum:</span
                                                                        >
                                                                        <span
                                                                            class="text"
                                                                            >{{
                                                                                dataTheMOUKPI?.kategori
                                                                            }}</span
                                                                        >
                                                                    </li>
                                                                    <li
                                                                        class="list-group-item"
                                                                    >
                                                                        <span
                                                                            class="title fw-medium w-100 d-inline-block"
                                                                            >Type
                                                                            of
                                                                            Memorandum:</span
                                                                        >
                                                                        <span
                                                                            class="text"
                                                                            >{{
                                                                                dataTheMOUKPI?.jenis
                                                                            }}</span
                                                                        >
                                                                    </li>
                                                                    <li
                                                                        class="list-group-item"
                                                                    >
                                                                        <span
                                                                            class="title fw-medium w-100 d-inline-block"
                                                                            >Memorandum
                                                                            Scope:</span
                                                                        >
                                                                        <span
                                                                            class="text"
                                                                            >{{
                                                                                dataTheMOUKPI?.scopeButiran
                                                                            }}</span
                                                                        >
                                                                    </li>
                                                                    <li
                                                                        class="list-group-item"
                                                                    >
                                                                        <span
                                                                            class="title fw-medium w-100 d-inline-block"
                                                                            >PIC:</span
                                                                        >
                                                                        <a
                                                                            :href="`${publicPath}user-view?s=${dataTheMOUKPI?.noStafPIC}`"
                                                                            class="btn-link"
                                                                            >{{
                                                                                getNama(
                                                                                    dataTheMOUKPI?.picGelaran,
                                                                                    dataTheMOUKPI?.pic
                                                                                )
                                                                            }}</a
                                                                        >
                                                                    </li>
                                                                    <li
                                                                        class="list-group-item"
                                                                    >
                                                                        <span
                                                                            class="title fw-medium w-40 d-inline-block"
                                                                            >Start
                                                                            Date:</span
                                                                        >
                                                                        <span
                                                                            class="text"
                                                                            >{{
                                                                                dataTheMOUKPI?.mouTarikhMulaDate
                                                                            }}</span
                                                                        >
                                                                    </li>
                                                                    <li
                                                                        class="list-group-item"
                                                                    >
                                                                        <span
                                                                            class="title fw-medium w-40 d-inline-block"
                                                                            >End
                                                                            Date:</span
                                                                        >
                                                                        <span
                                                                            class="text"
                                                                            >{{
                                                                                dataTheMOUKPI?.mouTarikhTamatDate
                                                                            }}</span
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
                                                                            >{{
                                                                                dataTheMOUKPI?.nilai?.toFixed(
                                                                                    2
                                                                                )
                                                                            }}</span
                                                                        >
                                                                    </li>
                                                                    <li
                                                                        class="list-group-item"
                                                                    >
                                                                        <span
                                                                            class="title fw-medium w-100 d-inline-block"
                                                                            >PTJ:</span
                                                                        >
                                                                        <span
                                                                            class="text"
                                                                            >{{
                                                                                dataTheMOUKPI?.ptjNama
                                                                            }}</span
                                                                        >
                                                                    </li>
                                                                    <li
                                                                        class="list-group-item"
                                                                    >
                                                                        <span
                                                                            class="title fw-medium w-100 d-inline-block"
                                                                            >PBU:</span
                                                                        >
                                                                        <span
                                                                            class="text"
                                                                            >{{
                                                                                dataTheMOUKPI?.subPTJNama
                                                                            }}</span
                                                                        >
                                                                    </li>
                                                                    <li
                                                                        class="list-group-item"
                                                                        v-if="
                                                                            dataTheMOUKPI?.path
                                                                        "
                                                                    >
                                                                        <span
                                                                            class="title fw-medium w-100 d-inline-block"
                                                                            >Document:</span
                                                                        >
                                                                        <a
                                                                            :href="`${publicPath}${dataTheMOUKPI?.path}`"
                                                                            target="_blank"
                                                                            >{{
                                                                                dataTheMOUKPI?.namaDok
                                                                            }}</a
                                                                        >
                                                                        <div
                                                                            class="d-block mt-1"
                                                                        >
                                                                            <a
                                                                                :href="`${publicPath}${dataTheMOUKPI?.path}`"
                                                                                target="_blank"
                                                                                class="btn btn-md btn-info"
                                                                                ><em
                                                                                    class="icon ni ni-download"
                                                                                ></em
                                                                                ><span
                                                                                    >Download</span
                                                                                ></a
                                                                            >
                                                                        </div>
                                                                    </li>
                                                                </ul>
                                                            </div>
                                                            <!-- .bio-block -->
                                                        </div>
                                                        <!-- .card-body -->
                                                    </div>
                                                    <div
                                                        class="card-content col-sep w-100"
                                                    >
                                                        <div class="card-body">
                                                            <div
                                                                class="bio-block"
                                                            >
                                                                <h4
                                                                    class="bio-block-title"
                                                                >
                                                                    KPI
                                                                </h4>
                                                                <h5>
                                                                    (ID:
                                                                    {{
                                                                        dataTheMOUKPI?.kpI_ID
                                                                    }})
                                                                    {{
                                                                        dataTheMOUKPI?.kpi
                                                                    }}
                                                                    ({{
                                                                        dataTheMOUKPI?.kod
                                                                    }})
                                                                </h5>
                                                                <p>
                                                                    {{
                                                                        dataTheMOUKPI?.penerangan ||
                                                                        "-"
                                                                    }}
                                                                </p>
                                                            </div>
                                                            <!-- .bio-block -->
                                                        </div>
                                                        <!-- .card-body -->
                                                        <div
                                                            class="card-body memo-kpi-detail-history-container"
                                                        >
                                                            <div
                                                                class="bio-block"
                                                            >
                                                                <h4
                                                                    class="bio-block-title"
                                                                >
                                                                    KPI Progress
                                                                </h4>
                                                                <div
                                                                    v-if="
                                                                        dataTheMOUKPI
                                                                            ?.progress
                                                                            ?.length <=
                                                                        0
                                                                    "
                                                                    class="alert alert-warning mt-3"
                                                                >
                                                                    No progress
                                                                    yet. Add KPI
                                                                    progress in
                                                                    below form.
                                                                </div>
                                                                <ul
                                                                    v-else
                                                                    class="nk-schedule mt-4"
                                                                >
                                                                    <li
                                                                        class="nk-schedule-item"
                                                                        v-for="(
                                                                            prog,
                                                                            pIndex
                                                                        ) in dataTheMOUKPI?.progress"
                                                                        v-bind:key="
                                                                            pIndex
                                                                        "
                                                                    >
                                                                        <div
                                                                            class="nk-schedule-item-inner"
                                                                        >
                                                                            <div
                                                                                class="nk-schedule-symbol active"
                                                                            ></div>
                                                                            <div
                                                                                class="nk-schedule-content flex-grow-1"
                                                                            >
                                                                                <span
                                                                                    class="smaller"
                                                                                >
                                                                                    {{
                                                                                        prog.tarikhKemaskini
                                                                                    }}
                                                                                </span>
                                                                                <div
                                                                                    role="alert"
                                                                                >
                                                                                    <p>
                                                                                        Evidence:
                                                                                        <a
                                                                                            :href="`${publicPath}${prog.buktiPath}`"
                                                                                            target="_blank"
                                                                                            >{{
                                                                                                prog.bukti
                                                                                            }}</a
                                                                                        >
                                                                                    </p>
                                                                                </div>
                                                                                <div
                                                                                    role="alert"
                                                                                >
                                                                                    <p>
                                                                                        Price
                                                                                        (RM)
                                                                                        /
                                                                                        Unit:
                                                                                        {{
                                                                                            prog.isAmount
                                                                                                ? `${
                                                                                                      prog.amaun
                                                                                                  } unit${
                                                                                                      parseInt(
                                                                                                          prog.amaun
                                                                                                      ) >
                                                                                                      0
                                                                                                          ? "s"
                                                                                                          : ""
                                                                                                  }`
                                                                                                : `RM ${prog.number}`
                                                                                        }}
                                                                                    </p>
                                                                                </div>
                                                                                <a
                                                                                    class="smaller"
                                                                                    :href="`${publicPath}user-view?s=${prog.author?.noStaf}`"
                                                                                    >by
                                                                                    {{
                                                                                        getNama(
                                                                                            prog
                                                                                                .author
                                                                                                ?.gelaran,
                                                                                            prog
                                                                                                .author
                                                                                                ?.nama
                                                                                        )
                                                                                    }}</a
                                                                                >
                                                                            </div>
                                                                        </div>
                                                                    </li>
                                                                </ul>
                                                            </div>
                                                            <!-- .bio-block -->
                                                        </div>
                                                        <div class="card-body">
                                                            <div
                                                                class="bio-block"
                                                            >
                                                                <div
                                                                    class="row"
                                                                >
                                                                    <div
                                                                        class="col-md-7"
                                                                    >
                                                                        <h4
                                                                            class="bio-block-title"
                                                                        >
                                                                            Progress
                                                                            Evidence
                                                                        </h4>
                                                                        <div
                                                                            class="form-group"
                                                                        >
                                                                            <div
                                                                                class="form-control-wrap"
                                                                            >
                                                                                <!-- <input
                                                                                    type="text"
                                                                                    placeholder="Write the KPI's progress evidence in here"
                                                                                    class="form-control"
                                                                                    id="bukti"
                                                                                    v-model="
                                                                                        evidence
                                                                                    "
                                                                                /> -->
                                                                                <input
                                                                                    class="form-control"
                                                                                    type="file"
                                                                                    @change="
                                                                                        (
                                                                                            evt
                                                                                        ) =>
                                                                                            handleFileUpload(
                                                                                                evt,
                                                                                                'kpievidence'
                                                                                            )
                                                                                    "
                                                                                />
                                                                                <div
                                                                                    class="btn btn-link"
                                                                                    v-if="
                                                                                        filePath?.kpievidence
                                                                                    "
                                                                                >
                                                                                    <a
                                                                                        :href="`${publicPath}${filePath?.kpievidence}`"
                                                                                        target="_blank"
                                                                                        >{{
                                                                                            fileName?.kpievidence
                                                                                        }}</a
                                                                                    >
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div
                                                                        class="col-md-5"
                                                                    >
                                                                        <h4
                                                                            class="bio-block-title"
                                                                        >
                                                                            Price
                                                                            (RM)
                                                                            /
                                                                            Unit
                                                                        </h4>
                                                                        <input
                                                                            type="number"
                                                                            class="form-control"
                                                                            id="Amaun"
                                                                            placeholder="Eg.: 9943"
                                                                            v-model="
                                                                                amount
                                                                            "
                                                                        />
                                                                        <div
                                                                            class="mou-kpi-option-container mt-3"
                                                                        >
                                                                            <label>
                                                                                <input
                                                                                    type="radio"
                                                                                    v-model="
                                                                                        isAmount
                                                                                    "
                                                                                    :value="
                                                                                        false
                                                                                    "
                                                                                />
                                                                                Price
                                                                                (RM)
                                                                            </label>
                                                                            <label>
                                                                                <input
                                                                                    type="radio"
                                                                                    v-model="
                                                                                        isAmount
                                                                                    "
                                                                                    :value="
                                                                                        true
                                                                                    "
                                                                                />
                                                                                Unit
                                                                            </label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <h4
                                                                    class="bio-block-title mt-3"
                                                                >
                                                                    Description
                                                                    /
                                                                    Justification
                                                                </h4>
                                                                <div
                                                                    class="form-group"
                                                                >
                                                                    <div
                                                                        class="form-control-wrap"
                                                                    >
                                                                        <textarea
                                                                            placeholder="Write the evidence's justification in here"
                                                                            class="form-control"
                                                                            id="bukti"
                                                                            rows="3"
                                                                            v-model="
                                                                                evidenceDescription
                                                                            "
                                                                        ></textarea>
                                                                    </div>
                                                                </div>
                                                                <div
                                                                    class="mt-3"
                                                                >
                                                                    <ul
                                                                        class="d-flex gap g-2 justify-content-start"
                                                                    >
                                                                        <li
                                                                            class="d-none d-md-block"
                                                                        >
                                                                            <div
                                                                                class="btn btn-success"
                                                                                @click="
                                                                                    onSave
                                                                                "
                                                                            >
                                                                                <em
                                                                                    class="icon ni ni-save"
                                                                                ></em
                                                                                >&nbsp;
                                                                                Save
                                                                            </div>
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
                                    </div>
                                    <!-- .tab-content -->
                                </div>
                                <!-- .nk-block -->
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
import { ref, watch } from "vue";
import { useToast } from "vue-toast-notification";
import "vue-toast-notification/dist/theme-sugar.css";

import ValidateMeComponent from "@/components/ValidateMe.vue";
import NavbarComponent from "@/components/Navbar.vue";
import TopNavComponent from "@/components/TopNav.vue";
import FooterComponent from "@/components/Footer.vue";
import LoadingComponent from "@/components/Loading.vue";
import InfoNotLoggedInComponent from "@/components/InfoNotLoggedIn.vue";
import {
    useStaffProfile,
    useGetOneMOUKPI,
    useMouEvidenceMemo,
    useHandleFileUpload,
} from "@/hooks/useAPI";

export default {
    name: "MemoKPIDetailsView",
    components: {
        ValidateMeComponent,
        NavbarComponent,
        TopNavComponent,
        FooterComponent,
        LoadingComponent,
        InfoNotLoggedInComponent,
    },
    setup() {
        const $toast = useToast();
        const publicPath = ref(process.env.VUE_APP_PUBLIC_PATH);

        const {
            data: dataStaffProfile,
            error: errorStaffProfile,
            loading: loadingStaffProfile,
        } = useStaffProfile();

        const params = new URLSearchParams(window.location.search);
        const kpiId = params.get("kpi") || "";

        const isAdmin = ref(false);
        const isPUU = ref(false);
        const isPTJ = ref(false);
        const isPIC = ref(false);
        const loadingTheMOUKPI = ref(true);
        const dataTheMOUKPI = ref(null);
        const errorTheMOUKPI = ref(null);
        const loadingSaveEvidence = ref(false);
        const errorSaveEvidence = ref(null);

        const getNama = (gelaran, nama) => {
            return (
                (gelaran?.toLowerCase()?.includes("tiada") ? "" : gelaran) +
                " " +
                nama
            );
        };

        watch(
            () => dataStaffProfile.value,
            (newDataStaffProfile) => {
                if (
                    newDataStaffProfile &&
                    newDataStaffProfile?.roles?.length > 0
                ) {
                    isAdmin.value = newDataStaffProfile?.roles?.find(
                        (r) => r.code === "Admin"
                    )
                        ? true
                        : false;
                    isPUU.value = newDataStaffProfile?.roles?.find(
                        (r) => r.code === "PUU"
                    )
                        ? true
                        : false;
                    isPTJ.value = newDataStaffProfile?.roles?.find(
                        (r) => r.code === "PTJ"
                    )
                        ? true
                        : false;

                    const {
                        data: dataMOU,
                        loading: loadingMOU,
                        error: errorMOU,
                    } = useGetOneMOUKPI(kpiId);

                    watch(
                        () => loadingMOU.value,
                        (newLoadingMOU) => {
                            loadingTheMOUKPI.value = newLoadingMOU;
                        }
                    );
                    watch(
                        () => dataMOU.value,
                        (newDataMOU) => {
                            dataTheMOUKPI.value = newDataMOU;
                            isPIC.value = newDataMOU?.isPIC;
                        }
                    );
                    watch(
                        () => errorMOU.value,
                        (newErrorMOU) => {
                            errorTheMOUKPI.value = newErrorMOU;
                            console.log(newErrorMOU);
                            // if (newErrorMOU) {
                            //     location.href = `${publicPath.value}memo-list`;
                            // }
                        }
                    );
                }
            },
            { immediate: true } // Run the watcher immediately on component mount
        );

        const color = (kod) => {
            if (kod === "01") return "dark";
            if (kod === "02") return "info";
            if (kod === "03") return "warning";
            if (kod === "04") return "success";
            if (kod === "05" || kod === "06" || kod === "07") return "danger";
            return "dark";
        };

        // const evidence = ref("");
        const evidenceDescription = ref("");
        const amount = ref(0);
        const isAmount = ref(false);
        const onSave = () => {
            if (!(fileName.value?.kpievidence?.length > 0)) {
                $toast.open({
                    message: "Please upload the evidence!",
                    type: "error",
                    position: "top-right",
                });
                return;
            }
            loadingSaveEvidence.value = true;
            const {
                data: dataEvidence,
                loading: loadingEvidence,
                error: errorEvidence,
            } = useMouEvidenceMemo({
                // Bukti: evidence.value,
                Bukti: fileName.value?.kpievidence,
                BuktiPath: filePath.value?.kpievidence,
                Penerangan: evidenceDescription.value,
                KPI_ID: dataTheMOUKPI.value?.kpI_ID,
                NoMemo: dataTheMOUKPI.value?.noMemo,
                Amaun: isAmount.value == true ? amount.value : 0,
                Number: isAmount.value == false ? amount.value : 0,
                isAmount: isAmount.value,
            });
            watch(
                () => loadingEvidence.value,
                (newLoadingEvidence) => {
                    loadingSaveEvidence.value = newLoadingEvidence;
                }
            );
            watch(
                () => errorEvidence.value,
                (newErrorEvidence) => {
                    errorSaveEvidence.value = newErrorEvidence;
                }
            );
            watch(
                () => dataEvidence.value,
                (newDataEvidence) => {
                    if (newDataEvidence) {
                        location.href = `${publicPath.value}kpi-view?kpi=${dataTheMOUKPI.value?.kpI_ID}`;
                    }
                }
            );
        };

        const filePath = ref({
            kpievidence: "",
        });
        const fileName = ref({
            kpievidence: "",
        });
        const handleFileUpload = async (event, category) => {
            const file = event.target.files[0]; // Get the selected file
            if (!file) return;

            // Use FormData to send the file to the server
            const formData = new FormData();
            formData.append("file", file);
            formData.append("category", category);

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
                        filePath.value[category] =
                            newDataHandleUpload?.filePath ??
                            newErrorHandleUpload;
                        fileName.value[category] =
                            newDataHandleUpload?.fileName ??
                            newErrorHandleUpload;
                    }
                }
            );
        };

        return {
            publicPath,
            dataStaffProfile,
            errorStaffProfile,
            loadingStaffProfile,
            isAdmin,
            isPUU,
            isPTJ,
            isPIC,
            loadingTheMOUKPI,
            dataTheMOUKPI,
            errorTheMOUKPI,
            getNama,
            loadingSaveEvidence,
            errorSaveEvidence,
            color,
            // evidence,
            evidenceDescription,
            amount,
            isAmount,
            onSave,
            filePath,
            fileName,
            handleFileUpload,
        };
    },
};
</script>

<style scoped>
.memo-kpi-detail-history-container {
    max-height: 500px;
    overflow-x: auto;
}
.memo-kpi-detail-breadcrumb-container {
    display: flex;
    flex-direction: row;
    align-items: center;
}
.mou-kpi-option-container {
    display: flex;
    flex-direction: column;
}
</style>
