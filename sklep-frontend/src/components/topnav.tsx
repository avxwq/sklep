import React from 'react';
import { Link } from 'react-router-dom';  // Importujemy Link do nawigacji
import '../styles/topnav.css'

export default function TopNavbar() {
  return (
    <nav className="navbar">
      <div className="navbar-container">
        {/* Logo sklepu */}
        <div className="navbar-logo">
          <Link to="/">PlantShop</Link>
        </div>

        {/* Linki nawigacyjne */}
        <ul className="navbar-links">
          <li>
            <Link to="/">Home</Link>
          </li>
          <li>
            <Link to="/shop">Shop</Link>
          </li>
          <li>
            <Link to="/contact">Contact</Link>
          </li>
          {/* Możesz dodać inne linki, jak login, koszyk itp. */}
        </ul>

        {/* Przyciski logowania i koszyka */}
        <div className="navbar-actions">
          <Link to="/login" className="navbar-button">
            Login
          </Link>
          <Link to="/cart" className="navbar-button">
            Cart
          </Link>
        </div>
      </div>
    </nav>
  );
}