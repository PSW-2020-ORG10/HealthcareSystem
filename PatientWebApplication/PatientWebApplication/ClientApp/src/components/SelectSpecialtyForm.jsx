import React, { Component } from "react"
import { loadedAllPatientReports, simpleSearchAppointments } from "../actions/actions"
import { connect } from "react-redux"
import axios from "axios";
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { showErrorToast, checkDateFormat } from "../utilities/Utilities"
import DatePicker from 'react-datepicker'
import "react-datepicker/dist/react-datepicker.css";

class SelectSpecialtyForm extends Component {
    state = {
        specialty: ""
    };

    componentDidMount() {
        debugger;
    }

    handleChange = (event) => {
        debugger;
        console.log(event)
        this.setState({
            specialty: event.target.value
        })
        this.props.handleSpecialtyChange(event)
    }

    render() {
        if (this.props.step !== 1) {
            return null
        }
        return (
            <div style={{ marginTop: "40px" }}>
                <label className="label label-date">Specialty: </label>
                <select className="field" defaultValue={this.state.specialty} onChange={this.handleChange.bind(this)}>
                    <option value=""></option>
                    <option value="Cardiology">Cardiology</option>
                    <option value="Pulmonology">Pulmonology</option>
                    <option value="Neurology">Neurology</option>
                    <option value="Otorhinolaryngology">Otorhinolaryngology</option>
                    <option value="Dermatology">Dermatology</option>
                </select>
            </div>
            )
    }
}


const mapStateToProps = (state) =>

    ({  })

export default connect(mapStateToProps)(SelectSpecialtyForm);