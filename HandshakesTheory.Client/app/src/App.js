import React from "react";
import { BrowserRouter } from "react-router-dom";
import { Provider } from "react-redux";
import { persistStore } from "redux-persist";

import { Routes } from "./Routes";
import { PersistGate } from "redux-persist/integration/react";

class App extends React.Component {
  render() {
    return (
      <BrowserRouter>
        <React.Fragment>
          <Routes />
        </React.Fragment>
      </BrowserRouter>
    );
  }
}

export default App;
