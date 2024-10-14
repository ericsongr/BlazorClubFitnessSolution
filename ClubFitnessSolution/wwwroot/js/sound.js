window.playNotificationSound = function () {
    var audio = new Audio('/AudioFiles/DING.mp3');
    audio.play();
};

window.playAlarmSound = function () {
    var audio = new Audio('/AudioFiles/Alarm-08.mp3');
    audio.play();
};

window.playDoubleScanSound = function () {
    var audio = new Audio('/AudioFiles/DOUBLE SCAN WAV.mp3');
    audio.play();
};

window.playMembershipInActiveSound = function () {
    var audio = new Audio('/AudioFiles/membership inactive wav.mp3');
    audio.play();
};

window.playPaymentIssueSound = function () {
    var audio = new Audio('/AudioFiles/PAYMENT ISSUE WAV.mp3');
    audio.play();
};
