import React, { useState } from 'react';
import '../styles/CartPage.css';

interface CartItem {
    id: number;
    name: string;
    price: number;
    quantity: number;
}

export default function CartPage() {
    const [cartItems, setCartItems] = useState<CartItem[]>([
        { id: 1, name: 'Monstera', price: 50, quantity: 2 },
        { id: 2, name: 'Ficus', price: 30, quantity: 1 },
        { id: 3, name: 'Succulent', price: 20, quantity: 3 },
    ]);

    const handleQuantityChange = (id: number, newQuantity: number) => {
        setCartItems((prevItems) =>
            prevItems.map((item) =>
                item.id === id ? { ...item, quantity: newQuantity } : item
            )
        );
    };

    const handleRemoveItem = (id: number) => {
        setCartItems((prevItems) => prevItems.filter((item) => item.id !== id));
    };

    const totalPrice = cartItems.reduce(
        (total, item) => total + item.price * item.quantity,
        0
    );

    return (
        <div className="basket-container">
            <h1>Koszyk</h1>
            {cartItems.length > 0 ? (
                <div>
                    <ul className="cart-list">
                        {cartItems.map((item) => (
                            <li key={item.id} className="cart-item">
                                <div className="item-details">
                                    <p className="item-name">{item.name}</p>
                                    <p className="item-price">{item.price} zl</p>
                                </div>
                                <div className="item-controls">
                                    <input
                                        type="number"
                                        min="1"
                                        value={item.quantity}
                                        onChange={(e) =>
                                            handleQuantityChange(
                                                item.id,
                                                parseInt(e.target.value, 10)
                                            )
                                        }
                                    />
                                    <button
                                        onClick={() => handleRemoveItem(item.id)}
                                        className="remove-button"
                                    >
                                        Usun
                                    </button>
                                </div>
                            </li>
                        ))}
                    </ul>
                    <div className="cart-summary">
                        <h3>£¹czna kwota: {totalPrice.toFixed(2)} zl</h3>
                        <button className="checkout-button">
                            Przejdz do kasy
                        </button>
                    </div>
                </div>
            ) : (
                <p>Twój koszyk jest pusty.</p>
            )}
        </div>
    );
}
