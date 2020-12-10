import React, { Component } from "react"
import { loadedAllPatients, blockPatient } from "../actions/actions"
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
        this.props.loadedAllPatients();
    }

    render() {
        if (this.props.allPatientsList === undefined) {

            return null;
        }
        const allPatientsList = this.props.allPatientsList;
        debugger;
        return (
            <div>
                <table className='table allPatients' >
                    <thead>
                        <tr>
                            <th style={{ textAlign: "center" }}>Patient</th>
                            <th style={{ textAlign: "center" }}>Number of canceled appointment</th>
                            <th style={{ textAlign: "center" }}></th>
                        </tr>
                    </thead>
                    {allPatientsList.map((f) => (
                        <tbody key={f}>
                            <tr key={f}>
                                <td style={{ textAlign: "center" }} >{f.firstName + ' ' + f.secondName}</td>
                                <td style={{ textAlign: "center" }} ></td>
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

    ({ allPatientsList: state.reducer.allPatientsList })

export default connect(mapStateToProps, { loadedAllPatients, blockPatient })(MaliciousPatientTable);

