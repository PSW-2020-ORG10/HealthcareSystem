import {
    FEEDBACK_CREATED
} from "../types2/types"

function addFeedback(state=initialState, action) {
    return {
        ...state,
        feedbackList: state.feedbackList.concat(action.payload),
    };
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
        default:
            return state;
    }
}

export default reducer;