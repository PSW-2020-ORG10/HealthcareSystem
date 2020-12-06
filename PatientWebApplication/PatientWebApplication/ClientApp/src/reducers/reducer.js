﻿import {
    FEEDBACK_CREATED,
    FEEDBACK_PUBLISHED,
    LOADED_PUBLISHED_FEEDBACK,
    LOADED_ALL_FEEDBACK,
    LOADED_ALL_PRESCRIPTIONS,
    LOADED_ALL_PATIENT_PRESCRIPTIONS,
    PATIENT_REGISTERED,
    SIMPLE_SEARCH_PATIENT_PRESCRIPTIONS,
    ADVANCED_SEARCH_PATIENT_PRESCRIPTIONS,
    FIND_ONE_PATIENT,
    LOADED_ALL_PATIENT_REPORTS,
    ADVANCED_SEARCH_PATIENT_APPOINTMENTS,
    LOADED_ALL_PATIENT_APPOINTMENTS,
    SURVEY_CREATED,
    LOADED_ALL_RATES,
    LOADED_ALL_DOCTOR_RATES,
    LOADED_APPOINTMENTSURVEY,
    LOADED_ALL_DOCTORS,
    RECOMMEND_APPOINTMENT,
    CREATE_RECOMMEND_APPOINTMENT
} from "../types/types"

function addFeedback(state=initialState, action) {
    return {
        ...state,
        feedbackList: state.feedbackList.concat(action.payload),
    };
}

function updateObjectInArray(array, action) {
    return array.map((item) => {
        if (item.id !== action.payload.id) {
            // This isn't the item we care about - keep it as-is
            return item
        }

        // Otherwise, this is the one we want - return an updated value
        return {
            ...item,
            ...action.payload
        }
    })
}

function loadPublishedFeedback(state = initialState, action) {
    return {
        ...state,
        publishedFeedbackList: action.payload,
    };
}

const initialState = {
    feedbackList: [],
    publishedFeedbackList: [],
    prescriptionsList: [],
    patientPrescriptionsList: [],
    patientList: [],
    patientInformationList: [],
    patientAppointments: [],
    patientAppointmentsList: [],
    appointmentSurveyList: [],
    surveyList: [], 
    patientAppointments: [],
    doctorRatesList: [],
    allRates: {},
    doctorList: [],
    recommendedAppointments: [],
    createdRecommendedAppointment: {}
};


function reducer(state = initialState, action) {
    switch (action.type) {
        case FEEDBACK_CREATED:
            return {
                ...state,
                feedbackList: state.feedbackList.concat(action.payload)
            };
        case FEEDBACK_PUBLISHED:
            return {
                ...state,
                publishedFeedbackList: state.publishedFeedbackList.concat(action.payload),
                feedbackList: updateObjectInArray(state.feedbackList, action)
            };
        case LOADED_PUBLISHED_FEEDBACK:                      
            return {
                ...state,
                publishedFeedbackList: action.payload,
            };
        case LOADED_ALL_FEEDBACK:
            return {
                ...state,
                feedbackList: action.payload

            };
        case LOADED_ALL_PRESCRIPTIONS:
            return {
                ...state,
                prescriptionsList: action.payload

            };
        case LOADED_ALL_PATIENT_PRESCRIPTIONS:
            return {
                ...state,
                patientPrescriptionsList: action.payload

            };

        case PATIENT_REGISTERED:
            return {
                ...state,
                feedbackList: state.patientList.concat(action.payload)
            }

        case SIMPLE_SEARCH_PATIENT_PRESCRIPTIONS:
            return {
                ...state,
                patientPrescriptionsList: action.payload

            };
        case ADVANCED_SEARCH_PATIENT_PRESCRIPTIONS:
            return {
                ...state,
                patientPrescriptionsList: action.payload

            };
        case FIND_ONE_PATIENT:
            return {
                ...state,
                patientInformationList: action.payload

            };
        case SURVEY_CREATED:
            return {
                ...state,
                feedbackList: state.surveyList.concat(action.payload)
            };
        case LOADED_APPOINTMENTSURVEY:
            return {
                ...state,
                appointmentSurveyList : action.payload
            }; 
        case LOADED_ALL_PATIENT_REPORTS:
            return {
                ...state,
                patientAppointments: action.payload
            };
        case LOADED_ALL_PATIENT_APPOINTMENTS:
            return {
                ...state,
                patientAppointmentsList: action.payload
            };
        case ADVANCED_SEARCH_PATIENT_APPOINTMENTS:
            return {
                ...state,
                patientAppointmentsList: action.payload

            };
        case LOADED_ALL_RATES:
            debugger;
            return {
                ...state,
                allRates: action.payload
            };
        case LOADED_ALL_DOCTOR_RATES:
            return {
                ...state,
                doctorRatesList: action.payload
            };
        case LOADED_ALL_DOCTORS:
            return {
                ...state,
                doctorList: action.payload

            };
        case RECOMMEND_APPOINTMENT:
            return {
                ...state,
                recommendedAppointments: action.payload

            };
        case CREATE_RECOMMEND_APPOINTMENT:
            return {
                ...state,
                createdRecommendedAppointment: action.payload

            };
        default:
            return state;
    }
}

export default reducer;