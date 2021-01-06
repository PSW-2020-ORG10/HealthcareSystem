import * as React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Counter from './components/Counter';
import AdminFeedback from './components/AdminFeedback';
import './custom.css'
import PatientFeedback from './components/PatientFeedback';
import CreateFeedback from './components/CreateFeedback';
import PrescriptionsSimple from './components/PrescriptionsSimple';
import AppointmentReportSimpleSearch from './components/AppointmentReportSimpleSearch';
import RegistrationOfPatient from './components/PatientRegister';
import PrescriptionsAdvanced from './components/PrescriptionsAdvanced';
import MyInformation from './components/MyInformation';
import AppointmentsAdvanced from './components/AppointmentsAdvanced';
import CreateSurvey from './components/CreateSurvey';
import DoctorRates from './components/DoctorRates';
import AllRates from './components/AllRates';
import ChooseAppointmentType from './components/ChooseAppointmentType';
import AllPatientsAppointments from './components/AllPatientsAppointments';
import { AuthRouteAdmin } from './AuthRouteAdmin'

export default () => (
    <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/patient-feedback' component={PatientFeedback} />
        <AuthRouteAdmin path='/admin-feedback' Component={AdminFeedback} />
        <Route path='/create-feedback' component={CreateFeedback} />
        <Route path='/prescriptions-simple' component={PrescriptionsSimple} />
        <Route path='/reports-simple' component={AppointmentReportSimpleSearch} />
        <Route path='/register-patient' component={RegistrationOfPatient} />
        <Route path='/prescriptions-advanced' component={PrescriptionsAdvanced} />
        <Route path='/my-information' component={MyInformation} />
        <Route path='/appointments-advanced' component={AppointmentsAdvanced} />
        <Route path='/create-survey' component={CreateSurvey} />
        <AuthRouteAdmin path='/rates-doctor' Component={DoctorRates} />
        <AuthRouteAdmin path='/rates-general' Component={AllRates} />
        <Route path='/choose-appointment-type' component={ChooseAppointmentType} />
        <Route path='/my-appointments' component={AllPatientsAppointments} />
    </Layout>
);
