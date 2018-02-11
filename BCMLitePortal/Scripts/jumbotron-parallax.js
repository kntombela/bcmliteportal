var jumboHeight = ('.jumbotron').outerHeight();
window.scroll(function (e) {
    var scrolled = $(window).scrollTop();
    ('.bg').css('height', (jumboHeight - scrolled) + 'px');
});