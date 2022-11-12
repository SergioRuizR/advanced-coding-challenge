import React, { useContext } from "react";
import TodoItem from "./TodoItem";
import { useSelector } from "react-redux";

import "./TodoList.css";

const TodoList = (props) => {
  const state = useSelector((state) => state);
  if (state.todo.length == 0) {
    return (
      <div className="flex flex-col min-h-screen">
        <div>
          <h1 className="text-white text-5xl text-center mb-5 mt-5">
            Nothing Here Yet
          </h1>
        </div>
      </div>
    );
  }

  return (
    <section className="">
      <h2 className="text-white text-5xl text-center mb-5 mt-5">TODO List</h2>
      <div className="grid sm:grid-cols-1 md:grid-cols-3 lg:grid-cols-3 gap-5">
        {state.todo.map((todo) => (
          <div key={todo.id}>
            <TodoItem todo={todo} />
          </div>
        ))}
      </div>
    </section>
  );
};

export default TodoList;
