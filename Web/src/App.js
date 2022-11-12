import React, { useEffect } from "react";
import { Provider, useDispatch } from "react-redux";
import store from "./store";

import Todos from "./components/Todo/Todos";
import { InitData } from "./actions/todoActions";

const App = (props) => {
  const dispatch = useDispatch();
  useEffect(() => {
    dispatch(InitData());
  }, [dispatch]);

  return <Todos />;
};

export default App;
