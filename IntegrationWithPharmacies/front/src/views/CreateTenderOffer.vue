<template>
    <div id="home" style="        background-image: url('images/wgMLUS.jpg');
        background-repeat: no-repeat;
        background-size: 175% 100%;
        height: 1000px">


        <div v-if="showWhenOpening" class="container">
            <div class="col-10">
                <table id="tenderMedicine">
                    <thead>
                    <th>Choose tender</th>
                    </thead>
                    <tr v-for="tender in activeTenders" :key="tender.id">
                        <td><button v-on:click="showTender($event, tender.id)">Tender {{tender.id}}</button></td>
                    </tr>
                </table>
            </div>
            <div class="col-80"></div>
        </div>

        <div v-if="showConcreteTender" class="container">
            <div class="col-10">
                <table id="tenderMedicine">
                    <thead>
                    <th>Choose tender</th>
                    </thead>
                    <tr v-for="tender in activeTenders" :key="tender.id">
                        <td><button v-on:click="showTender($event, tender.id)">Tender {{tender.id}}</button></td>
                    </tr>
                </table>
            </div>
         
            <div class="col-90">
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
                        <th>Available quantity</th>
                        <th>Price</th>

                        </thead>
                        <tbody>
                            <tr v-for="medicine in choosenTender.medicinesWithQuantity" :key="medicine.name">
                                <td>
                                    <label>{{medicine.medicineName}}</label>
                                </td>
                                <td>
                                    <label>{{medicine.quantity}}</label>
                                </td>
                                <td>
                                    <input type="text" v-model="medicine.availableQuantity">
                                </td>
                                <td>
                                    <input type="text" v-model="medicine.price">
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
                <div class="row justify-content-md-center">
                    <div class="col-25">
                        <label for="name">Pharmacy api: </label>
                    </div>
                    <div class="col-25">
                        <input type="text" v-model="choosenTender.pharmacyApi">
                    </div>
                </div>
                <div class="row justify-content-md-center">
                    
                    <div class="col-75">
                        <button class="button2" v-on:click="sendOffer">Send offer</button>
                    </div>
                </div>
                <div class="row">
                    <label v-if="sent" style="color:lightgreen;font-size:25px;">Successfully sent offer!</label>
                    <label v-if="notSent" style="color:red;font-size:25px;">Error occurred!</label>
                </div>

            </div>

            



        </div>
    </div>

</template>

<script>export default {
        data() {
            return {
                sent: false,
                notSent: false,
                activeTenders: [],
                showConcreteTender: false,
                showWhenOpening:true,
                choosenTender: {
                    id: "",
                    date: "",
                    medicinesWithQuantity: [],
                    pharmacyApi: ""
                }
            }
        },
        methods: {
            showTender: function (event, tenderId) {
                this.showWhenOpening = false;
                this.showConcreteTender = true;
                this.axios.get('api/tender/' + tenderId)
                    .then(res => {
                        this.choosenTender = res.data;
                    })
                    .catch(res => {
                        console.log(res);
                    })
            },
            sendOffer: function () {
                this.axios.post('api/tender/offer', this.choosenTender)
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
            this.axios.get('api/tender/active')
                .then(response => {
                    this.activeTenders = response.data;
                });

        }

    }</script>

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
        margin: auto
    }

    .container1 {
        border-radius: 5px;
        background-color: #1D8288;
        font-size: 30px;
        width: 100%;
        margin: auto
    }

    .col-25 {
        float: left;
        width: 25%;
        margin-top: 6px;
    }
    .col-10 {
        float: left;
        width: 15%;
        margin-top: 6px;
        margin-right: 6px;
        background-color: #f2f2f2;
    }
    .col {
        float: left;
        width: 22%;
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

    .col-45 {
        width: 45%;
    }

    .col-75 {
        float: left;
        width: 75%;
        margin-top: 6px;
    }

    .col-80 {
        float: left;
        width: 65%;
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
        width: 200px;
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
        border: 2px;
        border-color: azure;
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

