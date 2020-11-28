import React, { Component } from "react"
import { loadedAllPatientPrescriptions, advancedSearchPatientPrescriptions } from "../actions/actions"
import { connect } from "react-redux"
import { wrap } from "module";
import { showErrorToastIsUsed, checkIsUsed } from "../utilities/Utilities"


class PrescriptionsSearchAdvancedTable extends Component {
    state = {
        medicines: "",
        isUsed: "",
        comment: "",
        doctor: "",
        searchFields: [],
        first: "",
        firstRole: "",
        rest: [],
        restRoles: [],
        forAdding: -1,
        valueForArrays: "",
        valueForOperators: "",
        logicOperators: [],
        objectToSend: {},
        defaultLogicOperator: "and",
        help: [],
        helpOper: [],
        helpRest: [],
        helpForFirst: false
    };

    addSearchField = (event) => {
        event.preventDefault()
        let searchFields = this.state.searchFields.concat([''])
        let help = this.state.help
        help[this.state.forAdding + 1] = 0
        let helpOper = this.state.helpOper
        helpOper[this.state.forAdding + 1] = 0
        let helpRest = this.state.helpRest
        helpRest[this.state.forAdding + 1] = 0
        this.setState(prevState => {
            return {
                searchFields: searchFields,
                forAdding: prevState.forAdding + 1,
                help: help,
                helpOper: helpOper,
                helpRest: helpRest
            }
        });   
    }

    handleChange = (event) => {
        const { name, value, type, checked } = event.target
        type === "checkbox" ? this.setState({
            [name]: checked
        }) : this.setState({
            [name]: value,
            helpForFirst: false,
            first: value
        })
    }

    handleChangeRole = (event) => {
        const { name, value, type, checked } = event.target
        type === "checkbox" ? this.setState({
            [name]: checked
        }) : this.setState({
            [name]: value,
            helpForFirst: true,
            firstRole: value
        })
    }

    handleLogicOperators = (event) => {
        const { name, value, type, checked } = event.target
        let logicOperators = this.state.logicOperators
        logicOperators[this.state.forAdding] = value
        let helpOper = this.state.helpOper
        helpOper[this.state.forAdding] = 1
        this.setState({
            logicOperators: logicOperators,
            helpOper: helpOper,
            [name]: value
        })
    }

    handleArrays = (event) => {
        const { name, value, type, checked } = event.target
        let rest = this.state.rest
        rest[this.state.forAdding] = value
        let helpRest = this.state.helpRest
        helpRest[this.state.forAdding] = 1
        this.setState({
            rest: rest,
            helpRest: helpRest,
            [name]: value
        })
    }

    handleArraysRoles = (event) => {
        const { name, value, type, checked } = event.target
        let restRoles = this.state.restRoles
        restRoles[this.state.forAdding] = value
        let help = this.state.help
        help[this.state.forAdding] = 1
        this.setState({
            restRoles: restRoles,
            help : help,
            [name]: value
        })
    }

    componentDidMount() {
        debugger;
        this.props.advancedSearchPatientPrescriptions(this.state);
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
                    <td>
                        <select
                            className="field"
                            value={this.state.firstRole}
                            onChange={this.handleChangeRole}
                            name="first"
                       
                        >
                            <option value="medicines">Medicines </option>
                            <option value="isUsed">Used </option>
                            <option value="comment">Comment </option>
                            <option value="doctor">Doctor</option>
                        </select>
                     </td>
                    <td>
                        <input
                            className="field"
                            type="text"
                            defaultValue={this.state.helpForFirst == true ? this.state.first = "" : this.state.first}
                            name={this.state.first}
                            onChange={this.handleChange}
                         />
                    </td>
                    <td>
                        <button className="btn btn-primary" onClick={this.addSearchField}>Add New Field</button>
                    </td>
                </div>


                <div>
                    {this.state.searchFields.map((searchFields, index) => (
                        <div className="field-wrap" key={index}>
                            <td>
                                <select
                                    className="field"
                                    defaultValue={this.state.helpOper[index] == 0 ? this.state.logicOperators[index] = "and" : this.state.logicOperators[index]}
                                    onChange={this.handleLogicOperators}
                                    name="valueForOperators"
                                    value={this.state.logicOperators[index]}
                                    
                                >                  
                                    <option value="and">And</option>
                                    <option value="or">Or</option> 
                                </select>
                            </td>
                            <td>
                                <select
                                    className="field"
                                    defaultValue={this.state.help[index]==0 ? this.state.restRoles[index] = "medicines" : this.state.restRoles[index]}
                                    onChange={this.handleArraysRoles}
                                    name="valueForArrays"
                                    value={this.state.restRoles[index]}
                                >
                                    <option value="medicines">Medicines </option>
                                    <option value="isUsed">Used </option>
                                    <option value="comment">Comment </option>
                                    <option value="doctor">Doctor</option>
                                </select>
                            </td>
                            <td>
                            <input
                                className="field" 
                                    type="text"
                                    defaultValue={this.state.helpRest[index] == 0 ? this.state.rest[index] = "" : this.state.rest[index]}
                                    name={this.state.rest[index]}
                                    onChange={this.handleArrays}
                                />
                            </td>
                        </div>
                    ))}
                </div>

                <div className="btn-wrap align-right">
                    <button className="btn btn-primary btn-block btn-lg mb-4" /*disabled={this.state.defaultLogicOperator.length <= this.state.forAdding || this.state.restRoles.length <= this.state.forAdding}*/ onClick={this.searchPrescriptions.bind(this)}>Search</button>
                </div>

                <table className='table allPrescriptions' >
                    <thead>
                        <tr>
                            <th style={{ textAlign: "left" }}>Medicine</th>
                            <th style={{ textAlign: "center" }}>Is Used</th>
                            <th style={{ textAlign: "center" }}>Comment</th>
                            <th style={{ textAlign: "center" }}>Doctor</th>
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
                                <td style={{ textAlign: "center" }}>{f.doctor.firstName + " " + f.doctor.secondName}</td >
                            </tr>
                        </tbody>
                    ))}
                </table>

            </div>


        );
    }

    searchPrescriptions() {
        var flag = 0;

        if (this.state.firstRole == "isUsed") {
            if (this.state.first !== "" && !checkIsUsed(this.state.first)) {
                showErrorToastIsUsed()
                flag = 1
            }
        }

        for (var i = 0; i < this.state.restRoles.length; i++) {
            if (this.state.restRoles[i] == "isUsed") {
                if (this.state.rest[i] !== "" && !checkIsUsed(this.state.rest[i])) {
                    showErrorToastIsUsed()
                    flag = 1
                }
            }
        }
        if (flag == 0) {
            this.props.advancedSearchPatientPrescriptions({ firstRole: this.state.firstRole, first: this.state.first, restRoles: this.state.restRoles, rest: this.state.rest, logicOperators: this.state.logicOperators })
        }
    }




}


const mapStateToProps = (state) =>

    ({ patientPrescriptionsList: state.reducer.patientPrescriptionsList })

export default connect(mapStateToProps, { loadedAllPatientPrescriptions, advancedSearchPatientPrescriptions })(PrescriptionsSearchAdvancedTable);