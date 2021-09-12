// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
$(window).on("load", function () {

    $(".loader .inner").fadeOut(500, function () {
        $(".loader").fadeOut(750);
    });

});

//$(document).ready(function () {

//	$('#slides').superslides({
//		animation: 'fade',
//		play: 5000,
//		pagination: false
//	});

//	var typed = new Typed(".typed", {
//		strings: ["UiiSii Hm-12.", "Dm-10.", "Nickband."],
//		typeSpeed: 70,
//		loop: true,
//		startDelay: 1000,
//		showCursor: false
//	});



//	var defaults = {
//		containerID: 'toTop', // fading element id
//		containerHoverID: 'toTopHover', // fading element hover id
//		scrollSpeed: 1200,
//		easingType: 'linear'
//	};

//	$().UItoTop({
//		easingType: 'easeOutQuart'
//	});
//});

//jQuery(document).ready(function ($) {
//	$(".scroll").click(function (event) {
//		event.preventDefault();
//		$('html,body').animate({ scrollTop: $(this.hash).offset().top }, 1000);
//	});
//});
