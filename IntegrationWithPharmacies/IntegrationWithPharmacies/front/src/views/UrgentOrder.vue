<template>
    <div id="home" style="        background-image: url('images/wgMLUS.jpg');
        background-repeat: no-repeat;
        background-size: 175% 100%;
        height: 1000px">
        <h1>Share urgent procurement</h1>

        <div style="margin: 0; position: absolute;top :45%; left: 50%; transform: translate(-50%, -50%);">

           <div id="form">
                <h3>Fill form for urgent procurement:</h3>
                <label for="fname">Medicine name:</label>
                <select v-model="medicine">
                    <option v-for="med in medications" :key="med.id">
                        {{med.name}}
                    </option>
                </select>
                <label for="lname">Quantity:</label>
                <input type="number" id="quantity" name="quantity" v-model="quantity" placeholder="quantity...">
                <label style="color:sandybrown;font-size:15px;font-weight:normal">When it's urgent, procurement will be sent to first found pharmacy that has requested medicine.</label><br />
                <button class="button" v-on:click="sendHttp">Send HTTP</button>
                <button class="button" v-on:click="sendGRpc">Send gRPC</button>
                <div class="row">
                    <label v-if="sent" style="color:green;font-size:25px;">Successfully sent to pharmacy {{pharmacy}} </label>
                    <label v-if="notSent" style="color:red;font-size:25px;">Sorry. There is no pharmacy with this quantity of selected medicine!</label>
                </div>
            </div>

        </div>




    </div>


</template>

<script>
export default {
        data() {
                return {
                medications : [],
                medicine: "",
                quantity : 0,
                sent: false,
                notSent: false,
                showForm : false,
                showReport: false,
                pharmacy : ""
      
                }
        },
        methods: {
            sendHttp: function () {
                this.axios.get('api/urgentOrder/http/' + this.medicine + "_" + this.quantity)
                    .then(res => {
                        this.pharmacy = res.data;
                        this.sent = true;
                        this.notSent = false;

                    })
                    .catch(res => {
                        this.sent = false;
                        this.notSent = true;
                        console.log(res);
                    });              
            },
            sendGRpc: function () {
                this.axios.get('api/urgentOrder/grpc/' + this.medicine + "_" + this.quantity)
                    .then(res => {
                        this.pharmacy = res.data;
                        this.sent = true;
                        this.notSent = false;

                    })
                    .catch(res => {
                        this.sent = false;
                        this.notSent = true;
                        console.log(res);
                    });       
            }
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
    #mainbtn {
        color: #fff;
        background-color: #0000CD
    }
    label {
        font-size:22px;
        font-weight : bold;
    }
    h1 {
        align-content: center;
        font-weight: bold;
        font-size: 38px;
        margin: 0;
        position: absolute;
        left: 50%;
        transform: translate(-50%, -50%);
        color: #1D8288;
    }
    h3 {
        font-weight: bold;
        font-size: 25px;
        color: #0D184F;
    }
   
    #title {
        font-weight: 500;
        font-size: 3.5rem;
        color: #fff;
    }

    .klasa {
        position: absolute;
        top: 50%;
        left: 50%;
        -moz-transform: translateX(-50%) translateY(-50%);
        -webkit-transform: translateX(-50%) translateY(-50%);
        transform: translateX(-50%) translateY(-50%);
    }

    #header-desc {
        font-size: 1.5rem;
        color: #fff;
    }

    #paragraph {
        height: 10vh;
    }

    .button2 {
        background-color: #19b65f;
        border: double;
        color: white;
        padding: 15px 32px;
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-size: 25px;
        margin: 4px 2px;
        cursor: pointer;
        width: 300px;
        border: 8px;
        border-radius: 10%;
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
        margin: 4px 2px;
        cursor: pointer;
        color: white;
        width: 320px;
        border: 8px;
    }

    .button1 {
        color: #ffffff;
        border: 8px;
        border-radius: 10%;
        font: bold;
        font-size: 22px;
        width: 250px;
        text-decoration: underline;
    }

    ul {
        list-style-type: none;
        margin: 0;
        padding: 0;
        overflow: hidden;
        background-color: #0D184F;
    }

    li {
        float: left;
    }

        li a {
            display: block;
            color: white;
            text-align: center;
            padding: 14px 16px;
            text-decoration: none;
        }

            li a:hover:not(.active) {
                background-color: rgb(132, 204, 223);
            }

    .active {
        background-color: #334de4;
    }

    input[type=text], select {
        width: 100%;
        padding: 12px 20px;
        margin: 8px 0;
        display: inline-block;
        border: 1px solid #ccc;
        border-radius: 4px;
        box-sizing: border-box;
    }

    input[type=number], select {
        width: 100%;
        padding: 12px 20px;
        margin: 8px 0;
        display: inline-block;
        border: 1px solid #ccc;
        border-radius: 4px;
        box-sizing: border-box;
    }

    input[type=submit] {
        width: 100%;
        background-color: #4CAF50;
        color: white;
        padding: 14px 20px;
        margin: 8px 0;
        border: none;
        border-radius: 4px;
        cursor: pointer;
    }

        input[type=submit]:hover {
            background-color: #45a049;
        }

    div {
        border-radius: 5px;
        background-color: #f2f2f2;
        padding: 20px;
    }
</style>