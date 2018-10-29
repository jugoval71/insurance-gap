import React, { Component } from 'react';
import { Navbar, Nav } from 'react-bootstrap';

export default class Header extends Component {

    goTo(route) {
        this.props.history.replace(`/${route}`)
    }

    login() {
        this.props.auth.login();
    }

    logout() {
        this.props.auth.logout();
        this.props.history.replace('/home')
    }

    render() {
        const { isAuthenticated } = this.props.auth;

        return (
            <Navbar bg="light" variant="light">
                <Navbar.Brand href="/">Gap - Insurance</Navbar.Brand>
                <Nav className="mr-auto">
                    <Nav.Link onClick={this.goTo.bind(this, 'home')}>Home </Nav.Link>
                    {!isAuthenticated() && (<Nav.Link id="qsLoginBtn" onClick={this.login.bind(this)}>Log In</Nav.Link>)}
                    {isAuthenticated() && (<Nav.Link id="qsLogoutBtn" onClick={this.logout.bind(this)}>Log Out</Nav.Link>)}
                </Nav>

            </Navbar>)
    }
}