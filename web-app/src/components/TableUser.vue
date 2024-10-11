<template>
    <div class="card">
        <table
            :class="['table', { 'datatable-init': isNotDatatable !== true }]"
            data-nk-container="table-responsive"
        >
            <thead class="table-light">
                <tr>
                    <th class="tb-col">
                        <span class="overline-title">Name</span>
                    </th>
                    <th class="tb-col">
                        <span class="overline-title">Roles</span>
                    </th>
                    <th class="tb-col">
                        <span class="overline-title">Status</span>
                    </th>
                    <th class="tb-col tb-col-end" data-sortable="false">
                        <span class="overline-title">Action</span>
                    </th>
                </tr>
            </thead>
            <tbody v-if="localUsers?.length > 0">
                <tr v-bind:key="user.noStaf" v-for="user in localUsers">
                    <td class="tb-col">
                        <div class="media-group">
                            <div
                                class="media media-md media-middle media-circle"
                            >
                                <img
                                    src="../assets/images/avatar/a.jpg"
                                    alt="user"
                                />
                            </div>
                            <div class="media-text">
                                <a
                                    :href="`${publicPath}user-edit?s=${user.noStaf}`"
                                    class="title"
                                    v-if="tableType == null"
                                    >{{ getNama(user) }}</a
                                >
                                <a
                                    href="#"
                                    class="title"
                                    @click="choosePIC(user)"
                                    :data-pic="`${JSON.stringify(user)}`"
                                    v-if="tableType == 'memoPICs'"
                                >
                                    {{ getNama(user) }}
                                </a>
                                <a
                                    href="#"
                                    class="title"
                                    @click="addMember(user)"
                                    :data-member="`${JSON.stringify(user)}`"
                                    v-if="tableType == 'memoMembers'"
                                >
                                    {{ getNama(user) }}
                                </a>
                                <a
                                    href="#"
                                    class="title"
                                    @click="removeMember(user)"
                                    :data-moumember="`${JSON.stringify(user)}`"
                                    v-if="tableType == 'memoMOUMembers'"
                                >
                                    {{ getNama(user) }}
                                </a>
                                <span class="small text"
                                    >{{ user.noStaf }} | {{ user.email }}</span
                                >
                            </div>
                        </div>
                    </td>
                    <td class="tb-col">
                        {{
                            user.roles?.length > 0
                                ? user.roles?.map((r) => r.role)?.join(", ")
                                : "-"
                        }}
                    </td>
                    <td class="tb-col">
                        <span
                            class="badge text-bg-danger-soft"
                            v-if="user.roles?.length <= 0"
                            >Inactive</span
                        >
                        <span
                            class="badge text-bg-success-soft"
                            v-if="
                                user.roles?.length > 0 &&
                                user.roles?.find((r) => r.role === 'Staff')
                            "
                            >Active</span
                        >
                    </td>
                    <td class="tb-col tb-col-end">
                        <div class="dropdown">
                            <a
                                href="#"
                                class="btn btn-sm btn-icon btn-zoom me-n1"
                                data-bs-toggle="dropdown"
                            >
                                <em class="icon ni ni-more-v"></em>
                            </a>
                            <div
                                class="dropdown-menu dropdown-menu-sm dropdown-menu-end"
                            >
                                <div class="dropdown-content py-1">
                                    <ul
                                        class="link-list link-list-hover-bg-primary link-list-md"
                                    >
                                        <li>
                                            <a
                                                :href="`${publicPath}user-edit?s=${user.noStaf}`"
                                                v-if="tableType == null"
                                                ><em
                                                    class="icon ni ni-edit"
                                                ></em
                                                ><span>Update User</span></a
                                            >
                                        </li>
                                        <li>
                                            <a
                                                href="#"
                                                @click="choosePIC(user)"
                                                :data-pic="`${JSON.stringify(
                                                    user
                                                )}`"
                                                v-if="tableType == 'memoPICs'"
                                                ><em
                                                    class="icon ni ni-done"
                                                ></em
                                                ><span>Choose User</span></a
                                            >
                                        </li>
                                        <li>
                                            <a
                                                href="#"
                                                @click="addMember(user)"
                                                :data-member="`${JSON.stringify(
                                                    user
                                                )}`"
                                                v-if="
                                                    tableType == 'memoMembers'
                                                "
                                                ><em
                                                    class="icon ni ni-plus"
                                                ></em
                                                ><span>Add User</span></a
                                            >
                                        </li>
                                        <li>
                                            <a
                                                href="#"
                                                @click="removeMember(user)"
                                                :data-moumember="`${JSON.stringify(
                                                    user
                                                )}`"
                                                v-if="
                                                    tableType ==
                                                    'memoMOUMembers'
                                                "
                                                ><em
                                                    class="icon ni ni-cross"
                                                ></em
                                                ><span>Remove User</span></a
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
            <tbody v-else></tbody>
        </table>
    </div>
</template>

<script>
import { watchEffect, ref } from "vue";
import $ from "jquery";

export default {
    name: "TableUserComponent",
    props: {
        users: {
            type: Array,
            required: true,
        },
        tableType: {
            type: String,
            required: false,
        },
        isNotDatatable: {
            type: Boolean,
            required: false,
        },
    },
    data() {
        return {
            publicPath: process.env.VUE_APP_PUBLIC_PATH,
        };
    },
    setup(props, { emit }) {
        const choosePIC = (user) => {
            emit("handleChoosePIC", user);
        };
        const addMember = (user) => {
            emit("addMembers", user);
        };
        const removeMember = (user) => {
            emit("removeMembers", user);
        };
        const initDatatable = () => {
            $(".datatable-init").on("click", "a", (event) => {
                if (props.tableType === "memoPICs") {
                    const dataPICRaw = event.target?.dataset?.pic;
                    if (dataPICRaw) {
                        choosePIC(JSON.parse(dataPICRaw));
                    }
                }
                if (props.tableType === "memoMembers") {
                    const dataMemberRaw = event.target?.dataset?.member;
                    if (dataMemberRaw) {
                        addMember(JSON.parse(dataMemberRaw));
                    }
                }
                if (props.tableType === "memoMOUMembers") {
                    const dataMOUMemberRaw = event.target?.dataset?.moumember;
                    if (dataMOUMemberRaw) {
                        removeMember(JSON.parse(dataMOUMemberRaw));
                    }
                }
            });
        };

        const localUsers = ref([...props.users]);
        watchEffect(() => {
            localUsers.value = [...props.users];
            initDatatable();
        });

        return {
            localUsers,
            choosePIC,
            addMember,
            removeMember,
            initDatatable,
        };
    },
    methods: {
        getNama(user) {
            return (
                (user.gelaran?.toLowerCase()?.includes("tiada")
                    ? ""
                    : user.gelaran) +
                " " +
                user.nama
            );
        },
    },
};
</script>
