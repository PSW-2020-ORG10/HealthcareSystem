import React, { Component } from "react"
import { surveyCreated, loadedAppointmentSurvey } from "../actions/actions"
import { connect } from "react-redux"
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import "../css/app.css"

class CreateSurveyForm extends Component {
    state = {
        patientId: 1,
        doctorId: 1,
        doctorsProfessionalism:0,
        doctorsPoliteness: 0,
        doctorsTechnicality: 0,
        doctorsSkill: 0,
        doctorsKnowledge: 0,
        doctorsWorkingPace: 0,
        medicalStaffsProfessionalism: 0,
        medicalStaffsPoliteness: 0,
        medicalStaffsSkill: 0,
        medicalStaffsKnowledge: 0,
        medicalStaffsWorkingPace: 0,
        medicalStaffsTechnicality: 0,
        hospitalEnvironment: 0,
        hospitalEquipment: 0,
        hospitalHygiene: 0,
        hospitalPrices: 0,
        hospitalWaitingTime: 0
    };

    componentDidMount() {
        debugger;
        this.props.loadedAppointmentSurvey();
    }

    handleChange = (event) => {
        const { name, value, type, checked } = event.target
        type === "checkbox" ? this.setState({
            [name]: checked
        }) : this.setState({
            [name]: value
        })
    }



    render() {

        if (this.props.appointmentSurveyList === undefined) {

            return null;
        }
        const appointmentSurveyList = this.props.appointmentSurveyList;

        return (
            <div>
                <form>
                    <h2 className="label"></h2>
                    <h2 className="label">RATE DOCTORS: </h2>
                    <div className="field-wrap">
                        <label className="label">Doctor: </label>
                        <select className="field"
                            value={this.state.doctorId}
                            onChange={this.handleChange}
                            name="doctorId">
                            {appointmentSurveyList.map(fbb =>
                                <option key={fbb.id} value={fbb.doctorUserId}>{fbb.doctor.firstName + ' ' + fbb.doctor.secondName + ', for appointment on date: ' + fbb.date}</option>
                            )};
                        </select>
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Doctor Professionalism:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.doctorsProfessionalism}
                            name="doctorsProfessionalism"
                            onChange={this.handleChange}
                        />
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Doctor Politeness:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.doctorsPoliteness}
                            name="doctorsPoliteness"
                            onChange={this.handleChange}
                        />
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Doctor Technicality:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.doctorsTechnicality}
                            name="doctorsTechnicality"
                            onChange={this.handleChange}
                        />
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Doctor Skill:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.doctorsSkill}
                            name="doctorsSkill"
                            onChange={this.handleChange}
                        />
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Doctor Knowledge:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.doctorsKnowledge}
                            name="doctorsKnowledge"
                            onChange={this.handleChange}
                        />
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Doctor Working Pace:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.doctorsWorkingPace}
                            name="doctorsWorkingPace"
                            onChange={this.handleChange}
                        />
                    </div>
                    <h2 className="label"></h2>
                    <h2 className="label">RATE OUR WORKING STUFF: </h2>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Medical Staff Politeness:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.medicalStaffsPoliteness}
                            name="medicalStaffsPoliteness"
                            onChange={this.handleChange}
                        />
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Medical Staffs Skill:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.medicalStaffsSkill}
                            name="medicalStaffsSkill"
                            onChange={this.handleChange}
                        />
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Medical Staffs Knowledge:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.medicalStaffsKnowledge}
                            name="medicalStaffsKnowledge"
                            onChange={this.handleChange}
                        />
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                           Medical Staffs Working Pace:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.medicalStaffsWorkingPace}
                            name="medicalStaffsWorkingPace"
                            onChange={this.handleChange}
                        />
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Medical Staffs Technicality:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.medicalStaffsTechnicality}
                            name="medicalStaffsTechnicality"
                            onChange={this.handleChange}
                        />
                    </div>

                    <h2 className="label"></h2>
                    <h2 className="label">RATE OUR HOSPITAL IN GENERAL: </h2>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Hospital Enviroment:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.hospitalEnvironment}
                            name="hospitalEnvironment"
                            onChange={this.handleChange}
                        />
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Hospital Equipment:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.hospitalEquipment}
                            name="hospitalEquipment"
                            onChange={this.handleChange}
                        />
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Hospital Hygiene:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.hospitalHygiene}
                            name="hospitalHygiene"
                            onChange={this.handleChange}
                        />
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Hospital Prices:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.hospitalPrices}
                            name="hospitalPrices"
                            onChange={this.handleChange}
                        />
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Hospital Waiting Time:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.hospitalWaitingTime}
                            name="hospitalWaitingTime"
                            onChange={this.handleChange}
                        />
                    </div>

                    <div className="btn-wrap align-right">
                        <button className="btn btn-primary" onClick={this.createSurvey.bind(this)}>Create</button>
                    </div>
                </form>
            </div>
        )

    }

    createSurvey() {
        toast.configure();

        toast.success("Survey successfully created!", {
            position: toast.POSITION.TOP_RIGHT
        });

        this.props.surveyCreated(this.state)
    }

}

const mapStateToProps = (state) => 
    ({ appointmentSurveyList: state.reducer.appointmentSurveyList })

export default connect(mapStateToProps, { surveyCreated, loadedAppointmentSurvey})(CreateSurveyForm);