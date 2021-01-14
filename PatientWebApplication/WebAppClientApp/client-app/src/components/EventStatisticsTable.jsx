import React, { Component } from "react"
import { minSteps, maxSteps } from "../actions/actions"
import { connect } from "react-redux"
import { wrap } from "module";
import { formatDate } from "../utilities/Utilities"



class EventStatisticsTable extends Component {
    componentDidMount() {
        debugger;
        this.props.minSteps();
        this.props.maxSteps();
        
    }
    render() {
        debugger;
        if (this.props.minStepEvent === undefined || this.props.minStepEvent.length === 0){
            return null;
        }
        
        if (this.props.maxStepEvent === undefined || this.props.maxStepEvent.length === 0) {
            return null;
        }

        const minStepEvent = this.props.minStepEvent
        const maxStepEvent = this.props.maxStepEvent
        debugger;
        return (
            <div>
                <div>
                    <label className="label">Zakazivanje sa minimalnim brojem koraka je izveo: {minStepEvent.appointmentSchedulingEvent.patientId} u {minStepEvent.countSteps} koraka
                    </label>
                </div>
                <div>
                    <label className="label">Zakazivanje sa maksimalnim brojem koraka je izveo: {maxStepEvent.appointmentSchedulingEvent.patientId} u {maxStepEvent.countSteps} koraka
                    </label>
                </div>
            </div>
        );
    }

}


const mapStateToProps = (state) =>

    ({ minStepEvent: state.reducer.minStepEvent, maxStepEvent: state.reducer.maxStepEvent })

export default connect(mapStateToProps, { minSteps, maxSteps })(EventStatisticsTable);