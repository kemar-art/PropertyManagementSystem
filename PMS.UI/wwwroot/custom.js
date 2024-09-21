// wwwroot/js/custom.js
window.reloadVendorScript = function () {
    var script = document.createElement('script');
    script.src = "/preload.js";
    document.body.appendChild(script);
};
