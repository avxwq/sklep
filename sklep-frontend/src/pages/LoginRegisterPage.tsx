import React, { useState, useEffect } from 'react';
import LoginForm from '../components/Login/LoginForm'; 
import RegisterForm from '../components/Login/RegistrationForm'; 
import '../styles/LoginRegister.css'; 
import { useUserStorage } from '../services/UserStorage';

export default function LoginRegister() {
  const [isLogin, setIsLogin] = useState<boolean>(true);
  const { isLoggedIn } = useUserStorage(); 

  if (isLoggedIn) {
    return (
      <div className="container">
        <h2>Jesteś już zalogowany!</h2>
        {/* Optionally, you can redirect or show a dashboard here */}
      </div>
    );
  }

  return (
    <div className="container">
      {isLogin ? (
        <LoginForm />
      ) : (
        <RegisterForm />
      )}

      <div>
        {isLogin ? (
          <p>
            Nie posiadasz jeszcze konta?
            <button className="switch-btn" onClick={() => setIsLogin(false)}>Zarejestruj się</button>
          </p>
        ) : (
          <p>
            Posiadasz już konto? 
            <button className="switch-btn" onClick={() => setIsLogin(true)}>Zaloguj się</button>
          </p>
        )}
      </div>
    </div>
  );
}
