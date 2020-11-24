import React, { Component } from "react"
import { loadedAllPatientReports, simpleSearchAppointments } from "../actions/actions"
import { connect } from "react-redux"
import { wrap } from "module";
import axios from "axios";
import ReferralModal from "./ReferralModal"
import { Button } from 'react-bootstrap';

class AppointmentReportSimpleSearchTable extends Component {
    state = {
        Start: "",
        End: "",
        DoctorNameAndSurname: "",
        AppointmentType: "",
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

                        onChange={this.handleChange}
                    />
                     <input
                        className="field field-date field-end"
                        type="text"
                        value={this.state.End}
                        name="End"

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
                    <button className="btn btn-primary" onClick={this.searchAppointments.bind(this)}>Search</button>
                </div>

                <table className='table allPrescriptions' >
                    <thead>
                        <tr>
                            <th style={{ textAlign: "left" }}>Doctor</th>
                            <th style={{ textAlign: "center" }}>Type</th>
                            <th style={{ textAlign: "center" }}>Date</th>
                        </tr>
                    </thead>
                    {patientAppointments.map((f) => (
                        <tbody key={f.id, f.operationReferral}>
                            <tr key={f.id, f.operationReferral}>
                                <td style={{ textAlign: "left" }} >{f.doctor.firstName + " " + f.doctor.secondName}</td>
                                <td style={{ textAlign: "center" }} > {this.checkType(f)}</td >
                                <td style={{ textAlign: "center" }}>{f.date}</td >
                            </tr>
                        </tbody>
                    ))}
                </table>

            </div>


        );
        
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
        console.log(this.state);
        this.props.simpleSearchAppointments(this.state)
    }

}


const mapStateToProps = (state) =>

    ({ patientAppointments: state.reducer.patientAppointments })

export default connect(mapStateToProps, { loadedAllPatientReports, simpleSearchAppointments })(AppointmentReportSimpleSearchTable);