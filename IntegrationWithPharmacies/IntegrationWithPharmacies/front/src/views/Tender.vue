<template>
    <div id="home" style="        background-image: url('images/bg2.jpg');
        background-repeat: no-repeat;
        background-size: 175% 100%;
        height: 1000px">

        <div class="container1">
            <div class="row justify-content-md-center">
                <div class="col-15"></div>
                <div class="col">
                    <button class="button" v-on:click="showNewTenderDiv">Create new tender</button>
                </div>
                <div class="col-15"></div>
                <div class="col">
                    <button class="button" v-on:click="showActiveTenderDiv">Active tenders</button>
                </div>

                <div class="col-15"></div>
            </div>
        </div>
        <label class="h11" v-if="showCreateNewTender">Publish tender</label>
        <div v-if="showCreateNewTender" class="container5" style="background-color:whitesmoke">
            <h3>Fill the form for tender publishing:</h3>

            <div class="row" style="margin-top:30px">
                <div class="row justify-content-md-center">
                    <div class="col-25">
                        <label for="apiKey">Medication:</label>
                    </div>
                    <div class="col-75">
                        <select v-model="medicine">
                            <option v-for="med in medications" :key="med.id">
                                {{med.name}}
                            </option>
                        </select>
                    </div>


                </div>
                <div class="row justify-content-md-center">

                    <div class="col-25">
                        <label for="apiKey">Quantity:</label>
                    </div>
                    <div class="col-75">
                        <input type="number" v-model="quantity" name="quantity" placeholder="Enter quantity..">
                    </div>

                </div>
                <div class="row">
                    <div class="col-25">
                    </div>
                    <div class="col-45">
                        <button class="button1" style="margin-left:3px" v-on:click="addNewMedicine">&nbsp;&nbsp;+&nbsp;&nbsp;</button>
                    </div>
                </div>
                <hr v-if="showTable" />





            </div>
            <div class="row" style="margin-top:25px">
                <table id="tenderMedicine" v-if="showTable">
                    <thead>
                    <th>Medicine name</th>
                    <th>Quantity</th>
                    </thead>
                    <tr v-for="med in medicationQuantityList" :key="med.medicineName">
                        <td>{{med.medicineName}}</td>
                        <td>{{med.quantity}}</td>
                    </tr>
                </table>
            </div>
            <hr />
            <div class="row justify-content-md-center" style="margin-top:25px">
                <div class="col-25">
                    <label for="name">Tender is opened until:</label>
                </div>
                <div class="col-75">
                    <input type="text" id="endDate" v-model="endDate" placeholder="01/01/2020" />
                </div>
            </div>
            <div class="row justify-content-md-center">
                <div class="col-25"></div>
                <div class="col-75">
                    <button class="button2" v-on:click="publishTender">Publish</button>
                </div>
            </div>
            <div class="row">
                <label v-if="sent" style="color:lightgreen;font-size:25px;">Successfully published tender!</label>
                <label v-if="notSent" style="color:red;font-size:25px;">Error occurred!</label>
            </div>

        </div>
        <div>
            <div v-if="showActiveTender" class="container">
                <div class="col-15" style="margin-right:7px;">
                    <table id="tenderMedicine" style="align-content:center;">

                        <th style="color: #1D8288;width:300px;font-weight:bold">Choose tender:</th>

                        <tr class="red" v-for="tender in activeTenders" :key="tender.id">
                            <td><button class="button3" v-on:click="showTender($event, tender.id)">Tender {{tender.id}}</button></td>
                        </tr>
                    </table>
                </div>
                <div class="col-78"></div>
                <div class="col-25"></div>
            </div>
            <div v-if="showConcreteTender" class="container">
                <div class="col-15" style="margin-right:7px;">
                    <table id="tenderMedicine" style="align-content:center;">

                        <th style="color: #1D8288;width:300px;font-weight:bold">Choose tender:</th>

                        <tr v-for="tenderId in activeTenders" :key="tenderId.id">
                            <td><button class="button3" v-on:click="showTender($event, tenderId.id)">Tender {{tenderId.id}}</button></td>
                        </tr>
                    </table>
                </div>
                <div class="col-78" style="margin-top:33px">
                    <h1 for="apiKey" style="color: #1D8288;font-weight:bold;font-size:40px;text-align:center">Tender  {{this.choosenTender.id}}</h1>

                    <hr />
                    <div class="row justify-content-md-center" style="text-align:center;margin-bottom:10px">

                        <label style="color: black;font-weight:bold;font-size:40px;align-content:center" for="apiKey">Requested medicines:</label>
                        <hr />
                    </div>
                    <div class="row justify-content-md-center">
                        <table id="tenderMedicine" style="border:4px;border-color:white">
                            <thead>
                            <th>Medicine</th>
                            <th>Quantity</th>

                            </thead>
                            <tbody>
                                <tr v-for="medicine in choosenTender.medicinesWithQuantity" :key="medicine.name">
                                    <td>
                                        <label>{{medicine.medicineName}}</label>
                                    </td>
                                    <td>
                                        <label>{{medicine.quantity}}</label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>

                    </div>

                    <div class="row justify-content-md-center" style="margin-top:20px">
                        <div class="col-50">
                            <label for="name" style="font-weight:bold;font-style:italic">Tender is opened until:          {{this.choosenTender.date}}</label>
                        </div>

                    </div>
                </div>
                <div class="col-26" style="margin-left:35px;margin-top:3px">
                    <table id="tenderMedicine" >
                        <thead>
                        <th style="color: #1D8288;width:300px;font-weight:bold">Pharmacy offers for tender&nbsp; {{this.choosenTender.id}}:</th>


                        </thead>
                        <tr v-for="offer in pharmacyOffers" :key="offer.id">
                            <td><button class="button4" v-on:click="showPharmacyOffer($event, offer.pharmacyTenderOfferId)">Offer from &nbsp;{{offer.pharmacyName}}</button></td>
                            
                        </tr>
                    </table>

                </div>

            </div>

        </div>


        <!-- The Modal -->
        <div v-if="showConcreteOffer" class="modal">

            <!-- Modal content -->
            <div class="modal-content">
                <div class="modal-header" style="align-content:center">
                    <span v-on:click="closeModal" class="close">&times;</span>
                    <h1>Offer from  &nbsp;   {{this.choosenOffer.pharmacyName}}</h1>
                </div>
                <div class="modal-body">
                    <div class="row justify-content-md-center">

                    </div>
                    <div class="row justify-content-md-center">
                        <table id="tenderMedicine" style="font-size:25px">
                            <thead>
                            <th>Medicine</th>
                            <th>Quantity</th>
                            <th>Available quantity</th>
                            <th>Price</th>
                            </thead>
                            <tbody>
                                <tr v-for="medicine in choosenOffer.medicinesWithQuantity" :key="medicine.medicineName">
                                    <td>
                                        <label>{{medicine.medicineName}}</label>
                                    </td>
                                    <td>
                                        <label>{{medicine.quantity}}</label>
                                    </td>
                                    <td>
                                        <label>{{medicine.availableQuantity}}</label>
                                    </td>
                                    <td>
                                        <label>{{medicine.price}}</label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>

                    </div>



                </div>
                <div class="modal-footer">
                    <div class="row justify-content-md-center">

                        <button class="button2" v-on:click="acceptPharmacyOffer($event, choosenOffer.pharmacyTenderOfferId)">Accept&nbsp;✔</button>

                    </div>
                    <div class="row">
                        <label v-if="acceptOffer" style="color:lightgreen;font-size:25px;">Successfully accepted offer!</label>
                        <label v-if="notAcceptOffer" style="color:red;font-size:25px;">Error occurred!</label>
                    </div>
                </div>
            </div>

        </div>








    </div>

