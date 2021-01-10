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
    LOADED_ALL_RATES,
    LOADED_ALL_DOCTOR_RATES,
    ADVANCED_SEARCH_PATIENT_APPOINTMENTS,
    ADVANCED_SEARCH_APPOINTMENTS_ERROR,
    LOADED_ALL_PATIENT_APPOINTMENTS,
    OBSERVE_PATIENT_APPOINTMENTS_ERROR,
    LOADED_ALL_PATIENTS,
    OBSERVE_PATIENTS_ERROR,
    LOADED_ALL_DOCTORS,
    OBSERVE_DOCTORS_ERROR,
    RECOMMEND_APPOINTMENT,
    RECOMMEND_APPOINTMENT_ERROR,
    CREATE_RECOMMEND_APPOINTMENT,
    CREATE_RECOMMEND_APPOINTMENT_ERROR,
    LOADED_ALL_AVAILABLE_DOCTORS,
    LOADED_ALL_AVAILABLE_DOCTORS_ERROR,
    LOADED_ALL_AVAILABLE_APPOINTMENTS,
    LOADED_ALL_AVAILABLE_APPOINTMENTS_ERROR,
    APPOINTMENT_SCHEDULED,
    APPOINTMENT_SCHEDULED_ERROR,
    LOADED_ALL_PATIENT_APPOINTMENTS_INTWODAYS,
    LOADED_ALL_PATIENT_APPOINTMENTS_INFUTURE,
    CANCEL_APPOINTMENT,
    BLOCK_PATIENT,
    OBSERVE_BLOCK_PATIENT_ERROR,
    LOADED_ALL_PATIENT_APPOINTMENTS_WITH_SURVEYS,
    LOADED_ALL_PATIENT_APPOINTMENTS_WITHOUT_SURVEYS,
    LOADED_MALICIOUS_PATIENTS,
    OBSERVE_MALICIOUS_ERROR,
    LOADED_IMAGE,
    LOADED_IMAGE_ERROR,
    LOADED_ALL_MESSAGES,
    LOADED_SECOND_IMAGE,
    LOADED_THIRD_IMAGE,
    USER_LOGGEDIN,
    USER_LOGGEDIN_ERROR
} from "../types/types"
import axios from "axios";
import { func } from "prop-types";

