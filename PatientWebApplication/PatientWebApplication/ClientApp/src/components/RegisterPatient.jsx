import React, { Component } from "react"
import { patientRegistered } from "../actions/actions"
import axios from "axios";
import { connect } from "react-redux"
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { showErrorToast, checkDateFormat, checkEmailFormat, showErrorToastEmail } from "../utilities/Utilities"
import "../css/app.css"

class RegisterPatient extends Component {
    state = {
        patient: {
            firstName: "",
            secondName: "",
            gender: "Male",
            uniqueCitizensidentityNumber: "",
            dateOfBirth: "",
            phoneNumber: "",
            medicalIdNumber: "",
            allergie: "",
            city: "",
            email: "",
            password: "",
            isMarried: false,
            bornIn: "",
            parentName: "",
            exLastname: "",
            file: ""
        },
        file: null,
        fileName: "",
        fileUrl: null
                
    };

    handleChange = (event) => {
        var { name, value, type, checked } = event.target
        name = "this.state.patient." + name
        console.log(this.state.patient.firstName)
        console.log(name)
        type === "checkbox" ? this.setState({
            [name]: checked
        }) : this.setState({
            [name]: value
        })
    }
    
    handleChange2 = async(event) => {
        this.setState({
            fileUrl: URL.createObjectURL(event.target.files[0]),
            

        })
        const formData = new FormData();
        
        formData.append("formFile", event.target.files[0]);
        formData.append("fileName", event.target.files[0].name);

        

        var dummyThis = this;
        try {
            const res = await axios({

                method: 'post',
                url: 'http://localhost:60198/api/patientuser/image',
                data: formData,
                headers: { 'Content-Type': 'multipart/form-data' }
            })
                .then(function (response) {
                    
                    var patient = { ...dummyThis.state.patient };
                    patient.file = response.data;
                    dummyThis.setState({ patient });
                    console.log(response);
                })
                .catch(function (response) {
                    
                    console.log(response);






                });
            console.log(res);
        } catch (ex) {
            console.log(ex);
        }
    }
    updateFirstName(evt) {
        var patient = { ...this.state.patient };
        patient.firstName = evt.target.value;
        this.setState({ patient });
    }

    updateSurname(evt) {
        var patient = { ...this.state.patient };
        patient.secondName = evt.target.value;
        this.setState({ patient });
    }
    updateGender(evt) {
        var patient = { ...this.state.patient };
        patient.gender = evt.target.value;
        this.setState({ patient });
    }
    updateMedId(evt) {
        var patient = { ...this.state.patient };
        patient.medicalIdNumber = evt.target.value;
        this.setState({ patient });
    }
    updateBirthday(evt) {
        var patient = { ...this.state.patient };
        patient.dateOfBirth = evt.target.value;
        this.setState({ patient });
    }
    updateCity(evt) {
        var patient = { ...this.state.patient };
        patient.city = evt.target.value;
        this.setState({ patient });
    }
    updateEmail(evt) {
        var patient = { ...this.state.patient };
        patient.email = evt.target.value;
        this.setState({ patient });
    }
    updatePassword(evt) {
        var patient = { ...this.state.patient };
        patient.password = evt.target.value;
        this.setState({ patient });
    }
    updatePhone(evt) {
        var patient = { ...this.state.patient };
        patient.phoneNumber = evt.target.value;
        this.setState({ patient });
    }
    updateBorn(evt) {
        var patient = { ...this.state.patient };
        patient.bornIn = evt.target.value;
        this.setState({ patient });
    }
    updateParent(evt) {
        var patient = { ...this.state.patient };
        patient.parentName = evt.target.value;
        this.setState({ patient });
    }
    updateAllergie(evt) {
        var patient = { ...this.state.patient };
        patient.allergie = evt.target.value;
        this.setState({ patient });
    }
    updateUcin(evt) {
        var patient = { ...this.state.patient };
        patient.uniqueCitizensidentityNumber = evt.target.value;
        this.setState({ patient });
    }
    updateMarried(evt) {
        var patient = { ...this.state.patient };
        patient.isMarried = evt.target.checked;
        this.setState({ patient });
    }
    updateMaiden(evt) {
        var patient = { ...this.state.patient };
        patient.exLastname = evt.target.value;
        this.setState({ patient });
    }


