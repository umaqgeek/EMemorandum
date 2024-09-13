<template>
    <div class="card">
        <table
            class="datatable-init table"
            data-nk-container="table-responsive"
        >
            <thead class="table-light">
                <tr>
                    <th class="tb-col">No.</th>
                    <th class="tb-col">KPI</th>
                    <th class="tb-col">Description</th>
                    <th class="tb-col">Notes</th>
                    <th class="tb-col">Amount</th>
                    <th class="tb-col">Start Date</th>
                    <th class="tb-col">End Date</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td class="tb-col">1</td>
                    <td class="tb-col">
                        <div class="form-control-wrap">
                            <input
                                type="text"
                                class="form-control"
                                id="exampleFormControlInputText1"
                                placeholder="Input text placeholder"
                            />
                        </div>
                    </td>
                    <td class="tb-col">
                        <div class="form-control-wrap">
                            <textarea
                                placeholder="Textarea Placeholder"
                                class="form-control"
                                id="exampleFormControlTextarea8"
                                rows="3"
                            ></textarea>
                        </div>
                    </td>
                    <td class="tb-col">
                        <div class="form-control-wrap">
                            <textarea
                                placeholder="Textarea Placeholder"
                                class="form-control"
                                id="exampleFormControlTextarea8"
                                rows="3"
                            ></textarea>
                        </div>
                    </td>
                    <td class="tb-col">
                        <div class="form-control-wrap">
                            <input
                                type="text"
                                class="form-control"
                                id="exampleFormControlInputText1"
                                placeholder="Input text placeholder"
                            />
                        </div>
                    </td>
                    <td class="tb-col">
                        <div class="form-control-wrap">
                            <div class="form-control-icon end">
                                <em class="icon ni ni-eye"></em>
                            </div>
                            <input
                                type="text"
                                class="form-control"
                                id="exampleFormControlInputText4"
                                placeholder="Input text placeholder"
                            />
                        </div>
                    </td>
                    <td class="tb-col">
                        <div class="form-control-wrap">
                            <div class="form-control-icon end">
                                <em class="icon ni ni-eye"></em>
                            </div>
                            <input
                                type="text"
                                class="form-control"
                                id="exampleFormControlInputText4"
                                placeholder="Input text placeholder"
                            />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="tb-col">2</td>
                    <td class="tb-col">
                        <div class="form-control-wrap">
                            <input
                                type="text"
                                class="form-control"
                                id="exampleFormControlInputText1"
                                placeholder="Input text placeholder"
                            />
                        </div>
                    </td>
                    <td class="tb-col">
                        <div class="form-control-wrap">
                            <textarea
                                placeholder="Textarea Placeholder"
                                class="form-control"
                                id="exampleFormControlTextarea8"
                                rows="3"
                            ></textarea>
                        </div>
                    </td>
                    <td class="tb-col">
                        <div class="form-control-wrap">
                            <textarea
                                placeholder="Textarea Placeholder"
                                class="form-control"
                                id="exampleFormControlTextarea8"
                                rows="3"
                            ></textarea>
                        </div>
                    </td>
                    <td class="tb-col">
                        <div class="form-control-wrap">
                            <input
                                type="text"
                                class="form-control"
                                id="exampleFormControlInputText1"
                                placeholder="Input text placeholder"
                            />
                        </div>
                    </td>
                    <td class="tb-col">
                        <div class="form-control-wrap">
                            <div class="form-control-icon end">
                                <em class="icon ni ni-eye"></em>
                            </div>
                            <input
                                type="text"
                                class="form-control"
                                id="exampleFormControlInputText4"
                                placeholder="Input text placeholder"
                            />
                        </div>
                    </td>
                    <td class="tb-col">
                        <div class="form-control-wrap">
                            <div class="form-control-icon end">
                                <em class="icon ni ni-eye"></em>
                            </div>
                            <input
                                type="text"
                                class="form-control"
                                id="exampleFormControlInputText4"
                                placeholder="Input text placeholder"
                            />
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
export default {
    name: "TableKPIComponent",
    props: {
        label: String,
    },
};
</script>
