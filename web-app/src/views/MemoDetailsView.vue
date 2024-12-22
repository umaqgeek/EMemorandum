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
                        errorStaffProfile || errorTheMOU || errorSaveComment
                    "
                />
                <LoadingComponent
                    :loading="
                        loadingStaffProfile ||
                        loadingTheMOU ||
                        loadingSaveComment
                    "
                />
                <div class="nk-content" v-if="errorStaffProfile">
                    <InfoNotLoggedInComponent />
                </div>
                <div
                    class="nk-content"
                    v-if="
                        !errorStaffProfile && !errorTheMOU && !errorSaveComment
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
                                                        :class="[
                                                            'nav-link',
                                                            {
                                                                active:
                                                                    tab == 1,
                                                            },
                                                        ]"
                                                        data-bs-toggle="tab"
                                                        data-bs-target="#tab-1"
                                                        type="button"
                                                    >
                                                        Overview
                                                    </button>
                                                </li>
                                                <li class="nav-item">
                                                    <button
                                                        :class="[
                                                            'nav-link',
                                                            {
                                                                active:
                                                                    tab == 2,
                                                            },
                                                        ]"
                                                        data-bs-toggle="tab"
                                                        data-bs-target="#tab-2"
                                                        type="button"
                                                    >
                                                        Members
                                                    </button>
                                                </li>
                                                <li class="nav-item">
                                                    <button
                                                        :class="[
                                                            'nav-link',
                                                            {
                                                                active:
                                                                    tab == 3,
                                                            },
                                                        ]"
                                                        data-bs-toggle="tab"
                                                        data-bs-target="#tab-3"
                                                        type="button"
                                                    >
                                                        KPI
                                                    </button>
                                                </li>
                                            </ul>
                                        </div>
                                        <div
                                            class="gap-col"
                                            v-if="isPIC || isPUU || isUS"
                                        >
                                            <ul class="d-flex gap g-2">
                                                <li class="d-none d-md-block">
                                                    <a
                                                        :href="`${publicPath}memo-edit?memo=${dataTheMOU?.noMemo}`"
                                                        class="btn btn-soft btn-primary"
                                                    >
                                                        <em
                                                            class="icon ni ni-edit"
                                                        ></em
                                                        ><span
                                                            >Edit
                                                            Memorandum</span
                                                        >
                                                    </a>
                                                </li>
                                            </ul>
                                        </div>
                                        <div
                                            class="gap-col"
                                            v-if="
                                                (isPIC || isAdmin) &&
                                                dataTheMOU?.status?.kod != '07'
                                            "
                                        >
                                            <ul class="d-flex gap g-2">
                                                <li class="d-none d-md-block">
                                                    <a
                                                        href="#"
                                                        class="btn btn-danger"
                                                        @click="
                                                            showModalCancel = true
                                                        "
                                                    >
                                                        <em
                                                            class="icon ni ni-cross"
                                                        ></em
                                                        ><span>Cancel</span>
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
                                            :class="[
                                                'tab-pane',
                                                {
                                                    'show active': tab == 1,
                                                },
                                            ]"
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
                                                                            class="title fw-medium w-100 d-inline-block"
                                                                            >Status:</span
                                                                        >
                                                                        <span
                                                                            :class="`badge text-bg-${color(
                                                                                dataTheMOU
                                                                                    ?.status
                                                                                    ?.kod
                                                                            )}`"
                                                                            >{{
                                                                                dataTheMOU
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
                                                                                dataTheMOU?.noMemo
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
                                                                                dataTheMOU?.kategori
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
                                                                                dataTheMOU?.jenis
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
                                                                                dataTheMOU?.scopeButiran
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
                                                                            :href="`${publicPath}user-view?s=${dataTheMOU?.noStafPIC}`"
                                                                            class="btn-link"
                                                                            >{{
                                                                                getNama(
                                                                                    dataTheMOU?.picGelaran,
                                                                                    dataTheMOU?.pic
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
                                                                                dataTheMOU?.tarikhMulaDate
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
                                                                                dataTheMOU?.tarikhTamatDate
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
                                                                                dataTheMOU?.nilai?.toFixed(
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
                                                                                dataTheMOU?.ptjNama
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
                                                                                dataTheMOU?.subPTJNama
                                                                            }}</span
                                                                        >
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
                                                                    Project
                                                                    Title
                                                                </h4>
                                                                <p>
                                                                    {{
                                                                        dataTheMOU?.tajukProjek
                                                                    }}
                                                                </p>
                                                                <hr />
                                                            </div>
                                                            <div class="row">
                                                                <div
                                                                    class="col-lg-6"
                                                                >
                                                                    <span
                                                                        class="title fw-medium w-100 d-inline-block"
                                                                        >Fair
                                                                        Copy
                                                                        Document:</span
                                                                    >
                                                                    <a
                                                                        v-if="
                                                                            dataTheMOU?.path
                                                                        "
                                                                        :href="`${publicPath}${dataTheMOU?.path}`"
                                                                        target="_blank"
                                                                        >{{
                                                                            dataTheMOU?.namaDok
                                                                        }}</a
                                                                    >
                                                                    <div
                                                                        v-if="
                                                                            dataTheMOU?.path
                                                                        "
                                                                        class="d-block mt-1"
                                                                    >
                                                                        <a
                                                                            :href="`${publicPath}${dataTheMOU?.path}`"
                                                                            target="_blank"
                                                                            class="btn btn-md btn-info"
                                                                            ><em
                                                                                class="icon ni ni-download"
                                                                            ></em
                                                                            ><span
                                                                                >View
                                                                                /
                                                                                Download</span
                                                                            ></a
                                                                        >
                                                                    </div>
                                                                    <div v-else>
                                                                        N/A
                                                                    </div>
                                                                </div>
                                                                <div
                                                                    class="col-lg-6"
                                                                >
                                                                    <span
                                                                        class="title fw-medium w-100 d-inline-block"
                                                                        >Stamped
                                                                        Document:</span
                                                                    >
                                                                    <a
                                                                        v-if="
                                                                            dataTheMOU?.dokStampPath
                                                                        "
                                                                        :href="`${publicPath}${dataTheMOU?.dokStampPath}`"
                                                                        target="_blank"
                                                                        >{{
                                                                            dataTheMOU?.dokStamp
                                                                        }}</a
                                                                    >
                                                                    <div
                                                                        class="d-block mt-1"
                                                                        v-if="
                                                                            dataTheMOU?.dokStampPath
                                                                        "
                                                                    >
                                                                        <a
                                                                            :href="`${publicPath}${dataTheMOU?.dokStampPath}`"
                                                                            target="_blank"
                                                                            class="btn btn-md btn-info"
                                                                            ><em
                                                                                class="icon ni ni-download"
                                                                            ></em
                                                                            ><span
                                                                                >View
                                                                                /
                                                                                Download</span
                                                                            ></a
                                                                        >
                                                                    </div>
                                                                    <div v-else>
                                                                        N/A
                                                                    </div>
                                                                </div>
                                                                <div
                                                                    class="col-lg-6"
                                                                >
                                                                    <hr />
                                                                    <span
                                                                        class="title fw-medium w-100 d-inline-block"
                                                                        >Minutes
                                                                        Document:</span
                                                                    >
                                                                    <a
                                                                        v-if="
                                                                            dataTheMOU?.dokMinitPath
                                                                        "
                                                                        :href="`${publicPath}${dataTheMOU?.dokMinitPath}`"
                                                                        target="_blank"
                                                                        >{{
                                                                            dataTheMOU?.dokMinit
                                                                        }}</a
                                                                    >
                                                                    <div
                                                                        class="d-block mt-1"
                                                                        v-if="
                                                                            dataTheMOU?.dokMinitPath
                                                                        "
                                                                    >
                                                                        <a
                                                                            :href="`${publicPath}${dataTheMOU?.dokMinitPath}`"
                                                                            target="_blank"
                                                                            class="btn btn-md btn-info"
                                                                            ><em
                                                                                class="icon ni ni-download"
                                                                            ></em
                                                                            ><span
                                                                                >View
                                                                                /
                                                                                Download</span
                                                                            ></a
                                                                        >
                                                                    </div>
                                                                    <div v-else>
                                                                        N/A
                                                                    </div>
                                                                </div>
                                                                <div
                                                                    class="col-lg-6"
                                                                >
                                                                    <hr />
                                                                    <span
                                                                        class="title fw-medium w-100 d-inline-block"
                                                                        >Approved
                                                                        Document:</span
                                                                    >
                                                                    <a
                                                                        v-if="
                                                                            dataTheMOU?.dokLulusPath
                                                                        "
                                                                        :href="`${publicPath}${dataTheMOU?.dokLulusPath}`"
                                                                        target="_blank"
                                                                        >{{
                                                                            dataTheMOU?.dokLulus
                                                                        }}</a
                                                                    >
                                                                    <div
                                                                        class="d-block mt-1"
                                                                        v-if="
                                                                            dataTheMOU?.dokLulusPath
                                                                        "
                                                                    >
                                                                        <a
                                                                            :href="`${publicPath}${dataTheMOU?.dokLulusPath}`"
                                                                            target="_blank"
                                                                            class="btn btn-md btn-info"
                                                                            ><em
                                                                                class="icon ni ni-download"
                                                                            ></em
                                                                            ><span
                                                                                >View
                                                                                /
                                                                                Download</span
                                                                            ></a
                                                                        >
                                                                    </div>
                                                                    <div v-else>
                                                                        N/A
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!-- .bio-block -->
                                                        </div>
                                                        <!-- .card-body -->
                                                        <div
                                                            class="card-body memo-detail-history-container"
                                                        >
                                                            <div
                                                                class="bio-block"
                                                            >
                                                                <h4
                                                                    class="bio-block-title"
                                                                >
                                                                    Recent
                                                                    Activities
                                                                    &amp;
                                                                    History
                                                                </h4>
                                                                <ul
                                                                    class="nk-schedule mt-4"
                                                                >
                                                                    <li
                                                                        class="nk-schedule-item"
                                                                        v-for="(
                                                                            hist,
                                                                            hIndex
                                                                        ) in dataTheMOU?.history"
                                                                        v-bind:key="
                                                                            hIndex
                                                                        "
                                                                    >
                                                                        <div
                                                                            class="nk-schedule-item-inner"
                                                                        >
                                                                            <div
                                                                                class="nk-schedule-symbol active"
                                                                            ></div>
                                                                            <div
                                                                                :class="[
                                                                                    'nk-schedule-content flex-grow-1',
                                                                                    {
                                                                                        'alert alert-info':
                                                                                            hIndex ===
                                                                                            0,
                                                                                    },
                                                                                ]"
                                                                            >
                                                                                <span
                                                                                    class="smaller"
                                                                                    >{{
                                                                                        hist.created_At
                                                                                    }}</span
                                                                                >
                                                                                <div
                                                                                    role="alert"
                                                                                >
                                                                                    <p>
                                                                                        {{
                                                                                            hist.description
                                                                                        }}
                                                                                    </p>
                                                                                    <p
                                                                                        v-if="
                                                                                            hist
                                                                                                .comment
                                                                                                ?.length >
                                                                                            0
                                                                                        "
                                                                                    >
                                                                                        Comment:<br />
                                                                                        <strong
                                                                                            >{{
                                                                                                hist.comment
                                                                                            }}</strong
                                                                                        >
                                                                                    </p>
                                                                                </div>
                                                                                <a
                                                                                    class="smaller"
                                                                                    :href="`${publicPath}user-view?s=${hist.noStaf}`"
                                                                                    >by
                                                                                    {{
                                                                                        getNama(
                                                                                            hist.gelaran,
                                                                                            hist.nama
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
                                                        <!-- .card-body -->
                                                        <div
                                                            class="card-body"
                                                            v-if="isPTJ"
                                                        >
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
                                                                            id="comments"
                                                                            v-model="
                                                                                comments
                                                                            "
                                                                            rows="3"
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
                                                                                class="btn btn-soft btn-primary"
                                                                                @click="
                                                                                    onComment
                                                                                "
                                                                            >
                                                                                <em
                                                                                    class="icon ni ni-comments"
                                                                                ></em
                                                                                >&nbsp;
                                                                                Comment
                                                                            </div>
                                                                        </li>
                                                                    </ul>
                                                                    <ul
                                                                        class="d-flex gap g-2 justify-content-end"
                                                                        v-if="
                                                                            isAdmin ||
                                                                            isPTJ ||
                                                                            isPUU ||
                                                                            isPIC
                                                                        "
                                                                    >
                                                                        <li
                                                                            class="d-none d-md-block"
                                                                            v-if="
                                                                                (isPUU &&
                                                                                    dataTheMOU
                                                                                        ?.status
                                                                                        ?.kod ==
                                                                                        '01') ||
                                                                                dataTheMOU
                                                                                    ?.status
                                                                                    ?.kod ==
                                                                                    '00'
                                                                            "
                                                                            @click="
                                                                                onApproval(
                                                                                    '02'
                                                                                )
                                                                            "
                                                                        >
                                                                            <div
                                                                                class="btn btn-success"
                                                                            >
                                                                                <em
                                                                                    class="icon ni ni-done"
                                                                                ></em
                                                                                >&nbsp;
                                                                                Mark
                                                                                as
                                                                                Reviewed
                                                                            </div>
                                                                        </li>
                                                                        <li
                                                                            class="d-none d-md-block"
                                                                            v-if="
                                                                                isPTJ &&
                                                                                dataTheMOU
                                                                                    ?.status
                                                                                    ?.kod ==
                                                                                    '03'
                                                                            "
                                                                            @click="
                                                                                onApproval(
                                                                                    '04'
                                                                                )
                                                                            "
                                                                        >
                                                                            <div
                                                                                class="btn btn-success"
                                                                            >
                                                                                <em
                                                                                    class="icon ni ni-done"
                                                                                ></em
                                                                                >&nbsp;
                                                                                Approve
                                                                            </div>
                                                                        </li>
                                                                        <li
                                                                            class="d-none d-md-block"
                                                                            v-if="
                                                                                isPTJ &&
                                                                                dataTheMOU
                                                                                    ?.status
                                                                                    ?.kod ==
                                                                                    '02'
                                                                            "
                                                                            @click="
                                                                                onApproval(
                                                                                    '05'
                                                                                )
                                                                            "
                                                                        >
                                                                            <div
                                                                                class="btn btn-soft btn-danger"
                                                                            >
                                                                                <em
                                                                                    class="icon ni ni-cross"
                                                                                ></em
                                                                                >&nbsp;
                                                                                Reject
                                                                            </div>
                                                                        </li>
                                                                        <li
                                                                            class="d-none d-md-block"
                                                                            v-if="
                                                                                (isPTJ &&
                                                                                    dataTheMOU
                                                                                        ?.status
                                                                                        ?.kod ==
                                                                                        '02') ||
                                                                                (isPUU &&
                                                                                    (dataTheMOU
                                                                                        ?.status
                                                                                        ?.kod ==
                                                                                        '01' ||
                                                                                        dataTheMOU
                                                                                            ?.status
                                                                                            ?.kod ==
                                                                                            '00'))
                                                                            "
                                                                            @click="
                                                                                onApproval(
                                                                                    '04'
                                                                                )
                                                                            "
                                                                        >
                                                                            <div
                                                                                class="btn btn-soft btn-secondary"
                                                                            >
                                                                                <em
                                                                                    class="icon ni ni-edit-fill"
                                                                                ></em
                                                                                >&nbsp;
                                                                                Back
                                                                                to
                                                                                PIC
                                                                            </div>
                                                                        </li>
                                                                        <li
                                                                            class="d-none d-md-block"
                                                                            v-if="
                                                                                isPIC &&
                                                                                dataTheMOU
                                                                                    ?.status
                                                                                    ?.kod ==
                                                                                    '04'
                                                                            "
                                                                            @click="
                                                                                onApproval(
                                                                                    '00'
                                                                                )
                                                                            "
                                                                        >
                                                                            <div
                                                                                class="btn btn-success"
                                                                            >
                                                                                <em
                                                                                    class="icon ni ni-edit-fill"
                                                                                ></em
                                                                                >&nbsp;
                                                                                Ready
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
                                        <div
                                            :class="[
                                                'tab-pane',
                                                {
                                                    'show active': tab == 2,
                                                },
                                            ]"
                                            id="tab-2"
                                            tabindex="1"
                                        >
                                            <div class="card card-gutter-md">
                                                <div
                                                    class="card-row card-row-lg col-sep col-sep-lg"
                                                >
                                                    <TableLite
                                                        :title="membersTitle"
                                                        :columns="membersCols"
                                                        :data="members"
                                                        :isNoAction="true"
                                                    />
                                                </div>
                                            </div>
                                        </div>
                                        <div
                                            :class="[
                                                'tab-pane',
                                                {
                                                    'show active': tab == 3,
                                                },
                                            ]"
                                            id="tab-3"
                                            tabindex="2"
                                        >
                                            <div class="card card-gutter-md">
                                                <div
                                                    class="card-row card-row-lg col-sep col-sep-lg"
                                                >
                                                    <TableLite
                                                        :title="kpisTitle"
                                                        :columns="kpisCols"
                                                        :data="kpis"
                                                        :isNoAction="true"
                                                    />
                                                </div>
                                            </div>
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
        <ModalYesNo
            :visible="showModalCancel"
            title="Cancel Confirmation"
            message="Are you sure you want to cancel this memorandum?"
            @confirm="onApproval('07')"
            @cancel="showModalCancel = false"
        />
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
    useGetOneMOU,
    useMouCommentMemo,
    useMouApprovalRejectionMemo,
} from "@/hooks/useAPI";
import TableLite from "@/components/TableLite.vue";
import { LIMIT_TEXT } from "@/utils/constants";
import ModalYesNo from "@/components/ModalYesNo.vue";

export default {
    name: "MemoDetailsView",
    components: {
        ValidateMeComponent,
        NavbarComponent,
        TopNavComponent,
        FooterComponent,
        LoadingComponent,
        InfoNotLoggedInComponent,
        TableLite,
        ModalYesNo,
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
        const noMemo = params.get("memo") || "";

        const tab = ref(params.get("tab") || 1);
        const isAdmin = ref(false);
        const isPUU = ref(false);
        const isPTJ = ref(false);
        const isUS = ref(false);
        const isPIC = ref(false);
        const isMember = ref(false);
        const loadingTheMOU = ref(true);
        const dataTheMOU = ref(null);
        const errorTheMOU = ref(null);
        const loadingSaveComment = ref(false);
        const errorSaveComment = ref(null);

        const membersCols = ref(["Name"]);
        const members = ref([]);
        const membersTitle = ref("");

        const kpisCols = ref([
            "KPI",
            "Description",
            // "Notes",
            "Price (RM) / Unit",
            "Date From",
            "Date To",
        ]);
        const kpis = ref([]);
        const kpisTitle = ref("");

        const getNama = (gelaran, nama) => {
            return (
                (gelaran?.toLowerCase()?.includes("tiada") ? "" : gelaran) +
                " " +
                nama
            );
        };

        const getRolesStr = (roles) => {
            return roles?.length > 0
                ? roles?.map((r) => r.role)?.join(", ")
                : "-";
        };

        const getStatus = (roles) => {
            const isActive =
                roles?.length > 0 && roles?.find((r) => r.role === "Staff")
                    ? true
                    : false;
            const color = isActive ? "success" : "danger";
            const label = isActive ? "Active" : "Inactive";
            return `<span class="badge text-bg-${color}-soft">${label}</span>`;
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
                    isUS.value = newDataStaffProfile?.roles?.find(
                        (r) => r.code === "US"
                    )
                        ? true
                        : false;

                    const {
                        data: dataMOU,
                        loading: loadingMOU,
                        error: errorMOU,
                    } = useGetOneMOU(noMemo);

                    watch(
                        () => loadingMOU.value,
                        (newLoadingMOU) => {
                            loadingTheMOU.value = newLoadingMOU;
                        }
                    );
                    watch(
                        () => dataMOU.value,
                        (newDataMOU) => {
                            dataTheMOU.value = newDataMOU;
                            membersTitle.value = `<div class="flex-div mb-2"><div class="me-2">Memorandum No.:</div><h4 class="text">${newDataMOU?.noMemo}</h4></div><h5>Members of Memorandum</h5>`;
                            members.value = [
                                ...newDataMOU?.members?.map((member) => {
                                    if (
                                        member.noStaf ===
                                        newDataStaffProfile?.noStaf
                                    ) {
                                        isMember.value = true;
                                    }
                                    let memberName = getNama(
                                        member.gelaran,
                                        member.nama
                                    );
                                    return {
                                        Name: `<a href="${
                                            publicPath.value
                                        }user-view?s=${
                                            member.noStaf
                                        }">${memberName}</a><div>${getRolesStr(
                                            member.roles
                                        )}</div><div>${getStatus(
                                            member.roles
                                        )}</div>`,
                                    };
                                }),
                            ];
                            kpisTitle.value = `<div class="flex-div mb-2"><div class="me-2">Memorandum No.:</div><h4 class="text">${newDataMOU?.noMemo}</h4></div><h5>KPIs of Memorandum</h5>`;
                            kpis.value = [
                                ...newDataMOU?.kpIs?.map((kpi) => {
                                    const isUnit = kpi.amaun != 0;
                                    const unit = isUnit ? kpi.amaun : 0;
                                    const isNilai = kpi.nilai != 0;
                                    const nilai = isNilai ? kpi.nilai : 0;
                                    var priceUnit = "-";
                                    if (isUnit) {
                                        priceUnit = `${unit} unit${
                                            unit > 1 ? "s" : ""
                                        }`;
                                    } else if (isNilai) {
                                        priceUnit = `RM ${nilai}`;
                                    }
                                    const isDescMore =
                                        kpi.penerangan?.length > LIMIT_TEXT;
                                    const desc = kpi.penerangan?.substring(
                                        0,
                                        LIMIT_TEXT
                                    );
                                    return {
                                        KPI: `<a href="${publicPath.value}kpi-view?kpi=${kpi.kpI_ID}">${kpi.kpi} (${kpi.kod})</a>`,
                                        Description: `${desc}${
                                            isDescMore ? "..." : ""
                                        }`,
                                        // Notes: kpi.komen,
                                        "Price (RM) / Unit": priceUnit,
                                        "Date From": kpi.tarikhMulaDate,
                                        "Date To": kpi.tarikhTamatDate,
                                    };
                                }),
                            ];
                            isPIC.value = newDataMOU?.isPIC;
                        }
                    );
                    watch(
                        () => errorMOU.value,
                        (newErrorMOU) => {
                            if (newErrorMOU) {
                                location.href = `${publicPath.value}memo-list`;
                            }
                        }
                    );
                }
            },
            { immediate: true } // Run the watcher immediately on component mount
        );

        const comments = ref("");
        const onComment = () => {
            if (!(comments.value?.length > 0)) {
                $toast.open({
                    message: "Please fill in the comment!",
                    type: "error",
                    position: "top-right",
                });
                return;
            }
            loadingSaveComment.value = true;
            const {
                data: dataComment,
                loading: loadingComment,
                error: errorComment,
            } = useMouCommentMemo({
                Comment: comments.value,
                NoMemo: dataTheMOU.value?.noMemo,
            });
            watch(
                () => loadingComment.value,
                (newLoadingComment) => {
                    loadingSaveComment.value = newLoadingComment;
                }
            );
            watch(
                () => errorComment.value,
                (newErrorComment) => {
                    errorSaveComment.value = newErrorComment;
                }
            );
            watch(
                () => dataComment.value,
                (newDataComment) => {
                    if (newDataComment) {
                        location.href = `${publicPath.value}memo-detail?memo=${dataTheMOU.value?.noMemo}`;
                    }
                }
            );
        };

        const color = (kod) => {
            if (kod === "01") return "dark";
            if (kod === "02") return "info";
            if (kod === "03") return "warning";
            if (kod === "04") return "success";
            if (kod === "05" || kod === "06" || kod === "07") return "danger";
            return "dark";
        };

        const onApproval = (status) => {
            loadingSaveComment.value = true;
            const {
                data: dataComment,
                loading: loadingComment,
                error: errorComment,
            } = useMouApprovalRejectionMemo({
                Comment: comments.value,
                NoMemo: dataTheMOU.value?.noMemo,
                Status: status,
            });
            watch(
                () => loadingComment.value,
                (newLoadingComment) => {
                    loadingSaveComment.value = newLoadingComment;
                }
            );
            watch(
                () => errorComment.value,
                (newErrorComment) => {
                    errorSaveComment.value = newErrorComment;
                }
            );
            watch(
                () => dataComment.value,
                (newDataComment) => {
                    if (newDataComment) {
                        location.href = `${publicPath.value}memo-detail?memo=${dataTheMOU.value?.noMemo}`;
                    }
                }
            );
        };

        const showModalCancel = ref(false);

        return {
            publicPath,
            dataStaffProfile,
            errorStaffProfile,
            loadingStaffProfile,
            tab,
            isAdmin,
            isPUU,
            isPTJ,
            isUS,
            isPIC,
            isMember,
            loadingTheMOU,
            dataTheMOU,
            errorTheMOU,
            membersCols,
            members,
            membersTitle,
            kpisCols,
            kpis,
            kpisTitle,
            getNama,
            comments,
            onComment,
            loadingSaveComment,
            errorSaveComment,
            color,
            onApproval,
            showModalCancel,
        };
    },
};
</script>

<style scoped>
.memo-detail-history-container {
    max-height: 500px;
    overflow-x: auto;
}
</style>
