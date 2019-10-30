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

// funkcja poniżej nie działa...

function changeColor()
{
    if (this.InnerHtml === 'False') {
        this.backgroundColor = 'red';
        this.InnerHtml = 'True';
    }
    else {
        this.backgroundColor = 'lawnGreen';
        this.InnerHtml = 'False';
    }
}