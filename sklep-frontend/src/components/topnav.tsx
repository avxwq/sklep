import React from 'react';
import { Link } from 'react-router-dom';  // Importujemy Link do nawigacji
import '../styles/topnav.css'

export default function TopNavbar() {
  return (
    <nav className="navbar">
      <div className="navbar-container">
        <div className="navbar-logo">
          <Link to="/">PlantShop</Link>
        </div>

        <ul className="navbar-links">
          <li>
            <Link to="/">Strona główna</Link>
          </li>
          <li>
            <Link to="/shop">Produkty</Link>
          </li>
          <li>
            <Link to="/contact">Kontakt</Link>
          </li>
        </ul>

        <div className="navbar-actions">
          <Link to="/login" className="navbar-button">
            Zaloguj się
          </Link>
          <Link to="/cart" className="navbar-button">
            Koszyk
          </Link>
        </div>
      </div>
    </nav>
  );
}