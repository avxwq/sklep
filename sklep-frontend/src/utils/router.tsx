import { RouteObject } from 'react-router-dom';
import HomePage from "../pages/HomePage";
import LoginRegister from '../pages/LoginRegisterPage';

const routes: RouteObject[] = [
  {
    path: '/',
    element: <HomePage />, 
  },
    {
    path: '/login',
    element: <LoginRegister />, 
  }, 
];

export default routes;