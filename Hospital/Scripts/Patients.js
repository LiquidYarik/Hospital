
function getAllPatients() {
    return $.get('api/Patient');
}

//function getByiD(id) {
//    return $.get('api/Patient/' + id);
//};

$(document).ready(function () {
    FillPatientsTable();
});

function FillPatientsTable() {
    getAllPatients().then(function (patients) {

        var tableBody = document.getElementById('tableBody');

        patients.forEach(function (item) {
            var newTr = document.createElement('tr');

            var newTd1 = document.createElement('td');
            var newTd2 = document.createElement('td');
            var newTd3 = document.createElement('td');
            newTd1.innerHTML = item.PatientID;
            newTd2.innerHTML = item.Name;
            newTd3.innerHTML = item.Surname;
            newTr.appendChild(newTd1);
            newTr.appendChild(newTd2);
            newTr.appendChild(newTd3);
            newTr.setAttribute('title', 'Узнать подробнее');
            newTr.setAttribute('onclick', 'Find(' + item.PatientID + ')');
            tableBody.appendChild(newTr);

        });
    });
}


function Find(id) {
    window.location = '/Patient/Find/' + id;
}
function warning() {
    var z = document.getElementById('b');
    alert("Чтобы записаться на сеанс, выберите себя из списка.");
}
function Post() {
    var name = document.getElementById('name').value;
    var surname = document.getElementById('surname').value;
    var age = document.getElementById('age').value;
    var patient = { Name: name, Surname: surname, Age: age };

    $.post('/Patient/Add', patient).then(function (data) {
        alert("Вы успешно добавили запись");
        window.location = '/Patient/Patients';
        Showme();
        console.log('success');
    }, function (data) {
        alert("Повторите попытку");
        console.log('error');
    });
}
function Adi() {
    var z = document.getElementById('Adi');
    z.removeAttribute('hidden');
}
