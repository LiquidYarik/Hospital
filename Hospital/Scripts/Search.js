
//function init() {
//    $("#r").on("click", function () {
//        //$("#r").css("display", "none");
//        $(".modalW").css("display", "inline");
//        //$("body").css("background", "black");
//        $(".close").on("click", function () {
//            $(".modalW").css("display", "none");
//            //$("body").css("background", "");
//            $("#r").css("display", "");
//        });
//    });
//}

function GetScheduleDoctor() {
    
    var doctorId = document.getElementById('doctorId').innerHTML;
    return $.get('/api/Doctor/byid/' + doctorId);
}

$(document).ready(function () {
    FillScheduleDoctorTable();
});

function FillScheduleDoctorTable() {
    GetScheduleDoctor().then(function (doctor) {
        document.getElementById('name').value = doctor.Name;
        document.getElementById('surname').value = doctor.Surname;
        document.getElementById('age').value = doctor.Age;
        document.getElementById('experience').value = doctor.Experience;
        document.getElementById('category').value = doctor.specialization.Category;

        var tableBody = document.getElementById('tableBody');
        
        doctor.schedules.forEach(function (item) {
            var newTr = document.createElement('tr');
            var newTd1 = document.createElement('td');
            var newTd2 = document.createElement('td');
            var newTd3 = document.createElement('td');

            newTd1.innerHTML = new Date(item.Date).toLocaleDateString();
            newTd2.innerHTML = item.TimeString;
            newTd3.innerHTML = item.patients.Name;

            newTr.appendChild(newTd1);
            newTr.appendChild(newTd2);
            newTr.appendChild(newTd3);

            tableBody.appendChild(newTr);   
        });
    });
}

