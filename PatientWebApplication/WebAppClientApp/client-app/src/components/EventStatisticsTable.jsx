import React, { Component } from "react"
import { minSteps, maxSteps, succesRatio, mostCanceledStep } from "../actions/actions"
import { connect } from "react-redux"
import { wrap } from "module";
import { formatDate } from "../utilities/Utilities"



class EventStatisticsTable extends Component {
    componentDidMount() {
        debugger;
        this.props.minSteps();
        this.props.maxSteps();
        this.props.succesRatio();
        this.props.mostCanceledStep();
        
    }
    render() {
        debugger;
        if (this.props.minStepEvent === undefined || this.props.minStepEvent.length === 0){
            return null;
        }
        
        if (this.props.maxStepEvent === undefined || this.props.maxStepEvent.length === 0) {
            return null;
        }

        if (this.props.succesRatioPercentage === undefined || this.props.succesRatioPercentage.length === 0) {
            return null;
        }

        if (this.props.mostCanceledStepActual === undefined || this.props.mostCanceledStepActual.length === 0) {
            return null;
        }

        const minStepEvent = this.props.minStepEvent
        const maxStepEvent = this.props.maxStepEvent
        const succesRatioPercentage = this.props.succesRatioPercentage
        const mostCanceledStepActual = this.props.mostCanceledStepActual
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
                               Scheduling with least number of steps was done by: {minStepEvent.appointmentEventWithPatientDto.patient.name + " " + minStepEvent.appointmentEventWithPatientDto.patient.surname}
                            </td>
                            <td style={{ textAlign: "center" }}>
                                {minStepEvent.countSteps} steps
                            </td>                        
                        </tr>
                        <tr>
                            <td style={{ flexWrap: "wrap", wordWrap: "break-word", wordBreak: "break-word", width: '45%' }}>
                                Scheduling with most number of steps was done by: {maxStepEvent.appointmentEventWithPatientDto.patient.name + " " + maxStepEvent.appointmentEventWithPatientDto.patient.surname}
                            </td>
                            <td style={{ textAlign: "center" }}>
                                {maxStepEvent.countSteps} steps
                            </td>
                        </tr>
                        <tr>
                            <td style={{ flexWrap: "wrap", wordWrap: "break-word", wordBreak: "break-word", width: '45%' }}>
                                Ratio of successful appointment shceduled:
                            </td>
                            <td style={{ textAlign: "center" }}>
                                {succesRatioPercentage * 100} %
                            </td>
                        </tr>
                        <tr>
                        <td style={{ flexWrap: "wrap", wordWrap: "break-word", wordBreak: "break-word", width: '45%' }}>
                        Step at which most cancellations happend:
                            </td>
                            <td style={{ textAlign: "center" }}>
                            {mostCanceledStepActual}
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        );
    }

}


const mapStateToProps = (state) =>

    ({ minStepEvent: state.reducer.minStepEvent, maxStepEvent: state.reducer.maxStepEvent, succesRatioPercentage: state.reducer.succesRatioPercentage, mostCanceledStepActual: state.reducer.mostCanceledStepActual })

export default connect(mapStateToProps, { minSteps, maxSteps, succesRatio, mostCanceledStep })(EventStatisticsTable);