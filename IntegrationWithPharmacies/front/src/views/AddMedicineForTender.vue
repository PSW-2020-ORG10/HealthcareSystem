<template>
    <div id="report" style="background-image: url('images/wgMLUS.jpg');background-repeat: no-repeat;
  background-size: 175% 100%;  height: 1000px">
        <div style="        background-color: #1D8288">
            <h3 style="color:white;font-size: 35px;font-weight:bold"></h3>
        </div>
        <div style="margin: 0; position: absolute;top :45%; left: 50%; transform: translate(-50%, -50%);">

            <div id="form">
                <h3>Fill form for tender:</h3>
                <div class="row">
                    <div class="col-25">
                        <label for="name">Name of medicine:</label>
                    </div>
                    <div class="col-75">
                        <input type="text" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-25">
                        <label for="town">Quantity:</label>
                    </div>
                    <div class="col-75">
                        <input type="text">
                    </div>
                </div>

                <button class="button2" >Add medicine on list for tender</button>
               
                
            </div>

        </div>


    </div>
</template>
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


    .button1 {
        color: #ffffff;
        border: 8px;
        border-radius: 10%;
        font: bold;
        font-size: 22px;
        width: 250px;
        text-decoration: underline;
    }
</style>