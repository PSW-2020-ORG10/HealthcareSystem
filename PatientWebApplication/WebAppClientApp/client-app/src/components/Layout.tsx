import * as React from "react";
import { Container } from "reactstrap";
import NavMenu from "./NavMenu";
import { Route } from "react-router";
import Home from "../components/Home";
import PatientFeedback from "./PatientFeedback";
import AdminFeedback from "./AdminFeedback";
import CreateFeedback from "./CreateFeedback";
import PrescriptionsSimple from "./PrescriptionsSimple";
import AppointmentReportSimpleSearch from "./AppointmentReportSimpleSearch";
import RegistrationOfPatient from "./PatientRegister";
import PrescriptionsAdvanced from "./PrescriptionsAdvanced";
import MyInformation from "./MyInformation";
import AppointmentsAdvanced from "./AppointmentsAdvanced";
import CreateSurvey from "./CreateSurvey";
import DoctorRates from "./DoctorRates";
import AllRates from "./AllRates";
import ChooseAppointmentType from "./ChooseAppointmentType";
import AllPatientsAppointments from "./AllPatientsAppointments";
import MaliciousPatient from "./MaliciousPatient";
import ScheduleAppointment from "./ScheduleAppointment";
import AllAds from "./AllAds";
import Counter from "./Counter";
import { AuthRouteAdmin } from "../AuthRouteAdmin";
import { AuthRoutePatient } from "../AuthRoutePatient";
import { AuthRouteNotLogged } from "../AuthRouteNotLogged";
import EventStatistics from "./EventStatistics";

export default (props: { children: React.ReactNode }) => (
  <React.Fragment>
    <NavMenu />
    <Container>
      <AuthRouteNotLogged exact path="/" Component={Home} />
      <AuthRoutePatient path="/patient-feedback" Component={PatientFeedback} />
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
      <AuthRouteAdmin path="/event-statistics" Component={EventStatistics} />
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
    </Container>
  </React.Fragment>
);
