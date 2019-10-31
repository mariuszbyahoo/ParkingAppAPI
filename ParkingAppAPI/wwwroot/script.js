'use_strict';
attachColor();

function sendPut(guid) {
    var request = new XMLHttpRequest();
    var url = 'http://localhost:54790/api/Slots/' + guid;
    var emptyDataString = "";
    request.open('PATCH', url, true);
    request.onreadystatechange = function (aEvt) {
        if (request.readyState == 4) {
            if (request.status == 200) {
                console.log(request.responseText);
                changeColor(guid); // Jak tu wrzucić ten przycisk?
            }
            else {
                console.log("Error while loading the page.");
            }
        }
    };
    request.send(null); 
}

function changeColor(guid) {
    var clicketButton = document.getElementById(guid);
    // On tu nie wie co to event.target

    if (clicketButton.innerHTML == 'False') {
        clicketButton.style.backgroundColor = 'red';
        clicketButton.innerHTML = "True";
        console.log('Teraz guzik jest czerwony');
    }
    else {
        clicketButton.style.backgroundColor = 'lawnGreen';
        clicketButton.innerHTML = "False";
        console.log('I z powrotem zielony')
    }

}

function attachColor() {
    for (let i = 0; i < document.getElementsByClassName('slot').length; i++) {
        if (document.getElementsByClassName('slot').item(i).innerHTML === 'False') {
            document.getElementsByClassName('slot').item(i).style.backgroundColor = 'lawnGreen';
        }
        else {
            document.getElementsByClassName('slot').item(i).style.backgroundColor = 'red';
        }
    }
};