// LoginRegister.tsx
import React, { useState, useEffect } from 'react';
import LoginForm from '../components/Login/LoginForm'; // Your Login component
import RegisterForm from '../components/Login/RegistrationForm'; // Your Register component
import '../styles/LoginRegister.css';  // Import the updated CSS file

export default function LoginRegister() {
  const [isLogin, setIsLogin] = useState<boolean>(true);
  const [isLoggedIn, setIsLoggedIn] = useState<boolean>(false);

  // Check if the user is logged in (token exists in localStorage)
  useEffect(() => {
    const token = localStorage.getItem('token');
    if (token) {
      setIsLoggedIn(true);  // User is logged in
    } else {
      setIsLoggedIn(false); // User is not logged in
    }
  }, []); // Runs once when component mounts

  if (isLoggedIn) {
    return (
      <div className="container">
        <h2>You are already logged in!</h2>
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
            Don’t have an account? 
            <button className="switch-btn" onClick={() => setIsLogin(false)}>Register</button>
          </p>
        ) : (
          <p>
            Already have an account? 
            <button className="switch-btn" onClick={() => setIsLogin(true)}>Login</button>
          </p>
        )}
      </div>
    </div>
  );
}
