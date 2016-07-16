var client = function () {
    var totalTime = '';
    var bufferedTime = '';
    var loading = false;
    var sendLoadingStatusTime;
    var loadCompleted = false;
    var haveSendLoadCompletedStatus = false;

    function sendLoadingStatus() {
        $.get("/NotifyLoading?token=" + $("#token").val());
        sendLoadingStatusTime = new Date();
    };

    function sendLoadCompletedStatus() {
        $.get("/NotifyLoadCompleted?token=" + $("#token").val());
        haveSendLoadCompletedStatus = true;
    };


    return {
        getTotalTime: function () {
            return totalTime;
        },
        setTotalTime: function (value) {
            totalTime = value;
        },
        getBufferedTime: function () {
            return bufferedTime;
        },
        setBufferedTime: function (value) {
            bufferedTime = value;
        },
        setLoading: function (value) {
            loading = value;
        },
        sentLoadingStatus: function () {
            if (typeof (sendLoadingStatusTime) == 'undefined') {
                sendLoadingStatus();
            } else {
                var now = new Date();
                if ((now.getTime() - sendLoadingStatusTime.getTime()) > (60 * 1000)) {
                    sendLoadingStatus();
                }
            }
        },
        sendLoadCompletedStatus: function () {
            loadCompleted = true;
            if (haveSendLoadCompletedStatus == false) {
                sendLoadCompletedStatus();
            }
        }
    };
}();




window.setInterval(function () { checkLoadingStatus() }, 5000);

function checkLoadingStatus() {
    if (client.getTotalTime() == '')
        client.setTotalTime(getTotalTime());
    var bufferedTimeTemp = getBufferedTime();
    if (client.getBufferedTime() != '' && client.getBufferedTime() != bufferedTimeTemp) {
        client.sentLoadingStatus();
    }
    client.setBufferedTime(bufferedTimeTemp);
    if (client.getBufferedTime() == client.getTotalTime())
        client.sendLoadCompletedStatus()
}

function getTotalTime() {
    try {
        return $('video').get(0).seekable.end(0);
    } catch (e) {
        return '';
    }
}

function getBufferedTime() {
    try {
        return $('video').get(0).buffered.end(0);
    } catch (e) {
        return '';
    }
}


