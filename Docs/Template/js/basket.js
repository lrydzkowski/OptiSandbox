// Mini Basket JavaScript Functionality

document.addEventListener('DOMContentLoaded', function () {
  // Initialize the offcanvas basket
  const basketOffcanvas = new bootstrap.Offcanvas(document.getElementById('basketOffcanvas'));

  // Get cart icon element
  const cartIconWrapper = document.querySelector('.cart-icon-wrapper');

  // Open basket offcanvas when cart icon is clicked
  if (cartIconWrapper) {
    cartIconWrapper.addEventListener('click', function (e) {
      e.preventDefault();
      basketOffcanvas.show();
    });
  }

  // Quantity adjustment in mini basket
  const miniQtyBtns = document.querySelectorAll('.mini-qty-btn');

  miniQtyBtns.forEach(btn => {
    btn.addEventListener('click', function () {
      const input = this.parentElement.querySelector('.mini-qty-input');
      let value = parseInt(input.value);

      if (this.textContent === '-') {
        if (value > 1) {
          input.value = value - 1;
          updateCartTotal();
        }
      } else {
        if (value < 10) {
          input.value = value + 1;
          updateCartTotal();
        }
      }
    });
  });

  // Remove item from mini basket
  const miniRemoveBtns = document.querySelectorAll('.mini-remove-btn');

  miniRemoveBtns.forEach(btn => {
    btn.addEventListener('click', function () {
      const item = this.closest('.mini-basket-item');

      // Add fade-out animation
      item.style.opacity = '0';
      item.style.transform = 'translateX(20px)';
      item.style.transition = 'opacity 0.3s ease, transform 0.3s ease';

      // Remove after animation completes
      setTimeout(() => {
        item.remove();
        updateCartTotal();
        updateCartCount();
        checkIfEmpty();
      }, 300);
    });
  });

  // Function to update cart total
  function updateCartTotal() {
    // In a real implementation, this would calculate based on actual quantities and prices
    // This is a simplified example
    const items = document.querySelectorAll('.mini-basket-item');

    if (items.length === 0) {
      document.querySelector('.mini-basket-summary').classList.add('d-none');
    } else {
      document.querySelector('.mini-basket-summary').classList.remove('d-none');
    }
  }

  // Function to update cart item count
  function updateCartCount() {
    const items = document.querySelectorAll('.mini-basket-item');
    const cartCount = document.querySelector('.cart-count');

    if (cartCount) {
      cartCount.textContent = items.length;

      // Add animation
      cartCount.classList.add('updated');
      setTimeout(() => {
        cartCount.classList.remove('updated');
      }, 300);
    }
  }

  // Function to check if basket is empty
  function checkIfEmpty() {
    const items = document.querySelectorAll('.mini-basket-item');
    const emptyMessage = document.querySelector('.mini-basket-empty');
    const basketItems = document.querySelector('.mini-basket-items');

    if (items.length === 0) {
      emptyMessage.classList.remove('d-none');
      basketItems.classList.add('d-none');
    } else {
      emptyMessage.classList.add('d-none');
      basketItems.classList.remove('d-none');
    }
  }

  // Add to cart functionality (on product pages)
  const addToCartBtn = document.querySelector('.add-to-cart');

  if (addToCartBtn) {
    addToCartBtn.addEventListener('click', function (e) {
      e.preventDefault();

      // Show notification
      showCartNotification('Item added to your basket');

      // Update cart count
      const cartCount = document.querySelector('.cart-count');
      if (cartCount) {
        let count = parseInt(cartCount.textContent) || 0;
        cartCount.textContent = count + 1;

        // Add animation
        cartCount.classList.add('updated');
        setTimeout(() => {
          cartCount.classList.remove('updated');
        }, 300);
      }

      // Optionally open the basket offcanvas
      // basketOffcanvas.show();
    });
  }

  // Function to show cart notification
  function showCartNotification(message) {
    // Create notification element if it doesn't exist
    let notification = document.querySelector('.cart-notification');

    if (!notification) {
      notification = document.createElement('div');
      notification.className = 'cart-notification';

      const content = document.createElement('div');
      content.className = 'cart-notification-content';

      const icon = document.createElement('span');
      icon.className = 'cart-notification-icon';
      icon.textContent = '✓';

      const text = document.createElement('span');

      content.appendChild(icon);
      content.appendChild(text);
      notification.appendChild(content);

      document.body.appendChild(notification);
    }

    // Update message
    notification.querySelector('.cart-notification-content span:last-child').textContent = message;

    // Show notification
    notification.classList.add('show');

    // Hide after 3 seconds
    setTimeout(() => {
      notification.classList.remove('show');
    }, 3000);
  }
});