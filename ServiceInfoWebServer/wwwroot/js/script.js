const format = function (str, args) {
    let formatted = str;
    for (let i = 0; i < args.length; i++) {
        let regexp = new RegExp('\\{' + i + '\\}', 'gi');
        formatted = formatted.replace(regexp, args[i]);
    }
    return formatted;
};

function editFormatter(id) {
    return format(`<a href="/Edit?id={0}">Edit</a> | <a href="/Details?id={0}">Details</a> | <a href="/Delete?id={0}">Delete</a>`, [id]);
}

var $table = $('#table');
$(function () {
    $('#toolbar').find('select').change(function () {
        $table.bootstrapTable('refreshOptions', {
            exportDataType: $(this).val()
        });
    });
})

var trBoldBlue = $("table");

$(trBoldBlue).on("click", "tr", function () {
    $(this).toggleClass("bold-blue");
});

function linkFormatter(value) {
    return format("<a href='{0}'>{0}</a>", [value]);
}

function boolFormatter(value) {
    return `<input ${(value.includes("checked") ? "checked=\"checked\"" : "")} disabled="disabled" type="checkbox">`;
}

var activeDefaults = {
    '<input  disabled="disabled" type="checkbox">': "inactive",
    '<input checked="checked" disabled="disabled" type="checkbox">': "active"
};

var environmentDefaults = {
    Dev: 'Dev',
    Test: 'Test',
    Production: 'Production'
};