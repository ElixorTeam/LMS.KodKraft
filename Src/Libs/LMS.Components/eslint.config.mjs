// @ts-check

import globals from "globals"
import eslint from "@eslint/js"
import tseslint from "typescript-eslint"
import pluginPromise from "eslint-plugin-promise"
import pluginSimpleImportSort from "eslint-plugin-simple-import-sort"
import pluginUnicorn from "eslint-plugin-unicorn"
import pluginSonarjs from 'eslint-plugin-sonarjs'

const config = tseslint.config(
    eslint.configs.recommended,
    tseslint.configs.strictTypeChecked,
    pluginUnicorn.configs.recommended,
    pluginSonarjs.configs.recommended,
    pluginPromise.configs['flat/recommended'],
    {
        languageOptions: {
            parserOptions: {
                project: true,
                tsconfigRootDir: import.meta.dirname,
            },
            globals: globals.builtin,
        },
        plugins: {
            "simple-import-sort": pluginSimpleImportSort
        },
        rules: {
            "simple-import-sort/imports": "error",
            "simple-import-sort/exports": "error"
        }
    },
);

export default config;