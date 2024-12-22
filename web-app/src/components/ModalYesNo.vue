<template>
    <div v-if="visible" class="modal1-overlay" @click="onNo">
        <div class="modal1">
            <div class="modal1-header">
                <h3>{{ title }}</h3>
                <button class="close-button" @click="onNo">&times;</button>
            </div>
            <div class="modal1-body">
                <p>{{ message }}</p>
            </div>
            <div class="modal1-footer">
                <button class="btn btn-danger" @click="onYes">Yes</button>
                <button class="btn btn-secondary" @click="onNo">No</button>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: "ModalYesNoComponent",
    props: {
        visible: {
            type: Boolean,
            required: true,
        },
        title: {
            type: String,
            default: "Confirmation",
        },
        message: {
            type: String,
            default: "Are you sure?",
        },
    },
    methods: {
        onYes() {
            this.$emit("confirm");
            this.closeModal();
        },
        onNo() {
            this.$emit("cancel");
            this.closeModal();
        },
        closeModal() {
            this.$emit("update:visible", false);
        },
    },
};
</script>

<style scoped>
.modal1-overlay {
    position: absolute;
    z-index: 1000;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background-color: rgba(0, 0, 0, 0.5);
    display: flex;
    justify-content: center;
    align-items: center;
}

.modal1 {
    background: white;
    border-radius: 8px;
    padding: 20px;
    width: 300px;
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
}

.modal1-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
}

.modal1-header h3 {
    margin: 0;
}

.close-button {
    background: none;
    border: none;
    font-size: 1.5rem;
    cursor: pointer;
}

.modal1-body {
    margin: 20px 0;
}

.modal1-footer {
    display: flex;
    justify-content: flex-end;
    gap: 10px;
}
</style>
