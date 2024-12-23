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
                                    Manage Fields
                                </li>
                            </ol>
                        </nav>

                        <h1 class="mb-3">Manage Fields</h1>

                        <!-- Filter Input -->
                        <div class="mb-3">
                            <input
                                v-model="filterText"
                                class="form-control"
                                placeholder="Filter by Field"
                            />
                        </div>

                        <!-- Add Button -->
                        <button
                            class="btn btn-primary mb-3"
                            @click="openCreateModal"
                        >
                            Add New Field
                        </button>

                        <!-- Table -->
                        <table class="table table-bordered">
                            <thead>
                                <tr>
                                    <th @click="sortList('kodField')">
                                        kodField
                                    </th>
                                    <th @click="sortList('field')">Field</th>
                                    <th>Actions</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr
                                    v-for="item in paginatedList"
                                    :key="item?.kodField"
                                >
                                    <td>{{ item?.kodField }}</td>
                                    <td>{{ item?.field }}</td>
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
                                                    ? "Update Field"
                                                    : "Create Field"
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
                                            <label
                                                for="kodField"
                                                class="form-label"
                                                >kodField</label
                                            >
                                            <input
                                                id="kodField"
                                                v-model="form.kodField"
                                                :disabled="isEdit"
                                                class="form-control"
                                                maxlength="2"
                                            />
                                        </div>
                                        <div class="mb-3">
                                            <label
                                                for="field"
                                                class="form-label"
                                                >Field</label
                                            >
                                            <input
                                                id="field"
                                                v-model="form.field"
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
                                            field with kodField:
                                            {{ fieldToDelete?.kodField }}?
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
    useFetchMOUFields,
    useCreateMOUField,
    useUpdateMOUField,
    useDeleteMOUField,
} from "@/hooks/useAPI";

export default {
    name: "ManageFieldsView",
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
            data: fields = ref([]),
            loading: loadingFields,
            refetch,
        } = useFetchMOUFields();

        const filterText = ref("");
        const currentPage = ref(1);
        const itemsPerPage = ref(5);

        const isModalVisible = ref(false);
        const isDeleteModalVisible = ref(false);
        const isEdit = ref(false);
        const form = ref({ kodField: "", field: "" });
        const fieldToDelete = ref(null);

        const filteredList = ref([]);
        const paginatedList = ref([]);
        const totalPages = ref(0);

        watch(
            [fields, filterText],
            ([newFields, newFilterText]) => {
                const filtered =
                    newFields?.filter((item) =>
                        item?.field
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

        const createField = async () => {
            await useCreateMOUField(form.value);
            delayRefetch();
            closeModal();
        };

        const updateField = async () => {
            await useUpdateMOUField(form.value.kodField, form.value);
            delayRefetch();
            closeModal();
        };

        const openCreateModal = () => {
            isEdit.value = false;
            form.value = { kodField: "", field: "" };
            isModalVisible.value = true;
        };

        const openUpdateModal = (field) => {
            isEdit.value = true;
            form.value = { ...field };
            isModalVisible.value = true;
        };

        const openDeleteModal = (field) => {
            fieldToDelete.value = field;
            isDeleteModalVisible.value = true;
        };

        const closeModal = () => {
            isModalVisible.value = false;
        };

        const closeDeleteModal = () => {
            isDeleteModalVisible.value = false;
        };

        const confirmDelete = async () => {
            if (fieldToDelete.value) {
                await useDeleteMOUField(fieldToDelete.value.kodField);
                delayRefetch();
                closeDeleteModal();
            }
        };

        const submitForm = () => {
            if (isEdit.value) updateField();
            else createField();
        };

        return {
            publicPath,
            dataStaffProfile,
            errorStaffProfile,
            loading: loadingStaffProfile || loadingFields,
            filterText,
            fields,
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
            fieldToDelete,
            openCreateModal,
            openUpdateModal,
            openDeleteModal,
            closeModal,
            closeDeleteModal,
            confirmDelete,
            submitForm,
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
