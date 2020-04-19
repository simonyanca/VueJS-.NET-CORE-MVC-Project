<template>
    <div id="market1">
        {{ message }},{{xyi}}
    </div>
</template>
<script>
    export default {
      data: function() {
      return {
          message: 'Some Message',
          xyi : "Another Message",
        };
       }
    };
</script>