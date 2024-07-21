module.exports = {
    root: true,
    env: {
        node: true,
    },
    extends: [
        "plugin:vue/vue3-essential",
        "eslint:recommended",
        "plugin:prettier/recommended",
    ],
    parserOptions: {
        parser: "@babel/eslint-parser",
    },
    ignorePatterns: [
        "dist/", // Ignore built files
        "build/", // Ignore built files
        "src/assets/js/**", // Ignore JS files
    ],
    rules: {
        "no-console": process.env.NODE_ENV === "production" ? "warn" : "off",
        "no-debugger": process.env.NODE_ENV === "production" ? "warn" : "off",
        "prettier/prettier": [
            "error",
            {
                // Your custom Prettier options
                bracketSpacing: true,
                printWidth: 80,
                tabWidth: 4,
            },
        ],
        indent: ["error", 4],
        // Add or modify other rules as needed
    },
};
