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
                    :loading="
                        loadingStaffProfile ||
                        loadingTheMOU ||
                        loadingMouSelectData ||
                        loadingAddMOU
                    "
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
                                                    Edit Memorandum
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
                                                                    <textarea
                                                                        :readonly="
                                                                            !isPUU
                                                                        "
                                                                        class="form-control"
                                                                        :style="
                                                                            textareaStyle
                                                                        "
                                                                        placeholder="Eg.: Memorandum Persefahaman X dan K"
                                                                        v-model="
                                                                            form
                                                                                .form1
                                                                                .TajukProjek
                                                                        "
                                                                        @input="
                                                                            checkLength
                                                                        "
                                                                    ></textarea>
                                                                    <div>
                                                                        {{
                                                                            form
                                                                                .form1
                                                                                .TajukProjek
                                                                                ?.length
                                                                        }}
                                                                        /
                                                                        {{
                                                                            charLimit
                                                                        }}
                                                                        characters.
                                                                    </div>
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
                                                                    <input
                                                                        type="text"
                                                                        class="form-control"
                                                                        :value="
                                                                            dataTheMOU?.kategori
                                                                        "
                                                                        readonly
                                                                    />
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
                                                                    <input
                                                                        type="text"
                                                                        class="form-control"
                                                                        :value="
                                                                            dataTheMOU?.jenis
                                                                        "
                                                                        readonly
                                                                    />
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
                                                                    <multiselect
                                                                        :disabled="
                                                                            !isPUU
                                                                        "
                                                                        :allow-empty="
                                                                            false
                                                                        "
                                                                        v-model="
                                                                            form
                                                                                .form1
                                                                                .KodScope
                                                                        "
                                                                        :options="
                                                                            scopes
                                                                        "
                                                                        placeholder="Select a Scope"
                                                                        label="butiran"
                                                                        track-by="butiran"
                                                                    ></multiselect>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-12">
                                                            <div
                                                                class="form-group"
                                                            >
                                                                <label
                                                                    for="KodInd"
                                                                    class="form-label"
                                                                    >Industry
                                                                    Category</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <multiselect
                                                                        :disabled="
                                                                            !isPUU
                                                                        "
                                                                        :allow-empty="
                                                                            false
                                                                        "
                                                                        v-model="
                                                                            IndustryCategory
                                                                        "
                                                                        :options="
                                                                            industryCategories
                                                                        "
                                                                        placeholder="Select a Industry Category"
                                                                        label="industryCategory"
                                                                        track-by="industryCategory"
                                                                    ></multiselect>
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
                                                                    for="KodPTJ"
                                                                    class="form-label"
                                                                    >PTJ</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <input
                                                                        type="text"
                                                                        class="form-control"
                                                                        :value="
                                                                            dataTheMOU?.ptjNama
                                                                        "
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
                                                                    for="KodPTJSub"
                                                                    class="form-label"
                                                                    >PBU</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <multiselect
                                                                        :disabled="
                                                                            !isPUU
                                                                        "
                                                                        :allow-empty="
                                                                            false
                                                                        "
                                                                        v-model="
                                                                            form
                                                                                .form1
                                                                                .KodPTJSub
                                                                        "
                                                                        :options="
                                                                            PBUs
                                                                        "
                                                                        placeholder="Select a PBU"
                                                                        label="namaPBU"
                                                                        track-by="namaPBU"
                                                                    ></multiselect>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
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
                                                        <div class="col-lg-6">
                                                            <div
                                                                class="form-group"
                                                            >
                                                                <label
                                                                    for="Negara"
                                                                    class="form-label"
                                                                    >Country</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <multiselect
                                                                        :allow-empty="
                                                                            false
                                                                        "
                                                                        v-model="
                                                                            Negara
                                                                        "
                                                                        :options="
                                                                            countries
                                                                        "
                                                                        placeholder="Select a Country"
                                                                        label="name"
                                                                        track-by="name"
                                                                    ></multiselect>
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
                                                                    <!-- <button
                                                                        class="btn btn-outline-primary"
                                                                        type="button"
                                                                        id="button-addon2"
                                                                        data-bs-toggle="modal"
                                                                        data-bs-target="#searchPICsModal"
                                                                    >
                                                                        Search
                                                                        Members
                                                                    </button> -->
                                                                </div>
                                                                <!-- <div
                                                                    class="btn btn-link"
                                                                    v-on:click="
                                                                        assignYourselfPIC
                                                                    "
                                                                >
                                                                    Assign
                                                                    yourself
                                                                </div> -->
                                                                <div
                                                                    class="modal fade"
                                                                    id="searchPICsModal"
                                                                    tabindex="-1"
                                                                    aria-labelledby="searchPICsModalLabel"
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
                                                                                    id="searchPICsModalLabel"
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
                                                                                <TableUserSimpleComponent
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
                                                                    Fair Copy
                                                                    Document</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <input
                                                                        :disabled="
                                                                            !isPUU
                                                                        "
                                                                        class="form-control"
                                                                        type="file"
                                                                        @change="
                                                                            (
                                                                                evt
                                                                            ) =>
                                                                                handleFileUpload(
                                                                                    evt,
                                                                                    'faircopy'
                                                                                )
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
                                                                    for="NamaDok"
                                                                    class="form-label"
                                                                    >Uploaded
                                                                    Fair Copy
                                                                    Document</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <div
                                                                        class="btn btn-link"
                                                                        v-if="
                                                                            filePath?.faircopy
                                                                        "
                                                                    >
                                                                        <a
                                                                            :href="`${publicPath}${filePath?.faircopy}`"
                                                                            target="_blank"
                                                                            >{{
                                                                                fileName?.faircopy
                                                                            }}</a
                                                                        >
                                                                    </div>
                                                                    <div v-else>
                                                                        N/A
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <div
                                                                class="form-group"
                                                            >
                                                                <label
                                                                    for="DokStamp"
                                                                    class="form-label"
                                                                    >Upload a
                                                                    Stamped
                                                                    Document</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <input
                                                                        :disabled="
                                                                            !isPUU
                                                                        "
                                                                        class="form-control"
                                                                        type="file"
                                                                        @change="
                                                                            (
                                                                                evt
                                                                            ) =>
                                                                                handleFileUpload(
                                                                                    evt,
                                                                                    'stamped'
                                                                                )
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
                                                                    for="DokStamp"
                                                                    class="form-label"
                                                                    >Uploaded
                                                                    Stamped
                                                                    Document</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <div
                                                                        class="btn btn-link"
                                                                        v-if="
                                                                            filePath?.stamped
                                                                        "
                                                                    >
                                                                        <a
                                                                            :href="`${publicPath}${filePath?.stamped}`"
                                                                            target="_blank"
                                                                            >{{
                                                                                fileName?.stamped
                                                                            }}</a
                                                                        >
                                                                    </div>
                                                                    <div v-else>
                                                                        N/A
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <div
                                                                class="form-group"
                                                            >
                                                                <label
                                                                    for="DokMinit"
                                                                    class="form-label"
                                                                    >Upload a
                                                                    Minutes
                                                                    Document</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <input
                                                                        :disabled="
                                                                            !isUS &&
                                                                            !isPUU
                                                                        "
                                                                        class="form-control"
                                                                        type="file"
                                                                        @change="
                                                                            (
                                                                                evt
                                                                            ) =>
                                                                                handleFileUpload(
                                                                                    evt,
                                                                                    'minutes'
                                                                                )
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
                                                                    for="DokMinit"
                                                                    class="form-label"
                                                                    >Uploaded
                                                                    Minutes
                                                                    Document</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <div
                                                                        class="btn btn-link"
                                                                        v-if="
                                                                            filePath?.minutes
                                                                        "
                                                                    >
                                                                        <a
                                                                            :href="`${publicPath}${filePath?.minutes}`"
                                                                            target="_blank"
                                                                            >{{
                                                                                fileName?.minutes
                                                                            }}</a
                                                                        >
                                                                    </div>
                                                                    <div v-else>
                                                                        N/A
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <div
                                                                class="form-group"
                                                            >
                                                                <label
                                                                    for="DokLulus"
                                                                    class="form-label"
                                                                    >Upload an
                                                                    Approved
                                                                    Document</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <input
                                                                        :disabled="
                                                                            !isPIC &&
                                                                            !isPUU
                                                                        "
                                                                        class="form-control"
                                                                        type="file"
                                                                        @change="
                                                                            (
                                                                                evt
                                                                            ) =>
                                                                                handleFileUpload(
                                                                                    evt,
                                                                                    'approved'
                                                                                )
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
                                                                    for="DokLulus"
                                                                    class="form-label"
                                                                    >Uploaded
                                                                    Approved
                                                                    Document</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <div
                                                                        class="btn btn-link"
                                                                        v-if="
                                                                            filePath?.approved
                                                                        "
                                                                    >
                                                                        <a
                                                                            :href="`${publicPath}${filePath?.approved}`"
                                                                            target="_blank"
                                                                            >{{
                                                                                fileName?.approved
                                                                            }}</a
                                                                        >
                                                                    </div>
                                                                    <div v-else>
                                                                        N/A
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-12">
                                                            <div
                                                                class="form-group"
                                                            >
                                                                <label
                                                                    for="KodInd"
                                                                    class="form-label"
                                                                    >Fields</label
                                                                >
                                                                <div
                                                                    class="form-control-wrap"
                                                                >
                                                                    <multiselect
                                                                        :disabled="
                                                                            !isPUU
                                                                        "
                                                                        :multiple="
                                                                            true
                                                                        "
                                                                        v-model="
                                                                            form
                                                                                .form1
                                                                                .KodFields
                                                                        "
                                                                        :options="
                                                                            fields
                                                                        "
                                                                        placeholder="Select a Field"
                                                                        label="field"
                                                                        track-by="field"
                                                                    ></multiselect>
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
                                                        <div v-if="isPIC">
                                                            <button
                                                                class="btn btn-outline-primary"
                                                                type="button"
                                                                id="button-addon2"
                                                                data-bs-toggle="modal"
                                                                data-bs-target="#searchMembersModal"
                                                            >
                                                                Add Members
                                                            </button>
                                                        </div>
                                                        <TableUserSimpleComponent
                                                            :users="members"
                                                            tableType="memoMOUMembers"
                                                            @removeMembers="
                                                                removeMembers
                                                            "
                                                            :isNotDatatable="
                                                                true
                                                            "
                                                        />
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
                                                                            Members
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
                                                                        <TableUserSimpleComponent
                                                                            :users="
                                                                                allStaffSimple
                                                                            "
                                                                            tableType="memoMembers"
                                                                            @addMembers="
                                                                                addMembers
                                                                            "
                                                                        />
                                                                    </div>
                                                                    <div
                                                                        class="modal-footer"
                                                                    >
                                                                        <button
                                                                            id="closeBtnMembers"
                                                                            type="button"
                                                                            class="btn btn-sm btn-secondary"
                                                                            data-bs-dismiss="modal"
                                                                        >
                                                                            Close
                                                                        </button>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
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
                                                        <TableKPIComponent
                                                            :isPIC="isPIC"
                                                            :kpis="
                                                                form.form3.kpis
                                                            "
                                                            :listKPIs="KPIs"
                                                        />
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
                                                                    isPUU ||
                                                                    isUS ||
                                                                    menuNo === 3
                                                                "
                                                                href="#"
                                                                class="btn btn-success"
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
import Multiselect from "vue-multiselect";
import "vue-multiselect/dist/vue-multiselect.min.css";

