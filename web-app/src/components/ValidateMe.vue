<template>
    <LoadingComponent :loading="loading" />
</template>

<script>
import LoadingComponent from "@/components/Loading.vue";
import { useValidateMe } from "@/hooks/useAPI";

export default {
    name: "ValidateMeComponent",
    components: {
        LoadingComponent,
    },
    setup() {
        const { data, error, loading, refetch } = useValidateMe();
        return {
            data,
            error,
            loading,
            refetch,
        };
    },
};
</script>
