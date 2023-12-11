class PasswordDescription {
    private passwordInput: HTMLInputElement

    private passwordDescriptionUppercase: HTMLDivElement
    private passwordDescriptionLowercase: HTMLDivElement
    private passwordDescriptionContainNumber: HTMLDivElement
    private passwordDescriptionSpecialCharacter: HTMLDivElement
    private passwordDescriptionLength: HTMLDivElement

    private submitButton: HTMLButtonElement

    constructor(elems: {
        passwordInput: HTMLInputElement

        passwordDescriptionUppercase: HTMLDivElement
        passwordDescriptionLowercase: HTMLDivElement
        passwordDescriptionContainNumber: HTMLDivElement
        passwordDescriptionSpecialCharacter: HTMLDivElement
        passwordDescriptionLength: HTMLDivElement

        submitButton: HTMLButtonElement
    }) {
        const {
            passwordInput,
            passwordDescriptionUppercase,
            passwordDescriptionLowercase,
            passwordDescriptionContainNumber,
            passwordDescriptionSpecialCharacter,
            passwordDescriptionLength,
            submitButton
        } = elems

        this.passwordInput = passwordInput

        this.passwordDescriptionUppercase = passwordDescriptionUppercase
        this.passwordDescriptionLowercase = passwordDescriptionLowercase
        this.passwordDescriptionContainNumber = passwordDescriptionContainNumber
        this.passwordDescriptionSpecialCharacter = passwordDescriptionSpecialCharacter
        this.passwordDescriptionLength = passwordDescriptionLength

        this.submitButton = submitButton

        this.setupEventListener()
    }

    setupEventListener() {
        this.passwordInput.addEventListener("input", () => {
            const value = this.passwordInput.value

            let flag = 0

            if (value.length > 8) {
                this.passwordDescriptionLength.setAttribute("data-contain", "true")

                this.passwordDescriptionLength.innerHTML = `
                    <svg
                        xmlns="http://www.w3.org/2000/svg"
                        fill="currentColor"
                        viewBox="0 0 24 24"
                    >
                        <path
                          d="M2.25 12c0-5.385 4.365-9.75 9.75-9.75s9.75 4.365 9.75 9.75-4.365 9.75-9.75 9.75S2.25 17.385 2.25 12zm13.36-1.814a.75.75 0 10-1.22-.872l-3.236 4.53L9.53 12.22a.75.75 0 00-1.06 1.06l2.25 2.25a.75.75 0 001.14-.094l3.75-5.25z"
                          fill-rule="evenodd"
                          clip-rule="evenodd"
                        ></path>
                    </svg>
                    <p>&gt; 7 characters</p>`
                
                flag += 1
            } else {
                this.passwordDescriptionLength.setAttribute("data-contain", "false")

                this.passwordDescriptionLength.innerHTML = `
                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" stroke="currentColor" stroke-width="1.5" viewBox="0 0 24 24">
                        <path stroke-linecap="round" stroke-linejoin="round" d="M21 12a9 9 0 1 1-18 0 9 9 0 0 1 18 0z"></path>
                    </svg>
                    <p>&gt; 7 characters</p>`

                flag -= 1
            }

            if (/[A-Z]/.test(value)) {
                this.passwordDescriptionUppercase.setAttribute("data-contain", "true")

                this.passwordDescriptionUppercase.innerHTML = `
                    <svg
                        xmlns="http://www.w3.org/2000/svg"
                        fill="currentColor"
                        viewBox="0 0 24 24"
                    >
                        <path
                          d="M2.25 12c0-5.385 4.365-9.75 9.75-9.75s9.75 4.365 9.75 9.75-4.365 9.75-9.75 9.75S2.25 17.385 2.25 12zm13.36-1.814a.75.75 0 10-1.22-.872l-3.236 4.53L9.53 12.22a.75.75 0 00-1.06 1.06l2.25 2.25a.75.75 0 001.14-.094l3.75-5.25z"
                          fill-rule="evenodd"
                          clip-rule="evenodd"
                        ></path>
                    </svg>
                    <p>Uppercase letter</p>`

                flag += 1
            } else {
                this.passwordDescriptionUppercase.setAttribute("data-contain", "false")

                this.passwordDescriptionUppercase.innerHTML = `
                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" stroke="currentColor" stroke-width="1.5" viewBox="0 0 24 24">
                        <path stroke-linecap="round" stroke-linejoin="round" d="M21 12a9 9 0 1 1-18 0 9 9 0 0 1 18 0z"></path>
                    </svg>
                    <p>Uppercase letter</p>`

                flag -= 1
            }

            if (/[a-z]/.test(value)) {
                this.passwordDescriptionLowercase.setAttribute("data-contain", "true")

                this.passwordDescriptionLowercase.innerHTML = `
                    <svg
                        xmlns="http://www.w3.org/2000/svg"
                        fill="currentColor"
                        viewBox="0 0 24 24"
                    >
                        <path
                          d="M2.25 12c0-5.385 4.365-9.75 9.75-9.75s9.75 4.365 9.75 9.75-4.365 9.75-9.75 9.75S2.25 17.385 2.25 12zm13.36-1.814a.75.75 0 10-1.22-.872l-3.236 4.53L9.53 12.22a.75.75 0 00-1.06 1.06l2.25 2.25a.75.75 0 001.14-.094l3.75-5.25z"
                          fill-rule="evenodd"
                          clip-rule="evenodd"
                        ></path>
                    </svg>
                    <p>Lowercase letter</p>`

                flag += 1
            } else {
                this.passwordDescriptionLowercase.setAttribute("data-contain", "false")

                this.passwordDescriptionLowercase.innerHTML = `
                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" stroke="currentColor" stroke-width="1.5" viewBox="0 0 24 24">
                        <path stroke-linecap="round" stroke-linejoin="round" d="M21 12a9 9 0 1 1-18 0 9 9 0 0 1 18 0z"></path>
                    </svg>
                    <p>Lowercase letter</p>`

                flag -= 1
            }

            if (/[0-9]/.test(value)) {
                this.passwordDescriptionContainNumber.setAttribute("data-contain", "true")

                this.passwordDescriptionContainNumber.innerHTML = `
                    <svg
                        xmlns="http://www.w3.org/2000/svg"
                        fill="currentColor"
                        viewBox="0 0 24 24"
                    >
                        <path
                          d="M2.25 12c0-5.385 4.365-9.75 9.75-9.75s9.75 4.365 9.75 9.75-4.365 9.75-9.75 9.75S2.25 17.385 2.25 12zm13.36-1.814a.75.75 0 10-1.22-.872l-3.236 4.53L9.53 12.22a.75.75 0 00-1.06 1.06l2.25 2.25a.75.75 0 001.14-.094l3.75-5.25z"
                          fill-rule="evenodd"
                          clip-rule="evenodd"
                        ></path>
                    </svg>
                    <p>Number</p>`

                flag += 1
            } else {
                this.passwordDescriptionContainNumber.setAttribute("data-contain", "false")

                this.passwordDescriptionContainNumber.innerHTML = `
                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" stroke="currentColor" stroke-width="1.5" viewBox="0 0 24 24">
                        <path stroke-linecap="round" stroke-linejoin="round" d="M21 12a9 9 0 1 1-18 0 9 9 0 0 1 18 0z"></path>
                    </svg>
                    <p>Number</p>`

                flag -= 1
            }

            if (/[!@#$%^&*)(+=._-]/g.test(value)) {
                this.passwordDescriptionSpecialCharacter.setAttribute("data-contain", "true")

                this.passwordDescriptionSpecialCharacter.innerHTML = `
                    <svg
                        xmlns="http://www.w3.org/2000/svg"
                        fill="currentColor"
                        viewBox="0 0 24 24"
                    >
                        <path
                          d="M2.25 12c0-5.385 4.365-9.75 9.75-9.75s9.75 4.365 9.75 9.75-4.365 9.75-9.75 9.75S2.25 17.385 2.25 12zm13.36-1.814a.75.75 0 10-1.22-.872l-3.236 4.53L9.53 12.22a.75.75 0 00-1.06 1.06l2.25 2.25a.75.75 0 001.14-.094l3.75-5.25z"
                          fill-rule="evenodd"
                          clip-rule="evenodd"
                        ></path>
                    </svg>
                    <p>Special character (e.g. !?&lt;&gt;&#64;#$%)</p>`

                flag += 1
            } else {
                this.passwordDescriptionSpecialCharacter.setAttribute("data-contain", "false")

                this.passwordDescriptionSpecialCharacter.innerHTML = `
                    <svg xmlns="http://www.w3.org/2000/svg" fill="none" stroke="currentColor" stroke-width="1.5" viewBox="0 0 24 24">
                        <path stroke-linecap="round" stroke-linejoin="round" d="M21 12a9 9 0 1 1-18 0 9 9 0 0 1 18 0z"></path>
                    </svg>
                    <p>Special character (e.g. !?&lt;&gt;&#64;#$%)</p>`

                flag -= 1
            }

            this.submitButton.disabled = flag !== 5;
        })
    }
}

const passwordDescription = new PasswordDescription({
    passwordInput: document.querySelector("#password") as HTMLInputElement,
    passwordDescriptionUppercase: document.querySelector("[data-control=password-uppercase]") as HTMLDivElement,
    passwordDescriptionLowercase: document.querySelector("[data-control=password-lowercase]") as HTMLDivElement,
    passwordDescriptionContainNumber: document.querySelector("[data-control=password-contain-number]") as HTMLDivElement,
    passwordDescriptionSpecialCharacter: document.querySelector("[data-control=password-special-character]") as HTMLDivElement,
    passwordDescriptionLength: document.querySelector("[data-control=password-length]") as HTMLDivElement,
    submitButton: document.querySelector(".submit-button") as HTMLButtonElement,
})
