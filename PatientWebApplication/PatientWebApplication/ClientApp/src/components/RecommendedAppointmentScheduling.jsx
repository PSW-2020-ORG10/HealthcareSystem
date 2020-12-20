import React, { Component } from "react"
import { loadedAllDoctors, recommendAppointment, createRecommendAppointment } from "../actions/actions"
import { connect } from "react-redux"
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css'; 
import { wrap } from "module";
import RecommendationModal from "./RecommendationModal"
import { showErrorToast, checkDateFormat } from "../utilities/Utilities"
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';

class RecommendedAppointmentScheduling extends Component {
    state = {
        doctorId: 0,
        start: "",
        end: "",
        priority: "",
        modalShow: false,
        modalShowRecommended: this.props.show
    };

    handleChange = (event) => {
        const { name, value, type, checked } = event.target
        type === "checkbox" ? this.setState({
            [name]: checked
        }) : this.setState({
            [name]: value
        })
    }

    componentDidMount() {
        debugger;
        this.props.loadedAllDoctors();
        this.props.recommendAppointment({ doctorId: this.state.doctorId, start: this.state.start, end: this.state.end, priority: this.state.priority })
    }

    render() {
        debugger;
        if (this.props.doctorList === undefined) {

            return null;
        }      

        const doctorList = this.props.doctorList;

        const recommendedAppointments = this.props.recommendedAppointments;

        return (
            <Modal isOpen={this.state.modalShowRecommended} centered={true} size="lg" style={{ maxWidth: '1200px', width: '120%' }}>
                <ModalHeader toggle={this.toggle.bind(this)}> Get Recommended Appointments </ModalHeader>
                <ModalBody>
                    <div className="field-wrap">
                        <label className="label">Doctor: </label>
                        <select className="field"
                            value={this.state.doctorId}
                            onChange={this.handleChange}
                            name="doctorId">
                            <option value=""></option>
                            {doctorList.map(fbb =>
                                <option key={fbb.id} value={fbb.id}>{fbb.firstName + ' ' + fbb.secondName + ', ' + fbb.speciality}</option>
                            )};
                                </select>
                    </div>

                    <div className="field-wrap">
                        <label className="label label-date">From: </label>

                        <input
                            className="field field-date"
                            type="text"
                            value={this.state.start}
                            name="start"
                            placeholder="dd/MM/yyyy"
                            onChange={this.handleChange}
                        />
                        <input
                            className="field field-date field-end"
                            type="text"
                            value={this.state.end}
                            name="end"
                            placeholder="dd/MM/yyyy"
                            onChange={this.handleChange}
                        />
                        <label className="label label-date label-end">to: </label>

                    </div>

                    <div className="field-wrap">
                        <label className="label">Priority: </label>

                        <select
                            className="field"
                            value={this.state.priority}
                            onChange={this.handleChange}
                            name="priority"
                        >
                            <option value=""> </option>
                            <option value="doctor">Doctor </option>
                            <option value="date">Date Interval </option>
                        </select>
                        </div>

                </ModalBody>

                <ModalFooter>
                    <div className="btn-wrap align-right">
                        <button className="btn btn-primary" disabled={!this.state.start || !this.state.end || !this.state.priority || this.state.doctorId == 0} onClick={this.getRecommendedAppointment.bind(this)}>Schedule</button>
                    </div>

                    <div>
                        {this.state.modalShow ? <RecommendationModal show={this.state.modalShow} appointments={recommendedAppointments} onShowChange={this.getRecommendedAppointment.bind(this)} /> : null}
                    </div>
                </ModalFooter>
            </Modal>
        );
    }

    toggle() {
        this.setState({ modalShowRecommended: false });
        this.props.onShowChange();
    }

    getRecommendedAppointment() {

        debugger;

        var flag = 0;

        let newDate = new Date()
        let date = newDate.getDate();
        let month = newDate.getMonth() + 1;
        let year = newDate.getFullYear();

        // Please pay attention to the month (parts[1]); JavaScript counts months from 0:
        // January - 0, February - 1, etc.
        var todayDate = new Date(year, month - 1, date);


        var startDateParts = this.state.start.split('/');
        var startDate = new Date(startDateParts[2], startDateParts[1] - 1, startDateParts[0])

        var endDateParts = this.state.end.split('/');
        var endDate = new Date(endDateParts[2], endDateParts[1] - 1, endDateParts[0])


        if (startDate < todayDate) {
            flag = 1;
            toast.configure();

            toast.error("Please enter date that is yet to come!", {
                position: toast.POSITION.TOP_RIGHT
            });
        }

        if (endDate < todayDate) {
            flag = 1;
            toast.configure();

            toast.error("Please enter date that is yet to come!", {
                position: toast.POSITION.TOP_RIGHT
            });
        }

        if (endDate < startDate) {
            flag = 1;
            toast.configure();

            toast.error("Please enter valid start date and end date!", {
                position: toast.POSITION.TOP_RIGHT
            });
        }

        if (this.state.start !== "" && checkDateFormat(this.state.start)) {
            showErrorToast()
            flag = 1;
        }
        else if (this.state.end !== "" && checkDateFormat(this.state.end)) {
            showErrorToast()
            flag = 1;
        }

        if (flag == 0) {
            this.props.recommendAppointment({ doctorId: this.state.doctorId, start: this.state.start, end: this.state.end, priority: this.state.priority })

            this.setState({ modalShow: !this.state.modalShow })
        }
       
    }


}


const mapStateToProps = (state) =>

    ({ doctorList: state.reducer.doctorList, recommendedAppointments: state.reducer.recommendedAppointments })

export default connect(mapStateToProps, { loadedAllDoctors, recommendAppointment })(RecommendedAppointmentScheduling);