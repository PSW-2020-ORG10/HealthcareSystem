import React, { Component } from "react"
import {getStatistics} from "../actions/actions"
import { connect } from "react-redux"
import { wrap } from "module";
import { formatDate } from "../utilities/Utilities"



class EventStatisticsTable extends Component {
    componentDidMount() {
        debugger;
        this.props.getStatistics();
    }
    render() {
        debugger;
        if (this.props.statistics === undefined || this.props.statistics.length === 0){
            return null;
        }
        
        const statistics = this.props.statistics
        debugger;
        return (
            <div>
                <table className='table allFeedback' >
                    <thead>
                        <tr>
                            <th style={{ textAlign: "left" , width: '45%' }}> Statistics</th>
                            <th style={{ textAlign: "center" }}>Value</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td style={{ flexWrap: "wrap", wordWrap: "break-word", wordBreak: "break-word", width: '45%' }}>
                               Scheduling with least number of steps was done by: {statistics.minSteps.appointmentEventWithPatientDto.patient.name + " " + statistics.minSteps.appointmentEventWithPatientDto.patient.surname}
                            </td>
                            <td style={{ textAlign: "center" }}>
                                {statistics.minSteps.countSteps} steps
                            </td>                        
                        </tr>
                        <tr>
                            <td style={{ flexWrap: "wrap", wordWrap: "break-word", wordBreak: "break-word", width: '45%' }}>
                                Scheduling with most number of steps was done by: {statistics.maxSteps.appointmentEventWithPatientDto.patient.name + " " + statistics.maxSteps.appointmentEventWithPatientDto.patient.surname}
                            </td>
                            <td style={{ textAlign: "center" }}>
                                {statistics.maxSteps.countSteps} steps
                            </td>
                        </tr>
                        <tr>
                            <td style={{ flexWrap: "wrap", wordWrap: "break-word", wordBreak: "break-word", width: '45%' }}>
                                Average number of steps needed for scheduling: 
                            </td>
                            <td style={{ textAlign: "center" }}>
                                {parseFloat(statistics.averageStepsForSuccessfulAttempt).toFixed(1)} steps
                            </td>
                        </tr>
                        <tr>
                        <td style={{ flexWrap: "wrap", wordWrap: "break-word", wordBreak: "break-word", width: '45%' }}>
                               Cancelling with least number of steps was done by: {statistics.minStepsForCancelling.appointmentEventWithPatientDto.patient.name + " " + statistics.minStepsForCancelling.appointmentEventWithPatientDto.patient.surname}
                            </td>
                            <td style={{ textAlign: "center" }}>
                                {statistics.minStepsForCancelling.countSteps} steps
                            </td>                        
                        </tr>
                        <tr>
                            <td style={{ flexWrap: "wrap", wordWrap: "break-word", wordBreak: "break-word", width: '45%' }}>
                            Cancelling with most number of steps was done by: {statistics.maxStepsForCancelling.appointmentEventWithPatientDto.patient.name + " " + statistics.maxStepsForCancelling.appointmentEventWithPatientDto.patient.surname}
                            </td>
                            <td style={{ textAlign: "center" }}>
                                {statistics.maxStepsForCancelling.countSteps} steps
                            </td>
                        </tr>
                        <tr>
                            <td style={{ flexWrap: "wrap", wordWrap: "break-word", wordBreak: "break-word", width: '45%' }}>
                                Average number of steps needed for cancelling: 
                            </td>
                            <td style={{ textAlign: "center" }}>
                                {parseFloat(statistics.averageStepsForUnsuccessfulAttempt).toFixed(1)} steps
                            </td>
                        </tr>
                        <tr>
                            <td style={{ flexWrap: "wrap", wordWrap: "break-word", wordBreak: "break-word", width: '45%' }}>
                                Ratio of successful appointment shceduled:
                            </td>
                            <td style={{ textAlign: "center" }}>
                                {(statistics.successfulAttemptsRatio * 100).toFixed(1)} %
                            </td>
                        </tr>
                        <tr>
                        <td style={{ flexWrap: "wrap", wordWrap: "break-word", wordBreak: "break-word", width: '45%' }}>
                        Step at which most cancellations happend:
                            </td>
                            <td style={{ textAlign: "center" }}>
                            {statistics.mostCanceledStep}
                            </td>
                        </tr>
                        <tr>
                            <td style={{ flexWrap: "wrap", wordWrap: "break-word", wordBreak: "break-word", width: '45%' }}>
                                Maximum time for scheduling:
                            </td>
                            <td style={{ textAlign: "center" }}>
                            {statistics.maxTime.toFixed(1)} seconds
                            </td>
                        </tr>
                        <tr>
                            <td style={{ flexWrap: "wrap", wordWrap: "break-word", wordBreak: "break-word", width: '45%' }}>
                                Minimum time for scheduling:
                            </td>
                            <td style={{ textAlign: "center" }}>
                                {statistics.minTime.toFixed(1)} seconds
                            </td>
                        </tr>
                        <tr>
                            <td style={{ flexWrap: "wrap", wordWrap: "break-word", wordBreak: "break-word", width: '45%' }}>
                                Average time for scheduling:
                            </td>
                            <td style={{ textAlign: "center" }}>
                                {statistics.averageTime.toFixed(1)} seconds
                            </td>
                        </tr>
                        <tr>
                            <td style={{ flexWrap: "wrap", wordWrap: "break-word", wordBreak: "break-word", width: '45%' }}>
                                How many patients scheduled appointment in minimum steps:
                            </td>
                            <td style={{ textAlign: "center" }}>
                                {statistics.howManySchedulesInMinimumSteps}
                            </td>
                        </tr>
                        <tr>
                            <td style={{ flexWrap: "wrap", wordWrap: "break-word", wordBreak: "break-word", width: '45%' }}>
                                How many patients scheduled appointment in 5 to 7 steps:
                            </td>
                            <td style={{ textAlign: "center" }}>
                                {statistics.howManySchedulesInMediumSteps}
                            </td>
                        </tr>
                        <tr>
                            <td style={{ flexWrap: "wrap", wordWrap: "break-word", wordBreak: "break-word", width: '45%' }}>
                                How many patients scheduled appointment in more than 7 steps:
                            </td>
                            <td style={{ textAlign: "center" }}>
                                {statistics.howManySchedulesInMoreSteps}
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        );
    }

}


const mapStateToProps = (state) =>

    ({ statistics: state.reducer.statistics})

export default connect(mapStateToProps, { getStatistics })(EventStatisticsTable);