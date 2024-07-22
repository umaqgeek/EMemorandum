<template>
    <button type="button">{{ label }}</button>
</template>

<script>
export default {
    name: "ButtonComponent",
    props: {
        label: String,
    },
};
</script>
