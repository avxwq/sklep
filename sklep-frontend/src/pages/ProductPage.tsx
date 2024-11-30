import React, { useEffect, useState } from 'react';
import '../styles/Product.css'; // Import styl�w dla strony produkt�w
import Footer from "../components/footer";
import ProductList from "../components/ProductForm";

export default function ProductPage() {
    return (
        <div>
            <ProductList />
            <Footer />
        </div>
    );  
}
