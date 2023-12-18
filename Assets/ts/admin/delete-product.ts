class DeleteProduct {
    private button: NodeList
    private modal: NodeList

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

                if (open === "false") {
                    element.setAttribute("data-open", "true")

                    const current_modal = this.modal[index] as HTMLElement

                    current_modal.removeAttribute("style")

                    const backdrop = current_modal.firstElementChild as HTMLElement

                    backdrop.addEventListener("click", () => {
                        element.setAttribute("data-open", "false")
                        current_modal.setAttribute("style", "display: none")
                    })
                }
            })
        })
    }
}

const deleteProduct = new DeleteProduct({
    button: document.querySelectorAll("button[data-product-id]") as NodeList,
    modal: document.querySelectorAll("div[data-product-id]") as NodeList,
})
