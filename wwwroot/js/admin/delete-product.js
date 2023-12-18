"use strict";
class DeleteProduct {
    constructor(elems) {
        const { button, modal } = elems;
        this.button = button;
        this.modal = modal;
        this.setupEventListener();
    }
    setupEventListener() {
        this.button.forEach((node, index) => {
            const element = node;
            element.addEventListener("click", () => {
                const open = element.getAttribute("data-open");
                if (open === "false") {
                    element.setAttribute("data-open", "true");
                    const current_modal = this.modal[index];
                    current_modal.removeAttribute("style");
                    const backdrop = current_modal.firstElementChild;
                    backdrop.addEventListener("click", () => {
                        element.setAttribute("data-open", "false");
                        current_modal.setAttribute("style", "display: none");
                    });
                }
            });
        });
    }
}
const deleteProduct = new DeleteProduct({
    button: document.querySelectorAll("button[data-product-id]"),
    modal: document.querySelectorAll("div[data-product-id]"),
});
