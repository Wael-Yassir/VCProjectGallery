import Api from "@/features/Shared/services/api";

const loginBaseUrl = "api/Authenticate/login";
const registerBaseUrl = "api/Authenticate/register";

export default {
  login(credential) {
    return Api().post(loginBaseUrl, credential)
  },
  register(credential) {
    return Api().post(registerBaseUrl, credential);
  }
}