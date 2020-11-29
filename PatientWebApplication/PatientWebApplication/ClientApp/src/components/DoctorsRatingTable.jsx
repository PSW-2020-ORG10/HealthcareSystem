import React, { Component } from "react"
import { loadedAllDoctorRates } from "../actions/actions"
import { connect } from "react-redux"
import { formatDate } from "../utilities/Utilities"

class DoctorsRatingTable extends Component {
    componentDidMount() {
        debugger;
        this.props.loadedAllDoctorRates();
    }
    render() {
        debugger;
        if (this.props.doctorRatesList === undefined) {

            return null;
        }
        const doctorRatesList = this.props.doctorRatesList;
        return (

            <div className="wrap">
                {doctorRatesList.map((f) => (
                    <div key={f.doctor.Id} className="item-row">
                        <div key={f.doctor.Id} className="check-flag">
                            <span className="small-text-label">Name and Surname</span>
                            <span className="small-text-label hours">{'Average rate: ' + f.doctorAverage.toFixed(2) + ' / 5'}</span>
                            <span className="check-flag-label">{f.doctor.firstName + ' ' +  f.doctor.secondName}</span>
                            <textarea style={{ height: "230px" }} className="check-flag-textarea" disabled rows={3} value={'Knowledge: ' + f.doctorsKnowledgeAverage.toFixed(2) + '\nProfessionalism: ' + f.doctorsProfessionalismAverage.toFixed(2) + '\nPolitness: ' + f.doctorsPolitenessAverage.toFixed(2) + '\nTechnicality: ' + f.doctorsTechnicalityAverage.toFixed(2) + '\nSkill: ' + f.doctorsSkillAverage.toFixed(2) + '\nWorking Pace: ' + f.doctorsWorkingPaceAverage.toFixed(2)}></textarea>
                        </div>
                    </div>
                ))}
            </div>





        );
    }
}

const mapStateToProps = (state) =>

    ({ doctorRatesList: state.reducer.doctorRatesList })

export default connect(mapStateToProps, { loadedAllDoctorRates })(DoctorsRatingTable);