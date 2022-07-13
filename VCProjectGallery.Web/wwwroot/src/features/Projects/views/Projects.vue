<template>
  <v-container>
    <v-container>
      <h2>Projects</h2>
      <p>Browse and Manage Your Projects!</p>
    </v-container>

    <v-container>
      <v-data-table
        :headers="headers"
        :items="entities"
        :options.sync="options"
        :items-per-page="15"
        :loading="loadingState"
        class="elevation-2"
        :footer-props="{
          showFirstLastPage: true,
          firstIcon: 'far fa-arrow-to-left',
          lastIcon: 'far fa-arrow-to-right',
          prevIcon: 'far fa-angle-left',
          nextIcon: 'far fa-angle-right',
        }"
      >
        <template v-slot:top>
          <v-toolbar flat>
            <v-text-field
              v-model="options.search"
              append-icon="mdi-magnify"
              label="Search"
              single-line
              hide-details
            >
            </v-text-field>

            <v-divider class="mx-4" inset vertical></v-divider>

            <v-dialog v-model="dialog.addEdit" max-width="800px">
              <template v-slot:activator="{ on, attrs }">
                <v-btn
                  color="primary"
                  dark
                  class="mb-2"
                  v-bind="attrs"
                  v-on="on"
                >
                  Create Project
                </v-btn>
              </template>
              <v-card>
                <v-card-title>
                  <span class="text-h5">{{ dialogTitle }}</span>
                </v-card-title>

                <v-card-text>
                  <v-container>
                    <v-row>
                      <v-col cols="12" sm="6" md="6">
                        <v-text-field
                          :rules="rules"
                          v-model="selected.name"
                          label="Project Name"
                        ></v-text-field>
                      </v-col>
                      <v-col cols="12" sm="6" md="6">
                        <v-text-field
                          :rules="rules"
                          v-model="selected.client"
                          label="Client"
                        ></v-text-field>
                      </v-col>
                    </v-row>
                    <v-row>
                      <v-col cols="12" sm="6" md="6">
                        <v-text-field
                          :rules="rules"
                          v-model="selected.budget"
                          label="Budget"
                        ></v-text-field>
                      </v-col>
                      <v-col cols="12" sm="6" md="6">
                        <v-text-field
                          :rules="rules"
                          v-model="selected.location"
                          label="Location"
                        ></v-text-field>
                      </v-col>
                    </v-row>
                    <v-row>
                      <v-col cols="12" sm="12" md="12">
                        <v-text-field
                          :rules="rules"
                          v-model="selected.description"
                          label="Description"
                        ></v-text-field>
                      </v-col>
                    </v-row>
                  </v-container>
                </v-card-text>

                <v-card-actions>
                  <v-spacer></v-spacer>
                  <v-btn color="blue darken-1" text @click="close">
                    Cancel
                  </v-btn>
                  <v-btn color="blue darken-1" text @click="save"> Save </v-btn>
                </v-card-actions>
              </v-card>
            </v-dialog>

            <v-dialog v-model="dialog.delete" max-width="500px">
              <v-card>
                <v-card-title class="text-h6">
                  Are you sure you want to delete this project?
                </v-card-title>
                <v-card-actions>
                  <v-spacer></v-spacer>
                  <v-btn color="blue darken-1" text @click="close">
                    Cancel
                  </v-btn>

                  <v-btn color="blue darken-1" text @click="confirmDelete">
                    OK
                  </v-btn>
                  <v-spacer></v-spacer>
                </v-card-actions>
              </v-card>
            </v-dialog>
          </v-toolbar>
        </template>

        <template v-slot:[`item.budget`]="{ item }">
          <span
            >{{ item.budget }}
            {{
              item.budgetCurrency?.toLowerCase() === "us-dollar"
                ? "$"
                : item.budgetCurrency
            }}</span
          >
        </template>

        <template v-slot:[`item.actions`]="{ item }">
          <v-btn icon elevation="0" class="mr-1" @click="edit(item)">
            <i class="fas fa-pen" />
          </v-btn>
          <v-btn icon elevation="0" color="error" @click="del(item)">
            <i class="fas fa-trash-alt"></i>
          </v-btn>
        </template>
      </v-data-table>
    </v-container>
  </v-container>
</template>

<script>
import ApiService from "../services/projects-service";

export default {
  data() {
    return {
      entities: [],
      selected: {},
      options: {
        id: null,
        search: null,
      },
      loadingState: false,
      headers: [
        { text: "Name", value: "name", width: "200px" },
        { text: "Client", value: "client", width: "200px" },
        { text: "Budget", value: "budget", width: "200px" },
        { text: "Location", value: "location", width: "200px" },
        { text: "Description", value: "description" },
        {
          text: "Actions",
          value: "actions",
          align: "center",
          sortable: false,
          width: "125px",
        },
      ],
      modals: {
        update: false,
      },
      dialog: {
        addEdit: false,
        delete: false,
      },
      dialogDelete: false,
      editedItem: {},
      defaultItem: {},
      // https://stackoverflow.com/questions/784929/what-is-the-not-not-operator-in-javascript
      rules: [
        // Alt: Boolean(v) || "This field is required!" return false if the value is falsy (null, undefined, empty, .. etc)
        (val) => !!val || "This field is required!",
        (val) => val?.length > 3 || "Enter at least 3 characters!",
      ],
    };
  },
  mounted() {
    this.getData();
  },
  methods: {
    getData() {
      this.loadingState = true;
      ApiService.get()
        .then((res) => {
          this.entities = res.data;
          this.loadingState = false;
        })
        .catch(() => {
          this.loadingState = false;
        });
    },
    edit(item) {
      this.selected = item;
      this.dialog.addEdit = true;
      this.modals.update = true;
    },
    del(item) {
      this.selected = item;
      this.dialog.delete = true;
    },
    close() {
      this.selected = {};
      this.modals.update = false;
      this.dialog.addEdit = false;
      this.dialog.delete = false;
    },
    save() {
      // add new project
      if (this.modals.update === false) {
        ApiService.add(this.selected)
          .then((res) => {
            this.getData();
            console.log(res);
          })
          .catch((err) => {
            this.close();
            console.error(err);
          });
      } else {
        // update existing project
        ApiService.update(this.selected)
          .then((res) => console.log(res))
          .catch((err) => {
            this.close();
            console.error(err);
          });
      }

      this.close();
    },
    confirmDelete() {
      ApiService.delete(this.selected.id)
        .then((res) => {
          this.getData();
          console.log(res);
        })
        .catch((err) => {
          this.close();
          console.error(err);
        });

      this.close();
    },
  },
  computed: {
    dialogTitle() {
      return this.modals.update === false ? "Add New Project" : "Edit Project";
    },
  },
  watch: {},
};
</script>

<style>
</style>