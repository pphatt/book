"use strict";
class QuantityControl {
    constructor(elems) {
        const { input, decreasedButton, increasedButton } = elems;
        this.input = input;
        this.decreasedButton = decreasedButton;
        this.increasedButton = increasedButton;
        this.input.value = "1";
        this.setupEventListener();
    }
    setupEventListener() {
        this.input.addEventListener("input", (event) => {
            const element = this.input;
            element.value = element.value
                .replace(/[^0-9]/g, "")
                .replace(/^0+/, "");
            const value = parseInt(element.value);
            if (value > 999) {
                element.value = "999";
            }
            if (value < 0 || element.value === "") {
                element.value = "1";
            }
        });
        this.decreasedButton.addEventListener("click", () => {
            const element = this.input;
            element.value = element.value
                .replace(/[^0-9]/g, "")
                .replace(/^0+/, "");
            const value = parseInt(element.value);
            if (value > 1) {
                element.value = `${value - 1}`;
            }
        });
        this.increasedButton.addEventListener("click", () => {
            const element = this.input;
            element.value = element.value
                .replace(/[^0-9]/g, "")
                .replace(/^0+/, "");
            const value = parseInt(element.value);
            if (value < 999) {
                element.value = `${value + 1}`;
            }
        });
    }
}
class Description {
    constructor(elems) {
        this.defaultDescriptionHeight = 0;
        this.showMoreButton = null;
        this.showDescription = false;
        const { description } = elems;
        this.description = description;
        this.setupEventListener();
    }
    setupEventListener() {
        const element = this.description.children[0];
        this.defaultDescriptionHeight = element.offsetHeight;
        if (this.defaultDescriptionHeight > 250) {
            element.style.height = "234px";
            element.style.maxHeight = "234px";
            element.style.webkitMaskImage = "linear-gradient(black 0%, black 60%, transparent 100%)";
            const showMoreButtonHTML = `<div class="expand-description">
                    <button
                        class="expand-description-button"
                        data-open="false">
                        <svg
                            data-v-4c681a64=""
                            xmlns="http://www.w3.org/2000/svg"
                            width="24"
                            height="24"
                            fill="none"
                            stroke="currentColor"
                            stroke-linecap="round"
                            stroke-linejoin="round"
                            stroke-width="2"
                            viewBox="0 0 24 24">
                            <path d="m7 13 5 5 5-5M7 6l5 5 5-5"></path>
                        </svg>
                        <span>see more</span>
                        <svg
                            data-v-4c681a64=""
                            xmlns="http://www.w3.org/2000/svg"
                            width="24"
                            height="24"
                            fill="none"
                            stroke="currentColor"
                            stroke-linecap="round"
                            stroke-linejoin="round"
                            stroke-width="2"
                            viewBox="0 0 24 24">
                            <path d="m7 13 5 5 5-5M7 6l5 5 5-5"></path>
                        </svg>
                    </button>
                </div>`;
            this.description.insertAdjacentHTML("beforeend", showMoreButtonHTML);
            this.handleShowMore(element);
        }
        else {
            element.style.height = `${this.defaultDescriptionHeight}px`;
            element.style.maxHeight = `${this.defaultDescriptionHeight}px`;
            element.style.maskImage = "";
        }
    }
    handleShowMore(description) {
        const showMoreButtonWrapper = document.querySelector(".expand-description");
        this.showMoreButton = document.querySelector(".expand-description-button");
        if (this.showDescription) {
            this.showMoreButton.style.backgroundColor = "rgb(44 44 44)";
            showMoreButtonWrapper.style.borderColor = "transparent";
        }
        else {
            this.showMoreButton.style.backgroundColor = "";
            showMoreButtonWrapper.style.borderColor = "rgb(255, 103, 64)";
        }
        this.showMoreButton.addEventListener("click", (event) => {
            if (this.showDescription) {
                description.style.height = "234px";
                description.style.maxHeight = "234px";
                description.style.webkitMaskImage = "linear-gradient(black 0%, black 60%, transparent 100%)";
                showMoreButtonWrapper.style.borderColor = "rgb(255, 103, 64)";
                this.showDescription = false;
                this.showMoreButton.style.backgroundColor = "";
                this.showMoreButton.setAttribute("data-open", `${this.showDescription}`);
            }
            else {
                description.style.height = `${this.defaultDescriptionHeight}px`;
                description.style.maxHeight = `${this.defaultDescriptionHeight}px`;
                description.style.webkitMaskImage = "";
                showMoreButtonWrapper.style.borderColor = "transparent";
                this.showDescription = true;
                this.showMoreButton.style.backgroundColor = "rgb(44 44 44)";
                this.showMoreButton.setAttribute("data-open", `${this.showDescription}`);
            }
        });
    }
}
const quantityControl = new QuantityControl({
    input: document.querySelector("#qty"),
    decreasedButton: document.querySelector("[data-control=decreased]"),
    increasedButton: document.querySelector("[data-control=increased]")
});
const description = new Description({
    description: document.querySelector(".product-description-wrapper")
});
