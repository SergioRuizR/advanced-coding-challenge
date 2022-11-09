import React, { createContext, useState, useEffect } from "react";
// Replace this import with data fetched from service
import todosData from "../Todo/todos-data.json";

export const TodoContext = createContext();

export const TodoProvider = (props) => {
  const [todos, setTodos] = useState([]);

  const addTodoHandler = (todo) => {
    console.log(todo);
    setTodos([...todos, todo]);
    // Handle insert todo logic here
  };

  const removeTodoHandler = (id) => {
    console.log(id);
    setTodos(todos.filter((currentTodo) => currentTodo.id != id));
    // Handle delete todo logic here
  };

  useEffect(() => {
    setTodos(todosData);
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
