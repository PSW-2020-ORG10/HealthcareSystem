import {
    FEEDBACK_CREATED,
    CREATE_ERROR
} from "../types2/types"
import axios from "axios";

export const feedbackCreated = (feedback) => async (dispatch) => {
    alert("dosao");
    console.log(feedback.message);
    try {
        debugger;
        await axios.post("http://localhost:60198/api/feedback/" + feedback);
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