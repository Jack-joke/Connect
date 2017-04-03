var exec = require('cordova/exec');

function Readyui() {

}

Readyui.prototype.showToast = function(aString){


 exec(function(result){
     /*alert("OK" + reply);*/
   },
  function(result){
    /*alert("Error" + reply);*/
   },"Readyui",aString,[]);
}

 var readyui = new Readyui();
 module.exports = readyui;
