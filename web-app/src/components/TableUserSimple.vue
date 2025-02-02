<template>
    <div class="card">
        <!-- Filter Input -->
        <div class="mb-3">
            <input
                v-model="filterText"
                class="form-control"
                placeholder="Filter by Type"
            />
        </div>
        <!-- Table -->
        <table class="table table-bordered">
            <thead>
                <tr class="alert alert-secondary">
                    <th @click="sortList('nama')">Staff</th>
                    <th @click="sortList('roles')" v-if="isFull">Roles</th>
                    <th @click="sortList('status')" v-if="isFull">Status</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody v-if="paginatedList?.length > 0">
                <tr v-for="item in paginatedList" :key="item?.noStaf">
                    <td>
                        <a
                            :href="`${publicPath}user-edit?s=${item.noStaf}`"
                            class="title"
                            v-if="tableType == null"
                            >{{ getNama(item) }}</a
                        >
                        <a
                            href="#"
                            class="title"
                            @click="choosePIC(item)"
                            v-if="tableType == 'memoPICs'"
                        >
                            {{ getNama(item) }}
                        </a>
                        <a
                            href="#"
                            class="title"
                            @click="addMember(item)"
                            v-if="tableType == 'memoMembers'"
                        >
                            {{ getNama(item) }}
                        </a>
                        <a
                            href="#"
                            class="title"
                            @click="removeMember(item)"
                            v-if="tableType == 'memoMOUMembers'"
                        >
                            {{ getNama(item) }}
                        </a>
                        <div class="small text">
                            {{ item.nPejabat || item.jGiliran }}
                        </div>
                    </td>
                    <td
                        v-if="isFull"
                        v-html="
                            item.roles?.length > 0
                                ? item.roles?.length > 1
                                    ? item.roles
                                          ?.filter((r) => r.code != 'Staff')
                                          .map((r) => r.role)
                                          ?.join(',<br />')
                                    : 'Staff'
                                : '-'
                        "
                    ></td>
                    <td v-if="isFull">
                        <span
                            class="badge text-bg-danger-soft"
                            v-if="item.roles?.length <= 0"
                            >Inactive</span
                        >
                        <span
                            class="badge text-bg-success"
                            v-if="
                                item.roles?.length > 0 &&
                                item.roles?.find((r) => r.code === 'Staff')
                            "
                            >Active</span
                        >
                    </td>
                    <td>
                        <button
                            :href="`${publicPath}user-edit?s=${item.noStaf}`"
                            type="button"
                            v-if="tableType == null"
                            class="btn btn-sm btn-primary me-2"
                        >
                            Update User
                        </button>
                        <button
                            type="button"
                            v-if="tableType == 'memoPICs'"
                            class="btn btn-sm btn-primary me-2"
                            @click="() => choosePIC(item)"
                        >
                            Choose User
                        </button>
                        <button
                            type="button"
                            v-if="tableType == 'memoMembers'"
                            class="btn btn-sm btn-primary me-2"
                            @click="() => addMember(item)"
                        >
                            Add User
                        </button>
                        <button
                            type="button"
                            v-if="tableType == 'memoMOUMembers'"
                            class="btn btn-sm btn-primary me-2"
                            @click="() => removeMember(item)"
                        >
                            Remove User
                        </button>
                    </td>
                </tr>
            </tbody>
        </table>
        <!-- Pagination -->
        <nav>
            <ul class="pagination">
                <li class="page-item" :class="{ disabled: currentPage === 1 }">
                    <button type="button" class="page-link" @click="prevPage">
                        Previous
                    </button>
                </li>
                <li
                    class="page-item"
                    v-for="page in totalPages"
                    :key="page"
                    :class="{ active: page === currentPage }"
                >
                    <button
                        type="button"
                        class="page-link"
                        @click="changePage(page)"
                    >
                        {{ page }}
                    </button>
                </li>
                <li
                    class="page-item"
                    :class="{
                        disabled: currentPage === totalPages,
                    }"
                >
                    <button type="button" class="page-link" @click="nextPage">
                        Next
                    </button>
                </li>
            </ul>
        </nav>
    </div>
</template>

<script>
import { ref, watch, watchEffect } from "vue";

export default {
    name: "TableUserSimpleComponent",
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
        isFull: {
            type: Boolean,
            required: false,
        },
    },
    setup(props, { emit }) {
        const publicPath = ref(process.env.VUE_APP_PUBLIC_PATH);

        const filterText = ref("");
        const currentPage = ref(1);
        const itemsPerPage = ref(100);

        const filteredList = ref([]);
        const paginatedList = ref([]);
        const totalPages = ref(0);

        const choosePIC = (user) => {
            emit("handleChoosePIC", user);
        };

        const addMember = (user) => {
            emit("addMembers", user);
        };

        const removeMember = (user) => {
            emit("removeMembers", user);
        };

        const getNama = (user) => {
            return (
                (user.gelaran?.toLowerCase()?.includes("tiada")
                    ? ""
                    : user.gelaran) +
                " " +
                user.nama
            );
        };

        const localUsers = ref([...props.users]);
        watchEffect(() => {
            localUsers.value = [...props.users];
            paginatedList.value = [...props.users];
        });

        watch(
            [localUsers, filterText],
            ([newLocalUsers, newFilterText]) => {
                const filtered =
                    newLocalUsers?.filter((item) =>
                        // using getNama to get the proper display name
                        getNama(item)
                            .toLowerCase()
                            .includes(newFilterText.toLowerCase())
                    ) || [];

                filteredList.value = filtered;

                const start = (currentPage.value - 1) * itemsPerPage.value;
                paginatedList.value = filtered.slice(
                    start,
                    start + itemsPerPage.value
                );
                totalPages.value = Math.ceil(
                    filtered.length / itemsPerPage.value
                );
            },
            { immediate: true }
        );

        const changePage = (page) => {
            currentPage.value = page;
            const start = (page - 1) * itemsPerPage.value;
            paginatedList.value = filteredList.value.slice(
                start,
                start + itemsPerPage.value
            );
        };

        const prevPage = () => {
            if (currentPage.value > 1) currentPage.value--;
        };

        const nextPage = () => {
            if (currentPage.value < totalPages.value) currentPage.value++;
        };

        const sortColumn = ref(null);
        const sortOrder = ref(1);
        const sortList = (column) => {
            if (sortColumn.value === column) {
                sortOrder.value *= -1;
            } else {
                sortColumn.value = column;
                sortOrder.value = 1;
            }
        };

        return {
            publicPath,
            filterText,
            localUsers,
            filteredList,
            paginatedList,
            totalPages,
            currentPage,
            changePage,
            prevPage,
            nextPage,
            sortList,
            choosePIC,
            addMember,
            removeMember,
            getNama,
        };
    },
};
</script>
