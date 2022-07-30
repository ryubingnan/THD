// JavaScript Document
var inc = {
    header:
        '<header id="header" class="header">' +
        '<div class="header-cont">' +
        '<div class="header-block">' +
        '<div class="header-logo">' +
        '<p class="logo"><a href="/"><img src="/img/common/logo.svg" alt="パーソルエクセルHRパートナーズ株式会社"></a></p>' +
        '</div>' +
        '<div class="header-contact-btn">' +
        '<a href="/contact/">' +
        '<p class="text">お問い合わせ</p>' +
        '</a>' +
        '</div>' +
        '</div>' +
        '<div class="header-nav-toggle">' +
        '<span></span>' +
        '<span></span>' +
        '<span></span>' +
        '</div>' +
        '<div class="header-navi">' +
        '<ul class="header-navi-list">' +
        '<li class="list"><a class="link" href="/worker/">仕事をお探しの皆さま</a></li>' +
        '<li class="list"><a class="link" href="https://client.persol-hrpartners.co.jp/">企業のご担当者さま</a></li>' +
        '<li class="list"><a class="link" href="/company/">会社情報</a></li>' +
        '<li class="list"><a class="link" href="/recruit/">採用情報</a></li>' +
        '<li class="list"><a class="link" href="/company/branch/">拠点一覧</a></li>' +
        '</ul>' +
        '<div class="header-navi-btn">' +
        '<a class="link" href="/contact/"><span>お問い合わせ</span></a>' +
        '</div>' +
        '</div>' +
        '</div>' +
        '</header>' +
        '<div id="menu_overlay"></div>',
    footer:
        '<div class="pagetop-block">' +
        '<a href="#" id="pagetop"><img src="/img/common/icon_page_top.png" alt="pagetop"></a>' +
        '</div>' +
        '<footer id="footer" class="footer">' +
        '<div class="footer-cont">' +
        '<p class="footer-logo"><a href="https://www.persol-group.co.jp/"><img src="/img/common/foot_logo.svg" alt="PERSOL"></a></p>' +
        '<p class="footer-slogan"><img src="/img/common/foot_slogan.svg" alt="はたらいて、笑おう"></p>' +
        '</div>' +
        '<div class="footer-copyright">' +
        '<p class="footer-copy">&copy; PERSOL EXCEL HR PARTNERS CO., LTD.</p>' +
        '</div>' +
        '</div>' +
        '</footer>',
    footerNavi:
        '<div class="footer-nav-contents">' +
        '<div class="contents-inner">' +
        '<div class="footer-nav-cont">' +
        '<div class="footer-nav-block">' +
        '<div class="footer-nav-group">' +
        '<p class="heading"><a href="/worker/">仕事をお探しの皆さま</a></p>' +
        '<ul class="footer-nav-list">' +
        '<li class="list"><a href="/senior/">仕事をお探しのシニアの皆さま</a></li>' +
        '</ul>' +
        '</div>' +
        '<div class="footer-nav-group">' +
        '<p class="heading"><a href="https://client.persol-hrpartners.co.jp/">企業のご担当者さま</a></p>' +
        '<ul class="footer-nav-list">' +
        '<li class="list"><a href="https://client.persol-hrpartners.co.jp/service/">サービスラインナップ</a></li>' +
        '<li class="list"><a href="https://client.persol-hrpartners.co.jp/contract">活用手法を比較する</a></li>' +
        '<li class="list"><a href="https://client.persol-hrpartners.co.jp/advantage">当社の強み</a></li>' +
        '<li class="list"><a href="https://client.persol-hrpartners.co.jp/case">活用事例</a></li>' +
        '</ul>' +
        '</div>' +
        '</div>' +
        '<div class="footer-nav-block">' +
        '<div class="footer-nav-group">' +
        '<p class="heading"><a href="/company/">会社情報</a></p>' +
        '<ul class="footer-nav-list">' +
        '<li class="list"><a href="/company/profile.html">会社概要</a></li>' +
        '<li class="list"><a href="/company/message.html">社長メッセージ</a></li>' +
        '<li class="list"><a href="/company/history.html">沿革</a></li>' +
        '<li class="list"><a href="/company/news.html">ニュース</a></li>' +
        '</ul>' +
        '</div>' +
        '<div class="footer-nav-group">' +
        '<p class="heading"><a href="/recruit/">採用情報</a></p>' +
        '</div>' +
        '</div>' +
        '<div class="footer-nav-block">' +
        '<p class="heading"><a href="/company/branch/">拠点一覧</a></p>' +
        '<ul class="footer-nav-list">' +
        '<li class="list"><a href="/company/branch/#area01">北海道・東北エリア</a></li>' +
        '<li class="list"><a href="/company/branch/#area02">首都圏エリア</a></li>' +
        '<li class="list"><a href="/company/branch/#area03">東海・北信越エリア</a></li>' +
        '<li class="list"><a href="/company/branch/#area04">関西エリア</a></li>' +
        '<li class="list"><a href="/company/branch/#area05">中国・四国エリア</a></li>' +
        '<li class="list"><a href="/company/branch/#area06">九州・沖縄エリア</a></li>' +
        '</ul>' +
        '</div>' +
        '<div class="footer-nav-block">' +
        '<p class="heading"><a href="/contact/">お問い合わせ</a></p>' +
        '<ul class="footer-nav-list">' +
        '<li class="list"><a href="/haken/fcts/contact/index.cfm">オフィスワーク派遣</a></li>' +
        '<li class="list"><a href="/tech/fcts/contact/index.cfm">技術者派遣</a></li>' +
        '<li class="list"><a href="/tensyoku/contact/">転職支援</a></li>' +
        '<li class="list"><a href="https://group.tempstaff.co.jp/wcform/pub/pphr_ex/1061802320295jc3001f">正社員エンジニア</a></li>' +
        '<li class="list"><a href="/contact/index.cfm?fuseaction=contents.contact&cid=61">シニア人材登録</a></li>' +
        '<li class="list"><a href="https://client.persol-hrpartners.co.jp/contact">企業のご担当者さま</a></li>' +
        '<li class="list"><a href="/contact/index.cfm?fuseaction=contents.contact&cid=56">新卒採用</a></li>' +
        '<li class="list"><a href="/contact/index.cfm?fuseaction=contents.contact&cid=55">キャリア採用</a></li>' +
        '<li class="list"><a href="/contact/index.cfm?fuseaction=contents.contact&cid=49">その他</a></li>' +
        '</ul>' +
        '</div>' +
        '</div>' +
        '<div class="footer-link-cont">' +
        '<div class="footer-link-list">' +
        '<p class="footer-link"><a href="/info/policy.html">サイトのご利用にあたって</a></p>' +
        '<p class="footer-link"><a href="/info/privacy/">個人情報保護方針</a></p>' +
        '<p class="footer-link"><a href="/info/security.html">情報セキュリティ基本方針</a></p>' +
        '<p class="footer-link"><a href="/info/provided.html">労働者派遣事業に関わる情報提供</a></p>' +
        // '<p class="footer-link"><a href="/info/yuryoshokai.html">優良人材派遣事業行動指針</a></p>' +
        '</div>' +
        '</div>' +
        '</div>' +
        '</div>'
}

