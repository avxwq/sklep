import { RouteObject } from 'react-router-dom';
import HomePage from "../pages/HomePage";
import LoginRegister from '../pages/LoginRegisterPage';
import ContactPage from '../pages/ContactPage';

const routes: RouteObject[] = [
  {
    path: '/',
    element: <HomePage />, 
  },
  {
    path: '/login',
    element: <LoginRegister />,
  },
  {
    path: '/contact',
    element: <ContactPage />,
  }
];

export default routes;