import api from './api';

const supportRequestService = {
  getAllRequests: async () => {
    const response = await api.get('/supportrequest');
    return response.data;
  },

  getRequestsByUser: async (userId) => {
    const response = await api.get('/supportrequest/by-user', { params: { userId } });
    return response.data;
  },

  getRequestById: async (id) => {
    const response = await api.get(`/supportrequest/${id}`);
    return response.data;
  },

  createRequest: async (requestData) => {
    const response = await api.post('/supportrequest', requestData);
    return response.data;
  },

  updateStatus: async (id, status) => {
    const response = await api.put('/supportrequest/status', { id, status });
    return response.data;
  },

  uploadFile: async (file) => {
    const formData = new FormData();
    formData.append('file', file);
    const response = await api.post('/file/upload', formData, {
      headers: { 'Content-Type': 'multipart/form-data' },
    });
    return response.data;
  },

  getCommentsByRequest: async (supportRequestId) => {
    const response = await api.get('/supportrequestcomment/by-support-request', {
      params: { supportRequestId },
    });
    return response.data;
  },

  addComment: async (commentData) => {
    const response = await api.post('/supportrequestcomment', commentData);
    return response.data;
  },
};

export default supportRequestService;