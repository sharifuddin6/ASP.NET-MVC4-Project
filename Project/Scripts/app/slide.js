
function init($slide) {
    var slideCount = $slide.children().length;
    var currentSlide = 1;
    var previousSlide = slideCount;
    var fade = 5000;

    setInterval(function () {
        $slide.find("li:eq(" + currentSlide + ")").fadeIn(fade);
        $slide.find("li:eq(" + previousSlide + ")").fadeOut(fade);

        currentSlide++;
        previousSlide++;

        if (currentSlide > slideCount) {
            currentSlide = 1;
        }

        if (previousSlide > slideCount) {
            previousSlide = 1;
        }

    }, fade * 2);
}