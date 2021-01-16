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
            <Modal isOpen={this.state.modalShow} centered={true} style={{ maxWidth: '750px', width: '749px' }}>
                <ModalHeader className="btn-primary"> {this.state.date} </ModalHeader>
                <ModalBody>
                    <div className="mr-2 mb-3">
                        <label className="label">Diagnosis: </label>
                        <textarea className="ml-2 modal-textarea-diagnosis" disabled>{this.props.referral.diagnosis}</textarea>
                    </div>
                    <div className="mr-2">
                        <label className="label">Procedure: </label>
                        <textarea className="ml-2 modal-textarea-procedure" disabled>{this.props.referral.procedure}</textarea>
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