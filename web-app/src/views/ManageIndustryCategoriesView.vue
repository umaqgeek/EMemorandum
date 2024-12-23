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
                                    Manage Industry Categories
                                </li>
                            </ol>
                        </nav>

                        <h1 class="mb-3">Manage Industry Categories</h1>

                        <!-- Filter Input -->
                        <div class="mb-3">
                            <input
                                v-model="filterText"
                                class="form-control"
                                placeholder="Filter by Industry Category"
                            />
                        </div>

                        <!-- Add Button -->
                        <button
                            class="btn btn-primary mb-3"
                            @click="openCreateModal"
                        >
                            Add New Industry Category
                        </button>

                        <!-- Table -->
                        <table class="table table-bordered">
                            <thead>
                                <tr class="alert alert-secondary">
                                    <th @click="sortList('kodInd')">Kod</th>
                                    <th @click="sortList('industryCategory')">
                                        Industry Category
                                    </th>
                                    <th>Actions</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr
                                    v-for="item in paginatedList"
                                    :key="item?.kodInd"
                                >
                                    <td>{{ item?.kodInd }}</td>
                                    <td>{{ item?.industryCategory }}</td>
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
                                                    ? "Update Industry Category"
                                                    : "Create Industry Category"
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
                                                for="kodInd"
                                                class="form-label"
                                                >Kod</label
                                            >
                                            <input
                                                id="kodInd"
                                                v-model="form.kodInd"
                                                :disabled="isEdit"
                                                class="form-control"
                                                maxlength="2"
                                            />
                                        </div>
                                        <div class="mb-3">
                                            <label
                                                for="industryCategory"
                                                class="form-label"
                                                >Industry Category</label
                                            >
                                            <input
                                                id="industryCategory"
                                                v-model="form.industryCategory"
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
                                            industry category with Kod:
                                            {{ indCatToDelete?.kodInd }}?
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
    useFetchMOUIndustryCats,
    useCreateMOUIndustryCat,
    useUpdateMOUIndustryCat,
    useDeleteMOUIndustryCat,
} from "@/hooks/useAPI";

export default {
    name: "ManageIndustryCategoriesView",
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
            data: industryCategories = ref([]),
            loading: loadingIndustryCategories,
            refetch,
        } = useFetchMOUIndustryCats();

        const filterText = ref("");
        const currentPage = ref(1);
        const itemsPerPage = ref(100);

        const isModalVisible = ref(false);
        const isDeleteModalVisible = ref(false);
        const isEdit = ref(false);
        const form = ref({ kodInd: "", industryCategory: "" });
        const indCatToDelete = ref(null);

        const filteredList = ref([]);
        const paginatedList = ref([]);
        const totalPages = ref(0);

        watch(
            [industryCategories, filterText],
            ([newIndustryCategories, newFilterText]) => {
                const filtered =
                    newIndustryCategories?.filter((item) =>
                        item?.industryCategory
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

        const createIndustryCategory = async () => {
            await useCreateMOUIndustryCat(form.value);
            delayRefetch();
            closeModal();
        };

        const updateIndustryCategory = async () => {
            await useUpdateMOUIndustryCat(form.value.kodInd, form.value);
            delayRefetch();
            closeModal();
        };

        const openCreateModal = () => {
            isEdit.value = false;
            form.value = { kodInd: "", industryCategory: "" };
            isModalVisible.value = true;
        };

        const openUpdateModal = (industryCategory) => {
            isEdit.value = true;
            form.value = { ...industryCategory };
            isModalVisible.value = true;
        };

        const openDeleteModal = (industryCategory) => {
            indCatToDelete.value = industryCategory;
            isDeleteModalVisible.value = true;
        };

        const closeModal = () => {
            isModalVisible.value = false;
        };

        const closeDeleteModal = () => {
            isDeleteModalVisible.value = false;
        };

        const confirmDelete = async () => {
            if (indCatToDelete.value) {
                await useDeleteMOUIndustryCat(indCatToDelete.value.kodInd);
                delayRefetch();
                closeDeleteModal();
            }
        };

        const submitForm = () => {
            if (isEdit.value) updateIndustryCategory();
            else createIndustryCategory();
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
            loading: loadingStaffProfile || loadingIndustryCategories,
            filterText,
            industryCategories,
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
            indCatToDelete,
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
