import Api from "@/features/Shared/services/api";
// import store from "@/store";

const baseUrl = "Api/projects";
export default {
  get() {
    return Api().get(`${baseUrl}/get`);
  },
  add(entity) {
    return Api().post(`${baseUrl}/post`, entity);
  },
  update(entity) {
    return Api().put(`${baseUrl}/put/${entity.ID}`, entity)
  },
  delete(id) {
    return Api().delete(`${baseUrl}/delete/${id}`,);
    // return Api().delete(`${baseUrl}/${id}`, {
    //   headers: {
    //     'Authorization': `Bearer ${store.state.token}`
    //   }
    // });
  }
}