import React, { useContext, useState } from "react";
import { v4 as uuidv4 } from "uuid";
import { TodoContext } from "../context/TodoContext";

import Card from "../containers/Card";
import "./NewTodoForm.css";

const TodoForm = (props) => {
  const { addToDo } = useContext(TodoContext);
  const submitHandler = (event) => {
    event.preventDefault();
    addToDo({
      id: uuidv4(),
      title: title,
      description: description,
    });
    setTitle("");
    setDescription("");
  };

  const [title, setTitle] = useState("");
  const [description, setDescription] = useState("");

  return (
    <section className="bg-[#184A45FF] text-white shadow-md rounded px-8 pt-6 pb-8 mb-4 max-w-md mx-auto opacity-100">
      <h1 className="text-2xl text-center capitalize font-bold mb-10">
        Create new TODO
      </h1>
      <form onSubmit={submitHandler}>
        <div className="mb-4">
          <label className="block text-sm mb-2" htmlFor="To do">
            What to do next?
          </label>
          <input
            className="shadow appearance-none border rounded w-full py-2 px-3 leading-tight focus:outline-none focus:shadow-outline bg-[#B0B8B4FF] text-black"
            type="text"
            id="title"
            placeholder="To do"
            value={title}
            autoFocus
            onChange={(event) => {
              setTitle(event.target.value);
            }}
          />
        </div>
        <div className="mb-4">
          <label className="block text-sm  mb-2" htmlFor="Description">
            Description
          </label>
          <textarea
            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700       leading-tight focus:outline-none focus:shadow-outline bg-[#B0B8B4FF] resize-none"
            id="description"
            placeholder="Description"
            value={description}
            onChange={(event) => {
              setDescription(event.target.value);
            }}
          />
        </div>
        <div className="text-right">
          <button
            className="bg-[#008C76FF] transition duration-500 hover:scale-110 text-white font-bold py-2 px-4 rounded"
            type="submit"
          >
            Add TODO
          </button>
        </div>
      </form>
    </section>
  );
};

export default TodoForm;
