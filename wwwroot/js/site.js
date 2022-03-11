
$(document).scroll(function () {
    var y = $(this).scrollTop();
    if (y > 500) {
        $('#top_header_wrapper').slideDown();
    } else {
        $('#top_header_wrapper').slideUp();
    }
});

equalheight = function (container) {

    var currentTallest = 0,
        currentRowStart = 0,
        rowDivs = new Array(),
        $el,
        topPosition = 0;
    $(container).each(function () {

        $el = $(this);
        $($el).height('auto')
        topPostion = $el.position().top;

        if (currentRowStart != topPostion) {
            for (currentDiv = 0; currentDiv < rowDivs.length; currentDiv++) { rowDivs[currentDiv].height(currentTallest); }
            rowDivs.length = 0; // empty the array
            currentRowStart = topPostion;
            currentTallest = $el.height();
            rowDivs.push($el);
        } else {
            rowDivs.push($el);
            currentTallest = (currentTallest < $el.height()) ? ($el.height()) : (currentTallest);
        }
        for (currentDiv = 0; currentDiv < rowDivs.length; currentDiv++) { rowDivs[currentDiv].height(currentTallest); }
    });
}

$(window).ready(function () {
    equalheight('.why_reasons_wrapper .why_reason');
});

$(window).resize(function () {
    equalheight('.why_reasons_wrapper .why_reason');
});

$(window).ready(function () {
    equalheight('.product_items_wrapper .product');
});

$(window).resize(function () {
    equalheight('.product_items_wrapper .product');
});

$(window).ready(function () {
    equalheight('.tissue_paper_wrapper .tissue');
});

$(window).resize(function () {
    equalheight('.tissue_paper_wrapper .tissue');
});


$(window).ready(function () {
    var validator = $("#contactform").validate({
        rules: {
            FirstName: {
                required: true,
                minlength: 2
            },
            LastName: {
                required: true,
                minlength: 2
            },
            PhoneNumber: {
                required: true,
                minlength: 2
            },
            Email: {
                required: true,
                email: true
            },
            Message: {
                required: true,
                minlength: 20
            }
        },
        messages: {
            firstname: {
                required: "Please enter your first name",
                minlength: jQuery.format("Please enter your first name")
            },
            lastname: {
                required: "Please enter your last name",
                minlength: jQuery.format("Please enter your last name")
            },
            telephone: {
                required: "Please enter your telephone number",
                minlength: jQuery.format("Please enter your telephone number")
            },
            email: {
                required: "Please enter a valid email address",
                minlength: "Please enter a valid email address"
            },
            message: {
                required: "Please enter a message",
                minlength: jQuery.format("Enter at least {0} characters")
            }
        },
        success: function (label) {
            label.addClass("checked");

        }
    });
});

$(function () {
    $(".social_show_hide").click(function () {
        $("#sharing_wrapper").animate({ height: 'toggle' }, 200);
    });
});
(function (i, s, o, g, r, a, m) {
    i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
        (i[r].q = i[r].q || []).push(arguments)
    }, i[r].l = 1 * new Date(); a = s.createElement(o),
        m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
})(window, document, 'script', 'https://www.google-analytics.com/analytics.js', 'ga');

ga('create', 'UA-222595453-1', 'auto');
ga('send', 'pageview');