$(document).ready(function () {
    jsInclude();
});

function jsInclude() {
    $('[data-include]').each(function () {
        var _part = $(this).attr('data-include');
        $(this).replaceWith(inc[_part]);
    });

    // pagetop
    $('#pagetop').click(function () {
        $('body,html').animate({
            scrollTop: 0
        }, 400);
        return false;
    });

    checkDevice();
    setCurrentPageMenu();
}

/*------------------------------
  PC Menu
------------------------------*/
function setCurrentPageMenu() {
    var url = location.pathname;
    var urlDirLength = url.split('/').length;
    var urlFileName = url.split('/')[urlDirLength - 1];
    var urlDirName = url.split('/')[urlDirLength - 2];
    var navi = $('#header .header-navi-list .link');

    navi.each(function () {
        var href = $(this).attr('href');
        var hrefDirLength = $(this).attr('href').split('/').length;
        if (urlDirLength == hrefDirLength) {
            if (urlDirName == '') {
                var hrefDirName = href.split('/')[hrefDirLength - 2];
                var hrefPageName = href.split('/')[hrefDirLength - 1];
                if ((urlFileName == hrefPageName) || (urlFileName == '' && hrefPageName == 'index.html')) {
                    $(this).closest('li').addClass('current');
                    return false;
                }
            } else {
                var hrefDirName = href.split('/')[hrefDirLength - 2];
                if (urlDirName == hrefDirName) {
                    $(this).closest('li').addClass('current');
                    return false;
                }
            }
        }
        if (url === '/senior/') {
            if (href === '/worker/') {
                $(this).closest('li').addClass('current');
            }
        }
        if (urlDirName === 'news') {
            if (href === '/company/') {
                $(this).closest('li').addClass('current');
            }
        }
    });
}

/*------------------------------
  Check device
------------------------------*/
function checkDevice() {
    winW = (!window.innerWidth) ? $(window).width() : window.innerWidth;
    var breakPointSP = 768;
    if (winW > breakPointSP) {
        $('#header .header-navi-list .list.sp_acd').removeClass('_sp');
    } else {
        $('#header .header-navi-list .list.sp_acd').addClass('_sp');
    }
}
