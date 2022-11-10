import React, { useContext } from "react";
import { TodoContext } from "../../contexts/TodoContext";

const TodoItem = ({ todo }) => {
  const { removeToDo } = useContext(TodoContext);

  return (
    <div className="bg-[#FC766AFF] text-[#184A45FF] p-6 rounded-md h-50 transition duration-500 hover:scale-110 hover:bg-[#ed594c] ">
      <div className="relative group">
        <div className="font-bold text-xl capitalize h-9">{todo.title}</div>
        <div className="absolute -bottom-1 left-0 w-0 h-1 bg-[#4c5956] transition-all duration-500  group-hover:w-10/12"></div>
      </div>
      {/* <h1 className="font-bold text-xl capitalize h-9">{todo.title}</h1> */}
      <div className="text-sm h-16 overflow-y-auto	mt-5">{todo.description}</div>

      <div className="mt-5">
        <button
          className="bg-[#4eab97] hover:bg-[#129a7c] text-white font-bold py-2 px-4 rounded"
          onClick={(e) => {
            removeToDo(todo.id);
          }}
        >
          Delete
        </button>
      </div>
    </div>
  );
};

export default TodoItem;
