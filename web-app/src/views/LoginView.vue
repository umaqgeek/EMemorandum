<template>
    <!-- Root  -->
    <div class="nk-app-root">
        <!-- main  -->
        <div class="nk-main">
            <div class="nk-wrap align-items-center justify-content-center">
                <div class="container p-2 p-sm-4">
                    <div class="wide-xs mx-auto">
                        <div class="text-center mb-5">
                            <div class="brand-logo mb-1">
                                <router-link to="/dashboard" class="logo-link">
                                    <div class="logo-wrap">
                                        <img
                                            class="logo-img logo-light"
                                            src="../assets/images/LogoUTeM.webp"
                                            alt=""
                                        />
                                        <img
                                            class="logo-img logo-dark"
                                            src="../assets/images/LogoUTeM.webp"
                                            alt=""
                                        />
                                        <img
                                            class="logo-img logo-icon"
                                            src="../assets/images/LogoUTeM.webp"
                                            alt=""
                                        />
                                    </div>
                                </router-link>
                            </div>
                            <p>Sistem Pengurusan dan Pemantauan Memorandum.</p>
                        </div>
                        <div class="card card-gutter-lg rounded-4 card-auth">
                            <div class="card-body">
                                <div class="nk-block-head">
                                    <div class="nk-block-head-content">
                                        <h3 class="nk-block-title mb-1">
                                            Login to Account
                                        </h3>
                                        <p class="small">
                                            Please sign-in to your account and
                                            start the adventure.
                                        </p>
                                    </div>
                                </div>
                                <form action="#">
                                    <div class="row gy-3">
                                        <div class="col-12">
                                            <div class="form-group">
                                                <label
                                                    for="username"
                                                    class="form-label"
                                                    >Email</label
                                                >
                                                <div class="form-control-wrap">
                                                    <input
                                                        type="text"
                                                        class="form-control"
                                                        id="username"
                                                        placeholder="Enter username"
                                                        v-model="email"
                                                    />
                                                </div>
                                            </div>
                                            <!-- .form-group -->
                                        </div>
                                        <div class="col-12">
                                            <div class="form-group">
                                                <label
                                                    for="password"
                                                    class="form-label"
                                                    >Password</label
                                                >
                                                <div class="form-control-wrap">
                                                    <input
                                                        type="password"
                                                        class="form-control"
                                                        id="password"
                                                        placeholder="Enter password"
                                                        v-model="password"
                                                    />
                                                </div>
                                            </div>
                                            <!-- .form-group -->
                                        </div>
                                        <div class="col-12">
                                            <div
                                                class="d-flex flex-wrap justify-content-between"
                                            >
                                                <div
                                                    class="form-check form-check-sm"
                                                >
                                                    <input
                                                        class="form-check-input"
                                                        type="checkbox"
                                                        value=""
                                                        id="rememberMe"
                                                    />
                                                    <label
                                                        class="form-check-label"
                                                        for="rememberMe"
                                                    >
                                                        Remember Me
                                                    </label>
                                                </div>
                                                <a
                                                    href="./html/auths/auth-reset-classic.html"
                                                    class="small"
                                                    >Forgot Password?</a
                                                >
                                            </div>
                                        </div>
                                        <div class="col-12">
                                            <div class="d-grid">
                                                <div
                                                    v-on:click="login"
                                                    class="btn btn-primary"
                                                >
                                                    Login to account
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-12">
                                            <div
                                                v-if="errorMessage !== ''"
                                                class="alert alert-danger"
                                            >
                                                {{ errorMessage }}
                                            </div>
                                        </div>
                                    </div>
                                    <!-- .row -->
                                </form>
                            </div>
                            <!-- .card-body -->
                        </div>
                        <!-- .card -->
                        <div class="text-center mt-5">
                            <p class="small">
                                Don't have an account?
                                <a
                                    href="./html/auths/auth-register-classic.html"
                                    >Register</a
                                >
                            </p>
                        </div>
                    </div>
                    <!-- .col -->
                </div>
                <!-- .container -->
            </div>
        </div>
        <!-- .nk-main -->
    </div>
    <!-- .nk-app-root -->
</template>

<script>
export default {
    name: "LoginView",
    data() {
        return {
            email: "",
            password: "",
        };
    },
    computed: {
        loading() {
            return this.$store.getters.getLoading;
        },
        user() {
            return this.$store.getters.getUser;
        },
        errorMessage() {
            return this.$store.getters.getErrorMessage;
        },
    },
    methods: {
        login() {
            this.$store.dispatch("loginAction", {
                email: this.email,
                password: this.password,
            });
        },
    },
};
</script>
