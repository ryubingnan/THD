// JavaScript Document

$(function () {
    setFixHeight();
}());

$(window).on('resize', function () {
});

$(window).scroll(function () {
});


/*------------------------------
  setFixHeight
------------------------------*/
function setFixHeight() {
    $('.link-box-block .link-box-text').rwdFixHeight([
        { 'w': breakPointSP, 'column': 3 }
    ]);
}