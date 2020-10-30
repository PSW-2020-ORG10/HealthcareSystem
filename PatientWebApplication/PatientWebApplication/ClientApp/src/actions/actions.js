import {
    FEEDBACK_PUBLISHED,
    PUBLISH_ERROR
} from "../types/types"
import axios from "axios";

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