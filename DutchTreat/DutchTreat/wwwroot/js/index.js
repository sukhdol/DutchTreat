
$(document).ready(function() {
    var x = 0;
    var s = "";

    console.log("Hello PS!");

    var theForm = $("#theForm");

    theForm.hide();

    var button = $("#buyButton");

    button.on("click", function () {
        console.log("buying Item");
    });

    var productInfo = $(".product-props li");

    productInfo.on("click", function () {
        console.log("You clicked on " + $(this).text());
    });

    var $loginToggle = $("#loginToggle");
    var $popupForm = $(".popup-form");

    $loginToggle.on("click", function() {
        $popupForm.toggle(1000);
    });


});

