"use strict";
class Home {
    constructor(elems) {
        const { bestSellerCategory, mostViewProductCategory } = elems;
        this.bestSellerCategory = bestSellerCategory;
        this.mostViewProductCategory = mostViewProductCategory;
        this.setupEventListener();
    }
    setupEventListener() {
        this.bestSellerCategory.addEventListener("click", () => {
            this.bestSellerCategory.className = "best-seller-category header-active";
            this.mostViewProductCategory.className = "most-view-product-category";
        });
        this.mostViewProductCategory.addEventListener("click", () => {
            this.bestSellerCategory.className = "best-seller-category";
            this.mostViewProductCategory.className = "most-view-product-category header-active";
        });
    }
}
const home = new Home({
    bestSellerCategory: document.querySelector(".best-seller-category"),
    mostViewProductCategory: document.querySelector(".most-view-product-category")
});
