<template>
    <div class="nk-app-root">
        <div class="nk-main">
            <NavbarComponent
                :staffprofile="dataStaffProfile"
                :activeLabel="`codes`"
            />
            <div class="nk-wrap">
                <TopNavComponent
                    :staffprofile="dataStaffProfile"
                    :errorStaffProfile="errorStaffProfile"
                />
                <LoadingComponent :loading="loading" />
                <div class="nk-content" v-if="errorStaffProfile">
                    <InfoNotLoggedInComponent />
                </div>
                <div class="nk-content" v-if="!errorStaffProfile">
                    <div class="container">
                        <nav aria-label="breadcrumb" class="mb-3">
                            <ol class="breadcrumb">
                                <li class="breadcrumb-item">
                                    <a :href="`${publicPath}codes`"
                                        >Manage Codes/Utilities</a
                                    >
                                </li>
                                <li
                                    class="breadcrumb-item active"
                                    aria-current="page"
                                >
                                    Manage Categories
                                </li>
                            </ol>
                        </nav>

                        <h1 class="mb-3">Manage Categories</h1>

                        <!-- Filter Input -->
                        <div class="mb-3">
                            <input
                                v-model="filterText"
                                class="form-control"
                                placeholder="Filter by Category"
                            />
                        </div>

                        <!-- Add Button -->
                        <button
                            class="btn btn-primary mb-3"
                            @click="openCreateModal"
                        >
                            Add New Category
                        </button>

                        <!-- Table -->
                        <table class="table table-bordered">
                            <thead>
                                <tr class="alert alert-secondary">
                                    <th @click="sortList('kod')">Kod</th>
                                    <th @click="sortList('butiran')">
                                        Category
                                    </th>
                                    <th>Actions</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr
                                    v-for="item in paginatedList"
                                    :key="item?.kod"
                                >
                                    <td>{{ item?.kod }}</td>
                                    <td>{{ item?.butiran }}</td>
                                    <td>
                                        <button
                                            class="btn btn-sm btn-warning me-2"
                                            @click="openUpdateModal(item)"
                                        >
                                            Edit
                                        </button>
                                        <button
                                            class="btn btn-sm btn-danger"
                                            @click="openDeleteModal(item)"
                                        >
                                            Delete
                                        </button>
                                    </td>
                                </tr>
                            </tbody>
                        </table>

                        <!-- Pagination -->
                        <nav>
                            <ul class="pagination">
                                <li
                                    class="page-item"
                                    :class="{ disabled: currentPage === 1 }"
                                >
                                    <button class="page-link" @click="prevPage">
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
                                    <button class="page-link" @click="nextPage">
                                        Next
                                    </button>
                                </li>
                            </ul>
                        </nav>

                        <!-- Create/Update Modal -->
                        <div
                            class="modal"
                            v-bind:class="{ show: isModalVisible }"
                            v-if="isModalVisible"
                        >
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title">
                                            {{
                                                isEdit
                                                    ? "Update Category"
                                                    : "Create Category"
                                            }}
                                        </h5>
                                        <button
                                            type="button"
                                            class="btn-close"
                                            @click="closeModal"
                                        ></button>
                                    </div>
                                    <div class="modal-body">
                                        <div class="mb-3">
                                            <label for="kod" class="form-label"
                                                >Kod</label
                                            >
                                            <input
                                                id="kod"
                                                v-model="form.kod"
                                                :disabled="isEdit"
                                                class="form-control"
                                                maxlength="2"
                                            />
                                        </div>
                                        <div class="mb-3">
                                            <label
                                                for="butiran"
                                                class="form-label"
                                                >Category</label
                                            >
                                            <input
                                                id="butiran"
                                                v-model="form.butiran"
                                                class="form-control"
                                                maxlength="150"
                                            />
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <button
                                            type="button"
                                            class="btn btn-secondary"
                                            @click="closeModal"
                                        >
                                            Cancel
                                        </button>
                                        <button
                                            type="button"
                                            class="btn btn-primary"
                                            @click="submitForm"
                                        >
                                            {{ isEdit ? "Update" : "Create" }}
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!-- Delete Confirmation Modal -->
                        <div
                            class="modal"
                            v-bind:class="{ show: isDeleteModalVisible }"
                            v-if="isDeleteModalVisible"
                        >
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title">
                                            Confirm Deletion
                                        </h5>
                                        <button
                                            type="button"
                                            class="btn-close"
                                            @click="closeDeleteModal"
                                        ></button>
                                    </div>
                                    <div class="modal-body">
                                        <p>
                                            Are you sure you want to delete the
                                            Category with Kod:
                                            {{ IdToDelete?.kod }}?
                                        </p>
                                    </div>
                                    <div class="modal-footer">
                                        <button
                                            type="button"
                                            class="btn btn-secondary"
                                            @click="closeDeleteModal"
                                        >
                                            Cancel
                                        </button>
                                        <button
                                            type="button"
                                            class="btn btn-danger"
                                            @click="confirmDelete"
                                        >
                                            Delete
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <FooterComponent />
            </div>
        </div>
    </div>
