class DeleteUser {
    private button: NodeList
    private modal: NodeList

    private isAnimating: boolean = false

    constructor(elems: { button: NodeList; modal: NodeList }) {
        const {button, modal} = elems

        this.button = button
        this.modal = modal
        this.setupEventListener()
    }

    setupEventListener() {
        this.button.forEach((node, index) => {
            const element = node as HTMLElement

            element.addEventListener("click", () => {
                const open = element.getAttribute("data-open") as string

                if (open === "false" && !this.isAnimating) {
                    this.isAnimating = true

                    element.setAttribute("data-open", "true")

                    const current_modal = this.modal[index] as HTMLElement
                    current_modal.removeAttribute("style")
                    current_modal.className = "modal modal-animate-in"

                    const backdrop = current_modal.firstElementChild as HTMLElement
                    backdrop.className = "back-drop backdrop-animate-in"

                    backdrop.addEventListener("click", () => {
                        if (this.isAnimating) {
                            return
                        }

                        backdrop.className = "back-drop backdrop-animate-out"

                        current_modal.className = "modal modal-animate-out"
                    })

                    backdrop.addEventListener("animationend", (event) => {
                        this.isAnimating = false

                        backdrop.className = "back-drop"
                        current_modal.className = "modal"

                        if (event.animationName === "backdrop-animate-out") {
                            element.setAttribute("data-open", "false")
                            current_modal.setAttribute("style", "display: none")
                        }
                    });

                    (current_modal.querySelector("button:first-child") as HTMLButtonElement).addEventListener("click", () => {
                        if (this.isAnimating) {
                            return
                        }

                        backdrop.className = "back-drop backdrop-animate-out"

                        current_modal.className = "modal modal-animate-out"
                    })
                }
            })
        })
    }
}

const deleteUser = new DeleteUser({
    button: document.querySelectorAll("button[data-product-id]") as NodeList,
    modal: document.querySelectorAll("div[data-product-id]") as NodeList,
})
