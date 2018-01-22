function getAllSpecialization() {
    return $.get('api/Specialization');
};
$(document).ready(function () {
    FillSpecializationTable();
});

function FillSpecializationTable() {
    getAllSpecialization().then(function (specialization) {
        console.log(specialization);

        var tableBody = document.getElementById('tableBody');

        specialization.forEach(function (item) {
            var newTr = document.createElement('tr');
            var newTd1 = document.createElement('td');
            var newTd2 = document.createElement('td');
            newTd1.innerHTML = item.SpecializationID;
            newTd2.innerHTML = item.Category;
            newTr.appendChild(newTd1);
            newTr.appendChild(newTd2);
            tableBody.appendChild(newTr);

        });
    });
}