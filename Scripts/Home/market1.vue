<template>
    <div id="market1">
        {{ message }},{{mes}}
    </div>
</template>
<script>
    export default {
      data: function() {
      return {
          message: 'Some Message',
          mes : "Another Message",
        };
       }
    };
</script>