let allCarouselItem = document.querySelectorAll(".carousel-items");
let allCarouselItemPrice = document.querySelectorAll(".carousel-items > .product-price-carousel");
let allCarouselItemName = document.querySelectorAll(".carousel-items > .product-name-carousel");
let focusedItem = Math.floor(allCarouselItem.length / 2);
for (let i = 0; i < allCarouselItem.length; i++) {
    if (i === focusedItem) {
        allCarouselItem[i].style.transform = "scale(1)";
        allCarouselItemPrice[i].style.transform = "translateY(0)";
        allCarouselItemPrice[i].style.opacity = "1";
        allCarouselItemName[i].style.transform = "translateY(0)";
        allCarouselItemName[i].style.opacity = "1";
    } else {
        allCarouselItem[i].style.transform = "scale(0.6)";
    }
    setTimeout(function () {
        allCarouselItem[i].style.transition = "transform .4s linear 0s";
    }, 300);
}

let carousel = document.querySelector(".carousel-design");
let carouselMovement = -50;
let movement = 0;
document.getElementById("next").addEventListener("click", function () {
    document.getElementById("prev").style.pointerEvents = "auto";
    if ((focusedItem + movement) < (allCarouselItem.length - 3)) {
        movement++;
        focusedItem += movement;
        allCarouselItem[focusedItem].style.transform = "scale(1)";
        allCarouselItem[focusedItem - 1].style.transform = "scale(0.6)";       
        carousel.style.transform = "translateX(" + (carouselMovement - (movement * 9.1)) + "%)";
        allCarouselItemPrice[focusedItem].style.transform = "translateY(0)";
        allCarouselItemPrice[focusedItem].style.opacity = "1";
        allCarouselItemName[focusedItem].style.transform = "translateY(0)";
        allCarouselItemName[focusedItem].style.opacity = "1";
        allCarouselItemPrice[focusedItem - 1].style.transform = "translateY(-40px)";
        allCarouselItemPrice[focusedItem - 1].style.opacity = "0";
        allCarouselItemName[focusedItem - 1].style.transform = "translateY(40px)";
        allCarouselItemName[focusedItem - 1].style.opacity = "0";
        focusedItem = Math.floor(allCarouselItem.length / 2);
    } else {
        document.getElementById("next").style.pointerEvents = "none";
    }
});

document.getElementById("prev").addEventListener("click", function () {
    document.getElementById("next").style.pointerEvents = "auto";
    if ((focusedItem + movement) > 2) {
    movement--;
    focusedItem += movement;
    allCarouselItem[focusedItem].style.transform = "scale(1)";
    allCarouselItem[focusedItem + 1].style.transform = "scale(0.6)";
    carousel.style.transform = "translateX(" + (carouselMovement - (movement * 9.1)) + "%)";
    allCarouselItemPrice[focusedItem].style.transform = "translateY(0)";
    allCarouselItemPrice[focusedItem].style.opacity = "1";
    allCarouselItemName[focusedItem].style.transform = "translateY(0)";
    allCarouselItemName[focusedItem].style.opacity = "1";
    allCarouselItemPrice[focusedItem + 1].style.transform = "translateY(-40px)";
    allCarouselItemPrice[focusedItem + 1].style.opacity = "0";
    allCarouselItemName[focusedItem + 1].style.transform = "translateY(40px)";
    allCarouselItemName[focusedItem + 1].style.opacity = "0";
    focusedItem = Math.floor(allCarouselItem.length / 2);
    } else {
        document.getElementById("prev").style.pointerEvents = "none";
    }
})