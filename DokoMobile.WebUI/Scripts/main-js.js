let navHeight = document.querySelector(".navigation").offsetHeight;

window.addEventListener("load", function () {
    document.querySelector(".search-result").style.paddingTop = navHeight + "px";
});

let searchBox = document.querySelector(".search-bar");
searchBox.addEventListener("focus", function () {
    let resultsHeight = document.querySelector(".search-result").offsetHeight;
    document.querySelector(".page").style.transform = "translateY(" + (resultsHeight - navHeight )+ "px)";
});