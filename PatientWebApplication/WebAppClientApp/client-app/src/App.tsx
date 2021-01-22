import * as React from "react";
import { Route } from "react-router";
import Layout from "./components/Layout";
import Home from "./components/Home";
import Counter from "./components/Counter";
import AdminFeedback from "./components/AdminFeedback";
import "./custom.css";
import PatientFeedback from "./components/PatientFeedback";
import CreateFeedback from "./components/CreateFeedback";
import PrescriptionsSimple from "./components/PrescriptionsSimple";
import AppointmentReportSimpleSearch from "./components/AppointmentReportSimpleSearch";
import RegistrationOfPatient from "./components/PatientRegister";
import PrescriptionsAdvanced from "./components/PrescriptionsAdvanced";
import MyInformation from "./components/MyInformation";
import AppointmentsAdvanced from "./components/AppointmentsAdvanced";
import CreateSurvey from "./components/CreateSurvey";
import DoctorRates from "./components/DoctorRates";
import AllRates from "./components/AllRates";
import ChooseAppointmentType from "./components/ChooseAppointmentType";
import AllPatientsAppointments from "./components/AllPatientsAppointments";
import AllAds from "./components/AllAds";
import MaliciousPatient from "./components/MaliciousPatient";
import ScheduleAppointment from "./components/ScheduleAppointment";
import { AuthRouteAdmin } from "./AuthRouteAdmin";
import { AuthRoutePatient } from "./AuthRoutePatient";
import { AuthRouteNotLogged } from "./AuthRouteNotLogged";

export default () => (
  <Layout>
    <AuthRouteNotLogged exact path="/" Component={Home} />
    <AuthRouteNotLogged path="/patient-feedback" Component={PatientFeedback} />
    <AuthRouteAdmin path="/admin-feedback" Component={AdminFeedback} />
    <AuthRoutePatient path="/create-feedback" Component={CreateFeedback} />
    <AuthRoutePatient
      path="/prescriptions-simple"
      Component={PrescriptionsSimple}
    />
    <AuthRoutePatient
      path="/reports-simple"
      Component={AppointmentReportSimpleSearch}
    />
    <AuthRouteNotLogged
      path="/register-patient"
      Component={RegistrationOfPatient}
    />
    <AuthRoutePatient
      path="/prescriptions-advanced"
      Component={PrescriptionsAdvanced}
    />
    <AuthRoutePatient path="/my-information" Component={MyInformation} />
    <AuthRoutePatient
      path="/appointments-advanced"
      Component={AppointmentsAdvanced}
    />
    <AuthRoutePatient path="/create-survey" Component={CreateSurvey} />
    <AuthRouteAdmin path="/rates-doctor" Component={DoctorRates} />
    <AuthRouteAdmin path="/rates-general" Component={AllRates} />
    <AuthRoutePatient
      path="/choose-appointment-type"
      Component={ChooseAppointmentType}
    />
    <AuthRoutePatient
      path="/my-appointments"
      Component={AllPatientsAppointments}
    />
    <AuthRouteAdmin path="/malicious-patient" Component={MaliciousPatient} />
    <AuthRoutePatient
      path="/schedule-appointment"
      Component={ScheduleAppointment}
    />
    <AuthRoutePatient path="/patient-homepage" Component={Counter} />
  </Layout>
);
