import * as React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Counter from './components/Counter';
import FetchData from './components/FetchData';
import AdminFeedback from './components/AdminFeedback';

import './custom.css'
import PatientFeedback from './components/PatientFeedback';

export default () => (
    <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/patient-feedback' component={PatientFeedback} />
        <Route path='/admin-feedback' component={AdminFeedback} />
    </Layout>
);
