

function getDoctorByID(id)
{
    return $.get('api/Doctor/' + id);
}

// check this method! [getByiD last name]
function SearchByID(id) {
    return $.get('api/Doctor/' + id);
}
function getAll() {
    return $.get('api/Doctor');
}

$(document).ready(function () {
    FillDoctorsTable();
});

function FillDoctorsTable() {
    getAll().then(function (doctors) {  
        var tableBody = document.getElementById('tableBody');

        doctors.forEach(function (item) {
            var newTr = document.createElement('tr');          
            var newTd1 = document.createElement('td');
            var newTd2 = document.createElement('td');
            var newTd3 = document.createElement('td');

            newTd1.innerHTML = item.DoctorID;
            newTd2.innerHTML = item.Name;
            newTd3.innerHTML = item.Surname;

            newTr.appendChild(newTd1);
            newTr.appendChild(newTd2);
            newTr.appendChild(newTd3);
            newTr.setAttribute('title', 'Узнать подробнее');
            newTr.setAttribute('onclick', 'Find(' + item.DoctorID + ')');

            tableBody.appendChild(newTr);         
        });    
    });
}

function Find(id) {
    window.location = '/Doctor/Search/' + id;
}

function information()
{
    alert("Чтобы узнать информация о докторе, кликните на него");
}
