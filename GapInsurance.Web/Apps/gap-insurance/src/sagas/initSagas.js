import * as sagas from './index';

export const initSagas = (sagaMiddleware) => {    
    Object.keys(sagas).map(itm => sagas[itm]).forEach(sagaMiddleware.run.bind(sagaMiddleware));
};