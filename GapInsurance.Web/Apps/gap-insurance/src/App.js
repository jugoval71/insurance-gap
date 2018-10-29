import React, { Component } from 'react';
import { Route, Switch, Redirect } from 'react-router';
import { Provider } from 'react-redux';
import { ConnectedRouter } from 'connected-react-router'

import { PrivateRoute } from './Auth/PrivateRoute';
import HeaderContainer from './Header/HeaderContainer';
import Callback from './Callback/Callback';
import HomeContainer from './Home/HomeContainer';
import { Container } from 'react-bootstrap'
import store from './store/configureStore';

class App extends Component {

  handleAuthentication = ({ location }) => {
    if (/access_token|id_token|error/.test(location.hash)) {
      this.props.auth.handleAuthentication();
    }
  }

  render() {
    return (
      <Provider store={store}>
        <ConnectedRouter history={this.props.history}>
          <Container>
            <div className="App">
              <HeaderContainer auth={this.props.auth} history={this.props.history} />
              <div className="wrap">
                <Switch>
                  <PrivateRoute name="home" exact path='/home' component={HomeContainer} auth={this.props.auth} />
                  <Route path="/callback" render={(props) => { this.handleAuthentication(props); return <Callback {...props} /> }} />
                  <Redirect from="/" to="home" />
                </Switch>
              </div>
            </div>
          </Container>
        </ConnectedRouter>
      </Provider>
    );
  }
}

export default App;