</template>

<script>

    export default {
        data() {
            return {
                showCreateNewTender: false,
                medications: [],
                medicineName: "",
                quantity: "",
                medicationQuantityList: [],
                medicine: "",
                endDate: "",
                showTable: false,
                sent: false,
                notSent: false,
                showActiveTender: false,
                activeTenders: [],
                pharmacyOffers: [],
                showConcreteTender: false,
                showConcreteOffer: false,
                acceptOffer: false,
                notAcceptOffer:false,
                choosenTender: {
                    id: "",
                    date: "",
                    medicinesWithQuantity: [],
                    pharmacyName: "",
                    PharmacyTenderOfferId:0,
                },
                choosenOffer: {
                    medicinesWithQuantity: [],
                    id: 0,
                    pharmacyTenderOfferId:0,
                    pharmacyName: ""
                }
            }
        },
        methods: {
            showNewTenderDiv: function () {
                this.showCreateNewTender = true;
                this.showActiveTender = false;
                this.showConcreteTender = false;
                this.showConcreteOffer = false;
            },
            showActiveTenderDiv: function () {
                this.showCreateNewTender = false;
                this.showActiveTender = true;
                this.showConcreteTender = false;
                this.showConcreteOffer = false;


            },
            addNewMedicine: function () {
                this.showTable = true;
                const medicineWithQuantity = {
                    medicineName: this.medicine,
                    quantity: this.quantity,
                };
                this.medicationQuantityList.push(medicineWithQuantity)
            },
            publishTender: function () {
                const tender = {
                    medicinesWithQuantity: this.medicationQuantityList,
                    date: this.endDate,
                };

                this.axios.post('http://localhost:54679/api/tender', tender)
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
            showTender: function (event, tenderId) {
                this.showConcreteTender = true;
                this.showCreateNewTender = false;
                this.showActiveTender = false;
                this.showConcreteOffer = false;

                this.axios.get('http://localhost:54679/api/tender/' + tenderId)
                    .then(res => {
                        this.choosenTender = res.data;
                    })
                    .catch(res => {
                        console.log(res);
                    });
                this.axios.get('http://localhost:54679/api/tender/allPharmacyOffers/' + tenderId)
                    .then(response => {
                        this.pharmacyOffers = response.data;
                    });

            },
            showPharmacyOffer: function (event, offerId) {
                this.showConcreteOffer = true;

                this.axios.get('http://localhost:54679/api/tender/pharmacyOffer/' + offerId + '/' + this.choosenTender.id)
                    .then(response => {
                        this.choosenOffer = response.data;
                    });

            },
            acceptPharmacyOffer: function (event, offerId) {

                this.axios.get('http://localhost:54679/api/tender/acceptOffer/' + offerId + '/' + this.choosenTender.id)
                    .then(response => {
                        this.choosenOffer = response.data;
                        this.acceptOffer = true;
                        this.notAcceptOffer = false;
                    });
            },
            closeModal: function () {
                this.showConcreteOffer = false;
            }

        },
        mounted() {
            this.axios.get('http://localhost:54679/api/sharingPrescription/medicinesIsa')
                .then(res => {
                    this.medications = res.data;
                })
                .catch(res => {
                    console.log(res);
                });
            this.axios.get('http://localhost:54679/api/tender/active')
                .then(response => {
                    this.activeTenders = response.data;
                });



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
        font-size: 30px;
        width: 100%;
        margin: auto
    }
    .container5 {
        border-radius: 5px;
        font-size: 30px;
        width: 60%;
        margin: auto;
        margin-top : 5%;
        padding : 15px;
    }
    .container1 {
        border-radius: 5px;
        background-color: #1D8288;
        font-size: 30px;
        width: 100%;
        margin: auto;
    }

    .container4 {
        border-radius: 5px;
        background-color: #e9ebe4;
        font-size: 30px;
        width: 80%;
        margin: auto;
        margin-left: 15px;
    }

    .col-26 {
        float: right;
        width: 25%;
        margin-top: 6px;
        margin-left: 10px;
    }

    .col-25 {
        float: left;
        width: 22%;
        margin-top: 6px;
        margin-left: 6px;
    }

    .col {
        float: left;
        width: 22%;
    }

    .row5 {
        width: 100%;
        background-color: lightgray;
        height: auto;
    }

    .col-10 {
        float: left;
        width: 10%;
        margin-top: 6px;
        margin-right: 6px;
        background-color: #f2f2f2;
    }

    .col-15 {
        float: left;
        width: 15%;
        margin-top: 6px;
    }

    .col-18 {
        float: left;
        width: 30%;
        margin-top: 6px;
    }

    .col-45 {
        float: left;
        width: 45%;
        margin-top: 6px;
    }

    .col-45 {
        width: 45%;
    }

    .col-75 {
        float: left;
        width: 73%;
        margin-top: 6px;
    }

    .col-70 {
        float: left;
        width: 75%;
        margin-top: 6px;
        margin-left: 20px;
    }

    .col-80 {
        float: left;
        width: 65%;
        margin-top: 6px;
        background-color: #f2f2f2;
    }

    .col-78 {
        float: left;
        width: 58%;
        margin-top: 6px;
        background-color: #f2f2f2;
    }

    .col-90 {
        float: left;
        width: 80%;
        margin-top: 6px;
        margin-left: 10px;
        background-color: #f2f2f2;
    }

    .col-20 {
        float: left;
        width: 34%;
        margin-top: 6px;
        margin-left: 6px;
        background-color: #f2f2f2;
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
        background-color: darkseagreen;
        color: white;
        padding: 15px 32px;
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-size: 25px;
        float: right;
        margin: 4px 2px;
        cursor: pointer;
        width: 300px;
    }

    

    .button3 {
        background-color: none;
        color: #1D8288;
        padding: 15px 32px;
        text-align: center;
        text-decoration: underline;
        display: inline-block;
        font-size: 25px;
        float: left;
        margin: 4px 2px;
        cursor: pointer;
        width: 250px;
    }

    .button4 {
        background-color: none;
        color: #1D8288;
        padding: 15px 32px;
        text-align: center;
        text-decoration: underline;
        display: inline-block;
        font-size: 25px;
        float: left;
        margin: 4px 2px;
        cursor: pointer;
        width: 350px;
    }

    .button1 {
        background-color: darkseagreen;
        color: white;
        padding: 15px 32px;
        text-align: center;
        float:left;
        text-decoration: none;
        display: inline-block;
        font-size: 25px;
        width: 150px;
        cursor: pointer;
    }

    .button2 {
        background-color: darkseagreen;
        color: white;
        padding: 15px 32px;
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-size: 25px;
        width: 350px;
        margin: 4px 2px;
        cursor: pointer;
    }

    table {
        width: 100%;
        border: 2px;
        border-color: azure;
    }

    th, td {
        text-align: left;
        padding: 8px;
    }


    .row {
        width: 100%;
        margin-top: 3px;
    }

    .modal { /* Hidden by default */
        position: fixed; /* Stay in place */
        z-index: 1; /* Sit on top */
        padding-top: 100px; /* Location of the box */
        left: 0;
        top: 140px;
        width: 100%; /* Full width */
        height: 100%; /* Full height */
        overflow: auto; /* Enable scroll if needed */
        background-color: rgb(0,0,0); /* Fallback color */
        background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
    }

    /* Modal Content */
    .modal-content {
        position: center;
        background-color: whitesmoke;
        margin: auto;
        padding: 0;
        border: 1px solid #888;
        width: 80%;
        box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
        -webkit-animation-name: animatetop;
        -webkit-animation-duration: 0.4s;
        animation-name: animatetop;
        animation-duration: 0.4s
    }

    /* Add Animation */
    @-webkit-keyframes animatetop {
        from {
            top: -300px;
            opacity: 0
        }

        to {
            top: 0;
            opacity: 1
        }
    }

    @keyframes animatetop {
        from {
            top: -300px;
            opacity: 0
        }

        to {
            top: 0;
            opacity: 1
        }
    }

    /* The Close Button */
    .close {
        color: white;
        float: right;
        font-size: 50px;
        font-weight: bold;
    }

        .close:hover,
        .close:focus {
            color: #000;
            text-decoration: none;
            cursor: pointer;
        }

    .modal-header {
        padding: 2px 16px;
        background-color: #1D8288;
        color: white;
    }

    .modal-body {
        padding: 2px 16px;
    }

    .modal-footer {
        padding: 2px 16px;
        background-color: #1D8288;
        color: white;
    }
    h3 {
        font-weight: bold;
        font-size: 25px;
        color: #0D184F;
    }
     .h11 {
        align-content: center;
        font-weight: bold;
        font-size: 38px;
        margin: 0;
        position: absolute;
        left: 50%;
        top : 25%;
        transform: translate(-50%, -50%);
        color: #1D8288;
    }
</style>

