import React, { Component } from "react"
import { loadedAllRates } from "../actions/actions"
import { connect } from "react-redux"
import { formatDate } from "../utilities/Utilities"

class AllRatingTable extends Component {
    componentDidMount() {
        debugger;
        this.props.loadedAllRates();
    }
    render() {
        debugger;
        if (this.props.allRates.doctorAverage === undefined) {
            return null;
        }
        const allRates = this.props.allRates;
        return (
            <div>

                <div className="wrap">
                    <div className="item-row">
                        <div className="check-flag">
                            <span className="small-text-label">Average rating of:</span>
                            <span className="small-text-label hours">{'Average rate: ' + allRates.doctorAverage.toFixed(2) + ' / 5'}</span>
                            <span className="check-flag-label">Doctors</span>
                            <textarea style={{ height: "230px" }} className="check-flag-textarea" disabled rows={3} value={'Knowledge: ' + allRates.doctorsKnowledgeAverage.toFixed(2) + '\nProfessionalism: ' + allRates.doctorsProfessionalismAverage.toFixed(2) + '\nPolitness: ' + allRates.doctorsPolitenessAverage.toFixed(2) + '\nTechnicality: ' + allRates.doctorsTechnicalityAverage.toFixed(2) + '\nSkill: ' + allRates.doctorsSkillAverage.toFixed(2) + '\nWorking Pace: ' + allRates.doctorsWorkingPaceAverage.toFixed(2)}></textarea>
                        </div>
                    </div>
                </div>

                <div className="wrap">
                    <div className="item-row">
                        <div className="check-flag">
                            <span className="small-text-label">Average rating of:</span>
                            <span className="small-text-label hours">{'Average rate: ' + allRates.medicalStaffAverage.toFixed(2) + ' / 5'}</span>
                            <span className="check-flag-label">Medical staff</span>
                            <textarea style={{ height: "230px" }} className="check-flag-textarea" disabled rows={3} value={'Knowledge: ' + allRates.medicalStaffsKnowledgeAverage.toFixed(2) + '\nProfessionalism: ' + allRates.medicalStaffsProfessionalismAverage.toFixed(2) + '\nPolitness: ' + allRates.medicalStaffsPolitenessAverage.toFixed(2) + '\nTechnicality: ' + allRates.medicalStaffsTechnicalityAverage.toFixed(2) + '\nSkill: ' + allRates.medicalStaffsSkillAverage.toFixed(2) + '\nWorking Pace: ' + allRates.medicalStaffsWorkingPaceAverage.toFixed(2)}></textarea>
                        </div>
                    </div>
                </div>

                <div className="wrap">
                    <div className="item-row">
                        <div className="check-flag">
                            <span className="small-text-label">Average rating of:</span>
                            <span className="small-text-label hours">{'Average rate: ' + allRates.hospitalAverage.toFixed(2) + ' / 5'}</span>
                            <span className="check-flag-label">Hospital</span>
                            <textarea style={{ height: "200px" }} className="check-flag-textarea" disabled rows={3} value={'Environment: ' + allRates.hospitalEnvironmentAverage.toFixed(2) + '\nQuality of equipment: ' + allRates.hospitalEquipmentAverage.toFixed(2) + '\nHygiene: ' + allRates.hospitalHygieneAverage.toFixed(2) + '\nPrices: ' + allRates.hospitalPricesAverage.toFixed(2) + '\nWaiting time in hospital: ' + allRates.hospitalWaitingTimeAverage.toFixed(2)}></textarea>
                        </div>
                    </div>
                </div>


            </div>
        );
    }
}

const mapStateToProps = (state) => {
    debugger;
    return ({ allRates: state.reducer.allRates });
}



    

export default connect(mapStateToProps, { loadedAllRates })(AllRatingTable);