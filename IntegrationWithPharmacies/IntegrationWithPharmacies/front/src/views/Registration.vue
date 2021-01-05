<template>
    <div id="registration" style="background-image: url('images/wgMLUS.jpg');background-repeat: no-repeat;
  background-size: 175% 100%;  height: 1000px">
        <div style="        background-color: #1D8288">
            <h3 style="color:white;font-size: 35px;font-weight:bold">Register pharmacy in hospital system</h3>
        </div>
        <div class="container">

            <div class="row">
                <div class="col-25">
                    <label for="name">Name of pharmacy:</label>
                </div>
                <div class="col-75">
                    <input type="text" id="name" name="name" v-model="name" placeholder="Name of pharmacy..">
                </div>
            </div>
            <div class="row">
                <div class="col-25">
                    <label for="town">Town:</label>
                </div>
                <div class="col-75">
                    <input type="text" id="town" name="town" v-model="town" placeholder="Town..">
                </div>
            </div>
            <div class="row">
                <div class="col-25">
                    <label for="apiKey">Pharmacy api key:</label>
                </div>
                <div class="col-75">
                    <input type="text" v-model="pharmacyApiKey" name="pharmacyApiKey" placeholder="Enter pharmacy api key..">
                </div>

            </div>
            <div class="row">
                <label v-if="unique" style="color:lightgreen;font-size:25px;">Successfully saved api key!</label>
                <label v-if="notUnique" style="color:red;font-size:25px;">This api key already exists!</label>
            </div>




            <div class="row">
                <button class="button" v-on:click="register">Register</button>
            </div>
        </div>


    </div>
</template>

<script>
    export default {
        data() {
            return {
                pharmacyApiKey: "",
                unique: false,
                notUnique: false,
                emptyStringError: false,
                town: "",
                name : ""
               
            }
        },
        methods: {
               register: function () {
                const pharmacy = {
                    apiKey: this.pharmacyApiKey,
                    pharmacyId: 1253,
                    name: this.name,
                    town : this.town
                };
                this.axios.post('api/registration/', pharmacy)
                    .then(res => {
                        this.unique = true;
                        this.notUnique = false;
                        console.log(res);
                    })
                    .catch(res => {
                        this.notUnique = true;
                        this.unique = false;
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
        margin:10px;
        padding: 12px;
        border: 1px solid #ccc;
        border-radius: 4px;
        resize: vertical;
        font-size:25px;
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
        font-size:30px;
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