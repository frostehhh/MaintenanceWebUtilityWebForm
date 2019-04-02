// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("#MainContent_FacilityPeriodDetailsGridView_EncodingEndDate_0").change(function () {
    //var changedEncodingEndDate = $('#encodingEndDate :selected').val();
    var changedEncodingEndDate = document.getElementById("MainContent_FacilityPeriodDetailsGridView_EncodingEndDate_0").value;
    $("#MainContent_FacilityPeriodDetailsGridView_ChangedEncodingDate_0").val(changedEncodingEndDate);

    if ($("#MainContent_FacilityPeriodDetailsGridView_ChangedEncodingDate_0").val != $("#MainContent_FacilityPeriodDetailsGridView_InitialEncodingEndDate_0").val) {
        $("#MainContent_FacilityPeriodDetailsGridView_IsEncodingEndDateChanged_0").val('true');
    }
    else
    {
        $("#MainContent_FacilityPeriodDetailsGridView_IsEncodingEndDateChanged_0").val('false');
    }
});

