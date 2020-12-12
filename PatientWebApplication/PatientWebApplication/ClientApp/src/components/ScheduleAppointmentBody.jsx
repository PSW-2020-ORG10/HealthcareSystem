import React, { Component } from "react"
import { connect } from "react-redux"
import { wrap } from "module";
import axios from "axios";
import ScheduleRegularAppointmentModal from './ScheduleRegularAppointmentModal';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { showErrorToast, checkDateFormat } from "../utilities/Utilities"

class ScheduleAppointmentBody extends Component {
    state = {
        modalShow: false
    };

    componentDidMount() {
        debugger;
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
        debugger;
        return (
            <div>
                {this.state.modalShow ? <ScheduleRegularAppointmentModal show={this.state.modalShow} onShowChange={this.displayModal.bind(this)} /> : null}
                <button onClick={() => { this.displayModal() }} className="btn-primary btn-lg">Schedule regular appointment</button>
            </div>


        );

    }

    displayModal() {
        debugger;
        console.log()
        this.setState({ modalShow: !this.state.modalShow })
    }
}


const mapStateToProps = (state) =>

    ({})

export default connect(mapStateToProps)(ScheduleAppointmentBody);