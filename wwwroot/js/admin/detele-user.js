"use strict";
class DeleteUser {
    constructor(elems) {
        this.isAnimating = false;
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
                if (open === "false" && !this.isAnimating) {
                    this.isAnimating = true;
                    element.setAttribute("data-open", "true");
                    const current_modal = this.modal[index];
                    current_modal.removeAttribute("style");
                    current_modal.className = "modal modal-animate-in";
                    const backdrop = current_modal.firstElementChild;
                    backdrop.className = "back-drop backdrop-animate-in";
                    backdrop.addEventListener("click", () => {
                        if (this.isAnimating) {
                            return;
                        }
                        backdrop.className = "back-drop backdrop-animate-out";
                        current_modal.className = "modal modal-animate-out";
                    });
                    backdrop.addEventListener("animationend", (event) => {
                        this.isAnimating = false;
                        backdrop.className = "back-drop";
                        current_modal.className = "modal";
                        if (event.animationName === "backdrop-animate-out") {
                            element.setAttribute("data-open", "false");
                            current_modal.setAttribute("style", "display: none");
                        }
                    });
                    current_modal.querySelector("button:first-child").addEventListener("click", () => {
                        if (this.isAnimating) {
                            return;
                        }
                        backdrop.className = "back-drop backdrop-animate-out";
                        current_modal.className = "modal modal-animate-out";
                    });
                }
            });
        });
    }
}
const deleteUser = new DeleteUser({
    button: document.querySelectorAll("button[data-product-id]"),
    modal: document.querySelectorAll("div[data-product-id]"),
});
