class Search {
    private open: boolean = false;
    private opacity: number = 0;

    private searchWrapElement: HTMLDivElement;
    private navBarBackground: HTMLDivElement;
    private backdrop: HTMLDivElement;

    constructor(elems: {
        searchWrapElement: HTMLDivElement
        navBarBackground: HTMLDivElement
        backdrop: HTMLDivElement
    }) {
        const {searchWrapElement, navBarBackground, backdrop} = elems;

        this.searchWrapElement = searchWrapElement
        this.navBarBackground = navBarBackground
        this.backdrop = backdrop;

        this.setupEventListener();
    }

    setupEventListener() {
        this.searchWrapElement.addEventListener("click", (e: MouseEvent) => {
            e.stopPropagation();
            
            if (!this.open) {
                this.open = true;
            }

            this.searchInputActive()
        })

        this.backdrop.addEventListener("click", (e: MouseEvent) => {
            e.stopPropagation();

            if (this.open) {
                this.open = false;
            }

            this.searchInputActive()
        })

        window.addEventListener("scroll", () => {
            if (window.scrollY <= 56) {
                this.opacity = 0.0178571 * window.scrollY
            } else {
                this.opacity = 1
            }

            this.navBarBackgroundControl()
        })

        window.addEventListener("keydown", (e: KeyboardEvent) => {
            if (e.key === "k" && (e.metaKey || e.ctrlKey)) {
                e.preventDefault()
                this.open = !this.open
            }

            this.searchInputActive()
        })
    }

    searchInputActive() {
        this.searchWrapElement.className = ["search", this.open ? " active" : ""].join("")
    }

    navBarBackgroundControl() {
        this.navBarBackground.style.opacity = `${this.opacity}`
    }
}

const search = new Search({
    searchWrapElement: document.querySelector(".search") as HTMLDivElement,
    navBarBackground: document.querySelector(".navbar-background") as HTMLDivElement,
    backdrop: document.querySelector(".search-backdrop") as HTMLDivElement,
})
