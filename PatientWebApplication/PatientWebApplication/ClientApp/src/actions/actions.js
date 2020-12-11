import {
    FEEDBACK_CREATED,
    CREATE_ERROR,
    FEEDBACK_PUBLISHED,
    LOADED_PUBLISHED_FEEDBACK,
    PUBLISH_ERROR,
    LOADED_ALL_FEEDBACK,
    OBSERVE_ERROR,
    LOADED_ALL_PRESCRIPTIONS,
    OBSERVE_PRESCRIPTIONS_ERROR,
    LOADED_ALL_PATIENT_PRESCRIPTIONS,
    OBSERVE_PATIENT_PRESCRIPTIONS_ERROR,
    PATIENT_REGISTERED,
    SIMPLE_SEARCH_PATIENT_PRESCRIPTIONS,
    SIMPLE_SEARCH_PRESCRIPTIONS_ERROR,
    ADVANCED_SEARCH_PATIENT_PRESCRIPTIONS,
    ADVANCED_SEARCH_PRESCRIPTIONS_ERROR,
    FIND_ONE_PATIENT,
    FIND_ONE_PATIENT_ERROR,
    SURVEY_CREATED,
    LOADED_APPOINTMENTSURVEY,
    LOADED_ALL_PATIENT_REPORTS,
    OBSERVE_PATIENT_REPORTS_ERROR,
    LOADED_ALL_RATES,
    LOADED_ALL_DOCTOR_RATES,
    ADVANCED_SEARCH_PATIENT_APPOINTMENTS,
    ADVANCED_SEARCH_APPOINTMENTS_ERROR,
    LOADED_ALL_PATIENT_APPOINTMENTS,
    OBSERVE_PATIENT_APPOINTMENTS_ERROR,
    LOADED_ALL_DOCTORS,
    OBSERVE_DOCTORS_ERROR,
    RECOMMEND_APPOINTMENT,
    RECOMMEND_APPOINTMENT_ERROR,
    CREATE_RECOMMEND_APPOINTMENT,
    CREATE_RECOMMEND_APPOINTMENT_ERROR,
    LOADED_ALL_AVAILABLE_DOCTORS,
    LOADED_ALL_AVAILABLE_DOCTORS_ERROR,
    LOADED_ALL_AVAILABLE_APPOINTMENTS,
    LOADED_ALL_AVAILABLE_APPOINTMENTS_ERROR,
    APPOINTMENT_SCHEDULED,
    APPOINTMENT_SCHEDULED_ERROR,
    LOADED_ALL_PATIENT_APPOINTMENTS_INTWODAYS,
    LOADED_ALL_PATIENT_APPOINTMENTS_INFUTURE,
    CANCEL_APPOINTMENT,
    LOADED_ALL_PATIENT_APPOINTMENTS_WITH_SURVEYS,
    LOADED_ALL_PATIENT_APPOINTMENTS_WITHOUT_SURVEYS
} from "../types/types"
import axios from "axios";

export const feedbackCreated = (feedback) => async (dispatch) => {
    console.log(feedback.message);
    try {
        debugger;
        await axios.post("http://localhost:60198/api/feedback/", feedback);
        debugger;
        dispatch({
            type: FEEDBACK_CREATED,
            payload: feedback,
        });
    } catch (e) {
        dispatch({
            type: CREATE_ERROR,
            payload: console.log(e),
        });
    }
}; 

export const feedbackPublished = (id) => async (dispatch) => {
    try {
        const response = await axios.put("http://localhost:60198/api/feedback/" + id);
        dispatch({
            type: FEEDBACK_PUBLISHED,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: PUBLISH_ERROR,
            payload: console.log(e),
        });
    }
}; 

export const loadedPublishedFeedback = () => async (dispatch) => {
    try {
        debugger;
        const response = await axios.get("http://localhost:60198/api/feedback/published");        
        debugger;
        dispatch({
            type: LOADED_PUBLISHED_FEEDBACK,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: PUBLISH_ERROR,
            payload: console.log(e),
        });
    }
};

export const loadedAllFeedback = () => async (dispatch) => {
    try {
        debugger;
        const response = await axios.get("http://localhost:60198/api/feedback");
        debugger;
        dispatch({
            type: LOADED_ALL_FEEDBACK,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: OBSERVE_ERROR,
            payload: console.log(e),
        });
    }
};

export const loadedAllPrescriptions = () => async (dispatch) => {
    try {
        debugger;
        const response = await axios.get("http://localhost:60198/api/prescription");
        debugger;
        dispatch({
            type: LOADED_ALL_PRESCRIPTIONS,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: OBSERVE_PRESCRIPTIONS_ERROR,
            payload: console.log(e),
        });
    }
};

export const loadedAllPatientPrescriptions = () => async (dispatch) => {
    try {
        debugger;
        const response = await axios.get("http://localhost:60198/api/prescription/patient");
        debugger;
        dispatch({
            type: LOADED_ALL_PATIENT_PRESCRIPTIONS,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: OBSERVE_PATIENT_PRESCRIPTIONS_ERROR,
            payload: console.log(e),
        });
    }
};