export const feedbackCreated = (feedback) => async (dispatch) => {
    console.log(feedback.message);
    try {
        debugger;
        feedback.patientId = localStorage.getItem('patientId');
        await axios.post("http://localhost:54689/api/feedback", feedback,
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          }); 
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
        debugger
        const response = await axios.put("http://localhost:54689/api/feedback/" + id, {}, {
                headers: { "Access-Control-Allow-Origin": "*",
                "Authorization": "Bearer " + localStorage.getItem('token')}
              }); 
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
        const response = await axios.get("http://localhost:54689/api/feedback/published",
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          }); 
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
        const response = await axios.get("http://localhost:54689/api/feedback",
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          }); 
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
        const response = await axios.get("http://localhost:54689/api/prescription",
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          }); 
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
        var id = localStorage.getItem("patientId")
        const response = await axios.get("http://localhost:54689/api/prescription/patient/" + id,
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          }); 
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
        await axios.post("http://localhost:54689/api/patientuser", patient,
        {
            headers: { "Access-Control-Allow-Origin": "*" },
          });
        debugger;
        dispatch({
            type: PATIENT_REGISTERED,
            payload: patient,
        });
        return true;
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
        prescription.patientId = localStorage.getItem("patientId");
        const response = await axios.post("http://localhost:54689/api/prescription/search", prescription,
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          }); 
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
        var id = localStorage.getItem("patientId")
        await axios.get("http://localhost:54689/api/patientuser/getOne/" + id,
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          }) 
        .then(function (response) {
            dispatch({
                type: FIND_ONE_PATIENT,
                payload: response.data,
            });
            axios.get("http://localhost:53236/api/patientuser/getimage/" + response.data.file,
            {
                headers: { "Access-Control-Allow-Origin": "*",
                           "Authorization" :  "Bearer " + localStorage.getItem("token")}
              })
            .then(function(response2){
                dispatch({
                    type: LOADED_IMAGE,
                    payload: response2.data.fileContents,
                });
            })
        })
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
        prescription.patientId = localStorage.getItem("patientId")
        debugger;
        const response = await axios.post("http://localhost:54689/api/prescription/advancedsearch", prescription,
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          }); 
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
    patientId = localStorage.getItem("patientId");
    try {
        axios.all(  [axios.get('http://localhost:54689/api/doctorappointment/' + patientId,
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          }),
                     axios.get('http://localhost:54689/api/operation/' + patientId,
                     {
                        headers: { "Access-Control-Allow-Origin": "*",
                                   "Authorization" :  "Bearer " + localStorage.getItem("token")}
                      })])
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
    debugger;
    searchDto.patientId = localStorage.getItem("patientId");
    try {
        axios.all([axios.post('http://localhost:54689/api/appointmentSearch/search', searchDto,
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          }),
            axios.post('http://localhost:54689/api/operation/search',  searchDto,
            {
                headers: { "Access-Control-Allow-Origin": "*",
                           "Authorization" :  "Bearer " + localStorage.getItem("token")}
              })])
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
        const response = await axios.get("http://localhost:54689/api/survey",
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          });
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
    survey.patientId = localStorage.getItem("patientId");
    try {
        debugger;
        await axios.post("http://localhost:54689/api/survey", survey,
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          });
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
        appointment.patientId = localStorage.getItem("patientId")
        const response = await axios.post("http://localhost:54689/api/appointmentsearch/advancedsearch", appointment,
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          });
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
        const response = await axios.get("http://localhost:54689/api/doctorappointment/patient",
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          });
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

export const loadedAllRates = () => async (dispatch) => {
    try {
        debugger;
        const response = await axios.get("http://localhost:54689/api/survey/getRates",
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          });
        debugger;
        dispatch({
            type: LOADED_ALL_RATES,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: OBSERVE_ERROR,
            payload: console.log(e),
        });
    }
};

export const loadedAllDoctorRates = () => async (dispatch) => {
    try {
        debugger;
        const response = await axios.get("http://localhost:54689/api/survey/getDoctorRates",
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          });
        debugger;
        dispatch({
            type: LOADED_ALL_DOCTOR_RATES,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: OBSERVE_ERROR,
            payload: console.log(e),
        });
    }
};

export const loadedAllAvailableDoctors = (specialty, date, patientId) => async (dispatch) => {
    try {
        debugger;
        const response = await axios.get("http://localhost:54689/api/doctor/available?specialty=" + specialty+ "&date=" + date + "&patientId=" + patientId,
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          });
        debugger;
        dispatch({
            type: LOADED_ALL_AVAILABLE_DOCTORS,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: LOADED_ALL_AVAILABLE_DOCTORS_ERROR,
            payload: console.log(e),
        });
    }
};

export const loadedAllPatientAppointmentsInTwoDays = () => async (dispatch) => {
    try {
        debugger;
        var id = localStorage.getItem("patientId")
        const response = await axios.get("http://localhost:54689/api/doctorappointment/patientInTwoDays/" + id,
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          });
        debugger;
        dispatch({
            type: LOADED_ALL_PATIENT_APPOINTMENTS_INTWODAYS,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: OBSERVE_PATIENT_APPOINTMENTS_ERROR,
            payload: console.log(e),
        });
    }
};

