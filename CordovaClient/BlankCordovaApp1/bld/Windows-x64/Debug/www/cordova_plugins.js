cordova.define('cordova/plugin_list', function(require, exports, module) {
module.exports = [
    {
        "file": "plugins/cordova-plugin-device/www/device.js",
        "id": "cordova-plugin-device.device",
        "pluginId": "cordova-plugin-device",
        "clobbers": [
            "device"
        ]
    },
    {
        "file": "plugins/cordova-plugin-device/src/windows/DeviceProxy.js",
        "id": "cordova-plugin-device.DeviceProxy",
        "pluginId": "cordova-plugin-device",
        "merges": [
            ""
        ]
    },
    {
        "file": "plugins/cordova-plugin-inappbrowser/www/inappbrowser.js",
        "id": "cordova-plugin-inappbrowser.inappbrowser",
        "pluginId": "cordova-plugin-inappbrowser",
        "clobbers": [
            "cordova.InAppBrowser.open",
            "window.open"
        ]
    },
    {
        "file": "plugins/cordova-plugin-inappbrowser/src/windows/InAppBrowserProxy.js",
        "id": "cordova-plugin-inappbrowser.InAppBrowserProxy",
        "pluginId": "cordova-plugin-inappbrowser",
        "merges": [
            ""
        ]
    },
    {
        "file": "plugins/cordova-sqlite-storage/www/SQLitePlugin.js",
        "id": "cordova-sqlite-storage.SQLitePlugin",
        "pluginId": "cordova-sqlite-storage",
        "clobbers": [
            "SQLitePlugin"
        ]
    },
    {
        "file": "plugins/cordova-sqlite-storage/src/windows/sqlite-proxy.js",
        "id": "cordova-sqlite-storage.SQLiteProxy",
        "pluginId": "cordova-sqlite-storage",
        "merges": [
            ""
        ]
    },
    {
        "file": "plugins/cordova-sqlite-storage/src/windows/SQLite3-Win-RT/SQLite3JS/js/SQLite3.js",
        "id": "cordova-sqlite-storage.SQLite3",
        "pluginId": "cordova-sqlite-storage",
        "merges": [
            ""
        ]
    },
    {
        "file": "plugins/cordova-plugin-ms-azure-mobile-apps/www/MobileServices.Cordova.Ext.js",
        "id": "cordova-plugin-ms-azure-mobile-apps.AzureMobileServices.Ext",
        "pluginId": "cordova-plugin-ms-azure-mobile-apps",
        "runs": true
    },
    {
        "file": "plugins/cordova-plugin-ms-azure-mobile-apps/www/MobileServices.Cordova.js",
        "id": "cordova-plugin-ms-azure-mobile-apps.AzureMobileServices",
        "pluginId": "cordova-plugin-ms-azure-mobile-apps",
        "clobbers": [
            "WindowsAzure"
        ]
    },
    {
        "file": "plugins/phonegap-plugin-push/www/push.js",
        "id": "phonegap-plugin-push.PushNotification",
        "pluginId": "phonegap-plugin-push",
        "clobbers": [
            "PushNotification"
        ]
    },
    {
        "file": "plugins/phonegap-plugin-push/src/windows/PushPluginProxy.js",
        "id": "phonegap-plugin-push.PushPlugin",
        "pluginId": "phonegap-plugin-push",
        "merges": [
            ""
        ]
    }
];
module.exports.metadata = 
// TOP OF METADATA
{
    "cordova-plugin-device": "1.1.2",
    "cordova-plugin-inappbrowser": "1.4.0",
    "cordova-sqlite-storage": "1.4.7",
    "cordova-plugin-ms-azure-mobile-apps": "2.0.0-rc1",
    "cordova-plugin-whitelist": "1.2.2",
    "phonegap-plugin-push": "1.8.4"
};
// BOTTOM OF METADATA
});