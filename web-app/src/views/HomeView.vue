<template>
    <NavbarComponent />
    <div v-on:click="fetchTodo">fetch todo</div>
    <div v-for="todo in todos" v-bind:key="todo.id">loop data</div>
</template>

<script>
// @ is an alias to /src
import NavbarComponent from "@/components/Navbar.vue";
import axios from "axios";

export default {
    name: "HomeView",
    components: {
        NavbarComponent,
    },
    data() {
        return {
            todos: [],
        };
    },
    methods: {
        goHaha: () => {
            alert("haha");
        },
        fetchTodo: () => {
            var self = this;
            axios
                .get("https://jsonplaceholder.typicode.com/todos")
                .then((response) => {
                    self.todos = response.data;
                    console.log(self.todos);
                })
                .catch((error) => {
                    console.error(error);
                })
                .finally(() => {});
        },
    },
};
</script>
