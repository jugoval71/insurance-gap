import { createStore, applyMiddleware, compose } from 'redux';
import createSagaMiddleware from 'redux-saga';
import promiseMiddleware from 'redux-promise';
import rootReducer from '../reducers';
import { initSagas } from '../sagas/initSagas';
import { initialState } from '../initialState'
import { createBrowserHistory } from 'history';
import { connectRouter, routerMiddleware } from 'connected-react-router'

export const history = createBrowserHistory();

//  Create middlewares
const sagaMiddleware = createSagaMiddleware();
const appRouterMiddleware = routerMiddleware(history);

// Compose enhancers
let composables = compose(applyMiddleware(
    promiseMiddleware,
    sagaMiddleware,
    appRouterMiddleware)
);

const configureStore = () => {
    const store = createStore(connectRouter(history)(rootReducer), initialState, composables);
    initSagas(sagaMiddleware);
    return store;
};

const store = configureStore();

export default store;