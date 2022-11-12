import axios from "axios";

const client = axios.create({
  baseURL: "http://localhost:3001/api/todo",
});

export const getTodos = async () => {
  let responseService = {};
  await client
    .get("/")
    .then((response) => {
      responseService.errors = false;
      responseService.data = response.data;
    })
    .catch((error) => {
      console.log("Axios call ---> " + error);
      responseService.errors = true;
      responseService.data = [];
    });
  return responseService;
};

export const addTodoItem = async (todo) => {
  let responseService = {};
  await client
    .post("/", todo)
    .then((response) => {
      responseService.success = true;
      responseService.errors = {};
    })
    .catch((error) => {
      console.log(error);
      responseService.success = false;
      responseService.errors = error.response.data.errors;
    });

  return responseService;
};

export const deleteTodoItem = async (id) => {
  let responseService = {};
  await client
    .delete(`/${id}`)
    .then((response) => {
      responseService.success = true;
      responseService.errors = {};
    })
    .catch((error) => {
      responseService.success = false;
      responseService.errors = error.response.data.errors;
    });

  return responseService;
};
