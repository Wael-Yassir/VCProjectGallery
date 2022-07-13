import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

import axios from '../plugins/axios';

export default new Vuex.Store({
  state: {
    user: {},
    token: null
  },
  getters: {
    isAuth: state => !!state.token
  },
  mutations: {
    setToken: (state, res) => {
      state.token = res.data.token;
    },
    setUser: (state, user) => {
      state.user = user;
    }
  },
  actions: {
    async login ({ commit }, user) {
      await axios.post("api/Authenticate/login", user)
        .then(res => commit('setToken', res))
    },
    setUser({ commit }, user) {
      commit('setUser', user);
    }
  },
  modules: {
  }
})
