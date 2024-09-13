<template>
    <div
        class="modal fade"
        id="editCode"
        tabindex="-1"
        aria-labelledby="exampleModalLabel"
        aria-hidden="true"
    >
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">
                        Edit Code
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
                                        value="Type Of Memorandum"
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
                                        class="form-control"
                                        id=""
                                        rows="3"
                                        value="Type 1&#10;Type 2&#10;Type 3"
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
    name: "EditCodeComponent",
    props: {
        label: String,
    },
};
</script>
