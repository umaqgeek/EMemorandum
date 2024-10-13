<template>
    <div class="search-container" @click="isSearching = true">
        <div v-if="!isSearching" class="search-icon">
            <em class="icon ni ni-search"></em>
        </div>
        <div v-else>
            <input
                type="text"
                v-model="searchQuery"
                @blur="onBlur"
                @keydown.enter="triggerSearch"
                class="search-input"
                placeholder="Search memorandum here ..."
                ref="searchInput"
            />
        </div>
    </div>
</template>

<script>
export default {
    name: "SearchInputComponent",
    data() {
        return {
            publicPath: process.env.VUE_APP_PUBLIC_PATH,
            isSearching: false,
            searchQuery: "",
        };
    },
    watch: {
        isSearching(newVal) {
            if (newVal) {
                this.$nextTick(() => {
                    this.$refs.searchInput.focus();
                });
            }
        },
    },
    methods: {
        onBlur() {
            this.isSearching = false;
            this.searchQuery = "";
        },
        triggerSearch() {
            location.href = `${this.publicPath}memo-list?q=${this.searchQuery}`;
        },
    },
};
</script>

<style scoped>
.search-container {
    position: relative;
    display: inline-block;
    cursor: pointer;
}

.search-icon {
    font-size: 20px;
    padding: 5px;
}

.search-input {
    width: 300px;
    padding: 4px 12px;
    font-size: 16px;
    border: 1px solid #ccc;
    border-radius: 4px;
    transition: all 0.3s ease;
}

.search-icon:hover {
    cursor: pointer;
}
</style>
