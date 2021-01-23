import React, { Component } from "react"
import { loadedAllPatientReports, simpleSearchAppointments, loadedAllPatientAppointmentsWithoutSurvey } from "../actions/actions"
import { connect } from "react-redux"
import { wrap } from "module";
import axios from "axios";
import ReferralModal from "./ReferralModal"
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css'; 
import { showErrorToast, checkDateFormat } from "../utilities/Utilities"
import PrescriptionModal from "./PrescriptionModal";
import CreateSurveyForm from "./CreateSurveyForm";

class AppointmentReportSimpleSearchTable extends Component {
    state = {
        Start: "",
        End: "",
        DoctorNameAndSurname: "",
        AppointmentType: "",
        PatientId: 2,
        Referral: null,
        Date: "",
        modalShow: false,
        modalPrescriptionShow: false,
        appointmentId: "",
        isOperation: false,
        modalSurveyShow: false,
        appointmentToSend: null
    };

    componentDidMount() {
        debugger;
        this.props.loadedAllPatientReports();
        this.props.loadedAllPatientAppointmentsWithoutSurvey();
    }

    handleChange = (event) => {
        debugger;
        const { name, value, type, checked } = event.target
        type === "checkbox" ? this.setState({
            [name]: checked
        }) : this.setState({
            [name]: value
        })
        console.log(this.state)
    }

    render() {
        if (this.props.appointmentsWithSurvey === undefined) {

            return null;
        }
        const patientAppointments = this.props.patientAppointments;
        debugger;
        return (
            <div>
                {this.state.modalShow ? <ReferralModal show={this.state.modalShow} referral={this.state.Referral} date={this.state.Date} isOperation={this.state.isOperation} onShowChange={this.displayModal.bind(this)} /> : null}
                {this.state.modalPrescriptionShow ? <PrescriptionModal show={this.state.modalPrescriptionShow} date={this.state.Date} appointmentId={this.state.appointmentId} onShowChange={this.displayModalPrescription.bind(this)} /> : null}
                {this.state.modalSurveyShow ? <CreateSurveyForm show={this.state.modalSurveyShow} appointment={this.state.appointmentToSend}  onShowChange={this.fillSurvey.bind(this)} /> : null}
                <div className="field-wrap">
                    <label className="label" htmlFor="">
                        Doctor name and surname:
                        </label>
                    <input
                        className="field"
                        type="text"
                        value={this.state.DoctorNameAndSurname}
                        name="DoctorNameAndSurname"

                        onChange={this.handleChange.bind(this)}
                    />
                </div>

                <div className="field-wrap">
                    <label className="label label-date">From: </label>

                    <input
                        className="field field-date"
                        type="text"
                        value={this.state.Start}
                        name="Start"
                        placeholder="dd/MM/yyyy"
                        onChange={this.handleChange}
                    />
                     <input
                        className="field field-date field-end"
                        type="text"
                        value={this.state.End}
                        name="End"
                        placeholder="dd/MM/yyyy"
                        onChange={this.handleChange}
                    />
                    <label className="label label-date label-end">to: </label>

                </div>

                <div className="field-wrap">
                    <label className="label">Type of appointment: </label>

                    <select
                        className="field"
                        value={this.state.AppointmentType}
                        onChange={this.handleChange}
                        name="AppointmentType"
                    >
                        <option value=""> </option>
                        <option value="Appointment">Appointment </option>
                        <option value="Operation">Operation </option>
                    </select>
                </div>

                <div className="btn-wrap align-right">
                    <button className="btn btn-primary btn-block btn-lg mb-4" onClick={this.searchAppointments.bind(this)}>Search</button>
                </div>

                <br>
                </br>

                <table className='table allPrescriptions' >
                    <thead>
                        <tr>
                            <th style={{ textAlign: "left" }}>Doctor</th>
                            <th style={{ textAlign: "center" }}>Type</th>
                            <th style={{ textAlign: "center" }}>Date</th>
                            <th style={{ textAlign: "center" }}></th>
                            <th style={{ textAlign: "center" }}></th>
                            <th style={{ textAlign: "center" }}></th>
                        </tr>
                    </thead>
                    {patientAppointments.map((f) => (
                        <tbody key={f}>
                            <tr key={f}>
                                <td style={{ textAlign: "left" }} >{f.doctorNameAndSurname}</td>
                                <td style={{ textAlign: "center" }} > {this.checkType(f)}</td >
                                <td style={{ textAlign: "center" }}>{f.date}</td >
                                <td style={{ textAlign: "right" }}><button onClick={() => { this.displayModal(f) }} className="btn btn-primary">Report</button></td >
                                <td style={{ textAlign: "right" }}><button onClick={() => { this.displayModalPrescription(f) }} className="btn btn-primary">Prescription</button></td >
                                <td style={{ textAlign: "right" }}><button disabled={this.checkForSurvey(f)} onClick={() => this.fillSurvey(f)} className="btn btn-primary">Fill Survey</button></td >
                            </tr>
                        </tbody>
                    ))}
                </table>

            </div>


        );
        
    }

    checkForSurvey(f){
        if (typeof f.operationReferral !== 'undefined') {
            return true;
        }
        for (var index = 0; index < this.props.appointmentsWithSurvey.length; ++index) {
            if (f.id === this.props.appointmentsWithSurvey[index].id) return true;
        }
        return false;
    }

    fillSurvey(f) {
        this.setState({ modalSurveyShow: !this.state.modalSurveyShow })
        if (f === undefined) {
            return;
        }  
        this.setState({ appointmentToSend: f})
    }


    displayModalPrescription(f) {
        debugger;
        this.setState({ modalPrescriptionShow: !this.state.modalPrescriptionShow });
        if (f === undefined) {
            return;
        }
        else{
            debugger;
            this.setState({ appointmentId : f.id,  Date: f.date })
        }
        
    }

    displayModal(f) {
        debugger;
        console.log(f)
        this.setState({ modalShow: !this.state.modalShow })
        if (f === undefined) {
            return;
        }
        else if (typeof f.referral !== 'undefined') {
            this.setState({ Referral: f.referral[0], Date: f.date, isOperation: false })
        }
        else if (typeof f.operationReferral !== 'undefined') {
            this.setState({ Referral: f.operationReferral, Date: f.date, isOperation: true })
        }
    }

    checkType(f) {
        console.log(typeof f.operationReferral); 
        let type = typeof f.operationReferral
        console.log(type !== 'undefined');
        if (typeof f.operationReferral !== 'undefined') {
            return "Operation"
        }
        else {
            return "Appointment"
        }
    }

    searchAppointments() {
        debugger;
        if (this.state.Start !== "" && checkDateFormat(this.state.Start)) {
            showErrorToast()
        }
        else if (this.state.End !== "" && checkDateFormat(this.state.End)) {
            showErrorToast()
        }
        this.props.simpleSearchAppointments({ Start: this.state.Start, End: this.state.End, DoctorNameAndSurname: this.state.DoctorNameAndSurname, AppointmentType: this.state.AppointmentType, PatientId: this.state.PatientId })
    }

}


const mapStateToProps = (state) =>

    ({ patientAppointments: state.reducer.patientAppointments, appointmentsWithSurvey: state.reducer.patientAppointmentsWithoutSurveys })

export default connect(mapStateToProps, { loadedAllPatientReports, simpleSearchAppointments, loadedAllPatientAppointmentsWithoutSurvey })(AppointmentReportSimpleSearchTable);