// LoginForm.tsx
import React, { useState } from 'react';
import { api } from '../../api/api';
import '../../styles/LoginRegister.css';  // Import the updated CSS file

export default function LoginForm() {
  const [email, setEmail] = useState<string>('');
  const [password, setPassword] = useState<string>('');
  const [success, setSuccess] = useState<string>('');
  const [error, setError] = useState<string>('');

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setSuccess('');
    setError('');

    try {
      const data = await api.loginUser(email, password);
      setSuccess('Login successful');
      localStorage.setItem('token', data.token);
    } catch (err: any) {
      setError(err.response?.data?.message || 'Login failed');
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
