let cart = [];

const savedCart = localStorage.getItem("cart");
if (savedCart) {
    cart = JSON.parse(savedCart);
}

function renderCart() {
    const container = document.getElementById("cart-items");
    if (!container) return;

    container.innerHTML = "";

    if (cart.length === 0) {
        container.innerHTML = "<p>Запрос пуст</p>";
        return;
    }

    let ul = document.createElement("ul");
    ul.className = "list-group mb-3";
    
    for (let i = 0; i < cart.length; i++) {
        let li = document.createElement("li");
        li.className = "list-group-item d-flex justify-content-between align-items-center";
        li.innerHTML = cart[i] + ` <button class="btn btn-sm btn-danger" onclick="removeFromCart(${i})">Удалить</button>`;
        ul.appendChild(li);
    }
    
    container.appendChild(ul);
}

function addToCart(item) {
    cart.push(item);
    localStorage.setItem("cart", JSON.stringify(cart));
    renderCart();
}

function removeFromCart(index) {
    cart.splice(index, 1);
    localStorage.setItem("cart", JSON.stringify(cart));
    renderCart();
}

function clearCart() {
    cart = [];
    localStorage.setItem("cart", JSON.stringify(cart));
    renderCart();
}

document.addEventListener("DOMContentLoaded", () => {
    renderCart();
});