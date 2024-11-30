import React, { useEffect, useState } from 'react';
import '../styles/Product.css'; // Import styl�w dla strony produkt�w
import Footer from "../components/footer";
import ProductList from "../components/ProductForm";
import CategoryList from '../components/CategoryList';

export default function ProductPage() {
    return (
        <div>
            <CategoryList />
            <Footer />
        </div>
    );  
}
