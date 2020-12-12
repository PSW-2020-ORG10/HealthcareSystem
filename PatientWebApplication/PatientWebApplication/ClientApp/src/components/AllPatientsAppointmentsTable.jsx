import React, { Component } from "react"
import { loadedAllPatientAppointmentsWithSurvey, loadedAllPatientAppointmentsWithoutSurvey, loadedAllPatientAppointmentsInTwoDays, loadedAllPatientAppointmentsInFuture, cancelAppointment } from "../actions/actions"
import { connect } from "react-redux"
import { wrap } from "module";
import axios from "axios";
import CancelAppointmentButton from "./CancelAppointmentButton";
import ReferralModal from "./ReferralModal"
import CreateSurveyForm from "./CreateSurveyForm"
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { showErrorToast, checkDateFormat } from "../utilities/Utilities"

class AllPatientsAppointmentsTable extends Component {
    state = {   
        modalShow: false,
        modalSurveyShow: false,
        appointmentToSend: null
    };
    componentDidMount() {
        debugger;
        this.props.loadedAllPatientAppointmentsWithSurvey();
        this.props.loadedAllPatientAppointmentsWithoutSurvey();
        this.props.loadedAllPatientAppointmentsInTwoDays();
        this.props.loadedAllPatientAppointmentsInFuture();
    }

    render() {
        if (this.props.patientAppointmentsWithSurveys === undefined) {

            return null;
        }
        if (this.props.patientAppointmentsWithoutSurveys === undefined) {

            return null;
        }
        if (this.props.patientAppointmentsInTwoDaysList === undefined) {

            return null;
        }
        if (this.props.patientAppointmentsInFutureList === undefined) {

            return null;
        }
        const patientAppointmentsWithSurveys = this.props.patientAppointmentsWithSurveys;
        const patientAppointmentsWithoutSurveys = this.props.patientAppointmentsWithoutSurveys;
        const patientAppointmentsInTwoDaysList = this.props.patientAppointmentsInTwoDaysList;
        const patientAppointmentsInFutureList = this.props.patientAppointmentsInFutureList;
        debugger;
        return (
            <div>
                {this.state.modalShow ? <ReferralModal show={this.state.modalShow} referral={this.state.Referral} date={this.state.Date} onShowChange={this.displayModal.bind(this)} /> : null}
                {this.state.modalSurveyShow ? <CreateSurveyForm show={this.state.modalSurveyShow} appointment={this.state.appointmentToSend}  onShowChange={this.fillSurvey.bind(this)} /> : null}
                <table className='table allAppointments' >
                    <thead>
                        <tr>
                            <th style={{ textAlign: "left" }}>Doctor</th>
                            <th style={{ textAlign: "center" }}>Type</th>
                            <th style={{ textAlign: "center" }}>Date</th>
                            <th style={{ textAlign: "center" }}>Time</th>
                            <th style={{ textAlign: "center" }}></th>
                            <th style={{ textAlign: "center" }}></th>
                        </tr>
                    </thead>
                    {patientAppointmentsWithSurveys.map((f) => (
                        <tbody key={f.id}>
                            <tr key={f.id}>
                                <td style={{ textAlign: "left" }} >{f.doctor.firstName + ' ' + f.doctor.secondName}</td>
                                <td style={{ textAlign: "center" }} > {this.checkType(f)}</td >
                                <td style={{ textAlign: "center" }}>{f.date}</td >
                                <td style={{ textAlign: "center" }}>{f.start}</td >
                                <td style={{ textAlign: "right" }}><button disabled={f.referral.length == 0} onClick={() => { this.displayModal(f) }} className="btn btn-primary">Details</button></td >
                                <td style={{ textAlign: "right" }}><button onClick={() => this.fillSurvey(f)} className="btn btn-primary">Fill Survey</button></td >
                            </tr>
                        </tbody>
                    ))}
                    {patientAppointmentsWithoutSurveys.map((f) => (
                        <tbody key={f.id}>
                            <tr key={f.id}>
                                <td style={{ textAlign: "left" }} >{f.doctor.firstName + ' ' + f.doctor.secondName}</td>
                                <td style={{ textAlign: "center" }} > {this.checkType(f)}</td >
                                <td style={{ textAlign: "center" }}>{f.date}</td >
                                <td style={{ textAlign: "center" }}>{f.start}</td >
                                <td style={{ textAlign: "right" }}><button disabled={f.referral.length == 0} onClick={() => { this.displayModal(f) }} className="btn btn-primary">Details</button></td >
                                <td style={{ textAlign: "right" }}><button disabled={true} className="btn btn-primary">Fill Survey</button></td >
                            </tr>
                        </tbody>
                    ))}
                    {patientAppointmentsInTwoDaysList.map((f) => (
                        <tbody key={f.id}>
                            <tr key={f.id}>
                                <td style={{ textAlign: "left" }} >{f.doctor.firstName + ' ' + f.doctor.secondName}</td>
                                <td style={{ textAlign: "center" }} > {this.checkType(f)}</td >
                                <td style={{ textAlign: "center" }}>{f.date}</td >
                                <td style={{ textAlign: "center" }}>{f.start}</td >
                                <td style={{ textAlign: "right" }}><button disabled={true} className="btn btn-primary">Cancel</button></td >
                                <td style={{ textAlign: "right" }}><button disabled={true} className="btn btn-primary">Fill Survey</button></td >
                            </tr>
                        </tbody>
                    ))}
                    {patientAppointmentsInFutureList.map((f) => (
                        <tbody key={f.id}>
                            <tr key={f.id}>
                                <td style={{ textAlign: "left" }} >{f.doctor.firstName + ' ' + f.doctor.secondName}</td>
                                <td style={{ textAlign: "center" }} > {this.checkType(f)}</td >
                                <td style={{ textAlign: "center" }}>{f.date}</td >
                                <td style={{ textAlign: "center" }}>{f.start}</td >
                                <td style={{ textAlign: "right" }}><CancelAppointmentButton appointment={f}> </CancelAppointmentButton></td >
                                <td style={{ textAlign: "right" }}><button disabled={true} className="btn btn-primary">Fill Survey</button></td >
                            </tr>
                        </tbody>
                    ))}
                </table>
                <div>
                    {this.state.modalSurveyShow ? <CreateSurveyForm show={this.state.modalSurveyShow} appointmentToSend={this.state.appointmentToSend} onShowChange={this.fillSurvey.bind(this)} /> : null}
                </div>
            </div>
        );
    }

