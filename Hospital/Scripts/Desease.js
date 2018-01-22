function getAll() {
    return $.get('api/Disease');
};
function getByiD(id) {
    return $.get('api/Disease/' + id);
};
$(document).ready(function () {
    FillDeseaseTable();
});

function FillDeseaseTable() {
    getAll().then(function (desease) {
        console.log(desease);

        var tableBody = document.getElementById('tableBody');

        desease.forEach(function (item) {
            var newTr = document.createElement('tr');
            var newTd1 = document.createElement('td');
            var newTd2 = document.createElement('td');
            newTd1.innerHTML = item.DiseaseID;
            newTd2.innerHTML = item.Name;
            newTr.appendChild(newTd1);
            newTr.appendChild(newTd2);
            newTr.setAttribute('title', 'Узнать подробнее');
            newTr.setAttribute('onclick', 'Find(' + item.DiseaseID + ')');
            tableBody.appendChild(newTr);

        });
    });
}


function Find(id) {
    //    //$.get("fghg").then((rslt) => {
    //    //    getElementById("hiddn").value = rslt;
    //    //});
    window.location = '/Disease/Description/' + id;
}

function pat()
{
    window.location = '/Doctor/ShowDoctors';
}
function dis()
{
    window.location = '/Patient/Patients';
}