<template>
    <div class="card">
        <table
            class="datatable-init table"
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
            <tbody>
                <tr v-bind:key="user.noStaf" v-for="user in users">
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
                                    >{{
                                        user.gelaran
                                            ?.toLowerCase()
                                            ?.includes("tiada")
                                            ? ""
                                            : user.gelaran
                                    }}
                                    {{ user.nama }}</a
                                >
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
                                                ><em
                                                    class="icon ni ni-edit"
                                                ></em
                                                ><span>Update User</span></a
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
</template>

<script>
export default {
    name: "TableUserMgtComponent",
    props: {
        users: String,
    },
    data() {
        return {
            publicPath: process.env.VUE_APP_PUBLIC_PATH,
        };
    },
};
</script>
