/* eslint-disable no-multiple-empty-lines */
import React from 'react'
import { Provider } from 'react-redux'

import { persistStore } from "redux-persist"
import { PersistGate } from "redux-persist/integration/react"

import { MuiThemeProvider, createMuiTheme } from '@material-ui/core/styles'

import { ConnectedRouter } from "connected-react-router";
import { ReactReduxContext } from "react-redux";

import { history } from './../../state/createStore'

import createStore from '../../state/createStore'

import UI from './App'

const defaultTheme = {
  palette: {
    type: 'light',
    primary: {
      main: '#0089cf',
    },
    secondary: {
      main: '#ffffff',
    }
  },
  typography: {
    fontSize: 17
  }
}

export const tabeebTheme = createMuiTheme(defaultTheme)

const store = createStore()
const persistor = persistStore(store)

class App extends React.Component {
  render() {
    return (
      <MuiThemeProvider theme={tabeebTheme}>
        <Provider store={store} context={ReactReduxContext}>
          <PersistGate persistor={persistor}>
            <ConnectedRouter history={history} context={ReactReduxContext}>
              <UI />
            </ConnectedRouter>
          </PersistGate>
        </Provider>
      </MuiThemeProvider>
    )
  }
}

export default App
