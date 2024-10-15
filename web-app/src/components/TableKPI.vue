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
                        <th class="tb-col">KPI</th>
                        <th class="tb-col">Description</th>
                        <th class="tb-col">Notes</th>
                        <th class="tb-col">Amount</th>
                        <th class="tb-col">Date</th>
                    </tr>
                </thead>
                <tbody v-if="kpis?.length > 0">
                    <tr v-for="(kpi, kpiIndex) in kpis" v-bind:key="kpiIndex">
                        <td class="tb-col">{{ kpiIndex + 1 }}.</td>
                        <td class="tb-col">
                            <div class="form-control-wrap">
                                <input
                                    type="int"
                                    class="form-control"
                                    id="Nama"
                                    placeholder="Eg.: Reviewed by NC"
                                    v-model="kpi.Nama"
                                />
                            </div>
                        </td>
                        <td class="tb-col">
                            <div class="form-control-wrap">
                                <textarea
                                    placeholder="Eg.: This KPI need to be reviewed by NC."
                                    class="form-control"
                                    id="Penerangan"
                                    rows="3"
                                    v-model="kpi.Penerangan"
                                ></textarea>
                            </div>
                        </td>
                        <td class="tb-col">
                            <div class="form-control-wrap">
                                <textarea
                                    placeholder="Eg.: The amount shouldn't more than MYR 10,000."
                                    class="form-control"
                                    id="Komen"
                                    rows="3"
                                    v-model="kpi.Komen"
                                ></textarea>
                            </div>
                        </td>
                        <td class="tb-col">
                            <div class="form-control-wrap">
                                <input
                                    type="number"
                                    class="form-control"
                                    id="Amaun"
                                    placeholder="Eg.: 9943"
                                    v-model="kpi.Amaun"
                                />
                            </div>
                        </td>
                        <td class="tb-col">
                            <div class="form-group">
                                <div class="input-group">
                                    <input
                                        placeholder="dd/mm/yyyy"
                                        type="date"
                                        class="form-control"
                                        name="TarikhMula"
                                        v-model="kpi.TarikhMula"
                                    />
                                    <span class="input-group-text">to</span>
                                    <input
                                        placeholder="dd/mm/yyyy"
                                        type="date"
                                        class="form-control"
                                        name="TarikhTamat"
                                        v-model="kpi.TarikhTamat"
                                    />
                                </div>
                                <div class="mt-3">
                                    <button
                                        class="btn btn-outline-secondary"
                                        type="button"
                                        @click="clearKPI(kpiIndex)"
                                    >
                                        Clear
                                    </button>
                                    &nbsp;
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
    },
    methods: {
        // saveKPIs() {
        //     this.$emit("saveKPIs", this.kpis);
        // },
        addKPI() {
            // eslint-disable-next-line
            this.kpis.push({
                Nama: "",
                Penerangan: "",
                Komen: "",
                Amaun: 0,
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
                    k.Nama = "";
                    k.Penerangan = "";
                    k.Komen = "";
                    k.Amoun = 0;
                    k.TarikhMula = "";
                    k.TarikhTamat = "";
                }
                return k;
            });
            // this.saveKPIs();
        },
        // TODO: clear row throw mutable error for kpis
        removeKPI(kpiIndex) {
            // eslint-disable-next-line
            this.kpis = [...this.kpis, newKpi].filter(
                (_, kIndex) => kIndex !== kpiIndex
            );
            // this.saveKPIs();
        },
    },
};
</script>
