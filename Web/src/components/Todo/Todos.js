import React from "react";

import TodoForm from "./NewTodoForm";
import TodoList from "./TodoList";

import "./Todos.css";

const Todos = () => {
  return (
    <div className="bg-[#B0B8B4FF] h-fit">
      <div className="container mx-auto p-10">
        <TodoForm />
        <TodoList />
      </div>
    </div>
  );
};

export default Todos;
