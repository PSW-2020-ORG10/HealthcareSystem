<template>
    <div id="sharePrescription" style="background-image: url('images/wgMLUS.jpg');background-repeat: no-repeat;
  background-size: 175% 100%;  height: 1000px">
        <div style="        background-color: #1D8288">
            <h3 style="color:white;font-size: 35px;font-weight:bold;align-content:center;margin: 0 auto;">Share patient's prescription with pharmacy</h3>
        </div>
        <div class="container">

            <div class="row">
                <div class="col-25">
                    <label for="name">Patient's name:</label>
                </div>
                <div class="col-45">
                    <select v-model="selectedPatient">
                        <option v-for="pat in patients" :value="pat" :key="pat.id" v-on:select="showMedId">
                            {{pat.firstName}}&nbsp;{{pat.secondName}}&nbsp;&nbsp;|MedID: {{pat.medicalIdNumber}}
                        </option>

                    </select>
                    <hr>
                 <div v-if="hidden"   Selected: {{selectedPatient}}></div>
                </div>
                
            </div>
          
           
            <div class="row">
                <div class="col-15">
                    <label for="apiKey">Medication:</label>
                </div>
                <div class="col-45">
                    <select v-model="selected" v-on:select="showAvailability">
                        <option v-for="med in medications" :key="med.id">
                            {{med.name}}
                        </option>
                    </select>
                </div>

                <div class="col-15">
                    <label for="apiKey">Quantity:</label>
                </div>
                <div class="col-25">
                    <input type="number" v-model="quantity" name="quantity" placeholder="Enter quantity..">
                </div>

            </div>

            <div class="row">
                <button class="button2 col-25" v-on:click="specification">Show selected medicine specification</button>
                <div class="col-75" v-for="pharmacy in pharmacies" :key="pharmacy.id">
                    {{pharmacy.name}}
                    Apoteka Jankovic 2, Novi Sad
                </div>
            </div>
            <div v-if="showSpecification" class="row">
                <div class="col-25" style="border:thick solid #000000">
                    Specifikacija lijeka
                </div>
            </div>
            <div class="row">
                <div class="col-25">
                    <label for="name">Additional explanation:</label>
                </div>
                <div class="col-75">
                    <input type="text" id="explanation" name="explanation" v-model="explanation" placeholder="Explanation..">
                </div>
            </div>

            <div class="row">
                <button class="button" v-on:click="send">Send prescription to pharmacy</button>
            </div>
            <div class="row">
                <label v-if="sent" style="color:lightgreen;font-size:25px;">Successfully sent prescription!</label>
                <label v-if="notSent" style="color:red;font-size:25px;">Error occurred!</label>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                name: "",
                surname: "",
                medIdNumber: "",
                medications: [],
                quantity: 0,
                sent: false,
                notSent: false,
                showSpecification: false,
                selected: null,
                pharmacies: [], 
                explanation: "",
                patients: [],
                selectedPatient: null,
                hidden : false
            }
        },
        methods: {
            send: function () {
                const data = {
                    name: this.selectedPatient.firstName,
                    surname: this.selectedPatient.secondName,
                    medicalIDNumber: this.selectedPatient.medicalIdNumber,
                    medicine: this.selected,
                    quantity: this.quantity,
                    usage: this.explanation
                };
                this.axios.post('api/sharingPrescription/http', data)
                    .then(res => {
                        this.sent = true;
                        this.notSent = false;
                        console.log(res);
                    })
                    .catch(res => {
                        this.sent = false;
                        this.notSent = true;
                        console.log(res);
                    })

            },
            specification: function () {
                this.showSpecification = true;
            },
            showAvailability: function () {
                var parametres = {
                    medication: this.selected,
                    quantity: this.quantity
                }
                this.axios.post('api/sharingPrescription', parametres)
                    .then(res => {
                        this.pharmacies = res.pharmacies;
                    })
                    .catch(res=> {
                        console.log(res);
                    });
            }, 
            showMedId: function () {
                this.medIdNumber = this.selectedPatient.medicalIdNumber;
            }


        },
        mounted() {
            this.axios.get('api/sharingPrescription')
                .then(res => {
                    this.medications = res.data;
                })
                .catch(res => {
                    console.log(res);
                });
            this.axios.get('api/sharingPrescription/patients')
                .then(res => {
                    this.patients = res.data;
                    alert("OK");
                })
                .catch(res => {
                    alert("NOT OK");
                    console.log(res);
                })
        }
    }
</script>

<style scoped>
    <style >
    * {
        box-sizing: content-box;
    }

    input[type=text], select, textarea,input[type=number] {
        width: 80%;
        margin: 10px;
        padding: 12px;
        border: 1px solid #ccc;
        border-radius: 4px;
        resize: vertical;
        font-size: 25px;
    }

    label {
        padding: 12px 12px 12px 0;
        display: inline-block;
    }

    input[type=submit] {
        background-color: #4CAF50;
        color: white;
        padding: 12px 20px;
        border: none;
        border-radius: 4px;
        cursor: pointer;
    }

        input[type=submit]:hover {
            background-color: #45a049;
        }

    .container {
        border-radius: 5px;
        background-color: #f2f2f2;
        padding: 20px;
        font-size: 30px;
        width: 70%;
        margin: 0 auto;
    }

    .col-25 {
        float: left;
        width: 25%;
        margin-top: 6px;
    }
    .col-15 {
        float: left;
        width: 15%;
        margin-top: 6px;
    }
    .col-45 {
        float: left;
        width: 45%;
        margin-top: 6px;
    }

    .col-75 {
        float: left;
        width: 75%;
        margin-top: 6px;
    }

    /* Clear floats after the columns */
    .row:after {
        content: "";
        display: table;
        clear: both;
    }

    /* Responsive layout - when the screen is less than 600px wide, make the two columns stack on top of each other instead of next to each other */
    @media screen and (max-width: 600px) {
        .col-25, .col-75, input[type=submit] {
            width: 100%;
            margin-top: 0;
        }
    }

    .button {
        background-color: #1D8288;
        border: double;
        color: white;
        padding: 15px 32px;
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-size: 25px;
        float: right;
        margin: 4px 2px;
        cursor: pointer;
    }
    .button2 {
        background-color: #FFEF33;
        border: double;
        color: white;
        padding: 15px 32px;
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-size: 25px;
        float: left;
        margin: 4px 2px;
        cursor: pointer;
    }
</style>