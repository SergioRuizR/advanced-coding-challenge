import { applyMiddleware, createStore } from "redux";
import reducer from "../reducers";
import { getTodos } from "../services/todos";
import { ADD_TODOITEM, INIT_DATA } from "../types";
import thunk from "redux-thunk";

const store = createStore(reducer, applyMiddleware(thunk));

store.subscribe(() => console.log(store));

export default store;
