<template>
    <div id="home" style="        background-image: url('images/wgMLUS.jpg');
        background-repeat: no-repeat;
        background-size: 175% 100%;
        height: 1000px">

        <div class="container1">
            <div class="row justify-content-md-center">
                <div class="col-15"></div>
                <div class="col">
                    <button class="button" v-on:click="showNewTenderDiv">Create new tender</button>
                </div>
                <div class="col">
                    <button class="button" v-on:click="showActiveTenderDiv">Active tenders</button>
                </div>
                
                <div class="col-15"></div>
            </div>
        </div>

        <div v-if="showCreateNewTender" class="container">
            <div class="col-80">
                <div class="row justify-content-md-center">
                    <div class="col-15">
                        <label for="apiKey">Medication:</label>
                    </div>
                    <div class="col-45">
                        <select v-model="medicine">
                            <option v-for="med in medications" :key="med.id">
                                {{med.name}}
                            </option>
                        </select>
                    </div>


                </div>
                <div class="row justify-content-md-center">

                    <div class="col-15">
                        <label for="apiKey">Quantity:</label>
                    </div>
                    <div class="col-25">
                        <input type="number" v-model="quantity" name="quantity" placeholder="Enter quantity..">
                    </div>
                    <div class="col-25">
                        <button class="button1" v-on:click="addNewMedicine">+&nbsp;&nbsp;&nbsp;Add</button>
                    </div>
                </div>





                <div class="row justify-content-md-center">
                    <div class="col-15">
                        <label for="name">Tender is opened until:</label>
                    </div>
                    <div class="col-75">
                        <input type="text" id="endDate" v-model="endDate" placeholder="01/01/2020" />
                    </div>
                </div>
                <div class="row justify-content-md-center">
                    <div class="col-15"></div>
                    <div class="col-75">
                        <button class="button2" v-on:click="publishTender">Publish</button>
                    </div>
                </div>
                <div class="row">
                    <label v-if="sent" style="color:lightgreen;font-size:25px;">Successfully published tender!</label>
                    <label v-if="notSent" style="color:red;font-size:25px;">Error occurred!</label>
                </div>

            </div>
            <div class="col-20">
                <table id="tenderMedicine">
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

        </div>

        <div v-if="showActiveTender" class="container">
            <div class="col-10">
                <table id="tenderMedicine">
                    <thead>
                    <th>Tender id</th>
                    <th></th>
                    </thead>
                    <tr v-for="tender in activeTenders" :key="tender.id">
                        <td><button v-on:click="showTender($event, tender.id)">Tender {{tender.id}}</button></td>
                        <td></td>
                    </tr>
                </table>
            </div>
            <div class="col-78"></div>
            <div class="col-25"></div>
        </div>
        <div v-if="showConcreteTender" class="container">
            <div class="col-10">
                <table id="tenderMedicine">
                    <thead>
                    <th>Tender id</th>
                    </thead>
                    <tr v-for="tenderId in activeTenders" :key="tenderId.id">
                        <td><button v-on:click="showTender($event, tenderId.id)">Tender {{tenderId.id}}</button></td>
                    </tr>
                </table>
            </div>
            <div class="col-78">
                <div class="row justify-content-md-center">
                    <div class="col-15">
                        <label for="apiKey">Tender  {{this.choosenTender.id}}</label>
                    </div>

                </div>
                <div class="row justify-content-md-center">
                    <div class="col-18">
                        <label for="apiKey">Requested medicines:</label>
                    </div>
                </div>
                <div class="row justify-content-md-center">
                    <table id="tenderMedicine">
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

                <div class="row justify-content-md-center">
                    <div class="col-50">
                        <label for="name">Tender is opened until:          {{this.choosenTender.date}}</label>
                    </div>

                </div>
            </div>
            <div class="col-26">

                <table id="tenderMedicine">
                    <thead>
                    <th>Pharmacy offers for tender {{this.choosenTender.id}}</th>
                    <th></th>
                    </thead>
                    <tr v-for="offer in pharmacyOffers" :key="offer.id">
                        <td><button v-on:click="showPharmacyOffer($event, offer.pharmacyTenderOfferId)">Offer from   {{offer.pharmacyApi}}</button></td>
                        <td><button v-on:click="acceptPharmacyOffer($event, offer.pharmacyTenderOfferId)">Accept{{offer.pharmacyTenderOfferId}}</button></td>
                    </tr>
                </table>

            </div>

        </div>
        <div v-if="showConcreteOffer" class="container">
           
            <div class="col-70 justify-content-md-center">
                <div class="row justify-content-md-center">
                    <div class="col-15">
                        <label for="apiKey">Offer from     {{this.choosenOffer.pharmacyApi}}</label>
                    </div>

                </div>
                <div class="row justify-content-md-center">
                    <div class="col-18">
                        <label for="apiKey">Medicines:</label>
                    </div>
                </div>
                <div class="row justify-content-md-center">
                    <table id="tenderMedicine">
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
                <div class="row justify-content-md-center">
                    <div class="col-18">
                        <button class="button2" v-on:click="acceptPharmacyOffer($event, choosenOffer.pharmacyTenderOfferId)">Accept offer</button>
                    </div>
                </div>                  
                <div class="row">
                    <label v-if="acceptOffer" style="color:lightgreen;font-size:25px;">Successfully accepted offer!</label>
                    <label v-if="notAcceptOffer" style="color:red;font-size:25px;">Error occurred!</label>
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
                endDate :"",
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
                    pharmacyApi: "",
                    PharmacyTenderOfferId:0,
                },
                choosenOffer: {
                    medicinesWithQuantity: [],
                    id: 0,
                    pharmacyTenderOfferId:0,
                    pharmacyApi: ""
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
                
                this.axios.post('api/tender', tender)
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

                this.axios.get('api/tender/' + tenderId)
                    .then(res => {
                        this.choosenTender = res.data;
                    })
                    .catch(res => {
                        console.log(res);
                    });
                this.axios.get('api/tender/allPharmacyOffers/' + tenderId)
                    .then(response => {
                        this.pharmacyOffers = response.data;
                    });
                
            },
            showPharmacyOffer: function (event, offerId) {
                this.showConcreteOffer = true;

                this.axios.get('api/tender/pharmacyOffer/' + offerId + '/' + this.choosenTender.id)
                    .then(response => {
                        this.choosenOffer = response.data;
                    });
               
            },
            acceptPharmacyOffer: function (event, offerId) {

                this.axios.get('api/tender/acceptOffer/' + offerId + '/' + this.choosenTender.id)
                    .then(response => {
                        this.choosenOffer = response.data;
                        this.acceptOffer = true;
                        this.notAcceptOffer = false;
                    });
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
            this.axios.get('api/tender/active')
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
        background-color: #f2f2f2;
        font-size: 30px;
        width: 100%;
        margin : auto
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
        float: left;
        width: 25%;
        margin-top: 6px;
        margin-left: 6px;
        background-color: #f2f2f2;
    }
    .col-25 {
        float: left;
        width: 25%;
        margin-top: 6px;
        margin-left: 6px;
    }
    .col {
        float:left;
        width: 22%;
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
        width: 75%;
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
    }
    .button1 {
        background-color: darkseagreen;
        color: white;
        padding: 15px 32px;
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-size: 25px;
        width:200px;
        margin: 4px 2px;
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
        border:2px;
        border-color:azure;
    }

    th, td {
        text-align: left;
        padding: 8px;
    }

    tr:nth-child(even) {
        background-color: #ddd;
    }
   
    .row {
        width: 100%;
        margin-top: 3px;
    }
</style>

