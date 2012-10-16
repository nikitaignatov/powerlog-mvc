var expr = $("#expression");
var _expressionCache = $("#expressionCache");
var _resultCache = {};

$("#preview tbody").html('');
expr.focus();

function GetDate(jsonDate) {
    var value = new Date(parseInt(jsonDate.substr(6)));
    return value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();
}

function showPreview(data) {
    $("#expressionError").hide();
    $("#expressionError").html('');
    $("#preview tbody").html('');
    $("#previewTemplate").tmpl(data).appendTo("#preview tbody");
}

function getPreview(date, exrp) {
    $.ajax({
        dataType: "json",
        type: 'POST',
        data: { date: date, expression: exrp },
        url: "/LoggedExercise/PreviewLog",
        success: function (data) {
            var key = exrp.replace(/(\n|\r|\s|\t)/g, '');
            _resultCache[key] = data;
            showPreview(data);
        },
        error: function (data) {
            console.log(data);
            $("#expressionError").html(data.statusText);
            $("#expressionError").show();
            console.log('failure:' + data.status + ':' + data.statusText);
        }
    });
}


expr.keyup(function (e) {
    var date = $("#Date").val();
    var value = $(this).val().trim();
    var key = value.replace(/(\n|\r|\s|\t)/g, '');
    if (key in _resultCache) {
        showPreview(_resultCache[key]);
    } else if (value !== _expressionCache.val()) {
        _expressionCache.val(value);
        getPreview(date, value);
    }
});

expr.typeahead({
    items: 15,
    matcher: function (item) {
        return true;
    },
    source: function (query, process) {
        function test(q) {
            return !/\d/.test(q) && ($.trim(q) === q.toString());
        }

        if (test(query)) {
            return $.get('/exercise/get', { q: query }, function (data) {
                return process(data);
            });
        }
        return;
    }
});
