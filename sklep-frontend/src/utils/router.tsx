import { RouteObject } from 'react-router-dom';
import HomePage from "../pages/HomePage";
import LoginForm from '../components/Login/LoginForm';
import Register from '../components/Login/RegistrationForm';

const routes: RouteObject[] = [
  {
    path: '/',
    element: <HomePage />, 
  },
    {
    path: '/login',
    element: <LoginForm />, 
  }, 
  {
    path: '/register',
    element: <Register />, 
  },
];

export default routes;