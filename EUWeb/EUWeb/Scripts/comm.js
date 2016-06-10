$(function () {
    $('#menuSl li').bind('click', function (event) {
        $("#menuSl li").each(function (index) {//遍历列表里的每一项
            if ($(this).attr('class') == 'active') { //如果
                $(this).removeClass('active');
            }
        })
        $(this).addClass('active');
    });
    $("#myTab1 a").mousemove(function (e) {
        $(this).tab('show');
    });
    $("#myTab2 a").mousemove(function (e) {
        $(this).tab('show');
    });
    $("#myTab3 a").mousemove(function (e) {
        $(this).tab('show');
    });    
    function chanageMenuOpen() {
        var pageID = $("#pageID").attr("name");
        var openLi = $(".index_top2_menu_ul li:first");
        console.log(openLi);
        if (pageID != "index") {
            openLi.removeClass("open");
        } else {
            openLi.addClass("open");
        }
       
    };
    chanageMenuOpen();
});