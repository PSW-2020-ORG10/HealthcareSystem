import React, { Component } from "react"
import { loadedAllPatientPrescriptions } from "../actions/actions"
import { connect } from "react-redux"
import { wrap } from "module";

class PrescriptionsSearchSimpleTable extends Component {
    componentDidMount() {
        debugger;
        this.props.loadedAllPatientPrescriptions();
    }
    render() {
        debugger;
        if (this.props.patientPrescriptionsList === undefined) {

            return null;
        }

        const patientPrescriptionsList = this.props.patientPrescriptionsList;
        let medicines = ""
        return (

            <div>
                <table className='table allPrescriptions' >
                    <thead>
                        <tr>
                            <th style={{ textAlign: "center" }}>Medicine</th>
                            <th style={{ textAlign: "center" }}>Is Used</th>
                            <th style={{ textAlign: "center" }}>Comment</th>
                        </tr>
                    </thead>
                    {patientPrescriptionsList.map((f) => (
                        <tbody key={f.id}>
                            <tr key={f.id}>
                                {f.medicines !== undefined ? f.medicines.map((m) => (
                                    [medicines, m.id].join('    ')
                                )) : medicines = "Empty"}
                                <td style={{ textAlign: "center" }} > {f.isUsed ? "Used" : "Not used"}</td >
                                <td style={{ textAlign: "center" }}>{f.comment}</td >
                            </tr>
                        </tbody>
                    ))}
                </table>

            </div>


        );
    }

}


const mapStateToProps = (state) =>

    ({ patientPrescriptionsList: state.reducer.patientPrescriptionsList })

export default connect(mapStateToProps, { loadedAllPatientPrescriptions })(PrescriptionsSearchSimpleTable);