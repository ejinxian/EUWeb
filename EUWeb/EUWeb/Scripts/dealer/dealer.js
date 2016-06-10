$(function () {
    $('#myTab a:first').tab('show');//初始化显示哪个tab
    $('#myTab a').click(function (e) {
        e.preventDefault();//阻止a链接的跳转行为
        $(this).tab('show');//显示当前选中的链接及关联的content
    });
    $('#menuSl li').bind('click', function (event) {
        $("#menuSl li").each(function (index) {//遍历列表里的每一项  
            if ($(this).attr('class') == 'active') { //如果
                $(this).removeClass('active');
            }
        })
        $(this).addClass('active');
    })
})