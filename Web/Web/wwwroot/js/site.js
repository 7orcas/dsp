window.showAlert = function (message) {
    alert(message);
};

window.simulateClick = function (elementId) {
    console.log("simulateClick called: id=" + elementId);
    var element = document.getElementById(elementId);
    if (element) {
        element.click();
    }
};