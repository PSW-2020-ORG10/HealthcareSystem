import React, { Component } from "react"
import { connect } from "react-redux"
import axios from "axios";
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { showErrorToast, checkDateFormat } from "../utilities/Utilities"
import DatePicker from 'react-datepicker'
import "react-datepicker/dist/react-datepicker.css";
import { loadedAllAvailableDoctors } from "../actions/actions"
import { formatDate } from "../utilities/Utilities"

class SelectDoctorForm extends Component {
    state = {
        doctor: null,
        bgColor: 'white',
        timesDisabled: 0,
        availableDoctors: this.props.loadedAllAvailableDoctors(this.props.specialty, this.props.date, 2)
    };

    componentDidMount() {
        debugger;
        this.props.loadedAllAvailableDoctors(this.props.specialty, this.props.date, 2);
    }

    handleChange = (f) => {
        debugger;
        console.log(f)
        this.setState({
            doctor: f,
            bgColor: "lightBlue",
            timesDisabled: 1
        })
        this.props.handleDoctorChange(f)
    }

    render() {
        debugger
        if (this.props.step !== 2) {
            return null
        }
        if (this.state.timesDisabled == 0) this.props.disableNext();
        debugger;
        return (
            <div style={{ marginTop: "40px" }}>
                <table className='table allAppointments' >
                    <thead>
                        <tr>
                            <th style={{ textAlign: "left" }}>Name and Surname</th>
                            <th style={{ textAlign: "center" }}>Specialty</th>
                        </tr>
                    </thead>
                    {this.props.availableDoctors.map((f) => (
                        <tbody key={f.id}>
                            <tr style={this.state.doctor == f ? { backgroundColor: this.state.bgColor } : null} key={f.id} onClick={() => this.handleChange(f)}>
                                <td style={{ textAlign: "left" }} >{f.nameAndSurname}</td>
                                <td style={{ textAlign: "center" }} > {f.specialty}</td >
                            </tr>
                        </tbody>
                    ))}
                </table>
            </div>
            )
    }
}


const mapStateToProps = (state) => ({ availableDoctors: state.reducer.availableDoctors })

export default connect(mapStateToProps, { loadedAllAvailableDoctors })(SelectDoctorForm);