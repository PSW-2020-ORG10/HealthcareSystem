import React, { Component } from "react"
import { blockPatient } from "../actions/actions"
import { connect } from "react-redux"
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

class BlockPatientButton extends Component {


    render() {
        return (
            <React.Fragment>
                <button className="btn btn-danger" disabled={this.props.patient.isBlocked} onClick={this.blockApp.bind(this)}>Block</button>
            </React.Fragment>
        )
    }

    blockApp() {
        toast.configure();

        toast.success("Patient successfully blocked!", {
            position: toast.POSITION.TOP_RIGHT
        });
        debugger;
        this.props.blockPatient(this.props.patient.id); 
        window.location.href = "http://localhost:60198/malicious-patient";
    }
}

const mapStateToProps = (state) => ({

});

export default connect(mapStateToProps, { blockPatient })(BlockPatientButton);