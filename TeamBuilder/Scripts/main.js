$(function () {
    // Boostrap Datepicker
    $('.datepicker').datepicker();

    // Boostrap Tooltip
    $('.tip').tooltip();

    // Integrates Bootstrap error styling with MVC's error validation
    $('span.field-validation-valid, span.field-validation-error').each(function () {
        $(this).addClass('help-inline');
    });
    $(this).find('div.control-group').each(function () {
        if ($(this).find('span.field-validation-error').length > 0) {
            $(this).addClass('error');
        }
    });
});