export const patientRegistered = (patient) => async (dispatch) => {
    try {
        debugger;
        await axios.post("http://localhost:60198/api/patientuser", patient);
        debugger;
        dispatch({
            type: PATIENT_REGISTERED,
            payload: patient,
        });
    } catch (e) {
        dispatch({
            type: CREATE_ERROR,
            payload: console.log(e),
        });
    }
}; 

export const simpleSearchPatientPrescriptions = (prescription) => async (dispatch) => {
    console.log(prescription.medicines)
    try {
        debugger;
        const response = await axios.post("http://localhost:60198/api/prescription/search", prescription);
        debugger;
        dispatch({
            type: SIMPLE_SEARCH_PATIENT_PRESCRIPTIONS,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: SIMPLE_SEARCH_PRESCRIPTIONS_ERROR,
            payload: console.log(e),
        });
    }
};

export const findOnePatient = (id) => async (dispatch) => {
    try {
        debugger;
        const response = await axios.get("http://localhost:60198/api/patientuser/getone", {
            params: {
                id: id
            }
        });
        debugger;
        dispatch({
            type: FIND_ONE_PATIENT,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: FIND_ONE_PATIENT_ERROR,
            payload: console.log(e),
        });
    }
};

export const advancedSearchPatientPrescriptions = (prescription) => async (dispatch) => {
    console.log(prescription.medicines)
    try {
        debugger;
        const response = await axios.post("http://localhost:60198/api/prescription/advancedsearch", prescription);
        debugger;
        dispatch({
            type: ADVANCED_SEARCH_PATIENT_PRESCRIPTIONS,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: ADVANCED_SEARCH_PRESCRIPTIONS_ERROR,
            payload: console.log(e),
        });
    }
};
export const loadedAllPatientReports = (patientId) => async (dispatch) => {
    try {
        axios.all(  [axios.get('http://localhost:60198/api/doctorappointment/' + patientId),
                     axios.get('http://localhost:60198/api/operation/' + patientId)])
                        .then(axios.spread((firstResponse, secondResponse) => {
                            debugger;
                            var appointments = []
                            firstResponse.data.forEach(element => appointments.push(element));
                            secondResponse.data.forEach(element => appointments.push(element));
                            console.log(appointments)
                            dispatch({
                                type: LOADED_ALL_PATIENT_REPORTS,
                                payload: appointments,
                            })
                        }))
                        .catch(error => console.log(error))
    } catch (e) {
        dispatch({
            type: OBSERVE_PATIENT_REPORTS_ERROR,
            payload: console.log(e),
        });
    }
};

export const simpleSearchAppointments  = (searchDto) => async (dispatch) => {
    try {
        axios.all([axios.post('http://localhost:60198/api/doctorappointment/search', searchDto),
            axios.post('http://localhost:60198/api/operation/search',  searchDto)])
            .then(axios.spread((firstResponse, secondResponse) => {
                debugger;
                var appointments = []
                firstResponse.data.forEach(element => appointments.push(element));
                secondResponse.data.forEach(element => appointments.push(element));
                console.log(appointments)
                dispatch({
                    type: LOADED_ALL_PATIENT_REPORTS,
                    payload: appointments,
                })
            }))
            .catch(error => console.log(error))
    } catch (e) {
        dispatch({
            type: OBSERVE_PATIENT_REPORTS_ERROR,
            payload: console.log(e),
        });
    }
};

export const loadedAppointmentSurvey = () => async (dispatch) => {
    try {
        debugger;
        const response = await axios.get("http://localhost:60198/api/survey");
        debugger;
        dispatch({
            type: LOADED_APPOINTMENTSURVEY,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: OBSERVE_ERROR,
            payload: console.log(e),
        });
    }
};

export const surveyCreated = (survey) => async (dispatch) => {
    try {
        debugger;
        await axios.post("http://localhost:60198/api/survey/", survey);
        debugger;
        dispatch({
            type: SURVEY_CREATED,
            payload: survey,
        });
    } catch (e) {
        dispatch({
            type: OBSERVE_ERROR,
            payload: console.log(e),
        });
    }
};

export const advancedSearchPatientAppointments = (appointment) => async (dispatch) => {
    try {
        debugger;
        const response = await axios.post("http://localhost:60198/api/doctorappointment/advancedsearch", appointment);
        debugger;
        dispatch({
            type: ADVANCED_SEARCH_PATIENT_APPOINTMENTS,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: ADVANCED_SEARCH_APPOINTMENTS_ERROR,
            payload: console.log(e),
        });
    }
};

export const loadedAllPatientAppointments = () => async (dispatch) => {
    try {
        debugger;
        const response = await axios.get("http://localhost:60198/api/doctorappointment/patient");
        debugger;
        dispatch({
            type: LOADED_ALL_PATIENT_APPOINTMENTS,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: OBSERVE_PATIENT_APPOINTMENTS_ERROR,
            payload: console.log(e),
        });
    }
};

export const loadedAllRates = () => async (dispatch) => {
    try {
        debugger;
        const response = await axios.get("http://localhost:60198/api/survey/getRates");
        debugger;
        dispatch({
            type: LOADED_ALL_RATES,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: OBSERVE_ERROR,
            payload: console.log(e),
        });
    }
};

