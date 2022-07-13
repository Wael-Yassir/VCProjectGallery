import Api from "@/features/Shared/services/api";

const baseUrl = "projects";
export default {
  get() {
    return Api().get(baseUrl);
  },
  add(entity) {
    return Api().post(baseUrl, entity);
  },
  update(entity) {
    return Api().patch(`${baseUrl}/${entity.ID}`, entity)
  },
  delete(id) {
    return Api().delete(`${baseUrl}/${id}`);
  }
}