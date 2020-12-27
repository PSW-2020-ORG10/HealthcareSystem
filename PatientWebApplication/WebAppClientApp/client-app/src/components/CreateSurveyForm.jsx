import React, { Component } from "react"
import { surveyCreated, loadedAppointmentSurvey } from "../actions/actions"
import { connect } from "react-redux"
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import "../css/app.css"
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';

class CreateSurveyForm extends Component {
    constructor(props) {
        super(props);

        console.log(this.props)
    }
    state = { 
        
        patientId: 2,
        appointmentId:0,
        doctorsProfessionalism: 1,
        doctorsPoliteness: 1,
        doctorsTechnicality: 1,
        doctorsSkill: 1,
        doctorsKnowledge: 1,
        doctorsWorkingPace: 1,
        medicalStaffsProfessionalism: 1,
        medicalStaffsPoliteness: 1,
        medicalStaffsTechnicality: 1,
        medicalStaffsSkill: 1,
        medicalStaffsKnowledge: 1,
        medicalStaffsWorkingPace: 1,
        hospitalEnvironment: 1,
        hospitalEquipment: 1,
        hospitalHygiene: 1,
        hospitalPrices: 1,
        hospitalWaitingTime: 1,
        modalShow: this.props.show
        
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

   

    handleChange2 = (event) => {
        const { name, value, type, checked } = event.target
        const appointmentSurveyList = this.props.appointmentSurveyList;
        const appointment = appointmentSurveyList.filter(entry => Object.values(entry).some(val => val == value));
        //alert(appointment[0].id)
        type === "checkbox" ? this.setState({
            [name]: checked
        }) : this.setState({
            [name]: value
            //appointmentId: appointment.id
        })
        //alert(this.state.doctorId)
    }


    render() {
        debugger;       
        if (this.props.appointment === undefined) {

            return null;
        }
        if (this.props.appointmentSurveyList === undefined) {

            return null;
        }
        const appointmentSurveyList = this.props.appointmentSurveyList;

        return (
                <Modal isOpen={this.state.modalShow} centered={true}>
                <ModalHeader toggle={this.toggle.bind(this)}> </ModalHeader>
                    <ModalBody>

                    <input
                        className="field"
                        type="text"
                        defaultValue={this.state.appointmentId = this.props.appointment.id}
                        name={this.state.appointmentId}
                        hidden={true}
                    />
                    <input
                        className="field"
                        type="text"
                        defaultValue={this.state.patientId = this.props.appointment.patientUserId}
                        name={this.state.patientId}
                        hidden={true}
                    />   
                
                                <h2 className="label"></h2>
                                <h2 className="label">RATE DOCTORS: </h2>
                                <div className="field-wrap">
                                <label className="label">Doctor: {this.props.appointment.doctor.firstName + ' ' + this.props.appointment.doctor.secondName} </label>
                                

                                </div>    

                    


                                <div className="field-wrap">
                                    <label className="label" htmlFor="">
                                        Doctor Professionalism:
                                    </label>
                                    <label>
                                        1
                                        <input type="radio"
                                            value="1"
                                            name="doctorsProfessionalism"
                                            checked={this.state.doctorsProfessionalism == 1}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        2
                                        <input type="radio"
                                            value="2"
                                            name="doctorsProfessionalism"
                                            checked={this.state.doctorsProfessionalism == 2}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        3
                                        <input type="radio"
                                            value="3"
                                            name="doctorsProfessionalism"
                                            checked={this.state.doctorsProfessionalism == 3}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        4
                                        <input type="radio"
                                            value="4"
                                            name="doctorsProfessionalism"
                                            checked={this.state.doctorsProfessionalism == 4}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        5
                                        <input type="radio"
                                            value="5"
                                            name="doctorsProfessionalism"
                                            checked={this.state.doctorsProfessionalism == 5}
                                            onChange={this.handleChange} />
                                    </label>
                                </div>

                                <div className="field-wrap">
                                    <label className="label" htmlFor="">
                                        Doctor Politeness:
                                    </label>
                                    <label>
                                        1
                                        <input type="radio"
                                            value="1"
                                            name="doctorsPoliteness"
                                            checked={this.state.doctorsPoliteness == 1}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        2
                                        <input type="radio"
                                            value="2"
                                            name="doctorsPoliteness"
                                            checked={this.state.doctorsPoliteness == 2}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        3
                                        <input type="radio"
                                            value="3"
                                            name="doctorsPoliteness"
                                            checked={this.state.doctorsPoliteness == 3}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        4
                                        <input type="radio"
                                            value="4"
                                            name="doctorsPoliteness"
                                            checked={this.state.doctorsPoliteness == 4}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        5
                                        <input type="radio"
                                            value="5"
                                            name="doctorsPoliteness"
                                            checked={this.state.doctorsPoliteness == 5}
                                            onChange={this.handleChange} />
                                    </label>
                                </div>

                                <div className="field-wrap">
                                    <label className="label" htmlFor="">
                                        Doctor Technicality:
                                    </label>
                                    <label>
                                        1
                                        <input type="radio"
                                            value="1"
                                            name="doctorsTechnicality"
                                            checked={this.state.doctorsTechnicality == 1}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        2
                                        <input type="radio"
                                            value="2"
                                            name="doctorsTechnicality"
                                            checked={this.state.doctorsTechnicality == 2}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        3
                                        <input type="radio"
                                            value="3"
                                            name="doctorsTechnicality"
                                            checked={this.state.doctorsTechnicality == 3}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        4
                                        <input type="radio"
                                            value="4"
                                            name="doctorsTechnicality"
                                            checked={this.state.doctorsTechnicality == 4}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        5
                                        <input type="radio"
                                            value="5"
                                            name="doctorsTechnicality"
                                            checked={this.state.doctorsTechnicality == 5}
                                            onChange={this.handleChange} />
                                    </label>
                                </div>

                                <div className="field-wrap">
                                    <label className="label" htmlFor="">
                                        Doctor Skill:
                                    </label>
                                    <label>
                                        1
                                        <input type="radio"
                                            value="1"
                                            name="doctorsSkill"
                                            checked={this.state.doctorsSkill == 1}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        2
                                        <input type="radio"
                                            value="2"
                                            name="doctorsSkill"
                                            checked={this.state.doctorsSkill == 2}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        3
                                        <input type="radio"
                                            value="3"
                                            name="doctorsSkill"
                                            checked={this.state.doctorsSkill == 3}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        4
                                        <input type="radio"
                                            value="4"
                                            name="doctorsSkill"
                                            checked={this.state.doctorsSkill == 4}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        5
                                        <input type="radio"
                                            value="5"
                                            name="doctorsSkill"
                                            checked={this.state.doctorsSkill == 5}
                                            onChange={this.handleChange} />
                                    </label>
                                </div>

                                      








                                <div className="field-wrap">
                                    <label className="label" htmlFor="">
                                        Doctor Knowledge:
                                    </label>
                                    <label>
                                        1
                                        <input type="radio"
                                            value="1"
                                            name="doctorsKnowledge"
                                            checked={this.state.doctorsKnowledge == 1}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        2
                                        <input type="radio"
                                            value="2"
                                            name="doctorsKnowledge"
                                            checked={this.state.doctorsKnowledge == 2}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        3
                                        <input type="radio"
                                            value="3"
                                            name="doctorsKnowledge"
                                            checked={this.state.doctorsKnowledge == 3}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        4
                                        <input type="radio"
                                            value="4"
                                            name="doctorsKnowledge"
                                            checked={this.state.doctorsKnowledge == 4}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        5
                                        <input type="radio"
                                            value="5"
                                            name="doctorsKnowledge"
                                            checked={this.state.doctorsKnowledge == 5}
                                            onChange={this.handleChange} />
                                    </label>
                                </div>






                                <div className="field-wrap">
                                    <label className="label" htmlFor="">
                                        Doctor Working Pace:
                                    </label>
                                    <label>
                                        1
                                        <input type="radio"
                                            value="1"
                                            name="doctorsWorkingPace"
                                            checked={this.state.doctorsWorkingPace == 1}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        2
                                        <input type="radio"
                                            value="2"
                                            name="doctorsWorkingPace"
                                            checked={this.state.doctorsWorkingPace == 2}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        3
                                        <input type="radio"
                                            value="3"
                                            name="doctorsWorkingPace"
                                            checked={this.state.doctorsWorkingPace == 3}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        4
                                        <input type="radio"
                                            value="4"
                                            name="doctorsWorkingPace"
                                            checked={this.state.doctorsWorkingPace == 4}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        5
                                        <input type="radio"
                                            value="5"
                                            name="doctorsWorkingPace"
                                            checked={this.state.doctorsWorkingPace == 5}
                                            onChange={this.handleChange} />
                                    </label>
                                </div>

                   
                                <h2 className="label"></h2>
                                <h2 className="label">RATE OUR WORKING STAFF: </h2>



                                <div className="field-wrap">
                                    <label className="label" htmlFor="">
                                        Medical Staffs Professionalism:
                                    </label>
                                    <label>
                                        1
                                        <input type="radio"
                                            value="1"
                                            name="medicalStaffsProfessionalism"
                                            checked={this.state.medicalStaffsProfessionalism == 1}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        2
                                        <input type="radio"
                                            value="2"
                                            name="medicalStaffsProfessionalism"
                                            checked={this.state.medicalStaffsProfessionalism == 2}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        3
                                        <input type="radio"
                                            value="3"
                                            name="medicalStaffsProfessionalism"
                                            checked={this.state.medicalStaffsProfessionalism == 3}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        4
                                        <input type="radio"
                                            value="4"
                                            name="medicalStaffsProfessionalism"
                                            checked={this.state.medicalStaffsProfessionalism == 4}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        5
                                        <input type="radio"
                                            value="5"
                                            name="medicalStaffsProfessionalism"
                                            checked={this.state.medicalStaffsProfessionalism == 5}
                                            onChange={this.handleChange} />
                                    </label>
                                </div>

                                <div className="field-wrap">
                                    <label className="label" htmlFor="">
                                        Medical Staff Politeness:
                                    </label>
                                    <label>
                                        1
                                        <input type="radio"
                                            value="1"
                                            name="medicalStaffsPoliteness"
                                            checked={this.state.medicalStaffsPoliteness == 1}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        2
                                        <input type="radio"
                                            value="2"
                                            name="medicalStaffsPoliteness"
                                            checked={this.state.medicalStaffsPoliteness == 2}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        3
                                        <input type="radio"
                                            value="3"
                                            name="medicalStaffsPoliteness"
                                            checked={this.state.medicalStaffsPoliteness == 3}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        4
                                        <input type="radio"
                                            value="4"
                                            name="medicalStaffsPoliteness"
                                            checked={this.state.medicalStaffsPoliteness == 4}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        5
                                        <input type="radio"
                                            value="5"
                                            name="medicalStaffsPoliteness"
                                            checked={this.state.medicalStaffsPoliteness == 5}
                                            onChange={this.handleChange} />
                                    </label>
                                </div>

                                <div className="field-wrap">
                                    <label className="label" htmlFor="">
                                        Medical Staffs Technicality:
                                    </label>
                                    <label>
                                        1
                                        <input type="radio"
                                            value="1"
                                            name="medicalStaffsTechnicality"
                                            checked={this.state.medicalStaffsTechnicality == 1}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        2
                                        <input type="radio"
                                            value="2"
                                            name="medicalStaffsTechnicality"
                                            checked={this.state.medicalStaffsTechnicality == 2}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        3
                                        <input type="radio"
                                            value="3"
                                            name="medicalStaffsTechnicality"
                                            checked={this.state.medicalStaffsTechnicality == 3}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        4
                                        <input type="radio"
                                            value="4"
                                            name="medicalStaffsTechnicality"
                                            checked={this.state.medicalStaffsTechnicality == 4}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        5
                                        <input type="radio"
                                            value="5"
                                            name="medicalStaffsTechnicality"
                                            checked={this.state.medicalStaffsTechnicality == 5}
                                            onChange={this.handleChange} />
                                    </label>
                                </div>



                                <div className="field-wrap">
                                    <label className="label" htmlFor="">
                                        Medical Staffs Skill:
                                    </label>
                                    <label>
                                        1
                                        <input type="radio"
                                            value="1"
                                            name="medicalStaffsSkill"
                                            checked={this.state.medicalStaffsSkill == 1}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        2
                                        <input type="radio"
                                            value="2"
                                            name="medicalStaffsSkill"
                                            checked={this.state.medicalStaffsSkill == 2}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        3
                                        <input type="radio"
                                            value="3"
                                            name="medicalStaffsSkill"
                                            checked={this.state.medicalStaffsSkill == 3}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        4
                                        <input type="radio"
                                            value="4"
                                            name="medicalStaffsSkill"
                                            checked={this.state.medicalStaffsSkill == 4}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        5
                                        <input type="radio"
                                            value="5"
                                            name="medicalStaffsSkill"
                                            checked={this.state.medicalStaffsSkill == 5}
                                            onChange={this.handleChange} />
                                    </label>
                                </div>


                   

                                <div className="field-wrap">
                                    <label className="label" htmlFor="">
                                        Medical Staffs Knowledge:
                                    </label>
                                    <label>
                                        1
                                        <input type="radio"
                                            value="1"
                                            name="medicalStaffsKnowledge"
                                            checked={this.state.medicalStaffsKnowledge == 1}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        2
                                        <input type="radio"
                                            value="2"
                                            name="medicalStaffsKnowledge"
                                            checked={this.state.medicalStaffsKnowledge == 2}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        3
                                        <input type="radio"
                                            value="3"
                                            name="medicalStaffsKnowledge"
                                            checked={this.state.medicalStaffsKnowledge == 3}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        4
                                        <input type="radio"
                                            value="4"
                                            name="medicalStaffsKnowledge"
                                            checked={this.state.medicalStaffsKnowledge == 4}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        5
                                        <input type="radio"
                                            value="5"
                                            name="medicalStaffsKnowledge"
                                            checked={this.state.medicalStaffsKnowledge == 5}
                                            onChange={this.handleChange} />
                                    </label>
                                </div>

                   


                                <div className="field-wrap">
                                    <label className="label" htmlFor="">
                                        Medical Staffs Working Pace:
                                    </label>
                                    <label>
                                        1
                                        <input type="radio"
                                            value="1"
                                            name="medicalStaffsWorkingPace"
                                            checked={this.state.medicalStaffsWorkingPace == 1}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        2
                                        <input type="radio"
                                            value="2"
                                            name="medicalStaffsWorkingPace"
                                            checked={this.state.medicalStaffsWorkingPace == 2}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        3
                                        <input type="radio"
                                            value="3"
                                            name="medicalStaffsWorkingPace"
                                            checked={this.state.medicalStaffsWorkingPace == 3}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        4
                                        <input type="radio"
                                            value="4"
                                            name="medicalStaffsWorkingPace"
                                            checked={this.state.medicalStaffsWorkingPace == 4}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        5
                                        <input type="radio"
                                            value="5"
                                            name="medicalStaffsWorkingPace"
                                            checked={this.state.medicalStaffsWorkingPace == 5}
                                            onChange={this.handleChange} />
                                    </label>
                                </div>


                   

                    
                   

                                <h2 className="label"></h2>
                                <h2 className="label">RATE OUR HOSPITAL IN GENERAL: </h2>


                                <div className="field-wrap">
                                    <label className="label" htmlFor="">
                                        Hospital Enviroment:
                                    </label>
                                    <label>
                                        1
                                        <input type="radio"
                                            value="1"
                                            name="hospitalEnvironment"
                                            checked={this.state.hospitalEnvironment == 1}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        2
                                        <input type="radio"
                                            value="2"
                                            name="hospitalEnvironment"
                                            checked={this.state.hospitalEnvironment == 2}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        3
                                        <input type="radio"
                                            value="3"
                                            name="hospitalEnvironment"
                                            checked={this.state.hospitalEnvironment == 3}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        4
                                        <input type="radio"
                                            value="4"
                                            name="hospitalEnvironment"
                                            checked={this.state.hospitalEnvironment == 4}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        5
                                        <input type="radio"
                                            value="5"
                                            name="hospitalEnvironment"
                                            checked={this.state.hospitalEnvironment == 5}
                                            onChange={this.handleChange} />
                                    </label>
                                </div>


                   

                                <div className="field-wrap">
                                    <label className="label" htmlFor="">
                                        Hospital Equipment:
                                    </label>
                                    <label>
                                        1
                                        <input type="radio"
                                            value="1"
                                            name="hospitalEquipment"
                                            checked={this.state.hospitalEquipment == 1}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        2
                                        <input type="radio"
                                            value="2"
                                            name="hospitalEquipment"
                                            checked={this.state.hospitalEquipment == 2}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        3
                                        <input type="radio"
                                            value="3"
                                            name="hospitalEquipment"
                                            checked={this.state.hospitalEquipment == 3}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        4
                                        <input type="radio"
                                            value="4"
                                            name="hospitalEquipment"
                                            checked={this.state.hospitalEquipment == 4}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        5
                                        <input type="radio"
                                            value="5"
                                            name="hospitalEquipment"
                                            checked={this.state.hospitalEquipment == 5}
                                            onChange={this.handleChange} />
                                    </label>
                                </div>

                    

                                <div className="field-wrap">
                                    <label className="label" htmlFor="">
                                        Hospital Hygiene:
                                    </label>
                                    <label>
                                        1
                                        <input type="radio"
                                            value="1"
                                            name="hospitalHygiene"
                                            checked={this.state.hospitalHygiene == 1}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        2
                                        <input type="radio"
                                            value="2"
                                            name="hospitalHygiene"
                                            checked={this.state.hospitalHygiene == 2}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        3
                                        <input type="radio"
                                            value="3"
                                            name="hospitalHygiene"
                                            checked={this.state.hospitalHygiene == 3}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        4
                                        <input type="radio"
                                            value="4"
                                            name="hospitalHygiene"
                                            checked={this.state.hospitalHygiene == 4}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        5
                                        <input type="radio"
                                            value="5"
                                            name="hospitalHygiene"
                                            checked={this.state.hospitalHygiene == 5}
                                            onChange={this.handleChange} />
                                    </label>
                                </div>

                  


                                <div className="field-wrap">
                                    <label className="label" htmlFor="">
                                        Hospital Prices:
                                    </label>
                                    <label>
                                        1
                                        <input type="radio"
                                            value="1"
                                            name="hospitalPrices"
                                            checked={this.state.hospitalPrices == 1}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        2
                                        <input type="radio"
                                            value="2"
                                            name="hospitalPrices"
                                            checked={this.state.hospitalPrices == 2}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        3
                                        <input type="radio"
                                            value="3"
                                            name="hospitalPrices"
                                            checked={this.state.hospitalPrices == 3}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        4
                                        <input type="radio"
                                            value="4"
                                            name="hospitalPrices"
                                            checked={this.state.hospitalPrices == 4}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        5
                                        <input type="radio"
                                            value="5"
                                            name="hospitalPrices"
                                            checked={this.state.hospitalPrices == 5}
                                            onChange={this.handleChange} />
                                    </label>
                                </div>


                   

                                <div className="field-wrap">
                                    <label className="label" htmlFor="">
                                        How long did u wait:
                                    </label>
                                    <label>
                                        1
                                        <input type="radio"
                                            value="1"
                                            name="hospitalWaitingTime"
                                            checked={this.state.hospitalWaitingTime == 1}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        2
                                        <input type="radio"
                                            value="2"
                                            name="hospitalWaitingTime"
                                            checked={this.state.hospitalWaitingTime == 2}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        3
                                        <input type="radio"
                                            value="3"
                                            name="hospitalWaitingTime"
                                            checked={this.state.hospitalWaitingTime == 3}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        4
                                        <input type="radio"
                                            value="4"
                                            name="hospitalWaitingTime"
                                            checked={this.state.hospitalWaitingTime == 4}
                                            onChange={this.handleChange} />
                                    </label>
                                    <label>
                                        5
                                        <input type="radio"
                                            value="5"
                                            name="hospitalWaitingTime"
                                            checked={this.state.hospitalWaitingTime == 5}
                                            onChange={this.handleChange} />
                                    </label>
                                </div>
                    </ModalBody>
                    
                    <ModalFooter>
                                <div className="btn-wrap align-right">
                                    <button disabled={this.state.appointmentId==0} className="btn btn-primary" onClick={this.createSurvey.bind(this)}>Create</button>
                                </div>
                    </ModalFooter>
                
                            
                </Modal>
        )

    }
    toggle() {
        this.setState({ modalShow: false });
        this.props.onShowChange();
    }
    createSurvey() {
        toast.configure();

        toast.success("Survey successfully created!", {
            position: toast.POSITION.TOP_RIGHT
        });
        
        
        this.setState({ modalShow: false });
        this.props.onShowChange();
        this.props.surveyCreated({ patientId: this.state.patientId, appointmentId: this.state.appointmentId, doctorsProfessionalism: this.state.doctorsProfessionalism, doctorsPoliteness: this.state.doctorsPoliteness, doctorsTechnicality: this.state.doctorsTechnicality, doctorsSkill: this.state.doctorsSkill, doctorsKnowledge: this.state.doctorsKnowledge, doctorsWorkingPace: this.state.doctorsWorkingPace, medicalStaffsProfessionalism: this.state.medicalStaffsProfessionalism, medicalStaffsPoliteness: this.state.medicalStaffsPoliteness, medicalStaffsTechnicality: this.state.medicalStaffsTechnicality, medicalStaffsSkill: this.state.medicalStaffsSkill, medicalStaffsKnowledge: this.state.medicalStaffsKnowledge, medicalStaffsWorkingPace: this.state.medicalStaffsWorkingPace, hospitalEnvironment: this.state.hospitalEnvironment, hospitalEquipment: this.state.hospitalEquipment, hospitalHygiene: this.state.hospitalHygiene, hospitalPrices: this.state.hospitalPrices, hospitalWaitingTime: this.state.hospitalWaitingTime })     
        window.location.href = "http://localhost:60198/my-appointments";
    }

}

const mapStateToProps = (state) => 
    ({ appointmentSurveyList: state.reducer.appointmentSurveyList })

export default connect(mapStateToProps, { surveyCreated, loadedAppointmentSurvey})(CreateSurveyForm);