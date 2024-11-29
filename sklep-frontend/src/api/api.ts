import axios, { AxiosInstance, AxiosResponse } from 'axios';

const API_URL = 'http://localhost:5000/api'; 

const axiosInstance: AxiosInstance = axios.create({
  baseURL: API_URL,
  headers: {
    'Content-Type': 'application/json',
  },
});

const getToken = (): string | null => {
  return localStorage.getItem('token');
};

const setAuthHeader = (): void => {
  const token = getToken();
  if (token) {
    axiosInstance.defaults.headers['Authorization'] = `Bearer ${token}`;
  } else {
    delete axiosInstance.defaults.headers['Authorization']; 
  }
};

interface User {
  id: number;
  username: string;
  email: string;
}

export const api = {
  registerUser: async (username: string, email: string, password: string): Promise<User> => {
    try {
      const response: AxiosResponse<User> = await axiosInstance.post('/users/register', {
        username,
        email,
        password,
      });
      return response.data; 
    } catch (error: any) {
      console.error('Error registering user:', error.response?.data || error.message);
      throw error;
    }
  },


  loginUser: async (email: string, password: string) => {
  try {
    const response = await axiosInstance.post('/users/login', {
      email,
      password,
    });
    return response.data; // Backend zwróci token
  } catch (error: any) {
    console.error('Error logging in user:', error.response?.data || error.message);
    throw error;
  }
  },


  fetchUserProfile: async (): Promise<User> => {
    setAuthHeader(); 
    try {
      const response: AxiosResponse<User> = await axiosInstance.get('/users/profile');
      return response.data;
    } catch (error: any) {
      console.error('Error fetching user profile:', error.response?.data || error.message);
      throw error;
    }
  },

  logoutUser: (): void => {
    localStorage.removeItem('token');
    setAuthHeader(); 
  },
};

export default api;
