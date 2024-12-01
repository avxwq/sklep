import React, { useState, useEffect } from "react";
import "../styles/ProfilePage.css";

interface User {
    name: string;
    email: string;
    address: string;
    phone: string;
}

export default function Profile() {
    const [user, setUser] = useState<User | null>(null);
    const [isEditing, setIsEditing] = useState<boolean>(false);
    const [formData, setFormData] = useState<User | null>(null);

    useEffect(() => {
        // Za³ó¿my, ¿e dane u¿ytkownika s¹ pobierane z API
        const fetchUserData = async () => {
            const fakeUser: User = {
                name: "Jan Kowalski",
                email: "jan.kowalski@example.com",
                address: "Ul. Zielona 15, Warszawa",
                phone: "+48 123 456 789",
            };
            setUser(fakeUser);
            setFormData(fakeUser);
        };

        fetchUserData();
    }, []);

    const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        if (formData) {
            setFormData({
                ...formData,
                [e.target.name]: e.target.value,
            });
        }
    };

    const handleSave = () => {
        if (formData) {
            setUser(formData);
            setIsEditing(false);
            alert("Zapisano zmiany!");
        }
    };

    return (
        <div className="profile-container">
            <h1>Twoj Profil</h1>
            {user ? (
                <div className="profile-details">
                    <div className="profile-field">
                        <label>Imie i nazwisko:</label>
                        {isEditing ? (
                            <input
                                type="text"
                                name="name"
                                value={formData?.name}
                                onChange={handleInputChange}
                            />
                        ) : (
                            <p>{user.name}</p>
                        )}
                    </div>
                    <div className="profile-field">
                        <label>Email:</label>
                        {isEditing ? (
                            <input
                                type="email"
                                name="email"
                                value={formData?.email}
                                onChange={handleInputChange}
                            />
                        ) : (
                            <p>{user.email}</p>
                        )}
                    </div>
                    <div className="profile-field">
                        <label>Adres:</label>
                        {isEditing ? (
                            <input
                                type="text"
                                name="address"
                                value={formData?.address}
                                onChange={handleInputChange}
                            />
                        ) : (
                            <p>{user.address}</p>
                        )}
                    </div>
                    <div className="profile-field">
                        <label>Telefon:</label>
                        {isEditing ? (
                            <input
                                type="text"
                                name="phone"
                                value={formData?.phone}
                                onChange={handleInputChange}
                            />
                        ) : (
                            <p>{user.phone}</p>
                        )}
                    </div>

                    <div className="profile-actions">
                        {isEditing ? (
                            <button onClick={handleSave} className="save-button">
                                Zapisz
                            </button>
                        ) : (
                            <button
                                onClick={() => setIsEditing(true)}
                                className="edit-button"
                            >
                                Edytuj
                            </button>
                        )}
                    </div>
                </div>
            ) : (
                <p>£adowanie danych u¿ytkownika...</p>
            )}
        </div>
    );
}
