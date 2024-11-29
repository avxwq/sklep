import React, { useState } from 'react';
import { useUserStorage } from '../../services/UserStorage'; // Importuj hook kontekstu
import { api } from '../../api/api';
import '../../styles/LoginRegister.css';  // Importuj CSS

export default function RegisterForm() {
  const [username, setUsername] = useState<string>('');
  const [email, setEmail] = useState<string>('');
  const [password, setPassword] = useState<string>('');
  const [success, setSuccess] = useState<string>('');
  const [error, setError] = useState<string>('');

  // Uzyskaj dostęp do funkcji z UserStorageContext
  const { login } = useUserStorage();

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setSuccess('');
    setError('');

    try {
      // Wywołanie API do rejestracji
      const data = await api.registerUser(username, email, password);
      setSuccess(`Zarejestrowano użytkownika: ${data.username}`);

      // Po udanej rejestracji, od razu logujemy użytkownika
      login(data.token);  // Zapisanie tokena w stanie globalnym
      localStorage.setItem('token', data.token);  // Opcjonalnie zapisanie tokena w localStorage
    } catch (err: any) {
      setError(err.response?.data?.message || 'Rejestracja nie powiodła się');
    }
  };

  return (
    <div>
      <h2>Zarejestruj się</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label>Nazwa użytkownika:</label>
          <input
            type="text"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
            required
          />
        </div>
        <div>
          <label>Adres email:</label>
          <input
            type="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
          />
        </div>
        <div>
          <label>Hasło:</label>
          <input
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
          />
        </div>
        {success && <p className="success">{success}</p>}
        {error && <p className="error">{error}</p>}
        <button type="submit">Zarejestruj się</button>
      </form>
    </div>
  );
}
