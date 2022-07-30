// 移动端顶部导航显示隐藏
var isShow = false;
$('#headerBtn').click(function () {
    if (isShow) {
        isShow = false;
        $('.header-list-phone').hide();
    } else {
        isShow = true;
        $('.header-list-phone').show();
    }
})

// 控制返回顶部按钮显示隐藏
$(window).scroll(function () {
    var hei = $(window).scrollTop();
    var hei_scr = $(window).height() * 0.4;
    if (hei > hei_scr) {
        $('.to-top').css('display', 'block');
    } else {
        $('.to-top').css('display', 'none');
    }
});

// 返回顶部
$('.to-top').click(function () {
    $('html, body').animate({
        scrollTop: 0
    }, 500);
})