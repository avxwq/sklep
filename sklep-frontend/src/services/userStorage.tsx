import React, { createContext, useState, useEffect, ReactNode } from 'react';

// Define types for the context
interface UserStorageContextType {
  isLoggedIn: boolean;
  login: (token: string) => void;
  logout: () => void;
  cartItems: string[]; 
  addToCart: (item: string) => void;
  removeFromCart: (item: string) => void;
}

const UserStorageContext = createContext<UserStorageContextType | undefined>(undefined);

// Context Provider
export default function UserStorage({ children }: { children: ReactNode }) {
  const [isLoggedIn, setIsLoggedIn] = useState<boolean>(false);
  const [cartItems, setCartItems] = useState<string[]>([]);

  useEffect(() => {
    const token = localStorage.getItem('token');
    setIsLoggedIn(!!token); 

    const storedCart = localStorage.getItem('cartItems');
    if (storedCart) {
      setCartItems(JSON.parse(storedCart)); 
    }
  }, []);

  const login = (token: string) => {
    localStorage.setItem('token', token);
    setIsLoggedIn(true);
  };

  const logout = () => {
    localStorage.removeItem('token');
    setIsLoggedIn(false);
    setCartItems([]);
    localStorage.removeItem('cartItems');
  };

  const addToCart = (item: string) => {
    const updatedCart = [...cartItems, item];
    setCartItems(updatedCart);
    localStorage.setItem('cartItems', JSON.stringify(updatedCart));
  };

  const removeFromCart = (item: string) => {
    const updatedCart = cartItems.filter((cartItem) => cartItem !== item);
    setCartItems(updatedCart);
    localStorage.setItem('cartItems', JSON.stringify(updatedCart));
  };

  return (
    <UserStorageContext.Provider
      value={{
        isLoggedIn,
        login,
        logout,
        cartItems,
        addToCart,
        removeFromCart,
      }}
    >
      {children}
    </UserStorageContext.Provider>
  );
}

export function useUserStorage(): UserStorageContextType {
  const context = React.useContext(UserStorageContext);
  if (!context) {
    throw new Error('useUserStorage must be used within a UserStorageProvider');
  }
  return context;
}