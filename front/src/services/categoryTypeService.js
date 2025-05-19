import api from './api';

const categoryTypeService = {
  getCategories: async (params = {}) => {
    const response = await api.get('/supportcategory', { params });
    return response.data;
  },

  addCategory: async (categoryData) => {
    const response = await api.post('/supportcategory', categoryData);
    return response.data;
  },

  getTypes: async (params = {}) => {
    const response = await api.get('/supporttype', { params });
    return response.data;
  },

  addType: async (typeData) => {
    const response = await api.post('/supporttype', typeData);
    return response.data;
  },
};

export default categoryTypeService;