function show() {
    window.location = '';
}
function back() {
    window.location = 'http://localhost:1879/Patient/Patients';
}

function hm() {
    var d = document.getElementById('dd').value;
    if (d !== null) {
        document.getElementById('timeee').removeAttribute('hidden');
    }

    GetSpareDate();
}


function Send() {

    var doctorID = document.getElementById('doctorsSelect').value;
    var patientID = document.getElementById('PatientID').innerText;
    var d = document.getElementById('dd').value;
    var time = document.getElementById('tim').value;
    var s = { Date: d, DoctorID: doctorID, PatientID: patientID, Time: time };
    $.post('/api/Schedule/postschedule/schedule', s).then(function (data) {

        alert("Вы успешно добавили запись");
    });

}
function FillDoctorsSelect(doctors) {
    var z = document.getElementById('doctorsSelect');

    doctors.forEach(function (doctor) {
        var newOption = document.createElement('option');
        newOption.text = doctor.Name + ' ' + doctor.Surname;
        newOption.value = doctor.DoctorID;
        z.appendChild(newOption);
    });
}

function GetDoctorsByDisease(id) {
    $.get('/api/Doctor/bydisease/' + id).then(function (result) {
        var doctors = result;
        FillDoctorsSelect(doctors);

    });
}

//!!//
function init() {
    var diseaseId = document.getElementById('DiseaseID').innerText;
    GetDoctorsByDisease(diseaseId);
    GetSpareDate();
}



function CreateOptionsForTime(time) {
    var timeSelect = document.getElementById('tim');
    $('#tim').find('option').remove();

    time.forEach(function (data) {
        var newOption = document.createElement('option');
        newOption.text = data.Value;
        newOption.value = data.Key;
        timeSelect.appendChild(newOption);
    });

}

function GetSpareDate() {
    var doctorID = document.getElementById('doctorsSelect').value;
    var selectedDate = document.getElementById('dd').value;

    if (doctorID && selectedDate) {
        $.get(`/api/Schedule/availtimeslots/id/date?doctorId=${doctorID}&date=${selectedDate}`).then(function (result) {
            CreateOptionsForTime(result);
        });
    }
}
//!//
function getPatientByID() {

    var PatientID = document.getElementById('PatientID').innerHTML;
    return $.get('/api/Patient/find/' + PatientID);
}

$(document).ready(function () {
    GetPatientWithDisease();
});

function GetPatientWithDisease() {
    getPatientByID().then(function (patient) {
        var tableBody = document.getElementById('tableBody');

        $('#tableBody tr td')[0].innerText = patient.Surname;
        $('#tableBody tr td')[1].innerText = patient.Name;
        $('#tableBody tr td')[2].innerText = patient.Age;
        $('#tableBody tr td')[3].innerText = patient.disease.Name;
    });
}