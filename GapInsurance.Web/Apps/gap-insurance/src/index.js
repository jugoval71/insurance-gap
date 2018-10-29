import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import  { history } from './store/configureStore';
import Auth from './Auth/Auth';

const auth = new Auth(history);

// eslint-disable-next-line no-unused-vars
window._ = window._ || require('lodash');
// eslint-disable-next-line no-unused-vars
window.axios = window.axios || require('axios');
ReactDOM.render(<App history={history} auth={auth}/>, document.getElementById('root'));
