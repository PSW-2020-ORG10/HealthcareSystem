import * as React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Counter from './components/Counter';
import FetchData from './components/FetchData';
import AdminFeedback from './components/AdminFeedback';
import './custom.css'
import PatientFeedback from './components/PatientFeedback';
import CreateFeedback from './components/CreateFeedback';
import PrescriptionsSimple from './components/PrescriptionsSimple';
import RegistrationOfPatient from './components/PatientRegister';

export default () => (
    <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/patient-feedback' component={PatientFeedback} />
        <Route path='/admin-feedback' component={AdminFeedback} />
        <Route path='/create-feedback' component={CreateFeedback} />
        <Route path='/prescriptions-simple' component={PrescriptionsSimple} />
        <Route path='/register-patient' component={RegistrationOfPatient} />
    </Layout>
);
