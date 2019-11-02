'use_strict';
attachColor();

function sendPost() {
    var request = new XMLHttpRequest();
    var url = 'http://localhost:54790/api/Slots/';

    request.open('POST', url, true);
    request.setRequestHeader('Content-Type', 'application/json');
    request.onreadystatechange = function () {
        if (request.readyState == 4) {
            if (request.status == 201) {
                console.log(request.responseText);
            }
            else {
                console.log("Error while creating the slot");
            }
        }
    }
    request.send("{}");
}

function sendPut(guid) {
    var request = new XMLHttpRequest();
    var url = 'http://localhost:54790/api/Slots/' + guid;

    request.open('PATCH', url, true);
    request.onreadystatechange = function (aEvt) {
        if (request.readyState == 4) {
            if (request.status == 200) {
                console.log(request.responseText);
                changeColor(guid); 
            }
            else {
                console.log("Error while loading the page.");
            }
        }
    }
    request.send(null); 
}

function sendDelete() {
    var request = new XMLHttpRequest();
    var url = 'http://localhost:54790/api/Slots/random';

    request.open('DELETE', url, true);
    request.onreadystatechange = function () {
        if (request.readyState == 4) {
            if (request.status == 200) {
                console.log(request.responseText);
            }
            else {
                console.log("Error while loading the page.")
            }
        }
    }
    request.send(null);
}

function changeColor(guid) {
    var clicketButton = document.getElementById(guid);

    if (clicketButton.innerHTML == 'False') {
        clicketButton.style.backgroundColor = '#800000';
        clicketButton.innerHTML = "True";
        console.log('Teraz guzik jest czerwony');
    }
    else {
        clicketButton.style.backgroundColor = '#009900';
        clicketButton.innerHTML = "False";
        console.log('I z powrotem zielony');
    }

}

function attachColor() {
    for (let i = 0; i < document.getElementsByClassName('slot').length; i++) {
        if (document.getElementsByClassName('slot').item(i).innerHTML === 'False') {
            document.getElementsByClassName('slot').item(i).style.backgroundColor = '#009900'; // green
        }
        else {
            document.getElementsByClassName('slot').item(i).style.backgroundColor = '#800000'; // red
        }
    }
};