</template>

<script>
import { ref, watch } from "vue";
import NavbarComponent from "@/components/Navbar.vue";
import TopNavComponent from "@/components/TopNav.vue";
import FooterComponent from "@/components/Footer.vue";
import LoadingComponent from "@/components/Loading.vue";
import InfoNotLoggedInComponent from "@/components/InfoNotLoggedIn.vue";
import {
    useStaffProfile,
    useFetchPUUKategoriMemos,
    useCreatePUUKategoriMemo,
    useUpdatePUUKategoriMemo,
    useDeletePUUKategoriMemo,
} from "@/hooks/useAPI";

export default {
    name: "ManageKategoriMemosView",
    components: {
        LoadingComponent,
        NavbarComponent,
        TopNavComponent,
        FooterComponent,
        InfoNotLoggedInComponent,
    },
    setup() {
        const publicPath = ref(process.env.VUE_APP_PUBLIC_PATH);

        const {
            data: dataStaffProfile,
            error: errorStaffProfile,
            loading: loadingStaffProfile,
        } = useStaffProfile();
        const {
            data: types = ref([]),
            loading: loadingCategories,
            refetch,
        } = useFetchPUUKategoriMemos();

        const filterText = ref("");
        const currentPage = ref(1);
        const itemsPerPage = ref(100);

        const isModalVisible = ref(false);
        const isDeleteModalVisible = ref(false);
        const isEdit = ref(false);
        const form = ref({ kod: "", butiran: "" });
        const IdToDelete = ref(null);

        const filteredList = ref([]);
        const paginatedList = ref([]);
        const totalPages = ref(0);

        watch(
            [types, filterText],
            ([newCategories, newFilterText]) => {
                const filtered =
                    newCategories?.filter((item) =>
                        item?.butiran
                            ?.toLowerCase()
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

        const delayRefetch = (ms = 300) => {
            setTimeout(() => refetch(), ms);
        };

        const createKategoriMemo = async () => {
            console.log(form.value);
            await useCreatePUUKategoriMemo(form.value);
            delayRefetch();
            closeModal();
        };

        const updateKategoriMemo = async () => {
            await useUpdatePUUKategoriMemo(form.value.kod, form.value);
            delayRefetch();
            closeModal();
        };

        const openCreateModal = () => {
            isEdit.value = false;
            form.value = { kod: "", butiran: "" };
            isModalVisible.value = true;
        };

        const openUpdateModal = (butiran) => {
            isEdit.value = true;
            form.value = { ...butiran };
            isModalVisible.value = true;
        };

        const openDeleteModal = (butiran) => {
            IdToDelete.value = butiran;
            isDeleteModalVisible.value = true;
        };

        const closeModal = () => {
            isModalVisible.value = false;
        };

        const closeDeleteModal = () => {
            isDeleteModalVisible.value = false;
        };

        const confirmDelete = async () => {
            if (IdToDelete.value) {
                await useDeletePUUKategoriMemo(IdToDelete.value.kod);
                delayRefetch();
                closeDeleteModal();
            }
        };

        const submitForm = () => {
            if (isEdit.value) updateKategoriMemo();
            else createKategoriMemo();
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
            dataStaffProfile,
            errorStaffProfile,
            loading: loadingStaffProfile || loadingCategories,
            filterText,
            types,
            filteredList,
            paginatedList,
            totalPages,
            currentPage,
            changePage,
            prevPage,
            nextPage,
            isModalVisible,
            isDeleteModalVisible,
            isEdit,
            form,
            IdToDelete,
            openCreateModal,
            openUpdateModal,
            openDeleteModal,
            closeModal,
            closeDeleteModal,
            confirmDelete,
            submitForm,
            sortList,
        };
    },
};
</script>

<style scoped>
.modal {
    background: rgba(0, 0, 0, 0.5);
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    display: flex;
    justify-content: center;
    align-items: center;
}
</style>
