<template>
  <div id="app">
	<h1>Hello</h1>
  </div>
</template>

<script>
    export default {
        data() {
            return {}
        },
        mounted() {
            this.axios.get("http://localhost:57942/api/registration")
                .then(response => {
                    console.log(response.data);
                });
        }

    }
</script>