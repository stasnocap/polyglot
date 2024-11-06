import {nextui} from "@nextui-org/react";

/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./index.html",
    "./src/**/*.{js,ts,jsx,tsx}",
    "./node_modules/@nextui-org/theme/dist/**/*.{js,ts,jsx,tsx}"
  ],
  theme: {
    extend: {},
  },
  darkMode: "class",
  plugins: [nextui({
    themes: {
      purple: {
        extend: "light",
        colors: {
          background: "#F4EEFF",
          primary: {
            50: "#DCD6F7",
            100: "#A6B1E1",
            DEFAULT: "#424874"
          },
        }
      },
      cream: {
        extend: "light",
        colors: {
          background: "#FFF5E4",
          primary: {
            50: "#FFE3E1",
            100: "#FFD1D1",
            DEFAULT: "#FF9494"
          },
        }
      },
      skin: {
        extend: "light",
        colors: {
          background: "#FFC7C7",
          primary: {
            50: "#FFE2E2",
            100: "#F6F6F6",
            DEFAULT: "#8785A2"
          },
        }
      },
      teal: {
        extend: "dark",
        colors: {
          background: "#222831",
          primary: {
            50: "#393E46",
            100: "#00ADB5",
            DEFAULT: "#EEEEEE"
          },
        }
      },
      navy: {
        extend: "dark",
        colors: {
          background: "#1B262C",
          primary: {
            50: "#0F4C75",
            100: "#3282B8",
            DEFAULT: "#BBE1FA"
          },
        }
      },
      night: {
        extend: "dark",
        colors: {
          background: "#27374D",
          primary: {
            50: "#526D82",
            100: "#9DB2BF",
            DEFAULT: "#DDE6ED"
          },
        }
      },
    }
  })]
}

