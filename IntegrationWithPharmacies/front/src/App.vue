<template>
    <div id="app">
        <h1>Enter pharmacie's api key to register hospital</h1>
        <form border="1">
            <input type="text" v-model="pharmacyApiKey" />
        </form>
        <button v-on:click="saveApiKey">Save api key</button>
        <label v-if="unique">Successfully saved api key!</label>
        <label v-if="notUnique">This api key already exists!</label>
        <button v-on:click="getReport">Report about consumption of medicine</button>
        <label v-if="sent">Successfully sent report about consumption!</label>
        <label v-if="notSent">Error!Report about consumption can't be sent!</label>

    </div>
</template>

<script>
    export default {
        data: function () {
            return {
                pharmacyApiKey: "",
                unique: false,
                notUnique: false,
                emptyStringError: false,
                sent: false,
                notSent: false
            }
        },
        mounted() {
            this.axios.get("http://localhost:57942/api/registration")
                .then(response => {
                    console.log(response.data);
                });
        },
        methods: {
            saveApiKey: function () {
                const pharmacy = {
                    apiKey: this.pharmacyApiKey,
                    pharmacyId: 1253
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

            },
            getReport: function () { 
                this.axios.get('api/report/')
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

            }

        }

    }
</script>