import React, { useState } from 'react';
import { api } from '../../api/api';
import '../styles/ContactPage.css'; // Import stylów
export default function ContactPage() {
    const [name, setName] = useState('');
    const [email, setEmail] = useState('');
    const [message, setMessage] = useState('');
    const [success, setSuccess] = useState('');
    const [error, setError] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
        setSuccess('');
        setError('');

        // Wstawienie logiki do obs³ugi wysy³ania formularza
        if (!name || !email || !message) {
            setError('Proszê wype³niæ wszystkie pola.');
            return;
        }

        // W tym przypadku symulujemy, ¿e formularz jest poprawnie wys³any
        setSuccess('Twoja wiadomoœæ zosta³a wys³ana!');
        setName('');
        setEmail('');
        setMessage('');
    };

    return (
        <div className="contact-container">
            <div className="contact-info">
                <h1>Skontaktuj sie z nami!</h1>
                <p>Masz pytania? Chcialbys porozmawiac o naszych roslinach? Skontaktuj sie z nami!</p>

                <div className="contact-details">
                    <p><strong>Adres:</strong> Ul. Roslinna 7, 15-777 Bialystok</p>
                    <p><strong>Email:</strong> kontakt@plantshop.pl</p>
                    <p><strong>Telefon:</strong> +48 123 456 789</p>
                </div>

                <h3>Znajdz nas na mapie:</h3>
                {/* Przyk³adowa mapa */}
                <div className="map">
                    <iframe
                        title="Mapa"
                        width="500"
                        height="400"
                        frameBorder="0"
                        style={{ border: 0 }}
                        src="https://www.google.com/maps/embed/v1/place?q=Ul.%20Ro%C5%9Blinna%207,%2000-123%20Warszawa&key=YOUR_GOOGLE_MAPS_API_KEY"
                        allowFullScreen
                    ></iframe>
                </div>
            </div>

            <div className="contact-form">
                <h2>Formularz kontaktowy</h2>
                {success && <p className="success">{success}</p>}
                {error && <p className="error">{error}</p>}

                <form onSubmit={handleSubmit}>
                    <div className="form-group">
                        <label htmlFor="name">Imie i nazwisko</label>
                        <input
                            type="text"
                            id="name"
                            value={name}
                            onChange={(e) => setName(e.target.value)}
                            required
                        />
                    </div>

                    <div className="form-group">
                        <label htmlFor="email">Adres e-mail</label>
                        <input
                            type="email"
                            id="email"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                            required
                        />
                    </div>

                    <div className="form-group">
                        <label htmlFor="message">Wiadomosc</label>
                        <textarea
                            id="message"
                            value={message}
                            onChange={(e) => setMessage(e.target.value)}
                            required
                        />
                    </div>

                    <button type="submit">Wyslij wiadomosc</button>
                </form>
            </div>
        </div>
    );
}