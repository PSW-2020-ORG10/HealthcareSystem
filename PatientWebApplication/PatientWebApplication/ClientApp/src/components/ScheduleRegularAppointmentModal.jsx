import SelectDateForm from './SelectDateForm'
import React, { Component } from "react"
import { wrap } from "module";
import axios from "axios";
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';

class ScheduleRegularAppointmentModal extends Component {
    state = {
        modalShow: this.props.show,
        nextShow: true,
        prevShow: false,
        step: 1
    }
    divStyle = {
        height: '500px',
    };
    render() {
        debugger;
        return (
            <Modal isOpen={this.state.modalShow} centered={true}>
                <ModalHeader toggle={this.toggle.bind(this)}> {this.state.date} </ModalHeader>
                <ModalBody style={this.divStyle} className="d-flex justify-content-center">
                    <SelectDateForm step={this.state.step} />
                </ModalBody>
                <ModalFooter className="modalFooter">
                    {this.state.prevShow ? <Button color="warning"  onClick={this.prev.bind(this)}> Previous</Button > : null}
                    {this.state.nextShow ? <Button color="success" className="float-right" onClick={this.next.bind(this)}> Next</Button > : <Button color="primary" className="float-right">Schedule</Button >}
                </ModalFooter>
            </Modal>
        );
    }
    next() {
        debugger;
        this.setState({ step: ++this.state.step })
        this.showNextButton()
        this.showPrevButton()
    }
    prev() {
        debugger;
        this.setState({ step: --this.state.step })
        this.showNextButton()
        this.showPrevButton()
    }
    toggle() {
        this.setState({ modalShow: false });
        this.props.onShowChange();
    }
    showNextButton() {
        debugger;
        if (this.state.step > 3) {
            this.setState({ nextShow: false })
        } else {
            this.setState({ nextShow: true })
        }
    }
    showPrevButton() {
        debugger;
        if (this.state.step > 1) {
            this.setState({ prevShow: true })
        } else {
            this.setState({ prevShow: false })
        }
    }
}

export default (ScheduleRegularAppointmentModal);