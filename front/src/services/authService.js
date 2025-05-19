import api from './api';

const authService = {
  login: async (username, password) => {
    const response = await api.post('/auth/login', { username, password });
    return response.data;
  },

  register: async (username, email, password) => {
    const response = await api.post('/user', {
      username,
      email,
      password,
      role: 0,
    });
    return response.data;
  },
};

export default authService;