// JavaScript Document

var breakPointType = '';
var breakPointPC = 1020;
var breakPointSP = 768;
var winW = (!window.innerWidth) ? $(window).width() : window.innerWidth;
var h;
var t;
var touch = ('ontouchstart' in document) ? 'touchstart' : 'click';
var pagePath = location.pathname;
var url = location.href;

$(function () {
    mediaQueries();
    setPageEvent();
}());

$(window).on('resize', function () {
    mediaQueries();
});

$(window).on("scroll", function () {
    setPageTopPos();
});

$(window).on('load', function () {
    fixPosAnchorLink();
});



/*------------------------------
  mediaqueries
------------------------------*/
function mediaQueries() {
    winW = (!window.innerWidth) ? $(window).width() : window.innerWidth;
    if (winW > breakPointSP) {
        if (breakPointType != 'pc') {
            breakPointType = 'pc';
            pcWidthProp();
        }
    } else {
        if (breakPointType != 'sp') {
            breakPointType = 'sp';
            spWidthProp();
        }
    }
}

/*------------------------------
  PC ONLY
------------------------------*/
function pcWidthProp() {
    $('body').removeClass('sp_device');
    $('#header .header-navi-list .list.sp_acd').removeClass('_sp');
}

/*------------------------------
  SP ONLY
------------------------------*/
function spWidthProp() {
    $('body').addClass('sp_device');
    $('#header .header-navi-list .list.sp_acd').addClass('_sp');
}

/*------------------------------
  Page Event
------------------------------*/
function setPageEvent() {
    // SP Menu
    $('body').on('click', '.header-nav-toggle', function () {
        $('body').toggleClass('open');
        if ($('body').hasClass('open')) {
            $('#header .header-navi').fadeIn(300);
        } else {
            $('#header .header-navi').fadeOut(300);
        }
    })

    //Anker Link
    $("body").on('click', 'a[href^="#"]:not(a.modal)', function (e) {
        e.preventDefault();
        var href = $(this).attr("href");
        smoothScroll(href);
    });
}

/*------------------------------
  Page anchor link position
------------------------------*/
function fixPosAnchorLink() {
    var url = $(location).attr('href');
    if (url.indexOf("#") != -1) {
        var anchor = url.split("#");
        var target = $('#' + anchor[anchor.length - 1]);
        if (target.length) {
            var pos = Math.floor(target.offset().top) - 80;
            $("html, body").animate({ scrollTop: pos }, 500);
        }
    }
}

/*------------------------------
  Smooth Scroll
  #で始まるリンクのみ動作
  #のみなら動作しない
------------------------------*/
function smoothScroll(href) {
    if (href == '#' || href == '#modal') {
        return false;
    }
    setTimeout(function () {
        var target, position;
        target = $(href == "#" || href == "" ? 'html' : href);
        if (target.length > 0) {
            var headerHight = winW > breakPointSP ? 100 : 60;
            position = target.offset().top - headerHight;
            $('html,body').animate({ scrollTop: position }, 400, 'swing');
        }
    }, 5);
}

/*------------------------------
  Page top position
------------------------------*/

function setPageTopPos() {
    scrollHeight = $(document).height();
    scrollPosition = $(window).height() + $(window).scrollTop();
    footHeight = $('footer').innerHeight();
    if (scrollHeight - scrollPosition <= footHeight) {
        if (winW > breakPointSP) {
            $("#pagetop").css({
                "bottom": '2%'
            });
        } else {
            $("#pagetop").css({
                "bottom": '1%'
            });
        }
    } else {
        $("#pagetop").css({
            'bottom': '7%'
        });
    }
}


/*------------------------------
  レスポンシブ対応高さ揃え
------------------------------*/
/*
使用方法
$('高さ揃えする要素').rwdFixHeight([
    {'w':breakPointSP,'column':3},  ←PCの時　3カラムで高さ揃え
    {'w':0,'column':1}  ←SPの時　1カラムで高さ揃え
]);
任意のタイミングで高さ揃えしたい場合
$(this).rwdFixHeight('fix');
*/
var rwdFixHeightList = [];
var rwdFixHeightListTimer = false;
(function ($) {
    $.fn.rwdFixHeight = function (options) {
        var _obj, _list = [];
        if (options == 'fix') {
            fixH();
            return false;
        }
        if (this.length == 0) {
            return false;
        }

        if (options === undefined) {
            options = [];
        }
        if (options.length == 0) {
            options = [{ 'column': 1 }];
        }
        $.each(options, function (i, v) {
            var _o = {};
            if (v.w == undefined) {
                _o.w = 0;
            } else {
                _o.w = v.w;
            }
            if (v.column == undefined) {
                _o.column = 0;
            } else {
                _o.column = v.column;
            }
            _list.push(_o);
        });
        _obj = {
            'tgt': this,
            'list': _list
        }
        rwdFixHeightList.push(_obj);
        fixH();
        $(window).on("load", function () {
            fixH();
        });
        $(window).resize(function () {
            if (rwdFixHeightListTimer !== false) {
                clearTimeout(rwdFixHeightListTimer);
            }
            rwdFixHeightListTimer = setTimeout(function () {
                fixH();
            }, 10);
        });
        function fixH() {
            $.each(rwdFixHeightList, function (i, v) {
                var _max = 0;
                var _l = [];
                var _column = 0;
                var _winW = (!window.innerWidth) ? $(window).width() : window.innerWidth;
                $.each(v.list, function (i2, v2) {
                    if (v2.w < _winW) {
                        _column = v2.column;
                        return false;
                    }
                });
                v.tgt.css('height', 'auto');
                if (_column > 0) {
                    if (_column == 1) _column = 99999;
                    v.tgt.each(function (i2, v2) {
                        _max = Math.max(_max, $(v2).height());
                        _l.push(v2);
                        if ((i2 + 1) % _column == 0) {
                            $.each(_l, function (i3, v3) {
                                $(v3).height(_max);
                            });
                            _max = 0;
                            _l = [];
                        }
                    });
                    if (_l.length > 0) {
                        $.each(_l, function (i3, v3) {
                            $(v3).height(_max);
                        });
                    }
                }
            });
        }
    };
})(jQuery);
