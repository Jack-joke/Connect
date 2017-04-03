cordova.define("com.inscripts.cometchatsdk.Readyui", function(require, exports, module) {
var exec = require('cordova/exec');

function Readyui() {

}

Readyui.prototype.setUrl = function(url){
    var arr = [];
    arr[0]=url;
    exec(function(result){

    },
    function(result){

    },"Readyui","seturl",arr);
}

Readyui.prototype.login = function(username,password){
    var arr = [];
    arr[0] = username;
    arr[1] = password;
    exec(function(result){

    },function(result){

    },"Readyui","login",arr);
}

Readyui.prototype.launchCometChat = function(){
    exec(function(result){

    },function(result){

    },"Readyui","launchCometChat",[]);
}

Readyui.prototype.chatWithMe = function(userid){
     var arr = [];
     arr[0] = userid;
     exec(function(result){

     },function(result){

     },"Readyui","chatwithme",arr);
}

 var readyui = new Readyui();
 module.exports = readyui;

});
