import React, { Component } from "react"
import { loadedAllPatientAppointments, advancedSearchPatientAppointments } from "../actions/actions"
import { connect } from "react-redux"
import { wrap } from "module";
import { showErrorToast, checkDateFormat } from "../utilities/Utilities"


class AppointmentsSearchAdvancedTable extends Component {
    state = {
        doctor: "",
        date: "",
        room: "",
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
            help: help,
            [name]: value
        })
    }

    componentDidMount() {
        debugger;
        this.props.advancedSearchPatientAppointments(this.state);;
    }

    render() {
        debugger;
        if (this.props.patientAppointmentsList === undefined) {

            return null;
        }

        const patientAppointmentsList = this.props.patientAppointmentsList;
        let doctor = ""
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
                            <option value="doctor">Doctor </option>
                            <option value="date">Date </option>
                            <option value="room">Room </option>
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
                                    defaultValue={this.state.help[index] == 0 ? this.state.restRoles[index] = "doctor" : this.state.restRoles[index]}
                                    onChange={this.handleArraysRoles}
                                    name="valueForArrays"
                                    value={this.state.restRoles[index]}
                                >
                                    <option value="doctor">Doctor </option>
                                    <option value="date">Date </option>
                                    <option value="room">Room </option>
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
                    <button className="btn btn-primary" onClick={this.addSearchField}>Add New Field</button>
                </div>

                <div className="btn-wrap align-right">
                    <button className="btn btn-primary" /*disabled={this.state.defaultLogicOperator.length <= this.state.forAdding || this.state.restRoles.length <= this.state.forAdding}*/ onClick={this.searchAppointments.bind(this)}>Search</button>
                </div>

                <table className='table allAppointments' >
                    <thead>
                        <tr>
                            <th style={{ textAlign: "left" }}>Doctor</th>
                            <th style={{ textAlign: "center" }}>Date</th>
                            <th style={{ textAlign: "center" }}>Room</th>
                        </tr>
                    </thead>
                    {patientAppointmentsList.map((f) => (
                        <tbody key={f.id}>
                            <tr key={f.id}>
                                <td style={{ textAlign: "left" }} >
                                    {f.doctor.firstName + " " + f.doctor.secondName}
                                </td>
                                <td style={{ textAlign: "center" }} > {f.date}</td >
                                <td style={{ textAlign: "center" }}>{f.roomId}</td >
                            </tr>
                        </tbody>
                    ))}
                </table>

            </div>


        );
    }

    searchAppointments() {
        debugger;
        var flag = 0;
        var i;
        if (this.state.firstRole == "date" && this.state.first !== "" && checkDateFormat(this.state.first)) {
            showErrorToast()
            flag = 1
        }
        for (i = 0; i < this.state.restRoles.lenght; i++) {
            if (this.state.restRoles[i] == "date" && this.state.rest[i] !== "" && checkDateFormat(this.state.rest[i])) {
                showErrorToast()
                flag = 1
            }
        }
        if (flag == 0) {
            this.props.advancedSearchPatientAppointments({ firstRole: this.state.firstRole, first: this.state.first, restRoles: this.state.restRoles, rest: this.state.rest, logicOperators: this.state.logicOperators })
        }
    }




}


const mapStateToProps = (state) =>

    ({ patientAppointmentsList: state.reducer.patientAppointmentsList })

export default connect(mapStateToProps, { loadedAllPatientAppointments, advancedSearchPatientAppointments })(AppointmentsSearchAdvancedTable);
