<template>
    <div id="app">
        <content transition="slide-x-transition">
            <router-view></router-view>
        </content>
    </div>
</template>

<script>
    export default {
        name: 'App'
    };
</script>

<style>
</style>