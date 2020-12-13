import React, { Component } from "react"
import { loadedMaliciousPatients, blockPatient } from "../actions/actions"
import { connect } from "react-redux"
import { wrap } from "module";
import axios from "axios";
import ReferralModal from "./ReferralModal"
import BlockPatientButton from "./BlockPatientButton";
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { showErrorToast, checkDateFormat } from "../utilities/Utilities"

class MaliciousPatientTable extends Component {

    componentDidMount() {
        debugger;
        this.props.loadedMaliciousPatients();
    }

    render() {
        if (this.props.maliciousPatientsList === undefined) {

            return null;
        }
        const maliciousPatientsList = this.props.maliciousPatientsList;
        debugger;
        return (
            <div>
                <table className='table allPatients' >
                    <thead>
                        <tr>
                            <th style={{ textAlign: "center" }}>Patient</th>
                            <th style={{ textAlign: "center" }}>Phone number</th>
                            <th style={{ textAlign: "center" }}>Email</th>
                            <th style={{ textAlign: "center" }}></th>
                        </tr>
                    </thead>
                    {maliciousPatientsList.map((f) => (
                        <tbody key={f}>
                            <tr key={f}>
                                <td style={{ textAlign: "center" }} >{f.firstName + ' ' + f.secondName}</td>
                                <td style={{ textAlign: "center" }} >{f.phoneNumber}</td>
                                <td style={{ textAlign: "center" }} >{f.email}</td>
                                <td style={{ textAlign: "center" }}><BlockPatientButton patient={f}> </BlockPatientButton></td >
                            </tr>
                        </tbody>
                    ))}
                </table>
            </div>
        );
    }
    blockApp = (patient) => {
        toast.configure();

        toast.success("Patient successfully blocked!", {
            position: toast.POSITION.TOP_RIGHT
        });

        this.props.blockPatient(patient)
    }

}
    

const mapStateToProps = (state) =>

    ({ maliciousPatientsList: state.reducer.maliciousPatientsList })

export default connect(mapStateToProps, { loadedMaliciousPatients, blockPatient })(MaliciousPatientTable);

