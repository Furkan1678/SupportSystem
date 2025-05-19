import api from './api';

const notificationService = {
  getNotificationsByUser: async (userId) => {
    const response = await api.get('/notification/by-user', { params: { userId } });
    return response.data;
  },

  markAsRead: async (id) => {
    const response = await api.put('/notification/mark-as-read', { id });
    return response.data;
  },
};

export default notificationService;