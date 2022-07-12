<template>
  <div>
    <v-container>
      <h1>Hello, from projects</h1>
      <v-data-table
        dense
        :headers="headers"
        :items="entities"
        :options.sync="options"
        :items-per-page="15"
        :loading="loadingState"
        :footer-props="{
          showFirstLastPage: true,
          firstIcon: 'far fa-arrow-to-left',
          lastIcon: 'far fa-arrow-to-right',
          prevIcon: 'far fa-angle-left',
          nextIcon: 'far fa-angle-right',
        }"
      >

      </v-data-table>
    </v-container>
  </div>
</template>

<script>
import Api from "../services/projects-service";

export default {
  data() {
    return {
      entities: [],
      options: {
        id: null,
        search: null
      },
      loadingState: true,
      headers: [
        { text: "Name", value: "Name", width: "110px" }
      ]
    }
  },
  mounted() {
    this.getData();
  },
  methods: {
    getData() {
      Api.get()
        .then((res) => {
          this.entities = res.data.$values;
          console.log(this.entities);
        })
        .catch((err) => {
          console.log(err)
        })
    }
  },
  watch: {

  }
}
</script>

<style>

</style>