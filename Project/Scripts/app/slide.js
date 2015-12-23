
var $slide;

function init(slide) {
    $slide = slide;
    initSlideSelector();
    var loop = slideLoop(0);

    $(".slide-selector input").on("change", function () {
        clearInterval(loop);
        slideChange($(this).index());
        loop = slideLoop($(this).index());
    });
}

function initSlideSelector() {
    var $slideContainer = $slide.parent();
    var $selectorContainer = $(document.createElement("div"));
    $selectorContainer.addClass("slide-selector");

    for (var i = 0; i < $slide.children().length; i++) {
        var $selector = $("<input type='radio' name='slide' />");
        $selector.appendTo($selectorContainer);
    }

    $slideContainer.append($selectorContainer);
}

function slideLoop(currentSlide) {
    var slideIndex = currentSlide;
    var fadeDuration = 5000;
    $(".slide-selector input:eq(" + slideIndex + ")").prop("checked", true);

    return setInterval(function () {
        slideIndex = nextSlideIndex(slideIndex);
        $(".slide-selector input:eq(" + slideIndex + ")").prop("checked", true);
        $slide.find("li").fadeOut(fadeDuration);
        $slide.find("li:eq(" + slideIndex  + ")").fadeIn(fadeDuration);
    }, fadeDuration * 2);
}

function slideChange(currentSlide) {
    var fadeDuration = 1000;
    $slide.find("li").fadeOut(fadeDuration);
    $slide.find("li:eq(" + currentSlide + ")").fadeIn(fadeDuration);
}

function nextSlideIndex(currentSlide) {
    currentSlide++;
    if (currentSlide > $slide.children().length - 1) {
        currentSlide = 0;
    }

    return currentSlide;
}

function previousSlideIndex(currentSlide) {
    currentSlide--;
    if (currentSlide < 0) {
        currentSlide = $slide.children().length - 1;
    }

    return currentSlide;
}
