import { initialState } from '../initialState'
import { combineReducers } from 'redux';
import { handleActions } from 'redux-actions';
import homeReducer from './homeReducer';
import { routerReducer } from 'react-router-redux';

const insurance = handleActions({
    ...homeReducer,
}, initialState);

const rootReducer = combineReducers({
    insurance,
    routerReducer
});

export default rootReducer; 