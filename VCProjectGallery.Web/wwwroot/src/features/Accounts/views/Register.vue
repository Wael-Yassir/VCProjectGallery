<template>
  <div class="content">
    <v-card
      class="mx-auto pb-5 pt-4 rounded-xl"
      max-width="500"
      height="495"
      style="z-index: 1000"
    >
      <v-card-title class="mx-auto justify-center flex-column">
        <br />
        <strong class="text--secondary">Register a New Account</strong>
        <!-- <i class="fal fa-sign-in mr-2" style="line-height: 0"></i>Log in to your account -->
      </v-card-title>
      <v-form v-model="valid" @submit.prevent="submit" class="pa-3 mt-0 pt-0">
        <v-divider></v-divider>
        <v-container>
          <v-row align="center" justify="center" style="height: 300px">
            <v-col cols="12" md="10">
              <v-text-field
                v-model="userName"
                :rules="rules"
                label="Name"
                placeholder="user"
                class="pb-3"
              >
              </v-text-field>
              <v-text-field
                v-model="userEmail"
                :rules="rules"
                label="Email"
                placeholder="person@example.com"
                class="pb-3"
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
                class="pb-3"
              >
              </v-text-field>
              <v-subheader
                class="red--text font-weight-black"
                style="display: block; text-align: center; margin-top: 5px;"
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
                Register
              </v-btn>
            </v-col>
          </v-row>
        </v-container>
      </v-form>
    </v-card>
  </div>
</template>

<script>
import ApiService from "../services/accounts-service";

export default {
  data() {
    return {
      valid: false,
      loading: false,
      passwordIsVisible: false,
      password: "",
      userName: "",
      userEmail: "",
      rules: [(val) => !!val || "This field is required!"],
      errorMsg: "",
    };
  },
  methods: {
    clear() {
      this.userName = "";
      this.password = "";
      this.userEmail = "";
    },
    submit() {
      this.loading = true;

      const credential = {
        Username: this.userName,
        Email: this.userEmail,
        Password: this.password,
      };

      ApiService.register(credential)
        .then(() => {
          this.loading = false;
          this.$router.push("/login");
        })
        .catch(() => {
          this.loading = false;
          this.errorMsg = "Enter Valid Email Or Strong Password!";
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