"use strict";
class Search {
    constructor(elems) {
        this.open = false;
        this.opacity = 0;
        const { searchWrapElement, navBarBackground, backdrop } = elems;
        this.searchWrapElement = searchWrapElement;
        this.navBarBackground = navBarBackground;
        this.backdrop = backdrop;
        this.setupEventListener();
    }
    setupEventListener() {
        this.searchWrapElement.addEventListener("click", (e) => {
            e.stopPropagation();
            if (!this.open) {
                this.open = true;
            }
            this.searchInputActive();
        });
        this.backdrop.addEventListener("click", (e) => {
            e.stopPropagation();
            if (this.open) {
                this.open = false;
            }
            this.searchInputActive();
        });
        window.addEventListener("scroll", () => {
            if (window.scrollY <= 56) {
                this.opacity = 0.0178571 * window.scrollY;
            }
            else {
                this.opacity = 1;
            }
        });
        window.addEventListener("keydown", (e) => {
            if (e.key === "k" && (e.metaKey || e.ctrlKey)) {
                e.preventDefault();
                this.open = !this.open;
            }
        });
        this.navBarBackgroundControl();
    }
    searchInputActive() {
        this.searchWrapElement.className = ["search", this.open ? " active" : ""].join("");
    }
    navBarBackgroundControl() {
        this.navBarBackground.style.opacity = `${this.opacity}`;
    }
}
const search = new Search({
    searchWrapElement: document.querySelector(".search"),
    navBarBackground: document.querySelector(".navbar-background"),
    backdrop: document.querySelector(".search-backdrop"),
});
