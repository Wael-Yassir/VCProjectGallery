import Api from "@/features/Shared/services/api";


const BaseUrl = "api/Authenticate/register";
export default {
  register(credential) {
    return Api().post(BaseUrl, credential);
  }
}