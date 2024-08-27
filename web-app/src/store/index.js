import { createStore } from "vuex";
import axios from "axios";

import router from "../router";
import { API_URL } from "../utils/constants";

export default createStore({
    state: {
        loading: false,
        errorMessage: "",
        user: {},
    },
    getters: {
        getLoading: (state) => state.loading,
        getUser: (state) => state.user,
        getErrorMessage: (state) => state.errorMessage,
    },
    mutations: {
        loginHandler: (state, payload) => {
            state.loading = true;
            axios
                .post(`${API_URL}/auth/login`, payload, {
                    headers: {
                        "Content-Type": "application/json",
                    },
                })
                .then((response) => {
                    state.user = response.data;
                    state.errorMessage = "";
                    sessionStorage.setItem("token", response.data.Token); // Save the token for subsequent requests
                    router.push("/dashboard"); // Redirect to the dashboard page
                })
                .catch((error) => {
                    state.errorMessage = error.response?.data?.message || error;
                })
                .finally(() => {
                    state.loading = false;
                });
        },
    },
    actions: {
        loginAction: ({ commit }, payload) => {
            commit("loginHandler", payload);
        },
    },
    modules: {},
});
