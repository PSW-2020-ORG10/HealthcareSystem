import React, { Component } from "react"
import { loadedAllPatientReports, simpleSearchAppointments } from "../actions/actions"
import { connect } from "react-redux"
import { wrap } from "module";
import axios from "axios";
import ReferralModal from "./ReferralModal"
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css'; 
import { showErrorToast, checkDateFormat } from "../utilities/Utilities"

class AppointmentReportSimpleSearchTable extends Component {
    state = {
        Start: "",
        End: "",
        DoctorNameAndSurname: "",
        AppointmentType: "",
        PatientId: 2,
        Referral: null,
        Date: "",
        modalShow: false
    };

    componentDidMount() {
        debugger;
        this.props.loadedAllPatientReports(2);
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
        const patientAppointments = this.props.patientAppointments;
        debugger;
        return (
            <div>
                {this.state.modalShow ? <ReferralModal show={this.state.modalShow} referral={this.state.Referral} date={this.state.Date} onShowChange={this.displayModal.bind(this)} /> : null}
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
                        </tr>
                    </thead>
                    {patientAppointments.map((f) => (
                        <tbody key={f}>
                            <tr key={f}>
                                <td style={{ textAlign: "left" }} >{f.doctorNameAndSurname}</td>
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

    ({ patientAppointments: state.reducer.patientAppointments })

export default connect(mapStateToProps, { loadedAllPatientReports, simpleSearchAppointments })(AppointmentReportSimpleSearchTable);