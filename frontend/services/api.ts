import axios, { AxiosInstance } from 'axios';

const API_BASE_URL = process.env.NEXT_PUBLIC_API_URL || 'http://localhost:5000/api';

class ApiService {
    private client: AxiosInstance;
    constructor() {
        this.client = axios.create({
            baseURL: API_BASE_URL,
            headers: {
                'Content-Type': 'application/json',
            },
        });

        // Add token to requests
        this.client.interceptors.request.use((config) => {
            if (typeof window !== 'undefined') {
                const token = localStorage.getItem('auth_token');
                if (token) {
                    config.headers.Authorization = `Bearer ${token}`;
                }
            }
            return config;
        });

        // Handle errors
        this.client.interceptors.response.use((response) => response, (error) => {
            if (error.response?.status === 401) {
                if (typeof window !== 'undefined') {
                    localStorage.removeItem('auth_token');
                    window.location.href = '/auth/login';
                }
            }
            return Promise.reject(error);
        }); 
    }

    get<T>(url: string) {
        return this.client.get<T>(url);
    }

    post<T>(url: string, data?: any) {
        return this.client.post<T>(url, data);
    }

    put<T>(url: string, data?: any) {
        return this.client.put<T>(url, data);
    }

    delete<T>(url: string) {
        return this.client.delete<T>(url);
    }

}

export const api = new ApiService();