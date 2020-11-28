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
import AppointmentReportSimpleSearch from './components/AppointmentReportSimpleSearch';
import RegistrationOfPatient from './components/PatientRegister';
import MyInformation from './components/MyInformation';
import AppointmentsAdvanced from './components/AppointmentsAdvanced';
export default () => (
    <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/patient-feedback' component={PatientFeedback} />
        <Route path='/admin-feedback' component={AdminFeedback} />
        <Route path='/create-feedback' component={CreateFeedback} />
        <Route path='/prescriptions-simple' component={PrescriptionsSimple} />
        <Route path='/reports-simple' component={AppointmentReportSimpleSearch} />
        <Route path='/register-patient' component={RegistrationOfPatient} />
        <Route path='/my-information' component={MyInformation} />
        <Route path='/appointments-advanced' component={AppointmentsAdvanced} />
    </Layout>
);