export const loadedAllDoctorRates = () => async (dispatch) => {
    try {
        debugger;
        const response = await axios.get("http://localhost:60198/api/survey/getDoctorRates");
        debugger;
        dispatch({
            type: LOADED_ALL_DOCTOR_RATES,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: OBSERVE_ERROR,
            payload: console.log(e),
        });
    }
};

export const loadedAllAvailableDoctors = (specialty, date, patientId) => async (dispatch) => {
    try {
        debugger;
        const response = await axios.get("http://localhost:60198/api/doctor/available?specialty=" + specialty+ "&date=" + date + "&patientId=" + patientId);
        debugger;
        dispatch({
            type: LOADED_ALL_AVAILABLE_DOCTORS,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: LOADED_ALL_AVAILABLE_DOCTORS_ERROR,
            payload: console.log(e),
        });
    }
};

export const loadedAllPatientAppointmentsInTwoDays = () => async (dispatch) => {
    try {
        debugger;
        const response = await axios.get("http://localhost:60198/api/doctorappointment/patientInTwoDays");
        debugger;
        dispatch({
            type: LOADED_ALL_PATIENT_APPOINTMENTS_INTWODAYS,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: OBSERVE_PATIENT_APPOINTMENTS_ERROR,
            payload: console.log(e),
        });
    }
};

export const loadedAllAvailableAppointments = (dto) => async (dispatch) => {
    try {
        debugger;
        const response = await axios.post("http://localhost:60198/api/doctorappointment/availableappointments", dto);
        debugger;
        dispatch({
            type: LOADED_ALL_AVAILABLE_APPOINTMENTS,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: LOADED_ALL_AVAILABLE_APPOINTMENTS_ERROR,
            payload: console.log(e),
        });
    }
};
export const loadedAllPatientAppointmentsInFuture = () => async (dispatch) => {
    try {
        debugger;
        const response = await axios.get("http://localhost:60198/api/doctorappointment/patientInFuture");
        debugger;
        dispatch({
            type: LOADED_ALL_PATIENT_APPOINTMENTS_INFUTURE,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: OBSERVE_PATIENT_APPOINTMENTS_ERROR,
            payload: console.log(e),
        });
    }
};

export const appointmentScheduled = (appointment) => async (dispatch) => {
    try {
        debugger;
        const response = await axios.post("http://localhost:60198/api/doctorappointment", appointment);
        debugger;
        dispatch({
            type: APPOINTMENT_SCHEDULED,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: APPOINTMENT_SCHEDULED_ERROR,
            payload: console.log(e),
        });
    }
};

export const cancelAppointment = (appointmentId) => async (dispatch) => {
    try {
        debugger;
        const response = await axios.put("http://localhost:60198/api/doctorappointment/" + appointmentId );
        debugger;
        dispatch({
            type: CANCEL_APPOINTMENT,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: OBSERVE_PATIENT_APPOINTMENTS_ERROR,
            payload: console.log(e),
        });
    }
};

export const loadedAllPatientAppointmentsWithSurvey = () => async (dispatch) => {
    try {
        debugger;
        const response = await axios.get("http://localhost:60198/api/survey/");
        debugger;
        dispatch({
            type: LOADED_ALL_PATIENT_APPOINTMENTS_WITH_SURVEYS,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: OBSERVE_PATIENT_APPOINTMENTS_ERROR,
            payload: console.log(e),
        });
    }
};

export const loadedAllPatientAppointmentsWithoutSurvey = () => async (dispatch) => {
    try {
        debugger;
        const response = await axios.get("http://localhost:60198/api/survey/getWithSurveys");
        debugger;
        dispatch({
            type: LOADED_ALL_PATIENT_APPOINTMENTS_WITHOUT_SURVEYS,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: OBSERVE_PATIENT_APPOINTMENTS_ERROR,
            payload: console.log(e),
        });
    }
};

export const loadedAllDoctors = () => async (dispatch) => {
    try {
        debugger;
        const response = await axios.get("http://localhost:60198/api/doctor/");
        debugger;
        dispatch({
            type: LOADED_ALL_DOCTORS,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: OBSERVE_DOCTORS_ERROR,
            payload: console.log(e),
        });
    }
};

export const recommendAppointment = (appointment) => async (dispatch) => {
    console.log(appointment.start)
    try {
        debugger;
        const response = await axios.post("http://localhost:60198/api/doctorappointment/recommend", appointment);
        debugger;
        dispatch({
            type: RECOMMEND_APPOINTMENT,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: RECOMMEND_APPOINTMENT_ERROR,
            payload: console.log(e),
        });
    }
};

export const createRecommendAppointment = (appointment) => async (dispatch) => {
    console.log(appointment.start)
    try {
        debugger;
        const response = await axios.post("http://localhost:60198/api/doctorappointment/createRecommended", appointment);
        debugger;
        dispatch({
            type: CREATE_RECOMMEND_APPOINTMENT,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: CREATE_RECOMMEND_APPOINTMENT_ERROR,
            payload: console.log(e),
        });
    }
};
