var expr = $("#expression");
var _expressionCache = $("#expressionCache");
var _clearLocalStorage = $("#clearLocalStorage");
var _resultCache = {};
var _expressionsKey = "expressions";

$("#preview tbody").html('');
expr.focus();

function GetDate(jsonDate) {
    var value = new Date(parseInt(jsonDate.substr(6)));
    return value.getMonth() + 1 + "/" + value.getDate() + "/" + value.getFullYear();
}

function showPreview(data) {
    $("#expressionError").removeClass('error');
    $("#expressionError").addClass('success');
    $("#expressionError").html('You are awesome! Hit <strong>Enter</strong> when you have typed in all the sets.');
    $("#preview tbody").html('');
    $("#previewTemplate").tmpl(data).appendTo("#preview tbody");
}

function getPreview(date, exrp) {
    console.log(exrp.length);
    if (expr.length > 0) {
        console.log('lol');
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
                $("#expressionError").removeClass('success');
                $("#expressionError").addClass('error');
                $("#expressionError").html(data.statusText);
                $("#expressionError").show();
                console.log('failure:' + data.status + ':' + data.statusText);
            }
        });
    }
}

function showStoredExpressions() {
    var element = $("#expressionList");
    element.html('');
    var items = getExpressions();

    for (var i = 0; i < items.length; i++) {
        element.append("<li>" + items[i] + "<i class='icon-remove pull-right'></i></li>");
    }
    var date = $("#Date").val();
    getPreview(date, items.join(";"));
}

function getIndex(node) {
    var childs = node.parents("#expressionList").find("li");
    for (var i = 0; i < childs.length; i++) {
        if (node.parents("li")[0] == childs[i]) return i;
    }
    return -1;
}

function removeExpression(element) {
    var index = getIndex(element);
    var items = getExpressions();
    console.log(index);
    console.log(items);
    items.splice(index, 1);
    console.log(items);
    localStorage.setItem(_expressionsKey, JSON.stringify(items));
    showStoredExpressions();
}

function storeExpression(value) {
    var key = _expressionsKey;
    var store = [];
    if (localStorage[key])
        store = JSON.parse(localStorage[key]);
    store.push(value);
    localStorage.setItem(key, JSON.stringify(store));
    showStoredExpressions();
}

function getExpressions() {
    var key = _expressionsKey;
    var items = [];
    if (localStorage[key])
        items = JSON.parse(localStorage[key]);
    return items;
}
function test(q) {
    return !/\d/.test(q) && ($.trim(q) === q.toString());
}

$("#add-exercise").click(function (e) {
    e.preventDefault();
    var value = expr.val();
    if (value && $.trim(value) === value.toString() && /\d/.test(value)) {
        storeExpression(expr.val());
        expr.val('');
        var date = $("#Date").val();
        getPreview(date, getExpressions().join());
    }
    return false;
});
expr.keydown(function (e) {
    var keypressed = e.keyCode || e.which;
    if (keypressed == 13) {
        e.preventDefault();
        var value = expr.val();
        if (value && $.trim(value) === value.toString() && /\d/.test(value)) {
            storeExpression(expr.val());
            expr.val('');
            var date = $("#Date").val();
            getPreview(date, getExpressions().join());
        }
    }
});

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
        if (test(query)) {
            return $.get('/exercise/get', { q: query }, function (data) {
                return process(data);
            });
        }
        return;
    }
});

function init() {
    $(".icon-remove").live("click", function () {
        removeExpression($(this));
        $("#expressionError").html('removed item');
        $("#expressionError").show();
    });
    $("#saveButton").live("click", function () {
        expr.val(getExpressions().join(";"));
    });
    showStoredExpressions();
}
init();
