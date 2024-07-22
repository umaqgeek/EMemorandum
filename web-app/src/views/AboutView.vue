<template>
    <NavbarComponent />
    <div class="about">
        <h1>This is an about page</h1>
    </div>
</template>

<script>
// @ is an alias to /src
import NavbarComponent from "@/components/Navbar.vue";

export default {
    name: "AboutView",
    components: {
        NavbarComponent,
    },
};
</script>
