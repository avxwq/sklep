import React, { useState, useEffect } from 'react';
import { toast } from 'react-toastify'; // For toast notifications
import '../styles/CartPage.css';
import api from '../api/api';
import { useUser } from '../services/userContext'
interface CartItem {
    productId: number;
    name: string;
    price: number;
    quantity: number;
    totalPrice: number;
    imageUrl: string;
}

interface CartResponse {
    cartItems: CartItem[];
    totalValue: number;
}

export default function CartPage() {
    const [cartItems, setCartItems] = useState<CartItem[]>([]);
    const [totalValue, setTotalValue] = useState<number>(0);
    const { user, setUser } = useUser();
    const userId = user.id;

    useEffect(() => {
        const fetchCart = async () => {
            try {
                const data = await api.fetchUserCart(userId);
                setCartItems(data.cartItems);
                setTotalValue(data.totalValue);
            } catch (error) {
                toast.error('Failed to fetch cart data.');
            }
        };

        fetchCart();
    }, [userId]);

    const handleQuantityChange = async (productId: number, newQuantity: number) => {
        if (newQuantity < 1) return; 
        try {
            await api.updateCartItem(userId, productId, newQuantity);
            setCartItems((prevItems) =>
                prevItems.map((item) =>
                    item.productId === productId ? { ...item, quantity: newQuantity, totalPrice: item.price * newQuantity } : item
                )
            );
            toast.success('Cart updated!');
        } catch (error) {
            toast.error('Failed to update item in cart.');
        }
    };

    const handleRemoveItem = async (productId: number) => {
        try {
            await api.removeCartItem(userId, productId);
            setCartItems((prevItems) => prevItems.filter((item) => item.productId !== productId));
            toast.success('Item removed from cart!');
        } catch (error) {
            toast.error('Failed to remove item from cart.');
        }
    };

    return (
        <div className="basket-container">
            <h1>Koszyk</h1>
            {cartItems.length > 0 ? (
                <div>
                    <ul className="cart-list">
                        {cartItems.map((item) => (
                            <li key={item.productId} className="cart-item">
                                <div className="item-details">
                                    <img src={item.imageUrl} alt={item.name} className="item-image" />
                                    <div className="item-info">
                                        <p className="item-name">{item.name}</p>
                                        <p className="item-price">{item.price} zł</p>
                                        <p className="item-total">Total: {item.totalPrice} zł</p>
                                    </div>
                                </div>
                                <div className="item-controls">
                                    <input
                                        type="number"
                                        min="1"
                                        value={item.quantity}
                                        onChange={(e) =>
                                            handleQuantityChange(
                                                item.productId,
                                                parseInt(e.target.value, 10)
                                            )
                                        }
                                    />
                                    <button
                                        onClick={() => handleRemoveItem(item.productId)}
                                        className="remove-button"
                                    >
                                        Usuń
                                    </button>
                                </div>
                            </li>
                        ))}
                    </ul>
                    <div className="cart-summary">
                        <h3>Całkowita kwota: {totalValue.toFixed(2)} zł</h3>
                        <button className="checkout-button">Przejdź do kasy</button>
                    </div>
                </div>
            ) : (
                <p>Twój koszyk jest pusty.</p>
            )}
        </div>
    );
}