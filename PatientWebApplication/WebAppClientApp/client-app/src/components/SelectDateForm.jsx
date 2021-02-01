import React, { Component } from "react"
import { loadedAllPatientReports, simpleSearchAppointments } from "../actions/actions"
import { connect } from "react-redux"
import axios from "axios";
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { showErrorToast, checkDateFormat } from "../utilities/Utilities"
import DatePicker from 'react-datepicker'
import "react-datepicker/dist/react-datepicker.css";

class SelectDateForm extends Component {
    state = {
        date: new Date()  
    };

    componentDidMount() {
        debugger;
    }

    handleChange = (event) => {
        debugger;
        console.log(event)
        this.setState({
            date: event
        })
        this.props.handleDateChange(event)
    }

    render() {
        if (this.props.step !== 0) {
            return null
        }
        return (
            <div style={{ marginTop: "40px" }}>
                <label className="label">Date: </label>
                <DatePicker
                    id="datepickerInput"
                    name="date"
                    dateFormat="dd/MM/yyyy"
                    selected={this.state.date}
                    minDate={new Date()}
                    onChange={this.handleChange.bind(this)}
                />
            </div>
            )
    }
}


const mapStateToProps = (state) =>

    ({  })

export default connect(mapStateToProps)(SelectDateForm);