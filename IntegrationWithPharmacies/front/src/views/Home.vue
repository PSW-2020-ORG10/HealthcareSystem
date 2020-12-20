<template>
    <div id="home" style="background-image: url('images/wgMLUS.jpg');background-repeat: no-repeat;
  background-size: 175% 100%;  height: 1000px">
        <div id="header">
            <div id="header-text">
                <div id="header-title">
                   
                    <p id="header-desc"></p>
                  
                </div>
            </div>
            
        </div>
    </div>
</template>

<script>
export default {
  data() {
    return {
    }
  }
}
</script>

<style scoped>
    #mainbtn {
        color: #fff;
    }

    #header {
        display: flex;
        flex-direction: row;
        justify-content: flex-start;
        height: 100vh;
     
        
    }

    #header-text {
        display: flex;
        flex-direction: column;
        justify-content: center;
        padding-left: 10vw;
    }

    #title {
        font-weight: 500;
        font-size: 3.5rem;
        color: #fff;
    }

    #header-desc {
        font-size: 1.5rem;
        color: #fff;
    }

    #header-img {
        margin-left: auto;
        height: 100%;
        width: 50%;
    }

        #header-img img {
            width: 100%;
            height: 100%;
        }
</style>