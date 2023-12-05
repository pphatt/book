"use strict";
class CarouselTwo {
    constructor(elems) {
        this.currentActivePanel = Math.floor(Math.random() * 9);
        this.width = 212;
        this.isTransitioning = false;
        this.transitionDuration = 0;
        const { productSlider, nextSlideButton, prevSlideButton } = elems;
        this.productSlider = productSlider;
        this.nextSlideButton = nextSlideButton;
        this.prevSlideButton = prevSlideButton;
        this.setupEventListener();
        this.handleTransitionEnd();
        this.handleSwiperWrapperStyle();
    }
    setupEventListener() {
        this.nextSlideButton.addEventListener("click", () => {
            this.handleSlideButton("next");
        });
        this.prevSlideButton.addEventListener("click", () => {
            this.handleSlideButton("previous");
        });
        this.productSlider.addEventListener("transitionend", () => {
            this.handleTransitionEnd();
            this.handleSwiperWrapperStyle();
        });
    }
    handleSlideButton(direction) {
        if (this.isTransitioning) {
            return;
        }
        this.transitionDuration = 300;
        this.isTransitioning = true;
        if (direction === "next") {
            this.currentActivePanel += 1;
        }
        else {
            this.currentActivePanel -= 1;
        }
        this.handleSwiperWrapperStyle();
    }
    handleSwiperWrapperStyle() {
        this.productSlider.style.transitionDuration = `${this.transitionDuration}ms`;
        this.productSlider.style.transform = `translate3d(${this.width * -this.currentActivePanel}px, 0px, 0px)`;
        document.querySelectorAll(".product-2").forEach((swipe, index) => {
            const element = swipe;
            element.style.width = `${this.width}px`;
            if (index === this.currentActivePanel) {
                element.className = "product-2 product-slide-active";
            }
            else if (index === this.currentActivePanel + 1) {
                element.className = "product-2 product-slide-next";
            }
            else if (index === this.currentActivePanel - 1) {
                element.className = "product-2 product-slide-previous";
            }
            else {
                element.className = "product-2";
            }
        });
    }
    handleTransitionEnd() {
        this.transitionDuration = 0;
        this.isTransitioning = false;
        if (this.currentActivePanel === 8) {
            this.currentActivePanel = 7;
            const slidesArray = [...document.querySelectorAll(".product-2")];
            const reorderedSlides = [...slidesArray.slice(1, slidesArray.length), slidesArray[0]];
            this.productSlider.innerHTML = '';
            reorderedSlides.forEach(slide => {
                this.productSlider.appendChild(slide.cloneNode(true));
            });
        }
        if (this.currentActivePanel === 0) {
            this.currentActivePanel = 1;
            const slidesArray = [...document.querySelectorAll(".product-2")];
            const reorderedSlides = [slidesArray[slidesArray.length - 1], ...slidesArray.slice(0, slidesArray.length - 1)];
            this.productSlider.innerHTML = '';
            reorderedSlides.forEach(slide => {
                this.productSlider.appendChild(slide.cloneNode(true));
            });
        }
    }
}
const carouselTwo = new CarouselTwo({
    productSlider: document.querySelector(".product-slider-2"),
    nextSlideButton: document.querySelector(".carousel-next-2"),
    prevSlideButton: document.querySelector(".carousel-previous-2"),
});
