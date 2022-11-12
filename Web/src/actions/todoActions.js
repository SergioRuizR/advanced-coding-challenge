import { addTodoItem, getTodos } from "../services/todos";
import { ADD_TODOITEM, DELETE_TODOITEM, INIT_DATA } from "../types";

export const AddTodoItem = (todo) => {
  return async (dispatch) => {
    await addTodoItem(todo).then((response) => {
      dispatch({
        type: ADD_TODOITEM,
        payload: { success: response.success, todo: todo },
      });
    });
  };
};

export const DeleteTodoItem = (id) => ({ type: DELETE_TODOITEM, id: id });

export const InitData = () => {
  return async (dispatch) => {
    const todos = await getTodos();
    dispatch({ type: INIT_DATA, todos: todos });
  };
};
