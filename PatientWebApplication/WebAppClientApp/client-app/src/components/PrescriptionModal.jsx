import React, { Component } from "react"
import { wrap } from "module";
import axios from "axios";
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import { loadedPrescriptionFromAppointment } from '../actions/actions';
import { connect } from "react-redux";

class PrescriptionModal extends Component {
    state = {
        modalShow: this.props.show,
        date: this.props.date,
        appointmentId: this.props.appointmentId
    }
    componentDidMount(){
        debugger;
        this.props.loadedPrescriptionFromAppointment(this.state.appointmentId);
        console.log("ComponentDidMount Prescription")
    }
    render() {
        debugger;
        if(this.props.prescription.medicines === undefined){
            return null;
        }
        return (
            <Modal isOpen={this.state.modalShow} centered={true} style={{ maxWidth: '850px', width: '848px' }}>
                <ModalHeader className="modal-header"> {this.state.date} </ModalHeader>
                <ModalBody>
                {this.props.prescription.medicines.length === 0 ? <h3 className="text-center" style={{ marginTop: "50px", marginBottom: "50px" }}>No medicines prescribed for this appointment.</h3> : <div><div className="mr-2 mb-3">
                        <label className="label">Medicine: </label>
                        <div className="mr-5 ml-5 border">
                        <table className='table allPrescriptions' >
                    <thead>
                        <tr>
                            <th style={{ textAlign: "left" }}>Name</th>
                            <th style={{ textAlign: "center" }}>Quantity</th>
                            <th style={{ textAlign: "center" }}>How to use</th>
                        </tr>
                    </thead>
                    {this.props.prescription.medicines.map((f) => (
                        <tbody key={f}>
                            <tr key={f}>
                                <td style={{ textAlign: "left" }} >{f.medicine.name}</td>
                                <td style={{ textAlign: "center" }} > {f.quantity}</td >
                                <td style={{ textAlign: "center" }}>{f.howToUse}</td >
                            </tr>
                        </tbody>
                    ))}
                </table>
                        </div>
                    </div>
                    <div className="mr-2">
                        <label className="label">Procedure: </label>
                        <textarea className="ml-2 modal-textarea-diagnosis" disabled>{this.props.prescription.comment}</textarea>
                    </div></div>}
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

const mapStateToProps = (state) =>

    ({ prescription: state.reducer.appointmentPrescription })

export default connect(mapStateToProps, { loadedPrescriptionFromAppointment})(PrescriptionModal);