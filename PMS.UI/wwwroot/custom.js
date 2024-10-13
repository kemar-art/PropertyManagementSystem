// wwwroot/js/custom.js
//window.reloadVendorScript = function () {
//    var script = document.createElement('script');
//    script.src = "/preload.js";
//    document.body.appendChild(script);
//};

window.reloadVendorScript = function () {
    // Check if the script is already present in the document
    var existingScript = document.querySelector("script[src='/preload.js']");

    if (!existingScript) {
        var script = document.createElement('script');
        script.src = "/preload.js";
        script.onload = function () {
            initializeDropdown(); // Call your dropdown init function once the script is loaded
        };
        document.body.appendChild(script);
    }
};


