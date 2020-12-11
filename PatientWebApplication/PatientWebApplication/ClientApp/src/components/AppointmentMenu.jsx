import React, { Component } from "react"
import { loadedAllPatientReports, simpleSearchAppointments } from "../actions/actions"
import { connect } from "react-redux"
import { wrap } from "module";
import axios from "axios";
import RecommendedAppointmentScheduling from "./RecommendedAppointmentScheduling"
import ScheduleRegularAppointmentModal from './ScheduleRegularAppointmentModal';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { showErrorToast, checkDateFormat } from "../utilities/Utilities"

class AppointmentMenu extends Component {
    state = {
        modalShowRecommended: false,
        modalShow: false
    };

    render() {
        debugger;
        return (
            <div>
                {this.state.modalShowRecommended ? <RecommendedAppointmentScheduling show={this.state.modalShowRecommended} onShowChange={this.displayModalRecommended.bind(this)} /> : null}
                <table>
                        <tbody>
                            <tr>
                                {this.state.modalShow ? <ScheduleRegularAppointmentModal show={this.state.modalShow} onShowChange={this.displayModal.bind(this)} /> : null}
                                <td><button onClick={() => { this.displayModal() }} className="btn-primary btn-lg">Schedule regular appointment</button></td>
                            </tr>
                            <tr>
                                <td style={{ textAlign: "right" }}><button onClick={() => { this.displayModalRecommended() }} className="btn-primary  btn-lg">Schedule recommended appointment</button></td >
                            </tr>
                        </tbody>
                   
                </table>

            </div>


        );

    }

    displayModalRecommended() {
        debugger;
        this.setState({ modalShowRecommended: !this.state.modalShowRecommended })
    }

    displayModal() {
        debugger;
        console.log()
        this.setState({ modalShow: !this.state.modalShow })
    }

}


const mapStateToProps = (state) => ({

});

export default connect(mapStateToProps, {})(AppointmentMenu);