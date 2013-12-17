$(document).ready(function () {

    /* SLIDE NAVIGATION
    ---------------------------------------- */

    $('.slidePanel').click(function () {
        // set active item link
        //$('.slidePanel').removeClass('selected');
        //$(this).addClass('selected');

        // get current slide, for resizePanel() function
        var current = $(this);

        // scroll page to selected slide
        $('.slide-window').scrollTo($(this).attr('data-slide'), 600);

        //$(this).siblings('.toggleOptions').find('.toggleContent').slideUp(400);
        //slide(current);

        // cancel the link default behaviour
        return false;
    });

    function slide(current) {
        // scroll page to selected slide
        $('.slide-window').scrollTo($(this).attr('data-slide'), 600);
    }



    /* PAGE/SLIDE SETTINGS 
    ---------------------------------------- */

    // set height of content wrapper
    //var contentWrapperHeight = $(window).height() - 100;
    //$('.content-wrapper').css('height', contentWrapperHeight);

    // set max height of scrollbox div
    var scrollHeight = $(window).height() - 280;
    $('.scrollbox').css('max-height', scrollHeight);

    // set max height of paging div
    var pagingHeight = $('.slide-window').height() - 20;
    $('#paging-wrapper').css('max-height', pagingHeight);

    // set width of slide paging container
    var pagingWidth = $('.content-wrapper').width() - $('.slide-window').width() - 30;
    $('#paging-wrapper').css('width', pagingWidth);


    function resizePanel() {
        //get the browser width and height
        width = $(window).width();
        height = $(window).height();
        //get the mask width: width * total of items
        mask_width = width * $('.slide').length;

        //set the dimension    
        $('.slide-window, .slide').css({ width: width, height: height });
        $('.slide-wrapper').css({ width: mask_width, height: height });

        //if the item is displayed incorrectly, set it to the corrent pos
        $('.slide-window').scrollTo($('.selected').attr('href'), 0);

    }



    /* ACCORDION (RADIO BUTTON OPTIONS TOGGLING)
    ---------------------------------------- */

    // toggle visibility of radio button (accordion) options
    $('ul.toggleOptions > li > input[type="radio"]').click(function () {
        // toggle (show/hide) clicked radio button option 
        $(this).siblings('.toggleContent').slideToggle(400);

        // hide other options
        $(this).parent().siblings().children('.toggleContent').slideUp(400);
    });

    $('ul.toggleOptions > li > span').click(function () {
        // toggle (show/hide) clicked radio button option 
        $(this).siblings('.toggleContent').slideToggle(400);

        // hide other options
        $(this).parent().siblings().children('.toggleContent').slideUp(400);
    });




    /* WINDOW RESIZE EVENTS
    ---------------------------------------- */

    $(window).resize(function () {
        //call the resizePanel function
        //resizePanel();

        // set height of content wrapper
        //var contentWrapperHeight = $(window).height() - 100;
        //$('.content-wrapper').css('height', contentWrapperHeight);

        // set max height of scrollbox div
        var scrollHeight = $(window).height() - 280;
        $('.scrollbox').css('max-height', scrollHeight);

        // set max height of paging div
        var pagingHeight = $('.slide-window').height() - 20;
        $('#paging-wrapper').css('max-height', pagingHeight);

        // set width of slide paging container
        var pagingWidth = $('.content-wrapper').width() - $('.slide-window').width() - 30;
        $('#paging-wrapper').css('width', pagingWidth);
    });




    /* PROJECT EDITOR PAGE
    ---------------------------------------- */

    $('.ulNavEditor > li').click(function () {
        //$('.navEditor, .navEditor > ul > li').toggleClass('inactiveSubNav');
        //$(this).toggleClass('activeSubNav');
        
        // close mods editor if open
        if ($('a', this).attr('class') != 'editMods' && $('.overlayContainer').is(':visible')) $('.overlayContainer').slideUp();
        
        // set width of subnav
        var subNavWidth = $(window).width() - $('.ulNavEditor').width();

        // open sub nav (tools)
        if ($(this).has('ul')) {
            $(this).children('ul').width(subNavWidth);
            $(this).children('ul').fadeToggle(200);
        }
    });

    // open/close mods editor
    $('.editMods, .overlayClose a').click(function () {
        //$('.overlayBg').fadeToggle()

        // set height of overlay
        var overlayHeight = $(window).height() - 90;
        $('.overlayContainer').css('height',overlayHeight);

        // show/hide overlay
        $('.overlayContainer').slideToggle();
    });


});