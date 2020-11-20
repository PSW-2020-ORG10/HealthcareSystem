import {
    FEEDBACK_CREATED,
    FEEDBACK_PUBLISHED,
    LOADED_PUBLISHED_FEEDBACK,
    LOADED_ALL_FEEDBACK,
    LOADED_ALL_PRESCRIPTIONS,
    LOADED_ALL_PATIENT_PRESCRIPTIONS,
    PATIENT_REGISTERED,
    SIMPLE_SEARCH_PATIENT_PRESCRIPTIONS

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
    patientList: []
  
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

        default:
            return state;
    }
}

export default reducer;