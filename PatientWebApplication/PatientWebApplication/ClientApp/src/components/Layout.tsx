import * as React from 'react';
import { Container } from 'reactstrap';
import NavMenu from './NavMenu';
import { Route } from 'react-router';
import Layout from '../components/Layout';
import Home from '../components/Home';
import Counter from '../components/Counter';
import FetchData from '../components/FetchData';
import PatientFeedback from './PatientFeedback';
import AdminFeedback from './AdminFeedback';

export default (props: { children: React.ReactNode }) => (
    <React.Fragment>
        <NavMenu/>
        <Container>
            <Route exact path='/' component={Home} />
            <Route path='/patient-feedback' component={PatientFeedback} />
            <Route path='/admin-feedback' component={AdminFeedback} />
        </Container>
    </React.Fragment>
);
