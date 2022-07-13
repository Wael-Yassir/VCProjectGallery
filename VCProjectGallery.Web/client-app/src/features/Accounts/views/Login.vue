<template>
  <div class="content">
    <v-card
      class="mx-auto pb-5 pt-4 rounded-xl"
      max-width="500"
      height="450"
      style="z-index: 1000"
    >
      <v-card-title class="mx-auto justify-center flex-column">
        <br />
        <strong class="text--secondary">Log in to Your Account</strong>
        <!-- <i class="fal fa-sign-in mr-2" style="line-height: 0"></i>Log in to your account -->
      </v-card-title>
      <v-form v-model="valid" @submit.prevent="submit" class="pa-3 mt-0 pt-0">
        <v-divider></v-divider>
        <v-container>
          <v-row align="center" justify="center" style="height: 200px">
            <v-col cols="12" md="10">
              <v-text-field
                v-model="userName"
                :rules="rules"
                label="User Name"
                placeholder="user"
              >
              </v-text-field>
              <v-text-field
                v-model="password"
                :append-icon="
                  passwordIsVisible ? 'fal fa-eye' : 'fal fa-eye-slash'
                "
                :rules="rules"
                :type="passwordIsVisible ? 'text' : 'password'"
                label="Password"
                placeholder="Password"
                @click:append="passwordIsVisible = !passwordIsVisible"
              >
              </v-text-field>
              <v-subheader
                class="red--text font-weight-black"
                style="display: block; text-align: center; margin-top: 15px"
              >
                {{ errorMsg }}
              </v-subheader>
            </v-col>
          </v-row>
          <v-row justify="center" aling="center">
            <v-col cols="12" md="8" class="d-flex justify-center">
              <v-btn
                type="submit"
                color="info"
                :disabled="!valid"
                :loading="loading"
              >
                <i class="fal fa-sign-in mr-2" style="line-height: 0"></i>
                Login
              </v-btn>
            </v-col>
          </v-row>
          <router-link
            to="/register"
            class="
              light-blue--text
              text--darken-3
              font-weight-black
              text-decoration-underline
            "
            style="
              display: block;
              text-align: center;
              margin-top: 15px;
              cursor: pointer;
            "
          >
            Register
          </router-link>
        </v-container>
      </v-form>
    </v-card>
  </div>
</template>

<script>
import { mapActions } from "vuex";

export default {
  data() {
    return {
      valid: false,
      loading: false,
      passwordIsVisible: false,
      password: "",
      userName: "",
      rules: [(val) => !!val || "This field is required!"],
      errorMsg: "",
    };
  },
  methods: {
    ...mapActions(["setToken", "setUser"]),
    clear() {
      this.userName = "";
      this.password = "";
    },
    submit() {
      this.loading = true;

      const credential = {
        username: this.userName,
        password: this.password,
      };

      this.$store
        .dispatch("login", credential)
        .then(() => {
          this.loading = false;
          this.$store.commit("setUser", { Username: credential.username });
          this.$router.push("/projects");
        })
        .catch(() => {
          this.loading = false;
          this.errorMsg = "Login Error!";
        });
    },
  },
};
</script>

<style scoped>
.content {
  margin-top: 8%;
}
</style>