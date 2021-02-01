<template>
    <div id="report" style="        background-image: url('images/bg2.jpg');
        background-repeat: no-repeat;
        background-size: 175% 100%;
        height: 1000px">
        <div style="        background-color: #1D8288">
            <h3 style="color:white;font-size: 35px;font-weight:bold">Send report to pharmacy about consumption of medicine in specified period</h3>
        </div>
        <div class="container">

            <div class="row">
                <div class="col-25">
                    <label for="name">Start date:</label>
                </div>
                <div class="col-75">
                    <input type="text" id="startDate" v-model="startDate" placeholder="01/01/2020" />
                </div>
            </div>
            <div class="row">
                <div class="col-25">
                    <label for="town">End date:</label>
                </div>
                <div class="col-75">
                    <input type="text" id="endDate" v-model="endDate" placeholder="01/01/2020">
                </div>
            </div>

            <div class="row">
                <label v-if="sent" style="color:blue;font-size:25px;">Successfully sent report to pharmacies!</label>
                <label v-if="notSent" style="color:red;font-size:25px;">Please try again later!</label>
                <label v-if="notFilled" style="color:red;font-size:25px;">You must enter start and end date in format  01/01/2020.</label>

            </div>


            <div class="row">
                <button class="button" v-on:click="send">Send</button>
            </div>

        </div>


    </div>
</template>

<script>
    export default {
        data() {
            return {
                startDate: "",
                endDate: "",
                pharmacy: "",
                sent: false,
                notSent: false,
                emptyStringError: false,
                notFilled : false

            }
        },
        methods: {
            send: function () {
                if (this.startDate === "" || this.endDate === "") {
                    this.sent = false;
                    this.notSent = false;
                    this.notFilled = true;
                    return;
                }
                const date = {
                    startDate: this.startDate,
                    endDate: this.endDate
                };
                this.axios.post('http://localhost:54679/api/report', date)
                    .then(res => {
                        this.sent = true;
                        this.notSent = false;
                        this.notFilled = false;
                        console.log(res);
                    })
                    .catch(res => {
                        this.sent = false;
                        this.notSent = true;
                        this.notFilled = false;

                        alert("Sorry, you can not currently send report, please try later.");
                        console.log(res);
                    })
            }

        }
    }
</script>

<style scoped>
    <style >
    * {
        box-sizing: border-box;
    }

    input[type=text], select, textarea {
        width: 100%;
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
    }

    .col-25 {
        float: left;
        width: 25%;
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
</style>