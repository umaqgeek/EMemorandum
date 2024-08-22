<template>
    <div v-if="loading" class="loading">Loading ...</div>
</template>

<script>
export default {
    name: "LoadingComponent",
    props: {
        loading: Boolean,
    },
};
</script>
