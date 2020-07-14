import React from 'react'
import { Provider, ReactReduxContext } from 'react-redux'
import { persistStore } from 'redux-persist'
import { PersistGate } from 'redux-persist/integration/react'
import { ConnectedRouter } from 'connected-react-router'

import { MuiThemeProvider, createMuiTheme } from '@material-ui/core/styles'

import createStore, { history } from './../state/createStore'

import UI from './UI'

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
    fontSize: 14
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
