<template>
    <span>
        <table class="table" data-nk-container="table-responsive">
            <thead class="table-light">
                <tr>
                    <th class="tb-col">
                        <span class="overline-title">No.</span>
                    </th>
                    <th
                        class="tb-col"
                        v-for="(c, cIndex) in columns"
                        v-bind:key="cIndex"
                    >
                        <span class="overline-title">{{ c }}</span>
                    </th>
                    <th class="tb-col">
                        <span class="overline-title">Action</span>
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(d1, d1Index) in localData" v-bind:key="d1Index">
                    <td class="tb-col">{{ d1["no"] + 1 }}.</td>
                    <td
                        class="tb-col"
                        v-for="([d2key, d2], d2Index) in filteredD1(d1)"
                        v-bind:key="d1Index + d2Index + d2key"
                    >
                        <span v-html="d2"></span>
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
                                            <router-link to="/memo-edit">
                                                <em class="icon ni ni-edit"></em
                                                ><span>Edit</span>
                                            </router-link>
                                        </li>
                                        <li>
                                            <router-link to="/memo-detail"
                                                ><em class="icon ni ni-eye"></em
                                                ><span
                                                    >View Details</span
                                                ></router-link
                                            >
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <!-- dropdown -->
                    </td>
                </tr>
                <tr v-if="localData?.length <= 0">
                    <td :colspan="columns?.length + 2" align="center">
                        ... No Data ...
                    </td>
                </tr>
            </tbody>
        </table>
        <div class="table-lite-footer">
            <div class="table-lite-size">Per page</div>
            <div>
                <select
                    class="form-control"
                    v-model="limitData"
                    @change="updateSize"
                >
                    <option value="5">5</option>
                    <option value="10">10</option>
                    <option value="20">20</option>
                    <option value="50">50</option>
                    <option value="100">100</option>
                </select>
            </div>
            <div class="table-lite-pagination">
                <em class="icon ni ni-chevrons-left" @click="firstPage"></em>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <em class="icon ni ni-chevron-left" @click="prevPage"></em>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <div>{{ startNo + 1 }} - {{ endNo }} of {{ totalData }}</div>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <em class="icon ni ni-chevron-right" @click="nextPage"></em>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <em class="icon ni ni-chevrons-right" @click="lastPage"></em>
            </div>
            <div class="table-lite-size">&nbsp;</div>
        </div>
    </span>
</template>

<script>
/* eslint-disable */
import { ref, watch } from "vue";

export default {
    name: "TableLiteComponent",
    props: {
        columns: {
            type: Array,
            required: true,
        },
        data: {
            type: Array,
            required: false,
        },
    },
    setup(props) {
        const localData = ref([]);
        const oriData = ref([]);
        const startNo = ref(-1);
        const limitData = ref(5);
        const endNo = ref(startNo.value + limitData.value);
        const totalData = ref(0);

        watch(
            () => props.data,
            (newData) => {
                oriData.value = Array.isArray(newData)
                    ? [...newData].map((d, di) => {
                        return {
                            ...d,
                            no: di,
                        };
                    })
                    : [];
                totalData.value = [...oriData.value].length;
                startNo.value = totalData.value > 0 ? 0 : -1;
                endNo.value = parseInt(startNo.value) + parseInt(limitData.value) >= totalData.value ? totalData.value : parseInt(startNo.value) + parseInt(limitData.value);
                localData.value = [...oriData.value].slice(startNo.value, endNo.value);
            }
        );

        const firstPage = () => {
            startNo.value = totalData.value > 0 ? 0 : -1;
            endNo.value = parseInt(startNo.value) + parseInt(limitData.value) >= totalData.value ? totalData.value : parseInt(startNo.value) + parseInt(limitData.value);
            localData.value = [...oriData.value].slice(
                startNo.value,
                endNo.value
            );
        };

        const prevPage = () => {
            startNo.value = totalData.value > 0 ?
                (parseInt(startNo.value) - parseInt(limitData.value) <= 0
                    ? 0
                    : parseInt(startNo.value) - parseInt(limitData.value)) : -1;
            endNo.value =
                parseInt(startNo.value) + parseInt(limitData.value) >=
                totalData.value
                    ? totalData.value
                    : parseInt(startNo.value) + parseInt(limitData.value);
            localData.value = [...oriData.value].slice(
                startNo.value,
                endNo.value
            );
        };

        const nextPage = () => {
            startNo.value =
                parseInt(startNo.value) + parseInt(limitData.value) >=
                totalData.value
                    ? parseInt(startNo.value)
                    : parseInt(startNo.value) + parseInt(limitData.value);
            endNo.value =
                parseInt(startNo.value) + parseInt(limitData.value) >=
                totalData.value
                    ? totalData.value
                    : parseInt(startNo.value) + parseInt(limitData.value);
            localData.value = [...oriData.value].slice(
                startNo.value,
                endNo.value
            );
        };

        const lastPage = () => {
            const modulo = parseInt(oriData.value.length) % parseInt(limitData.value);
            var pagesLength =
                parseInt(oriData.value.length) / parseInt(limitData.value);
            pagesLength = modulo > 0 ? pagesLength : (pagesLength - 1);
            startNo.value = totalData.value > 0 ? (parseInt(pagesLength) * parseInt(limitData.value)) : -1;
            endNo.value =
                parseInt(startNo.value) + parseInt(limitData.value) >=
                totalData.value
                    ? totalData.value
                    : parseInt(startNo.value) + parseInt(limitData.value);
            localData.value = [...oriData.value].slice(
                startNo.value,
                endNo.value
            );
        };

        const updateSize = (evt) => {
            const newSize = evt.target.value;
            limitData.value = newSize;
            endNo.value =
                startNo.value + limitData.value >= totalData.value
                    ? totalData.value
                    : parseInt(startNo.value) + parseInt(limitData.value);
            localData.value = [...oriData.value].slice(
                startNo.value,
                endNo.value
            );
        };

        return {
            localData,
            oriData,
            startNo,
            limitData,
            endNo,
            totalData,
            firstPage,
            prevPage,
            nextPage,
            lastPage,
            updateSize,
        };
    },
    methods: {
        filteredD1(d1) {
            return Object.entries(d1).filter(([key, value]) => key !== 'no');
        }
    }
};
</script>

<style scoped>
.table-lite-footer {
    width: 100%;
    text-align: center;
    padding: 16px;
    border-top-style: solid;
    border-top-width: 1px;
    border-top-color: rgba(0, 0, 0, 0.2);
    cursor: pointer;
    display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: center;
}

.table-lite-footer div {
    display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: center;
}

.table-lite-footer > .table-lite-size {
    width: 10%;
}

.table-lite-footer > .table-lite-pagination {
    width: 80%;
}
</style>
