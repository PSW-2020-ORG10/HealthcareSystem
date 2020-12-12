import React, { Component } from "react"
import { wrap } from "module";
import { createRecommendAppointment } from "../actions/actions"
import axios from "axios";
import { connect } from "react-redux"
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css'; 
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';

class RecommendationModal extends Component {
    state = {
        appointment: null,
        bgColor: 'white',
        modalShow: this.props.show
    }

    handleChange = (f) => {
        debugger;
        console.log(f)
        this.setState({
            appointment: f,
            bgColor: "lightBlue"
        })
    }

    render() {
        debugger;
        if (this.props.appointments[0] == undefined) {
            return (
                <Modal isOpen={this.state.modalShow} centered={true}>
                    <ModalHeader> Appointments </ModalHeader>
                    <ModalBody>
                        <div className="h-100 d-flex justify-content-center align-items-center">
                            <label className="label">Sorry there is no available appointments.</label>
                        </div>
                    </ModalBody>
                    <ModalFooter>
                        <Button color="primary" onClick={this.toggle.bind(this)}>Close</Button>{' '}
                    </ModalFooter>
                </Modal>
            );
        }
        return (
            <Modal isOpen={this.state.modalShow} centered={true}>
                <ModalHeader> Appointments </ModalHeader>
                {!this.props.appointments[0].start ? <ModalBody>
                    <div className="h-100 d-flex justify-content-center align-items-center">
                        <label className="label">Sorry there is no available appointments.</label>
                    </div>
                </ModalBody> : <ModalBody>
                        <table className='table allAppointments' >
                            <thead>
                                <tr>
                                    <th style={{ textAlign: "left" }}>Start Time</th>
                                    <th style={{ textAlign: "center" }}>Date</th>
                                    <th style={{ textAlign: "center" }}>Doctor</th>
                                    <th style={{ textAlign: "right" }}>Room</th>
                                </tr>
                            </thead>
                            {this.props.appointments.map((f) => (
                                <tbody key={f.start}>
                                    <tr style={this.state.appointment == f ? { backgroundColor: this.state.bgColor } : null} key={f.start} onClick={() => this.handleChange(f)}>
                                        <td style={{ textAlign: "left" }} >{f.start}</td>
                                        <td style={{ textAlign: "center" }} >{f.date}</td>
                                        <td style={{ textAlign: "right" }} > {f.doctor != undefined ? f.doctor.firstName + " " + f.doctor.secondName : ""}</td >
                                        <td style={{ textAlign: "right" }} > {f.roomId}</td > 
                                    </tr>
                                </tbody>
                            ))}
                        </table>
                    </ModalBody>}
                <ModalFooter>
                    <Button color="primary" onClick={this.toggle.bind(this)}>Close</Button>{' '}
                    <Button color="primary" /*disabled={!this.props.appointment.date || !this.props.appointment.start || !this.props.appointment.roomId}*/ onClick={this.schedule.bind(this)}>Schedule</Button>{' '}
                </ModalFooter>
            </Modal>
        );
    }

    toggle() {
        this.setState({ modalShow: false });
        this.props.onShowChange();
    }

    schedule() {
        toast.configure();

        toast.success("Appointment successfully created!", {
            position: toast.POSITION.TOP_RIGHT
        });

        this.state.appointment.patientUserId = this.state.appointment.patient.id;
        this.state.appointment.doctorUserId = this.state.appointment.doctor.id;
        this.state.appointment.patient = null;
        this.state.appointment.doctor = null;

        console.log(this.state.appointment);

        this.props.createRecommendAppointment(this.state.appointment);

        this.setState({ modalShow: false });
        this.props.onShowChange();
    }
}

const mapStateToProps = (state) => ({

});

export default connect(mapStateToProps, { createRecommendAppointment })(RecommendationModal);