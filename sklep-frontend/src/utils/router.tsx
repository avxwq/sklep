import { RouteObject } from 'react-router-dom';
import HomePage from "../pages/HomePage";
import LoginRegister from '../pages/LoginRegisterPage';
import ContactPage from '../pages/ContactPage';
import ProductList from '../pages/ProductPage';
import ProductPage from '../pages/ProductPage';
import CartPage from '../components/cart';
import CategoryProducts from '../components/CategoryProducts';

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
  },
  {
      path: '/shop',
      element: <ProductPage />,
  },
  {
        path: '/cart',
        element: <CartPage />,
  },
  {
    path: '/category/:categoryId',
    element: <CategoryProducts />,  // The route for category products
  },
];

export default routes;