import ValidateMeComponent from "@/components/ValidateMe.vue";
import NavbarComponent from "@/components/Navbar.vue";
import TopNavComponent from "@/components/TopNav.vue";
import FooterComponent from "@/components/Footer.vue";
import LoadingComponent from "@/components/Loading.vue";
import InfoNotLoggedInComponent from "@/components/InfoNotLoggedIn.vue";
import TableUserSimpleComponent from "@/components/TableUserSimple.vue";
import TableKPIComponent from "@/components/TableKPI.vue";
import { getBearerToken } from "@/utils/tokenManagement";
import {
    useStaffProfile,
    useGetMOUSelectData,
    useGetAllStaffSimple,
    useHandleFileUpload,
    useMouUpdateMemo,
    useGetOneMOU,
} from "@/hooks/useAPI";

export default {
    name: "MemoEditView",
    data() {
        return {
            menuNo: 1,
            loadingAddMOU: false,
            addedMOUNoMemo: "",
            charLimit: 500,
            isLimitReached: false,
        };
    },
    components: {
        ValidateMeComponent,
        NavbarComponent,
        TopNavComponent,
        FooterComponent,
        LoadingComponent,
        InfoNotLoggedInComponent,
        TableUserSimpleComponent,
        TableKPIComponent,
        Multiselect,
    },
    setup() {
        const publicPath = ref(process.env.VUE_APP_PUBLIC_PATH);

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

        const countries = ref([]);
        const categories = ref([]);
        const types = ref([]);
        const scopes = ref([]);
        const PTJs = ref([]);
        const PBUsOri = ref([]);
        const PBUs = ref([]);
        const KPIs = ref([]);
        const industryCategories = ref([]);
        const fields = ref([]);
        watch(
            () => dataMouSelectData.value,
            (dataMouSelectDataUpdated) => {
                countries.value = dataMouSelectDataUpdated?.countries || [];
                categories.value = dataMouSelectDataUpdated?.kategoriMemo || [];
                types.value = dataMouSelectDataUpdated?.jenisMemo || [];
                scopes.value = dataMouSelectDataUpdated?.scopeMemo || [];
                PTJs.value = dataMouSelectDataUpdated?.ptj || [];
                PBUsOri.value = dataMouSelectDataUpdated?.subPTJ || [];
                KPIs.value = dataMouSelectDataUpdated?.kpIs || [];
                industryCategories.value =
                    dataMouSelectDataUpdated?.industryCategories || [];
                fields.value = dataMouSelectDataUpdated?.fields || [];
            }
        );

        const KodKategori = ref("");
        const KodJenis = ref("");
        const KodPTJ = ref("");
        const NoMemo = ref("");
        const Negara = ref("");
        const IndustryCategory = ref("");

        const { data: dataAllStaffSimple } = useGetAllStaffSimple();
        const allStaffSimple = ref([]);
        watch(
            () => dataAllStaffSimple.value,
            (newDataAllStaffSimple) => {
                allStaffSimple.value = newDataAllStaffSimple;
            }
        );

        const filePath = ref({
            faircopy: "",
            approved: "",
            minutes: "",
            stamped: "",
        });
        const fileName = ref({
            faircopy: "",
            approved: "",
            minutes: "",
            stamped: "",
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

        const params = new URLSearchParams(window.location.search);
        const noMemo = params.get("memo") || "";

        const isAdmin = ref(false);
        const isPUU = ref(false);
        const isPTJ = ref(false);
        const isUS = ref(false);
        const isPIC = ref(false);
        const loadingTheMOU = ref(true);
        const dataTheMOU = ref(null);
        const staffPIC = ref("");
        const members = ref([]);
        const form = ref({
            form1: {
                TajukProjek: "",
                KodScope: "",
                TarikhMula: "",
                TarikhTamat: "",
                KodPTJSub: "",
                NamaDok: "",
                Path: "",
                Nilai: "0",
                MS01_NoStaf: "",
                KodInd: "",
                KodFields: [],
            },
            form2: {},
            form3: {
                kpis: [],
            },
        });

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
                            NoMemo.value = newDataMOU?.noMemo;
                            KodKategori.value = newDataMOU?.kodKategori;
                            KodJenis.value = newDataMOU?.kodJenis;
                            KodPTJ.value = newDataMOU?.kodPTJ;
                            PBUs.value = [...PBUsOri.value].filter(
                                (p) => p.kodPejPBU == newDataMOU?.kodPTJ
                            );
                            form.value.form1.KodScope = {
                                kod: newDataMOU?.kodScope,
                                butiran: newDataMOU?.scopeButiran,
                            };
                            form.value.form1.KodPTJSub = {
                                kodPBU: newDataMOU?.kodPTJSub,
                                namaPBU: newDataMOU?.subPTJNama,
                            };
                            form.value.form1.KodFields = newDataMOU?.fields;
                            Negara.value = {
                                code: newDataMOU?.negara?.code,
                                name: newDataMOU?.negara?.name,
                            };
                            IndustryCategory.value = {
                                kodInd: newDataMOU?.industryCategory?.kodInd,
                                industryCategory:
                                    newDataMOU?.industryCategory
                                        ?.industryCategory,
                            };
                            form.value.form1.TarikhMula =
                                newDataMOU?.tarikhMulaDate2;
                            form.value.form1.TarikhTamat =
                                newDataMOU?.tarikhTamatDate2;
                            form.value.form1.TajukProjek =
                                newDataMOU?.tajukProjek;
                            filePath.value.faircopy = newDataMOU?.path;
                            fileName.value.faircopy = newDataMOU?.namaDok;
                            filePath.value.stamped = newDataMOU?.dokStampPath;
                            fileName.value.stamped = newDataMOU?.dokStamp;
                            filePath.value.minutes = newDataMOU?.dokMinitPath;
                            fileName.value.minutes = newDataMOU?.dokMinit;
                            filePath.value.approved = newDataMOU?.dokLulusPath;
                            fileName.value.approved = newDataMOU?.dokLulus;
                            form.value.form1.MS01_NoStaf =
                                newDataMOU?.noStafPIC;
                            const gelaran = newDataMOU?.picGelaran
                                ?.toLowerCase()
                                ?.includes("tiada")
                                ? ""
                                : newDataMOU?.picGelaran;
                            staffPIC.value = `${gelaran} ${newDataMOU?.pic} (${newDataMOU?.noStafPIC} | ${newDataMOU?.picEmail})`;
                            members.value = [...newDataMOU?.members];
                            form.value.form3.kpis = [...newDataMOU?.kpIs].map(
                                (kpi) => {
                                    return {
                                        ...kpi,
                                        KPI_ID: kpi.kpI_ID,
                                        Amaun:
                                            kpi.amaun > 0
                                                ? kpi.amaun
                                                : kpi.nilai,
                                        isAmount: kpi.amaun > 0,
                                        Penerangan: kpi.penerangan,
                                        TarikhMula: kpi.tarikhMulaDate2,
                                        TarikhTamat: kpi.tarikhTamatDate2,
                                        Komen: kpi.komen,
                                        Nama: kpi.nama,
                                        Kod: kpi.kod,
                                    };
                                }
                            );
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

        return {
            publicPath,
            dataStaffProfile,
            errorStaffProfile,
            loadingStaffProfile,
            dataMouSelectData,
            errorMouSelectData,
            loadingMouSelectData,
            countries,
            categories,
            types,
            scopes,
            PTJs,
            PBUsOri,
            PBUs,
            KPIs,
            KodKategori,
            KodJenis,
            KodPTJ,
            NoMemo,
            Negara,
            IndustryCategory,
            allStaffSimple,
            filePath,
            fileName,
            handleFileUpload,
            isAdmin,
            isPUU,
            isPTJ,
            isUS,
            isPIC,
            loadingTheMOU,
            dataTheMOU,
            staffPIC,
            members,
            form,
            industryCategories,
            fields,
        };
    },
    computed: {
        textareaStyle() {
            return {
                backgroundColor: this.isLimitReached
                    ? "rgba(255, 0, 0, 0.2)"
                    : "white",
            };
        },
    },
    methods: {
        handleChoosePIC(user) {
            const gelaran = user?.gelaran?.toLowerCase()?.includes("tiada")
                ? ""
                : user?.gelaran;
            this.staffPIC = `${gelaran} ${user?.nama} (${user?.noStaf} | ${user?.email})`;
            this.form.form1.MS01_NoStaf = user?.noStaf;
            document.getElementById("closeBtnPICs").click();
        },
        addMembers(user) {
            const member = this.members.find((m) => m.noStaf === user.noStaf);
            if (!member) {
                this.members.push(user);
                document.getElementById("closeBtnMembers").click();
            } else {
                this.$toast.open({
                    message:
                        "That staff has been added as part of the members.",
                    type: "error",
                    position: "top-right",
                });
            }
        },
        removeMembers(user) {
            const members = this.members.filter(
                (m) => m.noStaf !== user.noStaf
            );
            this.members = members;
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
        // saveKPIs(kpis) {
        //     this.form.form3.kpis = kpis;
        // },
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
            // var nilai = 0;
            // this.form.form3.kpis.map((kpi) => {
            //     nilai =
            //         kpi.isAmount == false ? parseInt(kpi.Amaun) + nilai : nilai;
            //     return kpi;
            // });
            const finalForm = {
                NoMemo: this.NoMemo,
                form1: {
                    KodKategori: this.KodKategori,
                    KodJenis: this.KodJenis,
                    KodPTJ: this.KodPTJ,
                    KodScope: this.form.form1.KodScope.kod,
                    KodPTJSub: this.form.form1.KodPTJSub.kodPBU,
                    TarikhMula: this.form.form1.TarikhMula,
                    TarikhTamat: this.form.form1.TarikhTamat,
                    TajukProjek: this.form.form1.TajukProjek,
                    NamaDok: this.fileName?.faircopy,
                    Path: this.filePath?.faircopy,
                    MS01_NoStaf: this.form.form1.MS01_NoStaf,
                    // Nilai: nilai,
                    Negara: this.Negara.code,
                    KodInd: this.IndustryCategory.kodInd,
                    DokStamp: this.fileName?.stamped,
                    DokStampPath: this.filePath?.stamped,
                    DokMinit: this.fileName?.minutes,
                    DokMinitPath: this.filePath?.minutes,
                    DokLulus: this.fileName?.approved,
                    DokLulusPath: this.filePath?.approved,
                },
                form2: {
                    Members: this.members.map((member) => {
                        return {
                            NoStaf: member.noStaf,
                            Peranan: member.roles
                                .map((role) => role.role)
                                .join("|"),
                        };
                    }),
                },
                form3: {
                    KPIs: this.form.form3.kpis.map((kpi, kpiIndex) => {
                        return {
                            KPI_ID: kpi?.kpI_ID || 0,
                            Amaun: kpi.Amaun,
                            isAmount: kpi.isAmount,
                            MOU04_Number: kpiIndex,
                            Penerangan: kpi.Penerangan,
                            TarikhMula: kpi.TarikhMula,
                            TarikhTamat: kpi.TarikhTamat,
                            Komen: kpi.Komen,
                            Nama: kpi.Nama,
                            Kod: kpi.Kod,
                        };
                    }),
                },
                KodFields: this.form.form1.KodFields?.map((kf) => kf.kodField),
            };

            const {
                data: dataAddMOU,
                loading: loadingAddMOU,
                error: errorAddMOU,
            } = useMouUpdateMemo(finalForm);

            this.loadingAddMOU = true;
            var self = this;
            watch(
                () => loadingAddMOU.value,
                (newLoadingAddMOU) => {
                    self.loadingAddMOU = newLoadingAddMOU;
                }
            );
            watch(
                () => dataAddMOU.value,
                (newDataAddMOU) => {
                    self.addedMOUNoMemo = newDataAddMOU?.noMemo;
                    if (newDataAddMOU?.noMemo) {
                        location.href = `${self.publicPath}memo-detail?memo=${self.NoMemo}`;
                    }
                }
            );
            watch(
                () => errorAddMOU.value,
                (newErrorAddMOU) => {
                    if (newErrorAddMOU) {
                        self.$toast.open({
                            message:
                                "Saving error! Please contact the system administrator.",
                            type: "error",
                            position: "top-right",
                        });
                    }
                }
            );
        },
        checkLength() {
            if (this.form.form1.TajukProjek.length > this.charLimit) {
                this.form.form1.TajukProjek =
                    this.form.form1.TajukProjek?.substring(0, this.charLimit);
                this.isLimitReached = true;
            } else {
                this.isLimitReached = false;
            }
        },
    },
};
</script>
