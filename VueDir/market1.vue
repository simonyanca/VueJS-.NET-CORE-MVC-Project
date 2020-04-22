<template>
<section id= "root">
    <ul v-for="item in goodsArr" :key="item.Id" id="market1">
        <li class="Name">{{ item.Name }}</li>
        <li class="Description">{{ item.Description }}</li>
        <li class="Img"><img v-bind:src="reversedMessage(item.ImgData)"></li>
        <li> <button @click="logId(item.Id)"></button></li>
    </ul>
</section>
</template>
    <script>
        export default {
          data: function() {
          return {
              goodsArr: Array,
            };
            },
            mounted() {
                let self= this;
                fetch('http://localhost:56180/api/HomeApi/market1').then(function (response) {
                    response.json().then(function (parsedJson) {
                        self.goodsArr = parsedJson;
                        console.log(self.goodsArr);
                    })
                })
            },
            methods: {
                reversedMessage(toConvert) {
                    return "data:image/jpg;base64," + toConvert;
                },
                logId(id) {
                    console.log(id);
                }
            }
        };
    </script>
    <style scoped>
    html,body {
        box-sizing: border-box;
    }
    ul,li{
        padding: 0;
        margin: 0;
        list-style: none;
    }
    ul{
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: space-between;
        width: 20%;
        height: 90%;
    }
    #root{
        display: flex;
        flex-direction: row;
        justify-content: space-between;
        align-items: center;
        background-color: #3456A6;
    }
    .Name{
        font-size: 1.5rem;
    }
    .Description{
        font-size: 1rem;
    }
    .Img{
        width : 100%;
        align-content: center;
    }
    .Img img{
        display: block;
         margin-left: auto;
         margin-right: auto;
        max-height: 200px;
        width: auto;
        height: auto;
    }
    </style>
