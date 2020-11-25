import React, { Component } from "react"
import { wrap } from "module";
import axios from "axios";
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';

class ReferralModal extends Component {
    state = {
        modalShow: this.props.show,
        date: this.props.date
    }
    render() {
        debugger;
        return (
            <Modal isOpen={this.state.modalShow} centered={true}>
                <ModalHeader> {this.state.date} </ModalHeader>
                <ModalBody>
                    <div className="h-100 d-flex justify-content-center align-items-center">
                            <label className="label">Medicine: </label>
                            <label className="label-data ml-2">{this.props.referral.medicine}</label>
                    </div>
                    <div className="h-100 d-flex justify-content-center align-items-center">
                        <label className="label">Take medicine until: </label>
                        <label className="label-data ml-2">{this.props.referral.takeMedicineUntil}</label>
                    </div>
                    <div className="h-100 d-flex justify-content-center align-items-center">
                        <label className="label">Quantity per day: </label>
                        <label className="label-data ml-2">{this.props.referral.quantityPerDay}</label>
                    </div>
                    <div className="h-100 d-flex justify-content-center align-items-center">
                        <label className="label">Comment: </label>
                        <label className="label-data ml-2">{this.props.referral.comment}</label>
                    </div>
        </ModalBody>
                <ModalFooter>
                    <Button color="primary" onClick={this.toggle.bind(this)}>Close</Button>{' '}
            </ModalFooter>
        </Modal>
        );
    }
    toggle() {
        this.setState({ modalShow: false });
        this.props.onShowChange();
    }
}

export default (ReferralModal);