    fillSurvey(f) {
        this.setState({ modalSurveyShow: !this.state.modalSurveyShow })
        if (f === undefined) {
            return;
        }  
        this.setState({ appointmentToSend: f})
    }

    displayModal(f) {
        debugger;
        console.log(f)
        this.setState({ modalShow: !this.state.modalShow })
        if (f === undefined) {
            return;
        }
        else if (typeof f.referral !== 'undefined') {
            this.setState({ Referral: f.referral[0], Date: f.date })
        }
        else if (typeof f.operationReferral !== 'undefined') {
            this.setState({ Referral: f.operationReferral, Date: f.date })
        }
    }

    checkType(f) {
        debugger;
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

    cancelApp=(appointment) => {
        toast.configure();

        toast.success("Appointment successfully cancelled!", {
            position: toast.POSITION.TOP_RIGHT
        });

        this.props.cancelAppointment(appointment)
    }
}



const mapStateToProps = (state) =>

    ({ patientAppointmentsWithSurveys: state.reducer.patientAppointmentsWithSurveys, patientAppointmentsWithoutSurveys: state.reducer.patientAppointmentsWithoutSurveys, patientAppointmentsInTwoDaysList: state.reducer.patientAppointmentsInTwoDaysList, patientAppointmentsInFutureList: state.reducer.patientAppointmentsInFutureList })

export default connect(mapStateToProps, { loadedAllPatientAppointmentsWithSurvey, loadedAllPatientAppointmentsWithoutSurvey, loadedAllPatientAppointmentsInTwoDays, loadedAllPatientAppointmentsInFuture, cancelAppointment })(AllPatientsAppointmentsTable);

