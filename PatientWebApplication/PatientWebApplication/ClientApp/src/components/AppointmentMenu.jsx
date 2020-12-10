import React, { Component } from "react"
import { loadedAllPatientReports, simpleSearchAppointments } from "../actions/actions"
import { connect } from "react-redux"
import { wrap } from "module";
import axios from "axios";
import RecommendedAppointmentScheduling from "./RecommendedAppointmentScheduling"
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { showErrorToast, checkDateFormat } from "../utilities/Utilities"

class AppointmentMenu extends Component {
    state = {
        modalShowRecommended: false 
    };

    render() {
        debugger;
        return (
            <div>
                {this.state.modalShowRecommended ? <RecommendedAppointmentScheduling show={this.state.modalShowRecommended} onShowChange={this.displayModalRecommended.bind(this)} /> : null}
                <table>
                        <tbody>
                            <tr>                             
                            <td style={{ textAlign: "right" }}><button onClick={() => { this.displayModalRecommended() }} className="btn btn-primary">Recommended Appointment Scheduling</button></td >
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

}


const mapStateToProps = (state) => ({

});

export default connect(mapStateToProps, {})(AppointmentMenu);