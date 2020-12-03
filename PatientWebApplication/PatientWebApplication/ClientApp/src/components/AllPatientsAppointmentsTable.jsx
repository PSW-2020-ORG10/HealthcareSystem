﻿import React, { Component } from "react"
import { loadedAllPatientAppointments } from "../actions/actions"
import { connect } from "react-redux"
import { wrap } from "module";
import axios from "axios";
import ReferralModal from "./ReferralModal"
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { showErrorToast, checkDateFormat } from "../utilities/Utilities"

class AllPatientsAppointmentsTable extends Component {
    state = {   
        modalShow: false
    };
    componentDidMount() {
        debugger;
        this.props.loadedAllPatientAppointments();
    }

    render() {
        if (this.props.patientAppointmentsList === undefined) {

            return null;
        }
        const patientAppointmentsList = this.props.patientAppointmentsList;
        debugger;
        return (
            <div>
                {this.state.modalShow ? <ReferralModal show={this.state.modalShow} referral={this.state.Referral} date={this.state.Date} onShowChange={this.displayModal.bind(this)} /> : null}
                <table className='table allAppointments' >
                    <thead>
                        <tr>
                            <th style={{ textAlign: "left" }}>Doctor</th>
                            <th style={{ textAlign: "center" }}>Type</th>
                            <th style={{ textAlign: "center" }}>Date</th>
                            <th style={{ textAlign: "center" }}></th>
                        </tr>
                    </thead>
                    {patientAppointmentsList.map((f) => (
                        <tbody key={f}>
                            <tr key={f}>
                                <td style={{ textAlign: "left" }} >{f.doctor.firstName + ' ' + f.doctor.secondName}</td>
                                <td style={{ textAlign: "center" }} > {this.checkType(f)}</td >
                                <td style={{ textAlign: "center" }}>{f.date}</td >
                                <td style={{ textAlign: "right" }}><button onClick={() => { this.displayModal(f) }} className="btn btn-primary">Details</button></td >
                            </tr>
                        </tbody>
                    ))}
                </table>
            </div>
        );
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
}


const mapStateToProps = (state) =>

    ({ patientAppointmentsList: state.reducer.patientAppointmentsList })

export default connect(mapStateToProps, { loadedAllPatientAppointments })(AllPatientsAppointmentsTable);

