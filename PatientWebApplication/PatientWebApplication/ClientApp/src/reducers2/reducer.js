import {
    FEEDBACK_CREATED,
    FEEDBACK_PUBLISHED,
    LOADED_PUBLISHED_FEEDBACK,
    LOADED_ALL_FEEDBACK
} from "../types2/types"

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
            ...action.item
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
    publishedFeedbackList: []
  
};


function reducer(state = initialState, action) {
    switch (action.type) {
        case FEEDBACK_CREATED:
            return {
                ...state,
                feedbackList: addFeedback(state, action),
            };
        case FEEDBACK_PUBLISHED:
            return {
                ...state,
                feedbackList: updateObjectInArray(state.feedbackList, action)
            };
        case LOADED_PUBLISHED_FEEDBACK:                      
            return {
                ...state,
                publishedFeedbackList: action.payload
               
            };
        case LOADED_ALL_FEEDBACK:
            return {
                ...state,
                feedbackList: action.payload

            };
        default:
            return state;
    }
}

export default reducer;