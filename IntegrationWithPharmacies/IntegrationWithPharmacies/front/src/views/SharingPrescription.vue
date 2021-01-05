<template>
    <div id="sharePrescription" style="        background-image: url('images/wgMLUS.jpg');
        background-repeat: no-repeat;
        background-size: 175% 100%;
        height: 1000px">
        <div style="        background-color: #1D8288">
            <h3 style="color:white;font-size: 35px;font-weight:bold;align-content:center;margin: 0 auto;">Share patient's prescription with pharmacy</h3>
        </div>
        <div class="container">

            <div class="row">
                <div class="col-15">
                    <label for="name">Patient:</label>
                </div>
                <div class="col-45">
                    <select v-model="selectedPatient">
                        <option v-for="pat in patients" :value="pat" :key="pat.id" v-on:select="showMedId">
                            {{pat.firstName}}&nbsp;{{pat.secondName}}&nbsp;&nbsp;MedID: {{pat.medicalIdNumber}}
                        </option>

                    </select>

                    <div v-if="hidden" Selected: {{selectedPatient}}></div>
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
                <button class="button2" v-on:click="specification">Show selected medicine specification </button>

            </div>
            <div class="row">
                <button class="button2" v-on:click="specificationGrpc">Show selected medicine specification - GRPC</button>

            </div>

            <div v-if="showSpecification" class="row">
                <div class="col-25" style="border:thick solid #000000">
                    {{medSpecification}}
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
                <button class="button3" v-on:click="showAvailability">Show availability</button>

            </div>
            <div class="row">
                <table id="customers" v-if="showTable">
                    <thead>
                        <tr style="font-weight: bold; ">
                            <th style="width: 200px;" scope="col">Name of pharmacy</th>
                            <th style="width: 200px;" scope="col">Medicine</th>

                            <th style="width: 200px;" scope="col">Avaible</th>
                            <th style="width: 200px;" scope="col"></th>
                            <th style="width: 200px;" scope="col"></th>

                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="pharmacy in pharmacies" :key="pharmacy.api">
                            <td>{{pharmacy.name}}</td>
                            <td>{{selected}}</td>
                            <td><div style="background-color:lightgreen">YES</div></td>
                            <td><button v-on:click="sendHttp($event, pharmacy.api)">Send(Http)</button></td>
                            <td><button v-on:click="sendSftp($event, pharmacy.api)">Send(Sftp)</button></td>
                        </tr>

                    </tbody>
                </table>
                <div v-if="showTableAvailability" class="row">
                    <div class="col-25" style="border:thick solid #000000">
                        Medicine is not available.
                    </div>
                </div>
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
                hidden: false,
                medSpecification: "",
                showTable: false,
                showTableAvailability : false
              
            }
        },
        methods: {
          
            specification: function () {
                this.showSpecification = true;
                this.axios.get('api/sharingPrescription/http/description/' + this.selected)
                    .then(res => {
                        this.medSpecification = res.data;
                    })
                    .catch(res => {
                        console.log(res);
                    });
            },

            specificationGrpc: function () {
                this.showSpecification = true;
                this.axios.get('api/sharingPrescription/grpc/description/' + this.selected)
                    .then(res => {
                        this.medSpecification = res.data;
                    })
                    .catch(res => {
                        console.log(res);
                    });
            },

            showAvailability: function () {
                this.showTable = true;
          
                this.axios.get('api/sharingPrescription/http/medicineAvailability/'+this.selected + "_"+this.quantity)
                    .then(res => {
                        this.pharmacies = res.data;
                        this.showTableAvailability = false;
                    })
                    .catch(res => {
                        this.showTableAvailability = true;
                        console.log(res);
                    });
            }, 
            showMedId: function () {
                this.medIdNumber = this.selectedPatient.medicalIdNumber;
            },
            sendHttp: function (event,pharmacy2) {
                const data = {
                    pharmacy: pharmacy2,
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
            sendSftp: function (event, pharmacy2) {
                const data = {
                    pharmacy: pharmacy2,
                    name: this.selectedPatient.firstName,
                    surname: this.selectedPatient.secondName,
                    medicalIDNumber: this.selectedPatient.medicalIdNumber,
                    medicine: this.selected,
                    quantity: this.quantity,
                    usage: this.explanation
                };
                this.axios.post('api/sharingPrescription', data)
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


        },
        mounted() {
            this.axios.get('api/sharingPrescription/medicinesIsa')
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

    #customers {
        font-family: Arial, Helvetica, sans-serif;
    }

        #customers td, #customers th {
            border: 1px solid #ddd;
            padding: 8px;
            background-color: #ddd;
            font-size: 28px;
        }

        #customers tr:nth-child(even) {
            background-color: #ddd;
            font-size: 28px;
        }

        #customers tr:hover {
            background-color: #ddd;
            font-size: 28px;
        }

        #customers th {
            padding-top: 12px;
            padding-bottom: 12px;
            text-align: left;
            background-color: #1D8288;
            color: white;
        }

    input[type=text], select, textarea, input[type=number] {
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
        background-color: lightgreen;
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

    .button3 {
        background-color: lightgreen;
        border: double;
        color: white;
        padding: 15px 32px;
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-size: 25px;
        float: initial;
        margin: 4px 2px;
        cursor: pointer;
    }
</style>

