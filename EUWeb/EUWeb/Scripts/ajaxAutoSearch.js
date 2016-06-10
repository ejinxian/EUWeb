$(function () {

    var ajaxFormSubmit = function () {
        var $form = $(this);

        var options = {
            url: $form.attr("action"),
            type: "get",
            data: $form.serialize()
        };

        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-movies-target"));
            $target.replaceWith(data);
        });
        return false;
    };


    var submitAutoCompleteForm = function (event , ui) {
        var $input = $(this);
        $input.val(ui.item.label);
        var $form = $input.parents("form:first");
        $form.submit();
    }

    //自动调用函数
    var createAutoComplete = function () {
        var $input = $(this);
        var options = {
            select: submitAutoCompleteForm,
            source: $input.attr("data-movies-autocomplete")
        };
        $input.autocomplete(options);
    };
    //分页
    var getPage = function () {
        $a = $(this);
        var options = {
            url: $a.attr("href"),
            data: $("form").serialize(),
            type: "get"
        };
        $.ajax(options).done(function (data) {
            var target = $a.parents("div.pagedList").attr("data-movies-target");
            $(target).replaceWith(data);
        });
        return false;
    }
    //搜索
    $("form[ data-movies-ajax='true']").submit(ajaxFormSubmit);
    //自动搜索
    $("input[data-movies-autocomplete]").each(createAutoComplete);
    //分页
    $(".body-content").on("click",".pagedList a",getPage);
});