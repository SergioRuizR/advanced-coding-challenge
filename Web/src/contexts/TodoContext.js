import React, { createContext, useState, useEffect } from "react";
import axios from "axios";
// import { useAxios } from "../hooks/useAxios";

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
        setTodos([...todos, todo]);
      })
      .catch((error) => {});
  };

  const removeTodoHandler = (id) => {
    client
      .delete(`/${id}`)
      .then((response) => {
        setTodos(todos.filter((currentTodo) => currentTodo.id != id));
      })
      .catch((error) => {});
  };

  useEffect(() => {
    client.get("/").then((response) => {
      setTodos(response.data);
    });
  }, []);

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
