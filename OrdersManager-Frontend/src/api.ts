import axios from "axios";

const api = axios.create({
  baseURL: "http://localhost:5149/api",
});

api.interceptors.request.use((config) => {
  const authToken = window.localStorage.getItem("AUTH_TOKEN");
  const isAuthenticated = Boolean(authToken);

  if (isAuthenticated) {
    config.headers['Authorization'] = `Bearer ${authToken}`;
  }

  return config;
});

export default api;
