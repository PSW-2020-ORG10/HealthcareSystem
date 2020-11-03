import {
    FEEDBACK_CREATED,
    FEEDBACK_PUBLISHED
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

const initialState = {
    feedbackList: [],
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
        default:
            return state;
    }
}

export default reducer;