export const loadedAllAvailableAppointments = (dto) => async (dispatch) => {
    try {
        debugger;
        dto.patientId = localStorage.getItem("patientId")
        const response = await axios.post("http://localhost:54689/api/doctorappointment/availableappointments", dto,
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          });
        debugger;
        dispatch({
            type: LOADED_ALL_AVAILABLE_APPOINTMENTS,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: LOADED_ALL_AVAILABLE_APPOINTMENTS_ERROR,
            payload: console.log(e),
        });
    }
};
export const loadedAllPatientAppointmentsInFuture = () => async (dispatch) => {
    try {
        debugger;
        var id = localStorage.getItem("patientId")
        const response = await axios.get("http://localhost:54689/api/doctorappointment/patientInFuture/" + id,
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          });
        debugger;
        dispatch({
            type: LOADED_ALL_PATIENT_APPOINTMENTS_INFUTURE,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: OBSERVE_PATIENT_APPOINTMENTS_ERROR,
            payload: console.log(e),
        });
    }
};

export const appointmentScheduled = (appointment) => async (dispatch) => {
    try {
        debugger;
        appointment.patientUserId = localStorage.getItem("patientId")
        const response = await axios.post("http://localhost:54689/api/doctorappointment", appointment,
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          });
        debugger;
        dispatch({
            type: APPOINTMENT_SCHEDULED,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: APPOINTMENT_SCHEDULED_ERROR,
            payload: console.log(e),
        });
    }
};

export const cancelAppointment = (appointmentId) => async (dispatch) => {
    try {
        debugger;
        const response = await axios.put("http://localhost:54689/api/doctorappointment/" + appointmentId, {},
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          });
        debugger;
        dispatch({
            type: CANCEL_APPOINTMENT,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: OBSERVE_PATIENT_APPOINTMENTS_ERROR,
            payload: console.log(e),
        });
    }
};

export const loadedAllPatientAppointmentsWithSurvey = () => async (dispatch) => {
    try {
        debugger;
        var id = localStorage.getItem("patientId")
        const response = await axios.get("http://localhost:54689/api/survey/" + id,
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          });
        debugger;
        dispatch({
            type: LOADED_ALL_PATIENT_APPOINTMENTS_WITH_SURVEYS,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: OBSERVE_PATIENT_APPOINTMENTS_ERROR,
            payload: console.log(e),
        });
    }
};

export const loadedAllPatientAppointmentsWithoutSurvey = () => async (dispatch) => {
    try {
        debugger;
        var id = localStorage.getItem("patientId")
        const response = await axios.get("http://localhost:54689/api/survey/getWithSurveys/" + id,
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          });
        debugger;
        dispatch({
            type: LOADED_ALL_PATIENT_APPOINTMENTS_WITHOUT_SURVEYS,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: OBSERVE_PATIENT_APPOINTMENTS_ERROR,
            payload: console.log(e),
        });
    }
};

export const loadedAllDoctors = () => async (dispatch) => {
    try {
        debugger;
        const response = await axios.get("http://localhost:54689/api/doctor",
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          });
        debugger;
        dispatch({
            type: LOADED_ALL_DOCTORS,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: OBSERVE_DOCTORS_ERROR,
            payload: console.log(e),
        });
    }
};

export const recommendAppointment = (appointment) => async (dispatch) => {
    console.log(appointment.start)
    try {
        debugger;
        appointment.patientId = localStorage.getItem("patientId");
        const response = await axios.post("http://localhost:54689/api/doctorappointment/recommend", appointment,
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          });
        debugger;
        dispatch({
            type: RECOMMEND_APPOINTMENT,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: RECOMMEND_APPOINTMENT_ERROR,
            payload: console.log(e),
        });
    }
};

export const createRecommendAppointment = (appointment) => async (dispatch) => {
    console.log(appointment.start)
    try {
        debugger;
        appointment.patientUserId = localStorage.getItem("patientId");
        const response = await axios.post("http://localhost:54689/api/doctorappointment", appointment,
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          });
        debugger;
        dispatch({
            type: CREATE_RECOMMEND_APPOINTMENT,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: CREATE_RECOMMEND_APPOINTMENT_ERROR,
            payload: console.log(e),
        });
    }
};


