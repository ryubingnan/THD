// �ƶ��˶���������ʾ����
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

// ���Ʒ��ض�����ť��ʾ����
$(window).scroll(function () {
    var hei = $(window).scrollTop();
    var hei_scr = $(window).height() * 0.4;
    if (hei > hei_scr) {
        $('.to-top').css('display', 'block');
    } else {
        $('.to-top').css('display', 'none');
    }
});

// ���ض���
$('.to-top').click(function () {
    $('html, body').animate({
        scrollTop: 0
    }, 500);
})