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
        startDate: new Date()
    };

    componentDidMount() {
        debugger;
    }

    handleChange = (event) => {
        debugger;
        console.log(event)
        this.setState({
            startDate: new Date(event)
        })
        console.log(this.state)
    }

    render() {
        if (this.props.step !== 1) {
            return null
        }
        return (
            <div>
                <DatePicker
                    id="datepickerInput"
                    name="date"
                    dateFormat="dd/MM/yyyy"
                    selected={this.state.startDate}
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