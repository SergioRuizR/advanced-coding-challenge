import React from "react";

import TodoForm from "./NewTodoForm";
import TodoList from "./TodoList";

// Replace this import with data fetched from service
import todosData from "./todos-data.json"

import "./Todos.css";

const Todos = () => {

  const addTodoHandler = (todo) => {
    console.log(todo);
    // Handle insert todo logic here
  };

  const removeTodoHandler = (todo) => {
    console.log(todo);
    // Handle delete todo logic here
  };

  return (
    <div className="Todos">
      <TodoForm onAddTodo={addTodoHandler} />

      <section>
        <TodoList todos={todosData} onRemoveItem={removeTodoHandler} />
      </section>
    </div>
  );
};

export default Todos;
