import React, { useEffect, useState } from 'react';
import '../styles/Product.css'; // Import stylów dla strony produktów
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
