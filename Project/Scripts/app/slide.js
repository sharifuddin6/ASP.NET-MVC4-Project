
function init($slide) {
    initSlideSelector($slide);
    var loop = slideLoop($slide, 0);

    $(".slide-selector input").on("change", function () {
        clearInterval(loop);
        slideChange($slide, $(this).index());
        loop = slideLoop($slide, $(this).index());
    });
}

function initSlideSelector($slide) {
    var $slideContainer = $slide.parent();
    var $selectorContainer = $(document.createElement("div"));
    $selectorContainer.addClass("slide-selector");

    for (var i = 0; i < $slide.children().length; i++) {
        var $selector = $("<input type='radio' name='slide' />");
        $selector.appendTo($selectorContainer);
    }

    $slideContainer.append($selectorContainer);
}

function slideLoop($slide, currentSlide) {
    var slideIndex = currentSlide;
    var fadeDuration = 5000;
    $(".slide-selector input:eq(" + slideIndex + ")").prop("checked", true);

    return setInterval(function () {
        slideIndex = nextSlideIndex($slide, slideIndex);
        $(".slide-selector input:eq(" + slideIndex + ")").prop("checked", true);
        $slide.find("li").fadeOut(fadeDuration);
        $slide.find("li:eq(" + slideIndex  + ")").fadeIn(fadeDuration);
    }, fadeDuration * 2);
}

function slideChange($slide, currentSlide) {
    var fadeDuration = 1000;
    $slide.find("li").fadeOut(fadeDuration);
    $slide.find("li:eq(" + currentSlide + ")").fadeIn(fadeDuration);
}

function nextSlideIndex($slide, currentSlide) {
    currentSlide++;
    if (currentSlide > $slide.children().length - 1) {
        currentSlide = 0;
    }

    return currentSlide;
}
