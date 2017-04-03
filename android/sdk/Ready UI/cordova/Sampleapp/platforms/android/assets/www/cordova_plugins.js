cordova.define('cordova/plugin_list', function(require, exports, module) {
module.exports = [
    {
        "file": "plugins/cordova-plugin-whitelist/whitelist.js",
        "id": "cordova-plugin-whitelist.whitelist",
        "runs": true
    },
    {
        "file": "plugins/com.inscripts.cometchatsdk/www/Readyui.js",
        "id": "com.inscripts.cometchatsdk.Readyui",
        "clobbers": [
            "Readyui"
        ]
    }
];
module.exports.metadata = 
// TOP OF METADATA
{
    "cordova-plugin-whitelist": "1.2.1",
    "com.inscripts.cometchatsdk": "0.2.12"
};
// BOTTOM OF METADATA
});