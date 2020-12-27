import React, { Component } from "react"
import { cancelAppointment } from "../actions/actions"
import { connect } from "react-redux"
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

class CancelAppointmentButton extends Component {


    render() {
        return (
            <React.Fragment>
                <button className="btn btn-primary" disabled={this.props.appointment.isCanceled} onClick={this.cancelApp.bind(this)}>Cancel</button>
            </React.Fragment>
        )
    }

    cancelApp() {
        toast.configure();

        toast.success("Appointment successfully cancelled!", {
            position: toast.POSITION.TOP_RIGHT
        });
        debugger;
        this.props.cancelAppointment(this.props.appointment.id);
        window.location.href = "http://localhost:60198/my-appointments";           
    }
}

const mapStateToProps = (state) => ({

});

export default connect(mapStateToProps, { cancelAppointment })(CancelAppointmentButton);