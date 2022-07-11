import Vue from 'vue'
import Vuetify from 'vuetify/lib/framework'

Vue.use(Vuetify)

export default new Vuetify({
  theme: {
    options: {
      customProperties: true,
    },
    themes: {
      light: {
        primary: "#3B96D2",
        secondary: "#2a363b",
        accent: "#8c9eff",
        success: "#4EB96F",
        error: "#E54C3C",
      },
    },
  },
});