import storage from 'redux-persist/lib/storage'
import { createStore, applyMiddleware, compose } from 'redux'
import createSagaMiddleware from 'redux-saga'
import { routerMiddleware } from 'connected-react-router'
import { persistReducer } from 'redux-persist'

import createRootReducer from './reducers'
import rootSaga from './sagas'

import { createHashHistory } from 'history'

export const history = createHashHistory()

export default (preloadedState) => {
    let store

    const persistConfig = {
        key: 'root',
        storage,
        whitelist: [],
    };

    const composeEnhancer = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;

    const sagaMiddleware = createSagaMiddleware()

    store = createStore(
        persistReducer(persistConfig, createRootReducer(history)),
        preloadedState,
        composeEnhancer(applyMiddleware(sagaMiddleware, routerMiddleware(history)))
    );

    sagaMiddleware.run(rootSaga);

    return store
}