<template>
    <div id="home" style="        background-image: url('images/wgMLUS.jpg');
        background-repeat: no-repeat;
        background-size: 175% 100%;
        height: 1000px">
        <h1>Our tenders</h1>

        <div>
           
            <button class="button" v-on:click="create">Create new tender</button>
            <button class="button">Active tenders</button>
            <button class="button">Past tenders</button>


        </div>

    </div>
</template>

<script>
    export default {
        data() {
            return {
               

            }
        },
        methods: {
            create: function () {
                window.location.href = "/newTender";
               

            }

        }

    }
</script>

<style scoped>
    #mainbtn {
        color: #fff;
        background-color: #0000CD
    }

    label {
        font-size: 22px;
        font-weight: bold;
    }

    h1 {
        align-content: flex-start;
        font-weight: bold;
        font-size: 38px;
        margin: 0;
        position: absolute;
        left: 50%;
        transform: translate(-50%, -50%);
        color: #1D8288;
    }

    

    #title {
        font-weight: 500;
        font-size: 3.5rem;
        color: #fff;
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
        width: 500px;
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
    .a {
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

   

      

    
    

   

    div {
        border-radius: 5px;
        background-color: #f2f2f2;
        padding: 20px;
    }
</style>