/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./index.html",
    "./src/**/*.{js,ts,jsx,tsx}",
  ],
  theme: {
    colors:{
      'prim' : '#89CFF0',
      'sec' : '#FDF0D5',
      'third' : '#D3D3D3',
    },
    extend: {},
  },
  plugins: [],
};