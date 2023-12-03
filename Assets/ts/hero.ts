class Hero {
    private currentActivePanel: number;
    private width: number = (document.querySelector(".swiper-wrapper") as HTMLDivElement).offsetWidth - 2

    private isTransitioning: boolean = false;
    private transitionDuration: number = 0;

    private swiperWrapper: HTMLDivElement;

    private nextSlideButton: HTMLButtonElement;
    private prevSlideButton: HTMLButtonElement;

    private slideNumberMarker: HTMLDivElement = document.querySelector(".swiper-number") as HTMLDivElement

    constructor(elems: {
        swiperWrapper: HTMLDivElement;

        nextSlideButton: HTMLButtonElement;
        prevSlideButton: HTMLButtonElement;
    }) {
        const {swiperWrapper, nextSlideButton, prevSlideButton} = elems;

        this.swiperWrapper = swiperWrapper

        this.nextSlideButton = nextSlideButton
        this.prevSlideButton = prevSlideButton

        this.currentActivePanel = Math.floor(Math.random() * 7) + 2

        this.setupEventListener()
        this.handleSwiperWrapperStyle()
    }

    setupEventListener() {
        this.nextSlideButton.addEventListener("click", () => {
            this.handleSlideButton("next")
        })

        this.prevSlideButton.addEventListener("click", () => {
            this.handleSlideButton("previous")
        })

        this.swiperWrapper.addEventListener("transitionend", () => {
            this.handleTransitionEnd()

            this.handleSwiperWrapperStyle()
        })
    }

    handleSlideButton(direction: string) {
        if (this.isTransitioning) {
            return
        }

        this.transitionDuration = 300
        this.isTransitioning = true

        if (direction === "next") {
            this.currentActivePanel += 1
        } else {
            this.currentActivePanel -= 1
        }

        this.handleSwiperWrapperStyle()
    }

    handleSwiperWrapperStyle() {
        this.swiperWrapper.style.transitionDuration = `${this.transitionDuration}ms`;
        this.swiperWrapper.style.transform = `translate3d(${this.width * -this.currentActivePanel}px, 0px, 0px)`;

        (document.querySelectorAll(".swiper-slide") as NodeList).forEach((swipe, index) => {
            const element = swipe as HTMLDivElement

            element.style.width = `${this.width}px`

            if (index === this.currentActivePanel) {
                element.className = "swiper-slide swiper-slide-active"
            } else if (index === this.currentActivePanel + 1) {
                element.className = "swiper-slide swiper-slide-next"
            } else if (index === this.currentActivePanel - 1) {
                element.className = "swiper-slide swiper-slide-previous"
            } else {
                element.className = "swiper-slide"
            }
        })

        const index = (document.querySelector(".swiper-slide-active") as HTMLDivElement).getAttribute("data-swiper-slide-index")!

        this.slideNumberMarker.innerHTML = `NO. ${parseInt(index) + 1}`
    }

    handleTransitionEnd() {
        this.transitionDuration = 0
        this.isTransitioning = false

        if (this.currentActivePanel === 9) {
            this.currentActivePanel = 8

            const slidesArray = [...(document.querySelectorAll(".swiper-slide") as NodeList)];

            const reorderedSlides = [...slidesArray.slice(1, 10), slidesArray[0]];

            this.swiperWrapper.innerHTML = '';

            reorderedSlides.forEach(slide => {
                this.swiperWrapper.appendChild(slide.cloneNode(true));
            });
        }

        if (this.currentActivePanel === 0) {
            this.currentActivePanel = 1

            const slidesArray = [...(document.querySelectorAll(".swiper-slide") as NodeList)];

            const reorderedSlides = [slidesArray[slidesArray.length - 1], ...slidesArray.slice(0, 9)];

            this.swiperWrapper.innerHTML = '';

            reorderedSlides.forEach(slide => {
                this.swiperWrapper.appendChild(slide.cloneNode(true));
            });
        }
    }
}

const hero = new Hero({
    swiperWrapper: document.querySelector(".swiper-wrapper") as HTMLDivElement,
    nextSlideButton: document.getElementById("next") as HTMLButtonElement,
    prevSlideButton: document.getElementById("previous") as HTMLButtonElement,
})