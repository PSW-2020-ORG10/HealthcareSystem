<template>
    <div id="availability" style="background-image: url('images/wgMLUS.jpg');background-repeat: no-repeat;
  background-size: 175% 100%;  height: 1000px">
        <div style="        background-color: #1D8288">
            <h3 style="color:white;font-size: 35px;font-weight:bold;margin: 0 auto;">Search medicine availability in pharmacies</h3>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-25">
                    <label for="name">Name of medication:</label>
                </div>
                <div class="col-75">
                    <input type="text" id="name" name="name" v-model="name" placeholder="Name of medication..">
                </div>
            </div>
            <div class="row">
                <button class="button" v-on:click="search">Search</button>
            </div>




        </div>

    </div>
</template>

<script>
    export default {
        data() {
            return {
                name: ""
            }
        },
        methods: {
            search: function () {
                
            }

        },
        mounted() {

        }
    }
</script>

<style scoped>
    <style >
    * {
        box-sizing: content-box;
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