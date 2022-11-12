import { ADD_TODOITEM, DELETE_TODOITEM, INIT_DATA } from "../types";
import axios from "axios";
import { toast } from "react-toastify";
import { addTodoItem, AddTodoItem, getTodos } from "../services/todos";

const client = axios.create({
  baseURL: "http://localhost:3001/api/todo",
});

const buildErrorMessage = (errors) => {
  let formatErrors = "";
  for (const [key, value] of Object.entries(errors)) {
    formatErrors += `\n${key}: ${value}\n`;
  }
  return formatErrors;
};

export default function todoReducers(state = [], action) {
  switch (action.type) {
    case INIT_DATA:
      !action.todos.errors
        ? toast.success("Info load correctly")
        : toast.error("Error fetching init data");
      state = action.todos.data;
      return state;
    case ADD_TODOITEM:
      console.log(JSON.stringify(action));
      if (action.payload.success) {
        toast.success("The todo item has been created");
        state = [...state, action.payload.todo];
      } else {
        toast.error(`${buildErrorMessage(action.payload.errors)}`);
      }
      return state;

    case DELETE_TODOITEM:
      if (action.payload.success) {
        toast.success("The todo item has been deleted");
        state = state.filter(
          (currentTodo) => currentTodo.id != action.payload.id
        );
      } else {
        toast.error(`${buildErrorMessage(action.payload.errors)}`);
      }
      return state;
    default:
      return state;
  }
}
