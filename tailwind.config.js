/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./Pages/**/*.cshtml",
        "./Views/**/*.cshtml"
    ],
    theme: {
        extend: {
            colors: {
                'darkBg': '#262626',
            },
        },
    },
    plugins: [],
}

