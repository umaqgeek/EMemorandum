<template>
    <div>
        <button
            class="btn btn-outline-primary mb-3"
            type="button"
            @click="addKPI"
        >
            Add KPI
        </button>
        <div class="card">
            <table
                class="datatable-init1 table"
                data-nk-container="table-responsive"
            >
                <thead class="table-light">
                    <tr>
                        <th class="tb-col">No.</th>
                        <th class="tb-col">KPI & Description</th>
                        <!-- <th class="tb-col">Notes</th> -->
                        <th class="tb-col">Amount / Unit</th>
                        <th class="tb-col">From & To</th>
                    </tr>
                </thead>
                <tbody v-if="kpis?.length > 0">
                    <tr v-for="(kpi, kpiIndex) in kpis" v-bind:key="kpiIndex">
                        <td class="tb-col">{{ kpiIndex + 1 }}.</td>
                        <td class="tb-col">
                            <div class="form-control-wrap">
                                <select
                                    class="form-control"
                                    id="Kod"
                                    v-model="kpi.Kod"
                                >
                                    <option value="">- Select KPI -</option>
                                    <option
                                        v-for="listKPI in listKPIs"
                                        v-bind:key="listKPI.kod"
                                        :value="listKPI.kod"
                                    >
                                        {{ listKPI.kpi }}
                                    </option>
                                </select>
                            </div>
                            <div class="form-control-wrap mt-2">
                                <textarea
                                    placeholder="Eg.: This KPI need to be reviewed by NC."
                                    class="form-control"
                                    id="Penerangan"
                                    rows="3"
                                    v-model="kpi.Penerangan"
                                ></textarea>
                            </div>
                        </td>
                        <!-- <td class="tb-col">
                            <div class="form-control-wrap">
                                <textarea
                                    placeholder="Eg.: The amount shouldn't more than MYR 10,000."
                                    class="form-control"
                                    id="Komen"
                                    rows="3"
                                    v-model="kpi.Komen"
                                ></textarea>
                            </div>
                        </td> -->
                        <td class="tb-col">
                            <div class="form-control-wrap">
                                <input
                                    type="number"
                                    class="form-control table-kpi-amount"
                                    id="Amaun"
                                    placeholder="Eg.: 9943"
                                    v-model="kpi.Amaun"
                                />
                                <label>
                                    <input
                                        type="radio"
                                        v-model="kpi.isAmount"
                                        :value="false"
                                        :name="`isAmount_${kpiIndex}`"
                                    />
                                    Price (RM)
                                </label>
                                <label>
                                    <input
                                        type="radio"
                                        v-model="kpi.isAmount"
                                        :value="true"
                                        :name="`isAmount_${kpiIndex}`"
                                    />
                                    Unit
                                </label>
                            </div>
                        </td>
                        <td class="tb-col">
                            <div class="form-group">
                                <input
                                    placeholder="Start date"
                                    type="date"
                                    class="form-control"
                                    name="TarikhMula"
                                    v-model="kpi.TarikhMula"
                                />
                                <div class="table-kpi-to">To</div>
                                <input
                                    placeholder="dd/mm/yyyy"
                                    type="date"
                                    class="form-control"
                                    name="TarikhTamat"
                                    v-model="kpi.TarikhTamat"
                                />
                                <div class="mt-3">
                                    <button
                                        class="btn btn-outline-danger"
                                        type="button"
                                        @click="removeKPI(kpiIndex)"
                                    >
                                        <em class="icon ni ni-cross"></em>
                                    </button>
                                </div>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script>
export default {
    name: "TableKPIComponent",
    props: {
        kpis: {
            type: Array,
            required: true,
        },
        listKPIs: {
            type: Array,
            required: true,
        },
    },
    methods: {
        // saveKPIs() {
        //     this.$emit("saveKPIs", this.kpis);
        // },
        addKPI() {
            // eslint-disable-next-line
            this.kpis.push({
                Kod: "",
                Nama: "",
                Penerangan: "",
                Komen: "",
                Amaun: 0,
                isAmount: false,
                TarikhMula: "",
                TarikhTamat: "",
            });
            // this.saveKPIs();
        },
        // TODO: clear row throw mutable error for kpis
        clearKPI(kpiIndex) {
            // eslint-disable-next-line
            this.kpis = [...this.kpis, newKpi].map((k, kIndex) => {
                if (kpiIndex === kIndex) {
                    k.Kod = "";
                    k.Nama = "";
                    k.Penerangan = "";
                    k.Komen = "";
                    k.Amaun = 0;
                    k.isAmount = false;
                    k.TarikhMula = "";
                    k.TarikhTamat = "";
                }
                return k;
            });
            // this.saveKPIs();
        },
        removeKPI(kpiIndex) {
            // eslint-disable-next-line
            this.kpis.splice(kpiIndex, 1);
            // this.saveKPIs();
        },
    },
};
</script>

<style scoped>
.table-kpi-to {
    width: 100%;
    text-align: center;
    background-color: rgba(0, 0, 0, 0.1);
    padding: 4px 0px;
    margin-left: auto;
    margin-right: auto;
}
.table-kpi-amount {
    width: 40%;
}
</style>
