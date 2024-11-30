import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import axios from 'axios';
import Product from './ProductForm';  
import CategoryList from './CategoryList';

interface Category {
  id: number;
  name: string;
}

interface Product {
  id: number;
  name: string;
  price: number;
  description: string;
  imageUrl: string;
  stockQuantity: number;
  categoryId: number;
  category: Category | null; 
}

export default function CategoryProducts() {
  const { categoryId } = useParams<{ categoryId: string }>(); 
  const [products, setProducts] = useState<Product[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string>('');

  useEffect(() => {
    const fetchProductsByCategory = async () => {
      if (!categoryId) return;

      try {
        const response = await axios.get(`http://localhost:5000/api/products/category/${categoryId}`);
        setProducts(response.data);
        setLoading(false);
      } catch (error) {
        setError('Error fetching products');
        setLoading(false);
      }
    };

    fetchProductsByCategory();
  }, [categoryId]);

  if (loading) {
    return <div>Loading products...</div>;
  }

  if (error) {
    return <div>{error}</div>;
  }

  return (
    <div>
      <CategoryList />
      <Product products={products} />
    </div>
  );
}