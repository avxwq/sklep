import React, { useEffect, useState } from 'react';
import '../styles/Product.css'; // Import stylów dla strony produktów

interface Product {
    id: number;
    name: string;
    price: number;
    description: string;
    imageUrl: string;
}

export default function ProductList() {
    const [products, setProducts] = useState<Product[]>([]);

    // Symulacja pobierania danych produktów z API
    useEffect(() => {
        // Przyk³adowa lista produktów
        const fetchedProducts: Product[] = [
            {
                id: 1,
                name: 'Monstera Deliciosa',
                price: 49.99,
                description: 'Piekna roslina doniczkowa o duzych, dziurawych lisciach.',
                imageUrl: '/images/monstera.jpg',
            },
            {
                id: 2,
                name: 'Ficus Lyrata',
                price: 69.99,
                description: 'Roslina z duzymi, ozdobnymi liscmi przypominajacymi skrzypce.',
                imageUrl: '/images/fikus.jpg',
            },
            {
                id: 3,
                name: 'Sansevieria Zeylanica',
                price: 29.99,
                description: 'Roslina o charakterystycznych pionowych lisciach, latwa w pielegnacji.',
                imageUrl: '/images/sansevieria.jpg',
            },
        ];

        setProducts(fetchedProducts);
    }, []);

    return (
        <div className="product-list-container">
            <h1>Nasze Produkty</h1>
            <ul className="product-list">
                {products.map((product) => (
                    <li key={product.id} className="product-item">
                        <img src={product.imageUrl} alt={product.name} className="product-image" />
                        <div className="product-info">
                            <h2 className="product-name">{product.name}</h2>
                            <p className="product-description">{product.description}</p>
                            <p className="product-price">{product.price.toFixed(2)} zl</p>
                            <button className="add-to-cart-button">Dodaj do koszyka</button>
                        </div>
                    </li>
                ))}
            </ul>
        </div>
    );
}
