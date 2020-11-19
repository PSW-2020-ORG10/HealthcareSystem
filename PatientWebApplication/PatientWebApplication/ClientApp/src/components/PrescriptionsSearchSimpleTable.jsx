import React, { Component } from "react"
import { loadedAllPatientPrescriptions, simpleSearchPatientPrescriptions } from "../actions/actions"
import { connect } from "react-redux"
import { wrap } from "module";

class PrescriptionsSearchSimpleTable extends Component {
    state = {
        medicines: "",
        isUsed: "",
        comment: ""
    };

    handleChange = (event) => {
        const { name, value, type, checked } = event.target
        type === "checkbox" ? this.setState({
            [name]: checked
        }) : this.setState({
            [name]: value
        })
    }

    componentDidMount() {
        debugger;
        this.props.simpleSearchPatientPrescriptions(this.state);
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
                
                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Medicine:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.medicines}
                            name="medicines"
                            
                            onChange={this.handleChange}
                        />
                    </div>

                    <div className="field-wrap">
                        <label className="label">Is used: </label>

                        <select
                            className="field"
                            value={this.state.isUsed}
                            onChange={this.handleChange}
                            name="isUsed"
                            >
                                <option value=""> </option>
                                <option value="True">Used </option>
                                <option value="False">Not used </option>
                        </select>
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Comment:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.comment}
                            name="comment"
                            
                            onChange={this.handleChange}
                        />
                    </div>

                    <div className="btn-wrap align-right">
                        <button className="btn btn-primary" onClick={this.searchPrescriptions.bind(this)}>Search</button>
                    </div>
                
                <table className='table allPrescriptions' >
                    <thead>
                        <tr>
                            <th style={{ textAlign: "left" }}>Medicine</th>
                            <th style={{ textAlign: "center" }}>Is Used</th>
                            <th style={{ textAlign: "center" }}>Comment</th>
                        </tr>
                    </thead>
                    {patientPrescriptionsList.map((f) => (
                        <tbody key={f.id}>
                            <tr key={f.id}>
                                <td style={{ textAlign: "left" }} >
                                    {f.medicines !== undefined ? f.medicines.map((m, i) => (
                                        f.medicines.length === i + 1 ? 
                                            [medicines, m.name, ''].join('') :
                                        [medicines, m.name, ', '].join('')
                                    )) : medicines = "Empty"}
                                </td>
                                <td style={{ textAlign: "center" }} > {f.isUsed ? "Used" : "Not used"}</td >
                                <td style={{ textAlign: "center" }}>{f.comment}</td >
                            </tr>
                        </tbody>
                    ))}
                </table>

            </div>


        );
    }

    searchPrescriptions() {
        this.props.simpleSearchPatientPrescriptions(this.state)
    }

    


}


const mapStateToProps = (state) =>

    ({ patientPrescriptionsList: state.reducer.patientPrescriptionsList })

export default connect(mapStateToProps, { loadedAllPatientPrescriptions, simpleSearchPatientPrescriptions})(PrescriptionsSearchSimpleTable);