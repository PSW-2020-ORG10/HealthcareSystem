import React, { Component } from "react"
import { connect } from "react-redux"
import axios from "axios";
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { showErrorToast, checkDateFormat } from "../utilities/Utilities"
import DatePicker from 'react-datepicker'
import "react-datepicker/dist/react-datepicker.css";
import { loadedAllAvailableAppointments } from "../actions/actions"
import { formatDate } from "../utilities/Utilities"

class SelectAppointmentForm extends Component {
    state = {
        appointment: null,
        bgColor: 'white',
        timesDisabled: 0
    };

    componentDidMount() {
        debugger;
        this.props.loadedAllAvailableAppointments({
            "Date": "03/03/2020",
            "DoctorId": "2",
            "PatientId": "2"
        });
    }

    handleChange = (f) => {
        debugger;
        console.log(f)
        this.setState({
            appointment: f,
            bgColor: "lightBlue",
            timesDisabled: 1
        })
        this.props.handleAppointmentChange(f)
    }

    render() {
        if (this.props.step !== 3) {
            return null
        }
        if (this.state.timesDisabled == 0) this.props.disableSchedule();
        debugger;
        return (
            <div style={{ marginTop: "40px" }}>
                <table className='table allAppointments' >
                    <thead>
                        <tr>
                            <th style={{ textAlign: "left" }}>Start Time</th>
                            <th style={{ textAlign: "center" }}>Date</th>
                            <th style={{ textAlign: "right" }}>Room</th>
                        </tr>
                    </thead>
                    {this.props.availableAppointments.map((f) => (
                        <tbody key={f.start}>
                            <tr style={this.state.appointment == f ? {backgroundColor : this.state.bgColor} : null } key={f.start} onClick={() => this.handleChange(f)}>
                                <td style={{ textAlign: "left" }} >{f.start}</td>
                                <td style={{ textAlign: "center" }} >{f.date}</td>
                                <td style={{ textAlign: "right" }} > {f.roomId}</td >
                            </tr>
                        </tbody>
                    ))}
                </table>
            </div>
            )
    }
}


const mapStateToProps = (state) => ({ availableAppointments: state.reducer.availableAppointments })

export default connect(mapStateToProps, { loadedAllAvailableAppointments })(SelectAppointmentForm);