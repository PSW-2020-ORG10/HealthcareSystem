import SelectDateForm from './SelectDateForm'
import React, { Component } from "react"
import { wrap } from "module";
import axios from "axios";
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import Stepper from 'react-stepper-horizontal';
import SelectSpecialtyForm from './SelectSpecialtyForm'
import SelectDoctorForm from './SelectDoctorForm'
import SelectAppointmentForm from './SelectAppointmentForm'
import { formatDate } from '../utilities/Utilities';
import AppointmentConfirmationModal from './AppointmentConfirmationModal'

class ScheduleRegularAppointmentModal extends Component {
    constructor(props) {
        super(props)

        this.handleDateChange = this.handleDateChange.bind(this)
        this.handleSpecialtyChange = this.handleSpecialtyChange.bind(this)
        this.handleDoctorChange = this.handleDoctorChange.bind(this)
        this.handleAppointmentChange = this.handleAppointmentChange.bind(this)
        this.disableNext = this.disableNext.bind(this)
        this.disableSchedule = this.disableSchedule.bind(this)
    }

    state = {
        modalShow: this.props.show,
        nextShow: true,
        prevShow: false,
        date: new Date(),
        specialty: "",
        doctorId: 0,
        appointment: null,
        step: 0,
        nextDisabled: false,
        scheduleDisabled: false,
        confirmationModalShow: false
    }
    divStyle = {
        height: '500px',
    };
    render() {
        debugger;
        return (
            <Modal isOpen={this.state.modalShow} centered={true}>
                {this.state.confirmationModalShow ? <AppointmentConfirmationModal appointment={this.state.appointment} show={this.state.confirmationModalShow} onShowChange={this.displayModal.bind(this)} toggleParent={this.toggle.bind(this)} /> : null}
                <ModalHeader toggle={this.toggle.bind(this)}></ModalHeader>
                <ModalBody style={this.divStyle} className="text-center">
                    <div>
                        <Stepper steps={[{ title: 'Pick date' }, { title: 'Select specialty' }, { title: 'Select doctor' }, { title: 'Pick time' }]} activeStep={this.state.step} />
                    </div>
                    {this.state.step == 0 ? < SelectDateForm step={this.state.step} handleDateChange={this.handleDateChange} /> : null}
                    {this.state.step == 1 ? < SelectSpecialtyForm step={this.state.step} handleSpecialtyChange={this.handleSpecialtyChange} /> : null}
                    {this.state.step == 2 ? < SelectDoctorForm step={this.state.step} specialty={this.state.specialty} date={formatDate(this.state.date)} disableNext={this.disableNext} handleDoctorChange={this.handleDoctorChange} /> : null}
                    {this.state.step == 3 ? < SelectAppointmentForm step={this.state.step} date={formatDate(this.state.date)} doctorId={this.state.doctorId} handleAppointmentChange={this.handleAppointmentChange} disableSchedule={this.disableSchedule} /> : null}
                </ModalBody>
                <ModalFooter className="modalFooter">
                    {this.state.prevShow ? <Button color="warning" onClick={this.prev.bind(this)}> Previous</Button > : null}
                    {this.state.nextShow ? <Button disabled={this.state.nextDisabled} color="success" className="float-right" onClick={this.next.bind(this)}> Next</Button > : <Button disabled={this.state.scheduleDisabled} onClick={() => { this.displayModal() }} color="primary" className="float-right">Schedule</Button >}
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
        this.setState({ nextDisabled: false })
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
        if (this.state.step > 2) {
            this.setState({ nextShow: false })
        } else {
            this.setState({ nextShow: true })
        }
    }

    showPrevButton() {
        debugger;
        if (this.state.step > 0) {
            this.setState({ prevShow: true })
        } else {
            this.setState({ prevShow: false })
        }
    }

    disableNext() {
        this.setState({ nextDisabled:true })
    }

    disableSchedule() {
        this.setState({ scheduleDisabled: true })
    }

    handleDateChange(e) {
        debugger;
        this.setState({
            date : e
        })
        console.log(this.state.date)
    }

    handleSpecialtyChange(e) {
        debugger;
        this.setState({
            specialty: e.target.value
        })
        console.log(this.state.specialty)
    }

    handleDoctorChange(f) {
        debugger;
        this.setState({
            doctorId: f.id,
            nextDisabled: false
        })
        console.log(this.state.doctorId)
    }

    handleAppointmentChange(f) {
        debugger;
        this.setState({
            appointment: f,
            scheduleDisabled: false
        })
        console.log(this.state.appointment)
    }

    displayModal() {
        debugger;
        this.setState({ confirmationModalShow: !this.state.confirmationModalShow })
    }
}

export default (ScheduleRegularAppointmentModal);