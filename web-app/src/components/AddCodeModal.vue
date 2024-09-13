<template>
    <div
        class="modal fade"
        id="addCode"
        tabindex="-1"
        aria-labelledby="exampleModalLabel"
        aria-hidden="true"
    >
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">
                        Add New Code
                    </h5>
                    <button
                        type="button"
                        class="btn-close"
                        data-bs-dismiss="modal"
                        aria-label="Close"
                    ></button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label
                                    for="exampleFormControlInputText1"
                                    class="form-label"
                                    >Name</label
                                >
                                <div class="form-control-wrap">
                                    <input
                                        type="text"
                                        class="form-control"
                                        id=""
                                        placeholder=""
                                    />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label
                                    for="exampleFormControlTextarea8"
                                    class="form-label"
                                    >Options (one per line)</label
                                >
                                <div class="form-control-wrap">
                                    <textarea
                                        placeholder="Textarea Placeholder"
                                        class="form-control"
                                        id=""
                                        rows="3"
                                        value="Kuala Lumpur &#10; Melaka &#10; Selangor"
                                    ></textarea>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button
                        type="button"
                        class="btn btn-sm btn-secondary"
                        data-bs-dismiss="modal"
                    >
                        Close
                    </button>
                    <button type="button" class="btn btn-sm btn-primary">
                        Save changes
                    </button>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
export default {
    name: "AddCodeComponent",
    props: {
        label: String,
    },
};
</script>
