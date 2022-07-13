import Api from "@/features/Shared/services/api";
import store from "@/store";

const baseUrl = "Api/projects";
export default {
  get() {
    return Api().get(`${baseUrl}/get`);
  },
  add(entity) {
    return Api().post(`${baseUrl}/post`, entity, {
      headers: {
        'Authorization': `Bearer ${store.state.token}`
      }
    });
  },
  update(entity) {
    return Api().put(`${baseUrl}/put/${entity.id}`, entity, {
      headers: {
        'Authorization': `Bearer ${store.state.token}`
      }
    })
  },
  delete(id) {
    return Api().delete(`${baseUrl}/delete/${id}`, {
      headers: {
        'Authorization': `Bearer ${store.state.token}`
      }
    });
  }
}