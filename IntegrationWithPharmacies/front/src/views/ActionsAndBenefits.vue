<template>
    <div id="registration" style="background-image: url('images/wgMLUS.jpg');background-repeat: no-repeat;
  background-size: 175% 100%;  height: 1000px">
        <table id="customers" style="width:2000px;">
            <tr>
                <th>Pharmacy</th>
                <th>Medication</th>
                <th>Offer</th>
                <th>Date</th>
                <th></th>
            </tr>
            <tr>
                <td>Jankovic 2, Novi Sad</td>
                <td>Andol</td>
                <td>Do kraja nedelje na popustu od 30%!</td>
                <td>30/11/2020</td>
                <td><button v-on:click="ignore">Ignore</button></td>
            </tr>
            <tr>
                <td>Jankovic 2, Novi Sad</td>
                <td>Andol</td>
                <td>Do kraja nedelje na popustu od 30%!</td>
                <td>30/11/2020</td>
                <td><button v-on:click="ignore">Ignore</button></td>
            </tr>

            <tr v-for="action in actionsAndBenefits" v-if="action.removed === false">
                <td>{{action.pharmacy}}</td>
                <td>{{action.description}}</td>
                <td>{{action.date}}</td>
                <td><button v-on:click="ignore($event, action)" v-if="notIgnored">Ignore</button></td>
            </tr>

        </table>


    </div>
</template>

<script>
    export default {
        data() {
            return {
               notIgnored  : true,
                actionsAndBenefits: null
            }
        },
        methods: {
            ignore: function () {
                this.notIgnored = false;

            }

        },
        mounted() {
           
        }
    }
</script>

<style scoped>
    <style >
    #customers {
        font-family: Arial, Helvetica, sans-serif;
        width: 2500px;
    }

    #customers td, #customers th {
        border: 1px solid #ddd;
        padding: 8px;
        background-color: #ddd;
        font-size : 28px;
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
</style>