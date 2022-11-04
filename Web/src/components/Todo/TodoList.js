import React from 'react';

import './TodoList.css';

const TodoList = props => {
  return (
    <section className="todo-list">
      <h2>TODO List</h2>
      <ul>
        {props.todos.map(todo => (
          <li key={todo.id} onClick={props.onRemoveItem.bind(this, todo.id)}>
            <span>{todo.title}</span>
            <span>{todo.description}</span>
          </li>
        ))}
      </ul>
    </section>
  );
};

export default TodoList;
