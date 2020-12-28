<template>
    <div id="home" style="        background-image: url('images/wgMLUS.jpg');
        background-repeat: no-repeat;
        background-size: 175% 100%;
        height: 1000px">

        <div class="container">
            <div class="row justify-content-md-center">

                <div class="col">
                    <button class="button" v-on:click="showNewTenderDiv">Create new tender</button>
                </div>
                <div class="col">
                    <button class="button">Active tenders</button>
                </div>
                <div class="col">
                    <button class="button">Past tenders</button>
                </div>
            </div>
        </div>

        <div v-if="showCreateNewTender" class="container">
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

                <div class="col-15">
                    <label for="apiKey">Quantity:</label>
                </div>
                <div class="col-25">
                    <input type="number" v-model="quantity" name="quantity" placeholder="Enter quantity..">
                </div>
                <div class="col-25">
                    <button class="button" v-on:click="addNewMedicine">Add</button>
                </div>
            </div>


            <div class="row justify-content-md-center">
                <table id="tenderMedicine">
                    <tr v-for="med in medicationQuantityList" :key="med.medicineName">
                        <td>{{med.medicineName}}</td>
                        <td>{{med.quantity}}</td>
                    </tr>
                </table>
            </div>

            <div class="row justify-content-md-center">
                <div class="col-25">
                    <label for="name">Tender is open until:</label>
                </div>
                <div class="col-75">
                    <input type="text" id="endDate" v-model="endDate" placeholder="01/01/2020" />
                </div>
            </div>
            <div class="row justify-content-md-center">
                <div class="col-25">
                    <label for="name">Publish tender</label>
                </div>
                <div class="col-75">
                    <button class="button" v-on:click="publishTender">Publish</button>
                </div>
            </div>
            <div class="row">
                <label v-if="sent" style="color:lightgreen;font-size:25px;">Successfully published tender!</label>
                <label v-if="notSent" style="color:red;font-size:25px;">Error occurred!</label>
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
                notSent: false
            }
        },
        methods: {
            showNewTenderDiv: function () {
                this.showCreateNewTender = true
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

        },
        mounted() {
            this.axios.get('api/sharingPrescription/medicinesIsa')
                .then(res => {
                    this.medications = res.data;
                })
                .catch(res => {
                    console.log(res);
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

