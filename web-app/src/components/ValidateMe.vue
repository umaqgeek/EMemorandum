<template>
    <LoadingComponent :loading="loading" />
</template>

<script>
import LoadingComponent from "@/components/Loading.vue";
import axios from "axios";
import { API_URL } from "@/utils/constants";
import { getBearerToken, resetBearerToken } from "@/utils/mocks";

export default {
    name: "ValidateMeComponent",
    components: {
        LoadingComponent,
    },
    data() {
        return {
            loading: false,
        };
    },
    mounted() {
        this.validateMe();
    },
    methods: {
        validateMe() {
            this.loading = true;
            axios
                .post(
                    `${API_URL}/auth/validate-me`,
                    {},
                    {
                        headers: {
                            "Content-Type": "application/json",
                            Authorization: `Bearer ${getBearerToken()}`,
                        },
                    }
                )
                .then((response) => {
                    console.log(response.data);
                })
                .catch((error) => {
                    console.log(error);
                    resetBearerToken();
                })
                .finally(() => {
                    this.loading = false;
                });
        },
    },
};
</script>
