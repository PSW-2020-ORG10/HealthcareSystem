import React, { Component } from "react"
import { loadedAllPatients } from "../actions/actions"
import { connect } from "react-redux"
import { wrap } from "module";
import axios from "axios";
import ReferralModal from "./ReferralModal"
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
                            <th style={{ textAlign: "center" }}></th>
                        </tr>
                    </thead>
                    {allPatientsList.map((f) => (
                        <tbody key={f}>
                            <tr key={f}>
                                <td style={{ textAlign: "center" }} >{f.firstName + ' ' + f.secondName}</td>
                                <td style={{ textAlign: "center" }}><button className="btn btn-danger">Block</button></td >
                            </tr>
                        </tbody>
                    ))}
                </table>
            </div>
        );
    }
}


const mapStateToProps = (state) =>

    ({ allPatientsList: state.reducer.allPatientsList })

export default connect(mapStateToProps, { loadedAllPatients })(MaliciousPatientTable);

