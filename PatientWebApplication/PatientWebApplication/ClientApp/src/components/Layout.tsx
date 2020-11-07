import * as React from 'react';
import { Container } from 'reactstrap';
import NavMenu from './NavMenu';
import { Route } from 'react-router';
import Home from '../components/Home';
import PatientFeedback from './PatientFeedback';
import AdminFeedback from './AdminFeedback';
import CreateFeedback from './CreateFeedback';

export default (props: { children: React.ReactNode }) => (
    <React.Fragment>
        <NavMenu/>
        <Container>
            <Route exact path='/' component={Home} />
            <Route path='/patient-feedback' component={PatientFeedback} />
            <Route path='/admin-feedback' component={AdminFeedback} />
            <Route path='/create-feedback' component={CreateFeedback} />
        </Container>
    </React.Fragment>
);
