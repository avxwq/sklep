import React from 'react';
import { useNavigate } from 'react-router-dom'; // Importujemy useNavigate do nawigacji
import '../styles/home.css';

export default function Home() {
    const navigate = useNavigate(); // Hook do obs³ugi nawigacji

    const handleExploreClick = () => {
        navigate('/shop'); // Przekierowanie do widoku /shop
        console.log("Explore button clicked");
    };

    return (
        <div className="home">
            <div className="home-overlay">
                <h1 className="home-title">Welcome to the Plant Shop</h1>
                <p className="home-description">
                    Discover our lush collection of indoor and outdoor plants.
                </p>
                <button className="home-button" onClick={handleExploreClick}>
                    Explore Now
                </button>
            </div>
        </div>
    );
}