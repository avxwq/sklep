import React from 'react';
import { Link } from 'react-router-dom';  // Importujemy Link do nawigacji
import '../styles/home.css'

export default function TopNavbar() {
    return (
        <div className="home">
            <div className="home-overlay">
                <h1 className="home-title">Welcome to the Plant Shop</h1>
                <p className="home-description">
                    Discover our lush collection of indoor and outdoor plants.
                </p>
                <button className="home-button">Explore Now</button>
            </div>
        </div>
    );
}