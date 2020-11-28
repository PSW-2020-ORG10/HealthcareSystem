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
    ADVANCED_SEARCH_PATIENT_APPOINTMENTS,
    ADVANCED_SEARCH_APPOINTMENTS_ERROR,
    LOADED_ALL_PATIENT_APPOINTMENTS,
    OBSERVE_PATIENT_APPOINTMENTS_ERROR
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
