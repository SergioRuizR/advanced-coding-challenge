import React, { createContext, useState, useEffect } from "react";
import axios from "axios";
import { toast } from "react-toastify";

export const TodoContext = createContext();

export const TodoProvider = (props) => {
  const client = axios.create({
    baseURL: "http://localhost:3001/api/todo",
  });

  const [todos, setTodos] = useState([]);

  const addTodoHandler = (todo) => {
    client
      .post("/", todo)
      .then((response) => {
        console.log(todos);
        toast.success("The todo item has been created");
        setTodos([...todos, todo]);
      })
      .catch((error) => {
        console.log(error);
        toast.error(`${buildErrorMessage(error.response.data.errors)}`);
      });
  };

  const removeTodoHandler = (id) => {
    client
      .delete(`/${id}`)
      .then((response) => {
        toast.success("The todo item has been deleted");
        setTodos(todos.filter((currentTodo) => currentTodo.id != id));
      })
      .catch((error) => {
        toast.error(`${buildErrorMessage(error.response.data.errors)}`);
      });
  };

  useEffect(() => {
    client.get("/").then((response) => {
      setTodos(response.data);
    });
  }, []);

  const buildErrorMessage = (errors) => {
    let formatErrors = "";
    for (const [key, value] of Object.entries(errors)) {
      formatErrors += `\n${key}: ${value}\n`;
    }
    return formatErrors;
  };

  return (
    <TodoContext.Provider
      value={{
        todos,
        addToDo: addTodoHandler,
        removeToDo: removeTodoHandler,
      }}
    >
      {props.children}
    </TodoContext.Provider>
  );
};
