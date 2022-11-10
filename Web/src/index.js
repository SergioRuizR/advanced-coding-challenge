import React from "react";
import ReactDOM from "react-dom";
import { TodoProvider } from "./contexts/TodoContext";

import "./index.css";
import App from "./App";

ReactDOM.render(
  <TodoProvider>
    <App />
  </TodoProvider>,
  document.getElementById("root")
);
