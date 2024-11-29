import React, { useState } from 'react';
import { useUserStorage } from '../../services/UserStorage'; // Importuj hook kontekstu
import { api } from '../../api/api';
import '../../styles/LoginRegister.css';  // Importuj CSS

export default function LoginForm() {
  const [email, setEmail] = useState<string>('');
  const [password, setPassword] = useState<string>('');
  const [success, setSuccess] = useState<string>('');
  const [error, setError] = useState<string>('');

  // Uzyskaj dostęp do funkcji i stanu z UserStorageContext
  const { login } = useUserStorage();

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setSuccess('');
    setError('');

    try {
      const data = await api.loginUser(email, password);
      setSuccess('Zalogowano pomyślnie');

      // Użyj funkcji login z kontekstu, aby zapisać token
      login(data.token);

      // Możesz również zapisać token w localStorage, jeśli chcesz
      localStorage.setItem('token', data.token);
    } catch (err: any) {
      setError(err.response?.data?.message || 'Nie udało się zalogować');
    }
  };

  return (
    <div>
      <h2>Zaloguj się</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label>Email:</label>
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
        <button type="submit">Zaloguj się</button>
      </form>
    </div>
  );
}