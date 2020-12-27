import React, { Component } from "react"
import { findOnePatient } from "../actions/actions"
import { connect } from "react-redux"
import { wrap } from "module";

class CheckPersonalInformationTable extends Component {
    componentDidMount() {
        debugger;
        this.props.findOnePatient(3);
    }
    render() {
        debugger;
        if (this.props.patientInformationList === undefined) {

            return null;
        }

        const patientInformationList = this.props.patientInformationList;
        return (

            <div>
                <table className='table patientInformation' >
                    <tbody>
                        <tr>
                            <th style={{ textAlign: "center", width: "700px", marginTop: "100px" }}></th>
                            <td>
                                <img src={'images/' + patientInformationList.file} width={200} height={150}  />

                            </td>
                        </tr>
                        <tr>
                            <th style={{ textAlign: "center", width: "700px" }}>Name:</th>
                            <td style={{ textAlign: "justify" }}>{patientInformationList.firstName}</td>
                        </tr>
                        <tr>
                            <th style={{ textAlign: "center" }} > Surname:</th >
                            <td style={{ textAlign: "justify", }}>{patientInformationList.secondName}</td >
                        </tr>
                        <tr>
                            <th style={{ textAlign: "center" }}>Unique Citizens Identity Number:</th>
                            <td style={{ textAlign: "justify" }}>{patientInformationList.uniqueCitizensidentityNumber}</td>
                        </tr>
                        <tr>
                            <th style={{ textAlign: "center" }} > Date of Birth:</th >
                            <td style={{ textAlign: "justify" }}>{patientInformationList.dateOfBirth}</td >
                        </tr>
                        <tr>
                            <th style={{ textAlign: "center" }} >Parent's name:</th >
                            <td style={{ textAlign: "justify" }}>{patientInformationList.parentName}</td >
                        </tr>
                        <tr>
                            <th style={{ textAlign: "center" }} >Phone number:</th >
                            <td style={{ textAlign: "justify" }}>{patientInformationList.phoneNumber}</td >
                        </tr>
                        <tr>
                            <th style={{ textAlign: "center", width: "700px" }}>Email:</th>
                            <td style={{ textAlign: "justify" }}>{patientInformationList.email}</td>
                        </tr>
                        <tr>
                            <th style={{ textAlign: "center" }}>Medical Number:</th>
                            <td style={{ textAlign: "justify" }}>{patientInformationList.medicalIdNumber}</td>
                        </tr>
                        <tr>
                            <th style={{ textAlign: "center" }} > Address:</th >
                            <td style={{ textAlign: "justify" }}>{patientInformationList.city}</td >
                        </tr>

                        <tr>
                            <th style={{ textAlign: "center" }} > Known allergies:</th >
                            <td style={{ textAlign: "justify" }}>{patientInformationList.allergie}</td >
                        </tr>
                        <tr>
                            <th style={{ textAlign: "center" }} >Phone number:</th >
                            <td style={{ textAlign: "justify" }}>{patientInformationList.phoneNumber}</td >
                        </tr>
                        <tr>
                            <th style={{ textAlign: "center" }} >Gender:</th >
                            <td style={{ textAlign: "justify" }}>{patientInformationList.gender}</td >
                        </tr>
                        <tr>
                            <th style={{ textAlign: "center" }} > Place of birth:</th >
                            <td style={{ textAlign: "justify" }}>{patientInformationList.bornIn}</td >
                        </tr>
                        <tr>
                            <th style={{ textAlign: "center" }} >Is married:</th >
                            <td style={{ textAlign: "justify" }}>{patientInformationList.isMarried ? "MARRIED" : "NOT MARRIED"}</td >
                        </tr>
                        <tr>
                            <th style={{ textAlign: "center" }} >Maiden name:</th >
                            <td style={{ textAlign: "justify" }}>{patientInformationList.exLastname}</td >
                        </tr>
                    </tbody>


                </table>

            </div>


        );
    }

}


const mapStateToProps = (state) =>

    ({ patientInformationList: state.reducer.patientInformationList })

export default connect(mapStateToProps, { findOnePatient })(CheckPersonalInformationTable);