export const loadedAllPatients = () => async (dispatch) => {
    try {
        debugger;
        const response = await axios.get("http://localhost:54689/api/patientuser",
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          });
        debugger;
        dispatch({
            type: LOADED_ALL_PATIENTS,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: OBSERVE_PATIENTS_ERROR,
            payload: console.log(e),
        });
    }
};

export const blockPatient = (patientId) => async (dispatch) => {
    try {
        debugger;
        const response = await axios.put("http://localhost:54689/api/patientuser/" + patientId, {},
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          });
        debugger;
        dispatch({
            type: BLOCK_PATIENT,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: OBSERVE_BLOCK_PATIENT_ERROR,
            payload: console.log(e),
        });
    }
};

export const loadedMaliciousPatients = () => async (dispatch) => {
    try {
        debugger;
        const response = await axios.get("http://localhost:54689/api/patientuser/malicious",
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          });
        debugger;
        dispatch({
            type: LOADED_MALICIOUS_PATIENTS,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: OBSERVE_MALICIOUS_ERROR,
            payload: console.log(e),
        });
    }
};

export const loadedImage = (fileName) => async (dispatch) => {
    try {
        debugger;
        const response = await axios.get("http://localhost:54689/api/patientuser/getimage/" + fileName,
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          });
        debugger;
        dispatch({
            type: LOADED_IMAGE,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: LOADED_IMAGE_ERROR,
            payload: console.log(e),
        });
    }
};

export const loadedImageForAds = (fileName) => async (dispatch) => {
    try {
        const response = await axios.get("http://localhost:54689/api/patientuser/getimage/" + fileName,
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          })
        .then(function(response){
            dispatch({
                type: LOADED_IMAGE,
                payload: response.data.fileContents,
            });
        })
    } catch (e) {
        dispatch({
            type: LOADED_IMAGE_ERROR,
            payload: console.log(e),
        });
    }
};

export const loadedAllMessages = () => async (dispatch) => {
    try {
        debugger;
        const response = await axios.get("http://localhost:53236/api/message",
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          });
        debugger;
        dispatch({
            type: LOADED_ALL_MESSAGES,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: LOADED_IMAGE_ERROR,
            payload: console.log(e),
        });
    }
};

export const loadedImageForSecondAd = (fileName) => async (dispatch) => {
    try {
        const response = await axios.get("http://localhost:54689/api/patientuser/getimage/" + fileName,
        {
            headers: { "Access-Control-Allow-Origin": "*",
            "Authorization" :  "Bearer " + localStorage.getItem("token")}
          })
        .then(function(response){
            dispatch({
                type: LOADED_SECOND_IMAGE,
                payload: response.data.fileContents,
            });
        })
    } catch (e) {
        dispatch({
            type: LOADED_IMAGE_ERROR,
            payload: console.log(e),
        });
    }
};

export const loadedImageForThirdAd = (fileName) => async (dispatch) => {
    try {
        const response = await axios.get("http://localhost:54689/api/patientuser/getimage/" + fileName,
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          })
        .then(function(response){
            dispatch({
                type: LOADED_THIRD_IMAGE,
                payload: response.data.fileContents,
            });
        })
    } catch (e) {
        dispatch({
            type: LOADED_IMAGE_ERROR,
            payload: console.log(e),
        });
    }
};
export const userLoggedIn = (user) => async (dispatch) => {
    try {
        debugger;
        const response = await axios.post("http://localhost:54689/api/login", user,
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + localStorage.getItem("token")}
          });
        debugger;
        var parts = response.data.token.split('.'); // header, payload, signature
        var userInfo = JSON.parse(atob(parts[1]));
        localStorage.setItem("token", response.data.token)
        localStorage.setItem("patientId", userInfo.user_id);
        localStorage.setItem("role", userInfo.role);
        return true;
    } catch (e) {
        console.log(e);
    }
};
