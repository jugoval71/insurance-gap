import React from 'react';
import { Route } from 'react-router-dom';

export const PrivateRoute = ({ component: Component, auth: Auth, ...rest }) => {
    if (Auth.isAuthenticated() === false) {
        Auth.login();
        return null;
    }
    return (
        <Route {...rest} render={props => (<Component {...props} />)} />
    )
} 