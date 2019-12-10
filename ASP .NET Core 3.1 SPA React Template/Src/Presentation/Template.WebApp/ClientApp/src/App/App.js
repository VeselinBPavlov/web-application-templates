import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from '../components/Layout';
import { Home } from '../components/Home';
import { Managers } from '../components/Managers/Managers';
import ApiAuthorizationRoutes from '../components/api-authorization/ApiAuthorizationRoutes';
import AuthorizeRoute from '../components/api-authorization/AuthorizeRoute';
import { ApplicationPaths } from '../components/api-authorization/ApiAuthorizationConstants';

import './custom.css'

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={Home} />
                <AuthorizeRoute path='/managers' component={Managers} />
                <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
            </Layout>
        );
    }
}
