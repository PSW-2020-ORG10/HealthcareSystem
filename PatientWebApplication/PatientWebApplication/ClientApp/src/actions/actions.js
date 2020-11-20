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
    SIMPLE_SEARCH_PRESCRIPTIONS_ERROR

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
        await axios.post("http://localhost:60198/api/patientuser/", patient);
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

