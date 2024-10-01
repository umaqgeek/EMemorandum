<template>
    <span :class="`badge text-bg-${color}`">{{ label }}</span>
</template>

<script>
export default {
    name: "ChipStatusComponent",
    props: {
        status: Object,
    },
    computed: {
        label() {
            return this.status?.status;
        },
        color() {
            if (this.status?.kod == "01") return "dark";
            if (this.status?.kod == "02") return "info";
            if (this.status?.kod == "03") return "success";
            if (this.status?.kod == "04") return "warning";
            if (this.status?.kod == "05") return "danger";
            return "dark";
        },
    },
};
</script>
