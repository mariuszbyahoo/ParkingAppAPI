(function attachColor()
{
    for (let i = 0; i < document.getElementsByClassName('slot').length; i++)
    {
        if (document.getElementsByClassName('slot').item(i).innerHTML === 'False')
        {
            document.getElementsByClassName('slot').item(i).style.backgroundColor = 'lawnGreen';
        }
        else
        {
            document.getElementsByClassName('slot').item(i).style.backgroundColor = 'red';
        }
    }
})();

function sendPut(guid)
{
    window.alert(guid);
}