﻿<template>
    <div id="registration" style="background-image: url('images/bg2.jpg');background-repeat: no-repeat;
  background-size: 175% 100%;  height: 1000px">
        <table id="customers" style="width:2000px;">
            <tr>
                <th>Pharmacy</th>
                <th>Offer</th>
                <th>Published</th>
                <th>Valid until</th>
                <th></th>
            </tr>

            <tr v-for="action in this.actionsAndBenefits" v-bind:key="action.id">
                <td>{{action.pharmacyName}}</td>
                <td>{{action.text}}</td>
                <td>{{action.dateStamp}}</td>
                <td>{{action.dateAction}}</td>
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
               actionsAndBenefits: [],
            }
        },
        methods: {
            ignore: function () {
                this.notIgnored = false;
            }


        },
        mounted() {
            this.axios.get('http://localhost:54679/api/actionsAndBenefits')
                .then(res => {
                    if (res.status != 200) {
                        alert("Sorry, actions and benefits are not currently available, please try later.")
                        return;
                    }
                    this.actionsAndBenefits = res.data;
                    console.log(this.actionsAndBenefits);

                })
                .catch(res => {
                    alert("Sorry, actions and benefits are not currently available, please try later.");
                    console.log(res);
                })
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