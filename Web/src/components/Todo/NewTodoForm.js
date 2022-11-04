import React from "react";

import Card from "../UI/Card";
import "./NewTodoForm.css";

const TodoForm = (props) => {
  const submitHandler = (event) => {
    event.preventDefault();
    props.onAddTodo({ title: "foo", description: "bar" });
  };

  return (
    <section className="todo-form">
      <Card>
        <h1>Create new TODO</h1>
        <form onSubmit={submitHandler}>
          <div className="form-control">
            <label htmlFor="title">What to do next?</label>
            <input
              type="text"
              id="title"
              onChange={(event) => {
                console.log(event.target.value);
              }}
            />
          </div>
          <div className="form-control">
            <label htmlFor="description">Description</label>
            <textarea
              id="description"
              onChange={(event) => {
                console.log(event.target.value);
              }}
            />
          </div>
          <div className="todo-form__actions">
            <button type="submit">Add Todo</button>
          </div>
        </form>
      </Card>
    </section>
  );
};

export default TodoForm;
