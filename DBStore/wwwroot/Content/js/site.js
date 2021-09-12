// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(window).on("load", function () {

    $(".loader .inner").fadeOut(500, function () {
        $(".loader").fadeOut(750);
    });

});

document.getElementById("test").addEventListener('click', () => { alert("HERE.") })
//(function ($) {
//    // Main Object
//    var RESHOP = {};

//    var

//    $modalProductDetailElement = $('#js-product-detail-modal');
//// Init Lightgallery plugin
//$productDetailElement.lightGallery({
//    selector: '.pd-o-img-wrap',// lightgallery-core
//    download: false,// lightgallery-core
//    thumbnail: false,// Thumbnails
//    autoplayControls: false,// Autoplay-plugin
//    actualSize: false,// Zoom-plugin: Enable actual pixel icon
//    hash: false, // Hash-plugin
//    share: false// share-plugin
//});
//// Thumbnail images
//// Fires after first initialization
//$productDetailElementThumbnail.on('init', function () {
//    $(this).closest('.slider-fouc').removeAttr('class');
//});

//$productDetailElementThumbnail.slick({
//    slidesToShow: 4,
//    slidesToScroll: 1,
//    infinite: false,
//    arrows: true,
//    dots: false,
//    focusOnSelect: true,
//    asNavFor: $productDetailElement,
//    prevArrow: '<div class="pt-prev"><i class="fas fa-angle-left"></i>',
//    nextArrow: '<div class="pt-next"><i class="fas fa-angle-right"></i>',
//    responsive: [
//        {
//            breakpoint: 1200,
//            settings: {
//                slidesToShow: 4
//            }
//        },
//        {
//            breakpoint: 992,
//            settings: {
//                slidesToShow: 3
//            }
//        },
//        {
//            breakpoint: 576,
//            settings: {
//                slidesToShow: 2
//            }
//        }
//    ]
//});



//})(jQuery);


container.onmouseover = container.onmouseout = handler;

function handler(event) {

    function str(el) {
        if (!el) return "null"
        return el.className || el.tagName;
    }

    log.value += event.type + ':  ' +
        'target=' + str(event.target) +
        ',  relatedTarget=' + str(event.relatedTarget) + "\n";
    log.scrollTop = log.scrollHeight;

    if (event.type == 'mouseover') {
        event.target.style.background = 'pink'
    }
    if (event.type == 'mouseout') {
        event.target.style.background = ''
    }
}
