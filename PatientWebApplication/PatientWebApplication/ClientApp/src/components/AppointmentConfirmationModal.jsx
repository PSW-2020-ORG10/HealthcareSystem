import React, { Component } from "react"
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import { appointmentScheduled } from "../actions/actions";
import { connect } from "react-redux"

class AppointmentConfirmationModal extends Component {
    state = {
        confirmationModalShow: this.props.show
    }

    componentDidMount() {
        debugger;
    }

    toggle() {
        this.setState({ confirmationModalShow: false });
        this.props.toggleParent();
        this.props.onShowChange();
    }

    toggle1() {
        this.setState({ confirmationModalShow: false });
        this.props.onShowChange();
    }

    render() {
        debugger;
        return (
            <Modal isOpen={this.state.confirmationModalShow} centered={true}>
                <ModalHeader></ModalHeader>
                <ModalBody>
                    <h4>Are you sure you want to schedule an appointment?</h4>
                </ModalBody>
                <ModalFooter className="modalFooter">
                    <Button color="danger" onClick={() => this.toggle1()}> No</Button >
                    <Button color="success" className="float-right" onClick={() => this.scheduleAppointment()}> Yes</Button >
                </ModalFooter>
            </Modal>
        );
    }

    scheduleAppointment() {
        this.props.appointmentScheduled(this.props.appointment)
        this.toggle()
    }
}

const mapStateToProps = (state) => ({  })

export default connect(mapStateToProps, { appointmentScheduled })(AppointmentConfirmationModal);