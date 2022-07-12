import Api from "@/features/Shared/services/api";

const baseUrl = "projects";
export default {
  get() {
    return Api().get(baseUrl);
  }
}