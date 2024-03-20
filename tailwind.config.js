/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./Pages/**/*.cshtml",
        "./Views/**/*.cshtml"
    ],
    theme: {
        extend: {
            colors: {
                'custom-blue': '#1DA1F2',
            },
        },
    },
    plugins: [],
}

