import axios from 'axios';

// Define the base URL for your API
const API_URL = 'http://localhost:5000/api'; // Replace with your API URL

// Create an axios instance with default settings
const axiosInstance = axios.create({
  baseURL: API_URL,
  headers: {
    'Content-Type': 'application/json',
  },
});

// User-related API endpoints
export const api = {
  // Register a new user
  registerUser: async (username: string, email: string, password: string) => {
    try {
      const response = await axiosInstance.post('/users', {
        username,
        email,
        password,
      });
      return response.data;
    } catch (error) {
      console.error('Error registering user:', error);
      throw error;
    }
  },

  // User login
  loginUser: async (email: string, password: string) => {
    try {
      const response = await axiosInstance.post('/users/login', {
        email,
        password,
      });
      return response.data;
    } catch (error) {
      console.error('Error logging in user:', error);
      throw error;
    }
  },
}

export default api;
