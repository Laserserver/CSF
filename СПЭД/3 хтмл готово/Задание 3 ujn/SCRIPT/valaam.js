function show(name) 
{
    var elem = document.getElementById(name);
    if (elem)
        elem.style.display = "block";
}
function hide(name) 
{
    var elem = document.getElementById(name);
    if (elem)
        elem.style.display = "none";
}
function get()
{
    if (Valaam.Ans.value == "Сортавала")
        alert("Правильно!");
    else alert("Неправильно!");
}