function VibrateOnTouch(vibrationsetting) {

    console.log("Vibration Settings Received: " + vibrationsetting);

    if (vibrationsetting === undefined) {
        vibrationsetting = "medium";
    }

    var checkExist = setInterval(function () {
        var counterBtn = document.getElementById("counterbtn");
        //console.log('checking Counter Btn');
        if (!!counterBtn) {
            $("#counterbtn").vibrate(vibrationsetting);
            clearInterval(checkExist);
        }
    }, 100);
}