import React, { Component } from "react"
import { wrap } from "module";
import axios from "axios";
import { Modal } from "react-bootstrap";
import { Button } from 'react-bootstrap';

class ReferralModal extends Component {
    state = {
        show: this.props
    }
    render() {
        debugger;
        return <>{this.state.show && <Modal.Dialog>
            <Modal.Header closeButton>
                <Modal.Title>Modal title</Modal.Title>
            </Modal.Header>

            <Modal.Body>
                <p>Modal body text goes here.</p>
            </Modal.Body>

            <Modal.Footer>
                <button onClick={() => { this.setState({ show: false}) }}>Close</button>
                <Button variant="primary">Save changes</Button>
            </Modal.Footer>
        </Modal.Dialog>}</>
    }
}

export default (ReferralModal);