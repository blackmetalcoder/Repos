<template>
  <div class="app">
    <img src="./assets/logo.png">
    <h1>{{Message}}</h1>
    <h2>Related Links</h2>
    <ul>
      <li><a target="_blank" href="https://vuejs.org">Core Vue Docs</a></li>
      <li><a target="_blank" href="https://forum.vuejs.org">Vue Forum</a></li>
      <li><a target="_blank" href="https://github.com/NeutroniumCore/Neutronium">Neutronium Project</a></li>
      <li><a target="_blank" href="https://github.com/NeutroniumCore/neutronium-vue">Neutronium Vue client</a></li>
      <li><a target="_blank" href="https://github.com/NeutroniumCore/Neutronium.Template/blob/master/README.md">Template documentation</a></li>
    </ul>
  </div>
</template>

<script>
const props={
  viewModel: Object,
  __window__: Object
};

export default {
  name: 'app',
  props,
  data () {
    return this.viewModel
  }
}
</script>

<style>
.app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

img {
  height: 300px;
}

h1, h2 {
  font-weight: normal;
}

ul {
  list-style-type: none;
  padding: 0;
}

li {
  display: inline-block;
  margin: 0 10px;
}

a {
  color: #42b983;
}
</style>
