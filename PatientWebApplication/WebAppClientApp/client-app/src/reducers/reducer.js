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
    LOADED_ALL_PATIENTS,
    LOADED_ALL_DOCTORS,
    RECOMMEND_APPOINTMENT,
    CREATE_RECOMMEND_APPOINTMENT,
    LOADED_ALL_AVAILABLE_DOCTORS,
    LOADED_ALL_AVAILABLE_DOCTORS_ERROR,
    LOADED_ALL_AVAILABLE_APPOINTMENTS,
    LOADED_ALL_AVAILABLE_APPOINTMENTS_ERROR,
    LOADED_ALL_PATIENT_APPOINTMENTS_INTWODAYS,
    LOADED_ALL_PATIENT_APPOINTMENTS_INFUTURE,
    CANCEL_APPOINTMENT,
    BLOCK_PATIENT,
    LOADED_ALL_PATIENT_APPOINTMENTS_WITH_SURVEYS,
    LOADED_ALL_PATIENT_APPOINTMENTS_WITHOUT_SURVEYS,
    LOADED_MALICIOUS_PATIENTS,
    APPOINTMENT_SCHEDULED,
    LOADED_IMAGE,
    LOADED_IMAGE_ERROR,
    LOADED_ALL_MESSAGES,
    LOADED_SECOND_IMAGE,
    LOADED_THIRD_IMAGE,
    USER_LOGGEDIN,
    PRESCRIPTION_LOADED,
    STORE_EVENT,
    GET_STATISTICS
} from "../types/types";
import { parseStringToDate } from '../utilities/Utilities';

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
    allPatientsList: [],
    doctorList: [],
    recommendedAppointments: [],
    createdRecommendedAppointment: {},
    patientAppointmentsInTwoDaysList: [],
    patientAppointmentsInFutureList: [],
    patientAppointmentsWithSurveys: [],
    patientAppointmentsWithoutSurveys: [],
    canceledAppointment: {},
    allPatientsBlockList: [],
    maliciousPatientsList: [],
    availableDoctors: [],
    availableAppointments: [],
    loadedImage : "",
    loadedSecondImage : "",
    loadedThirdImage : "",
    loadedAllMessagesList: [],
    userCookie : {},
    userToken : "",
    appointmentPrescription : {},  
    appointmentEvent : {},
    statistics: []
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
        case LOADED_ALL_AVAILABLE_DOCTORS:
            return {
                ...state,
                availableDoctors: action.payload
            };
        case LOADED_ALL_AVAILABLE_APPOINTMENTS:
            return {
                ...state,
                availableAppointments: action.payload
            };   
        case LOADED_ALL_PATIENTS:
            return {
                ...state,
                allPatientsList: action.payload
            };   
        case LOADED_ALL_PATIENT_APPOINTMENTS_INTWODAYS:
            return {
                ...state,
                patientAppointmentsInTwoDaysList: action.payload
            };
        case LOADED_ALL_PATIENT_APPOINTMENTS_INFUTURE:
            return {
                ...state,
                patientAppointmentsInFutureList: action.payload
            };
        case CANCEL_APPOINTMENT:
            return {
                ...state,
                patientAppointmentsList: updateObjectInArray(state.patientAppointmentsList, action)
            };     
        case LOADED_ALL_PATIENT_APPOINTMENTS_WITH_SURVEYS:
            debugger;
            return {
                ...state,
                patientAppointmentsWithSurveys: action.payload
            };     
        case LOADED_ALL_PATIENT_APPOINTMENTS_WITHOUT_SURVEYS:
            debugger;
            return {
                ...state,
                patientAppointmentsWithoutSurveys: action.payload
            };   
        case BLOCK_PATIENT:
            return {
                ...state,
                allPatientsBlockList: updateObjectInArray(state.allPatientsBlockList, action)
            }; 
        case LOADED_MALICIOUS_PATIENTS:
            return {
                ...state,
                maliciousPatientsList: action.payload
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
            debugger;
            var date = new Date();
            date.setDate(date.getDate() + 2);
            var appointmentDate = parseStringToDate(action.payload.date);
            if (appointmentDate <= date) {
                return {
                    ...state,
                    patientAppointmentsInTwoDaysList: state.patientAppointmentsInTwoDaysList.concat(action.payload),
                    createdRecommendedAppointment: action.payload
                }
            }
            else {
                return {
                    ...state,
                    patientAppointmentsInFutureList: state.patientAppointmentsInFutureList.concat(action.payload),
                    createdRecommendedAppointment: action.payload
                };
            }
        case APPOINTMENT_SCHEDULED:
            debugger;
            var date = new Date();
            date.setDate(date.getDate() + 2);
            var appointmentDate = parseStringToDate(action.payload.date);
            if (appointmentDate <= date) {
                return {
                    ...state,
                    patientAppointmentsInTwoDaysList: state.patientAppointmentsInTwoDaysList.concat(action.payload)
                }
            }
            else {
                return {
                    ...state,
                    patientAppointmentsInFutureList: state.patientAppointmentsInFutureList.concat(action.payload)
                };
            }
        case LOADED_IMAGE:
            debugger;
        return {
            ...state,
            loadedImage: action.payload
        };
        case LOADED_SECOND_IMAGE:
            debugger;
        return {
            ...state,
            loadedSecondImage: action.payload
        };
        case LOADED_THIRD_IMAGE:
            debugger;
        return {
            ...state,
            loadedThirdImage: action.payload
        };
        case LOADED_ALL_MESSAGES:
            return {
                ...state,
                loadedAllMessagesList: action.payload
            }; 
        case USER_LOGGEDIN:
            debugger;
            var parts = action.payload.token.split('.'); // header, payload, signature
            var user = JSON.parse(atob(parts[1]));
            return {
                ...state,
                userToken: action.payload.token,
                userCookie: user
            };
        case PRESCRIPTION_LOADED:
            debugger;
            return {
                ...state,
                appointmentPrescription: action.payload
            }; 
        case STORE_EVENT:
                return {
                    ...state,
                    appointmentEvent: action.payload
                };
        case GET_STATISTICS:
            return {
                ...state,
                statistics: action.payload
            };
        default:
            return state;
    }
}

export default reducer;