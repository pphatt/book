"use strict";
class UserPanel {
    constructor(elems) {
        this.showUserPanel = false;
        this.onAnimation = false;
        const { navWrapper, userButton, panelBackdrop } = elems;
        this.navWrapper = navWrapper;
        this.userButton = userButton;
        this.panelBackdrop = panelBackdrop;
        this.setupEventListener();
    }
    setupEventListener() {
        this.userButton.addEventListener("click", () => {
            if (this.onAnimation) {
                return;
            }
            this.handleShowUserPanel();
        });
        this.panelBackdrop.addEventListener("click", () => {
            if (this.onAnimation) {
                return;
            }
            this.handleShowUserPanel();
        });
    }
    handleShowUserPanel() {
        this.showUserPanel = !this.showUserPanel;
        if (this.showUserPanel) {
            const panel = `
                <div class="auth-panel-wrapper panel-enter-animation">
                  <div class="auth-panel-container">
                    <div class="auth-panel-role-wrapper">
                      <a class="auth-panel-role">
                        <span class="inner-auth-panel-role">
                          <div>
                            <div class="auth-avatar">
                              <svg
                                data-v-4c681a64=""
                                data-v-5e0ed1a1=""
                                xmlns="http://www.w3.org/2000/svg"
                                width="24"
                                height="24"
                                fill="none"
                                viewBox="0 0 24 24"
                              >
                                <path
                                  stroke="currentColor"
                                  stroke-linecap="round"
                                  stroke-linejoin="round"
                                  stroke-width="2"
                                  d="M20 21v-2a4 4 0 0 0-4-4H8a4 4 0 0 0-4 4v2m8-10a4 4 0 1 0 0-8 4 4 0 0 0 0 8Z"
                                ></path>
                              </svg>
                            </div>
                            <div class="auth-role-name">${this.userButton.getAttribute("data-role") === "True" ? "User" : "Admin"}</div>
                          </div>
                        </span>
                      </a>
                      <span class="line"></span>
                      <button class="dashboard-button">
                        <svg
                          data-v-4c681a64=""
                          data-v-5e0ed1a1=""
                          xmlns="http://www.w3.org/2000/svg"
                          width="24"
                          height="24"
                          fill="none"
                          viewBox="0 0 24 24"
                        >
                          <path
                            stroke="currentColor"
                            stroke-linecap="round"
                            stroke-linejoin="round"
                            stroke-width="2"
                            d="M20 21v-2a4 4 0 0 0-4-4H8a4 4 0 0 0-4 4v2m8-10a4 4 0 1 0 0-8 4 4 0 0 0 0 8Z"
                          ></path>
                        </svg>
                        <span>Profile</span>
                      </button>
                      ${this.userButton.getAttribute("data-role") === "True"
                ? ""
                : `<a href="/admin/manage-products" class="dashboard-button">
                                <svg
                                  xmlns="http://www.w3.org/2000/svg"
                                  width="24"
                                  height="24"
                                  viewBox="0 0 24 24"
                                  fill="none"
                                  stroke="currentColor"
                                  stroke-width="2"
                                  stroke-linecap="round"
                                  stroke-linejoin="round"
                                >
                                  <path d="M14.5 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7.5L14.5 2z" />
                                  <polyline points="14 2 14 8 20 8" />
                                  <line x1="16" x2="8" y1="13" y2="13" />
                                  <line x1="16" x2="8" y1="17" y2="17" />
                                  <line x1="10" x2="8" y1="9" y2="9" />
                                </svg>
                                <span>Dashboard</span>
                              </a>`}
                      <span class="line"></span>
                      <form action="/account/logout" method="post">
                         <button class="logout-button">
                            <span>Logout</span>
                         </button>
                      </form>
                    </div>
                  </div>
                </div>`;
            this.navWrapper.insertAdjacentHTML("beforeend", panel);
            this.panelBackdrop.setAttribute("data-open", "true");
            this.onAnimation = true;
            this.navWrapper.children[this.navWrapper.childElementCount - 1].addEventListener("animationend", (event) => {
                if (event.animationName === 'enter') {
                    this.navWrapper.children[this.navWrapper.childElementCount - 1].className = "auth-panel-wrapper";
                    this.onAnimation = false;
                }
            });
        }
        else {
            this.navWrapper.children[this.navWrapper.childElementCount - 1].className = "auth-panel-wrapper panel-exit-animation";
            this.panelBackdrop.setAttribute("data-open", "false");
            this.onAnimation = true;
            this.navWrapper.children[this.navWrapper.childElementCount - 1].addEventListener("animationend", (event) => {
                if (event.animationName === 'exit') {
                    this.navWrapper.removeChild(this.navWrapper.children[this.navWrapper.childElementCount - 1]);
                    this.onAnimation = false;
                }
            });
        }
    }
}
const userPanel = new UserPanel({
    navWrapper: document.querySelector(".side-navbar"),
    userButton: document.querySelector(".user-button"),
    panelBackdrop: document.querySelector(".auth-panel-backdrop")
});