    render() {
        
        return (
            <div>
                <form action="http://localhost:60198/register-patient">

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Name:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.patient.firstName}
                            name="firstName"                          
                            onChange={(e)=>this.updateFirstName(e)}
                        />
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Surname:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.patient.secondName}
                            name="secondName"
                            onChange={(e) => this.updateSurname(e)}
                        />
                    </div>

                    <div className="field-wrap">
                        <label className="label">Gender: </label>

                        <select
                            className="field"
                            defaultValue={this.state.patient.gender}
                            onChange={(e) => this.updateGender(e)}
                            name="gender"
                        >
                            <option value=""></option>
                            <option value="Male">Male </option>
                            <option value="Female">Female </option>
                        </select>
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Medical Record ID:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.patient.medicalIdNumber}
                            name="medicalIdNumber"
                            onChange={(e) => this.updateMedId(e)}
                        />
                    </div>
                 

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Birth date:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.patient.dateOfBirth}
                            name="dateOfBirth"
                            placeholder="mm/dd/yyyy"
                            onChange={(e) => this.updateBirthday(e)}
                        />
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Address:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.patient.city}
                            name="city"
                            onChange={(e) => this.updateCity(e)}
                        />
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Email:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.patient.email}
                            name="email"
                            placeholder="email@address.com"
                            onChange={(e) => this.updateEmail(e)}
                        />
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                           Password:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.patient.password}
                            name="password"
                            onChange={(e) => this.updatePassword(e)}
                        />
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Phone number:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.patient.phoneNumber}
                            name="phoneNumber"
                            onChange={(e) => this.updatePhone(e)}
                        />
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Place of birth:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.patient.bornIn}
                            name="bornIn"
                            onChange={(e) => this.updateBorn(e)}
                        />
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Parents name:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.patient.parentName}
                            name="parentName"
                            onChange={(e) => this.updateParent(e)}
                        />
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Allergie:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.patient.allergie}
                            name="allergie"
                            onChange={(e) => this.updateAllergie(e)}
                        />
                    </div>
                   

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Unique Citizens identity Number:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.patient.uniqueCitizensidentityNumber}
                            name="uniqueCitizensidentityNumber"
                            onChange={(e) => this.updateUcin(e)}
                        />
                    </div>

                    

                    <div className="field-wrap">
                        <label className="label">
                            <input
                                type="checkbox"
                                name="isMarried"
                                checked={this.state.patient.isMarried}
                                onChange={(e) => this.updateMarried(e)}
                            /> Married
                        </label>
                    </div>

                    <div className="field-wrap">
                        <label className="label" htmlFor="">
                            Maiden name:
                        </label>
                        <input
                            className="field"
                            type="text"
                            value={this.state.patient.exLastname}
                            name="exLastname"
                            disabled={((this.state.patient.gender.toString() === "Female") && (this.state.patient.isMarried)) ? "" : "disabled"} 
                            onChange={(e) => this.updateMaiden(e)}
                        />
                    </div>

                    <div>
                        <input type="file" onChange={this.handleChange2} />
                        <img src={this.state.fileUrl} className="photo" />
                    </div>

                    
                    <div className="btn-wrap align-right">
                        <button disabled={!this.state.patient.firstName || !this.state.patient.secondName || this.state.patient.gender == "" || !this.state.patient.allergie || !this.state.patient.bornIn || !this.state.patient.city || !this.state.patient.dateOfBirth || !this.state.patient.email || !this.state.patient.medicalIdNumber || !this.state.patient.parentName || !this.state.patient.password || !this.state.patient.phoneNumber || !this.state.patient.uniqueCitizensidentityNumber} className="btn btn-primary" onClick={this.createRegistration.bind(this)}>Register</button>
                    </div>
                </form>
            </div>
        )
    }

    createRegistration() {
        if (this.state.patient.dateOfBirth !== "" && checkDateFormat(this.state.patient.dateOfBirth)) {
            showErrorToast()
        } else if (this.state.patient.email !== "" && checkEmailFormat(this.state.patient.email)){
            showErrorToastEmail()
        }
        else {
            toast.configure();


            toast.success("Registration successful!", {
                position: toast.POSITION.TOP_RIGHT
            });





            console.log(this.state.patient);

            this.props.patientRegistered(this.state.patient)


        }
    }

}

const mapStateToProps = (state) => ({

});

export default connect(mapStateToProps, { patientRegistered })(RegisterPatient);
