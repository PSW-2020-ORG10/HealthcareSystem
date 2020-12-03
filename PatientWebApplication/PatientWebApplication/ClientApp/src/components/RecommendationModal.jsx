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
        modalShow: this.props.show
    }
    render() {
        debugger;
        return (
            <Modal isOpen={this.state.modalShow} centered={true}>
                <ModalHeader> Appointment </ModalHeader>
                {!this.props.appointment.start ? <ModalBody>
                    <div className="h-100 d-flex justify-content-center align-items-center">
                        <label className="label">Sorry there is no available appointments.</label>
                    </div>
                </ModalBody> : <ModalBody>
                        <div className="h-100 d-flex justify-content-center align-items-center">
                            <label className="label">Date: </label>
                            <label className="label-data ml-2">{this.props.appointment.date}</label>
                        </div>
                        <div className="h-100 d-flex justify-content-center align-items-center">
                            <label className="label">Start Time: </label>
                            <label className="label-data ml-2">{this.props.appointment.start}</label>
                        </div>
                        <div className="h-100 d-flex justify-content-center align-items-center">
                            <label className="label">Room: </label>
                            <label className="label-data ml-2">{this.props.appointment.roomId}</label>
                        </div>
                        <div className="h-100 d-flex justify-content-center align-items-center">
                            <label className="label">Doctor: </label>
                            <label className="label-data ml-2">{this.props.appointment.doctor != undefined ? this.props.appointment.doctor.firstName + " " + this.props.appointment.doctor.secondName : ""}</label>
                        </div>
                    </ModalBody>}
                <ModalFooter>
                    <Button color="primary" onClick={this.toggle.bind(this)}>Close</Button>{' '}
                    <Button color="primary" disabled={!this.props.appointment.date || !this.props.appointment.start || !this.props.appointment.roomId} onClick={this.schedule.bind(this)}>Schedule</Button>{' '}
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

        this.props.createRecommendAppointment(this.props.appointment)

        this.setState({ modalShow: false });
        this.props.onShowChange();
    }
}

const mapStateToProps = (state) => ({

});

export default connect(mapStateToProps, { createRecommendAppointment })(RecommendationModal);