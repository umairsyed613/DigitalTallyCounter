function VibrateOnTouch() {
    var checkExist = setInterval(function () {
        var counterBtn = document.getElementById("counterbtn");
        console.log('checking Counter Btn');
        if (!!counterBtn) {
            $("#counterbtn").vibrate("long");
            clearInterval(checkExist);
        }
    }, 100);
}