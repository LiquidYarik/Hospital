function back() {
    window.location = 'http://localhost:61043/Disease';
}

function DiseaseWithDescription() {
    var diseaseId = document.getElementById('diseaseId').innerHTML;
    return $.get('/api/Disease/byid/' + diseaseId);
};

$(document).ready(function () {
    GetDiseaseWithDescription();
});

function GetDiseaseWithDescription() {
    DiseaseWithDescription().then(function (desease) {
        var tableBody = document.getElementById('tableBody');

        
            //var newTr = document.createElement('tr');
            //var newTd1 = document.createElement('td');
        //var newTd2 = document.createElement('td');
        $('#tableBody tr td')[0].innerText = desease.Name;
        $('#tableBody tr td')[1].innerText = desease.Description;
            //newTd1.innerHTML = item.Name;
            //newTd2.innerHTML = item.Description;
            //newTr.appendChild(newTd1);
            //newTr.appendChild(newTd2);
            //tableBody.appendChild(newTr);

    });
}