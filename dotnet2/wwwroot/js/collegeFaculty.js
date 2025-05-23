﻿if (!window.app) {
    window.app = {};
}

window.app.collegeFaculty = (function ($) {

    // Initialize the UI
    var initUi = function () {
        debugger;
        GetCollegeFacultyList();
      /*  $('#updateCollegeFaculty').hide();*/ // Hide update button on load
    };

    // Register event handlers
    var initEvent = function () {
        $("#saveCollegeFaculty").on("click", InsertcollegeFaculty );
        $("#updateCollegeFaculty").on("click", UpdatecollegeFaculty);
    };

    // Event delegation for edit button
    $(document).on("click", ".editcollegeFaculty", function () {
        debugger;
        var id = $(this).data('id');
        GetCollegeFacultyByID(id);
    });


     //Insert Faculty
    var InsertcollegeFaculty = function (e) {
        e.preventDefault();
        debugger;

        var data = {
            FirstName: $('#firstName').val(),
            LastName: $('#lastName').val(),
            Email: $('#email').val(),
            PhoneNumber: $('#phoneNumber').val(),
            Department: $('#department').val(),
            HireDate: $('#hireDate').val(),
            Designation: $('#designation').val()
        };

        $.ajax({
            url: '/collegeFaculty/AddcollegeFaculty',
            method: 'post',
            dataType: 'json',
            data: data,
            success: function (response) {
                alert(response.message || "Faculty added successfully");
                GetCollegeFacultyList();
                ResetForm();
            },
            error: function (xhr, status, error) {
                alert("Unable to insert: " + error);
            }
        });
    };

     //Update Faculty
    var UpdatecollegeFaculty = function (e) {
        e.preventDefault();
        debugger;

        var data = {
            FacultyID: $('#facultyID').val(),
            FirstName: $('#firstName').val(),
            LastName: $('#lastName').val(),
            Email: $('#email').val(),
            PhoneNumber: $('#phoneNumber').val(),
            Department: $('#department').val(),
            HireDate: $('#hireDate').val(),
            Designation: $('#designation').val()
        };

        $.ajax({
            url: '/collegeFaculty/UpdatecollegeFaculty',
            method: 'post',
            dataType: 'json',
            data: data,
            success: function (response) {
                alert(response.message || "Faculty updated successfully");
                GetCollegeFacultyList();
                ResetForm();
            },
            error: function (xhr, status, error) {
                alert("Unable to update: " + error);
            }
        });
    };

    // Reset form
    var ResetForm = function () {
        $('#facultyID').val('');
        $('#firstName').val('');
        $('#lastName').val('');
        $('#email').val('');
        $('#phoneNumber').val('');
        $('#department').val('');
        $('#hireDate').val('');
        $('#designation').val('');
        $('#saveCollegeFaculty').show();
        $('#updateCollegeFaculty').hide();
    };

    // get all faculty list
    var GetCollegeFacultyList = function () {
        debugger;
        $.ajax({
            url: '/collegeFaculty/AllcollegeFaculty',
            method: 'get',
            datatype: 'json',
            success: function (data) {
                debugger;
                var html= '';
                var i = 1;
                $.each(data, function (index, item) {
                    html += '<tr>';
                    html += '<td>' + i + '</td>';
                    html += '<td>' + item.firstName + '</td>';
                    html += '<td>' + item.lastName + '</td>';
                    html += '<td>' + item.email + '</td>';
                    html += '<td>' + item.phoneNumber + '</td>';
                    html += '<td>' + item.department + '</td>';
                    html += '<td>' + item.hireDate + '</td>';
                    html += '<td>' + item.designation + '</td>';
                    html += '<td>';
                    html += '<button class="btn btn-info editcollegeFaculty" data-id="' + item.facultyID + '">edit</button>';

                    html += '<button class="btn btn-info deletecollegeFaculty" data-id="' + item.facultyID + '">delete</button>';
                    html += '</td></tr>';
                    i++;
                });
                $('#collegeFacultyTableBody').html(html);
            },
            error: function () {
                alert("unable to retrieve faculty list.");
            }
        });
    };

    // get single faculty by id
    var GetCollegeFacultyByID = function (id) {

        debugger;
        $.ajax({
            url: '/collegeFaculty/GetCollegeFacultyByID?FacultyID=' + id,
            method: 'get',
            datatype: 'json',
            success: function (item) {
                debugger;
                $('#facultyID').val(item.facultyID);
                $('#firstName').val(item.firstName);
                $('#lastName').val(item.lastName);
                $('#email').val(item.email);
                $('#phoneNumber').val(item.phonenumber);
                $('#department').val(item.department);
                $('#hireDate').val(item.hireDate);
                $('#designation').val(item.designation);

                $('#saveCollegefaculty').hide();
                $('#updateCollegefaculty').show();
            },
            error: function () {
                alert("unable to retrieve faculty details.");
            }
        });
    };

    // On document ready
    var onDocumentReady = function () {
        initUi();
        initEvent();
    };

    return {
        onDocumentReady: onDocumentReady,
        GetCollegeFacultyByID:GetCollegeFacultyByID
    
    };

}(jQuery));

// Run on document ready
jQuery(window.app.collegeFaculty.onDocumentReady);
