import React, { useState, useEffect, useContext } from 'react';
import { useNavigate } from 'react-router-dom';
import styled from 'styled-components';
import { motion } from 'framer-motion';
import { AuthContext } from '../context/AuthContext';
import api from '../services/api';

const Container = styled.div`
  padding: 30px;
  background: #0a0a0a;
  min-height: 100vh;
  display: flex;
  justify-content: center;
`;

const Card = styled(motion.div)`
  max-width: 800px;
  width: 100%;
  background: #1a1a1a;
  border: 1px solid #00ff00;
  border-radius: 15px;
  padding: 30px;
  box-shadow: 0 4px 12px rgba(0, 255, 0, 0.2);
`;

const Title = styled(motion.h2)`
  font-size: 2.5rem;
  font-weight: 600;
  color: #00ff00;
  text-align: center;
  margin-bottom: 20px;
  text-transform: uppercase;
`;

const FormLabel = styled.label`
  color: #ffffff;
  font-weight: 500;
  margin-bottom: 10px;
  display: block;
`;

const Input = styled.input`
  width: 100%;
  padding: 10px;
  background: #2a2a2a;
  border: 1px solid #00b4d8;
  border-radius: 8px;
  color: #ffffff;
  font-family: 'Fira Code', monospace;

  &:focus {
    outline: none;
    border-color: #ff00ff;
  }
`;

const Textarea = styled.textarea`
  width: 100%;
  padding: 10px;
  background: #2a2a2a;
  border: 1px solid #00b4d8;
  border-radius: 8px;
  color: #ffffff;
  font-family: 'Fira Code', monospace;
  resize: vertical;

  &:focus {
    outline: none;
    border-color: #ff00ff;
  }
`;

const Select = styled.select`
  width: 100%;
  padding: 10px;
  background: #2a2a2a;
  border: 1px solid #00b4d8;
  border-radius: 8px;
  color: #ffffff;
  font-family: 'Fira Code', monospace;

  &:focus {
    outline: none;
    border-color: #ff00ff;
  }
`;

const FileInput = styled.input`
  width: 100%;
  padding: 10px;
  background: #2a2a2a;
  border: 1px solid #00b4d8;
  border-radius: 8px;
  color: #ffffff;
  font-family: 'Fira Code', monospace;
`;

const Button = styled(motion.button)`
  background: #00ff00;
  color: #0a0a0a;
  padding: 12px 20px;
  border: none;
  border-radius: 8px;
  font-weight: 500;
  font-family: 'Fira Code', monospace;
  width: 100%;

  &:hover {
    background: #ff00ff;
    color: #ffffff;
  }

  &:disabled {
    background: #555;
    cursor: not-allowed;
  }
`;

const Alert = styled(motion.div)`
  background: #ff6b6b;
  color: #ffffff;
  padding: 15px;
  border-radius: 10px;
  margin-bottom: 20px;
`;

const SuccessText = styled.p`
  color: #00ff00;
  margin-top: 10px;
`;

function CreateSupportRequest() {
  const { user } = useContext(AuthContext);
  const navigate = useNavigate();
  const [formData, setFormData] = useState({
    supportTypeId: '',
    supportCategoryId: '',
    subject: '',
    description: '',
    attachmentUrl: '',
    priority: 1,
  });
  const [types, setTypes] = useState([]);
  const [categories, setCategories] = useState([]);
  const [error, setError] = useState('');
  const [file, setFile] = useState(null);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    if (!user) {
      navigate('/login');
      return;
    }
    const fetchData = async () => {
      try {
        setLoading(true);
        const typesResponse = await api.get('/supporttype', { params: { isActive: true } });
        setTypes(typesResponse.data || []);
        const categoriesResponse = await api.get('/supportcategory', { params: { isActive: true } });
        setCategories(categoriesResponse.data || []);
      } catch (err) {
        setError(`Veriler yüklenirken hata: ${err.message}`);
      } finally {
        setLoading(false);
      }
    };
    fetchData();
  }, [user, navigate]);

  const handleFileChange = async (e) => {
    const selectedFile = e.target.files[0];
    if (selectedFile) {
      try {
        setLoading(true);
        const formData = new FormData();
        formData.append('file', selectedFile);
        const response = await api.post('/file/upload', formData, {
          headers: { 'Content-Type': 'multipart/form-data' },
        });
        setFormData((prev) => ({ ...prev, attachmentUrl: response.data.url }));
        setFile(selectedFile);
        setError('');
      } catch (err) {
        setError(`Dosya yüklenirken hata: ${err.message}`);
      } finally {
        setLoading(false);
      }
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (!user?.id) {
      setError('Kullanıcı kimliği bulunamadı.');
      return;
    }
    if (loading) return;
    try {
      setLoading(true);
      await api.post('/supportrequest', { ...formData, userId: user.id });
      navigate('/support-requests');
    } catch (err) {
      setError(`Talep oluşturulurken hata: ${err.message}`);
    } finally {
      setLoading(false);
    }
  };

  return (
    <Container>
      <Card
        initial={{ opacity: 0, y: 50 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ duration: 0.5 }}
      >
        <Title className="glitch">Yeni Destek Talebi</Title>
        {error && (
          <Alert
            initial={{ opacity: 0 }}
            animate={{ opacity: 1 }}
            transition={{ duration: 0.3 }}
          >
            {error}
          </Alert>
        )}
        <form onSubmit={handleSubmit}>
          <div style={{ display: 'flex', gap: '20px', flexWrap: 'wrap' }}>
            <div style={{ flex: '1', minWidth: '300px', marginBottom: '15px' }}>
              <FormLabel>Destek Türü</FormLabel>
              <Select
                value={formData.supportTypeId}
                onChange={(e) => setFormData({ ...formData, supportTypeId: e.target.value })}
                required
                disabled={types.length === 0 || loading}
              >
                <option value="">Seçiniz</option>
                {types.map((type) => (
                  <option key={type.id} value={type.id}>
                    {type.name}
                  </option>
                ))}
              </Select>
              {types.length === 0 && !loading && (
                <p style={{ color: '#ff6b6b', fontSize: '0.9rem' }}>
                  Destek türleri yüklenemedi.
                </p>
              )}
            </div>
            <div style={{ flex: '1', minWidth: '300px', marginBottom: '15px' }}>
              <FormLabel>Kategori</FormLabel>
              <Select
                value={formData.supportCategoryId}
                onChange={(e) => setFormData({ ...formData, supportCategoryId: e.target.value })}
                required
                disabled={categories.length === 0 || loading}
              >
                <option value="">Seçiniz</option>
                {categories.map((cat) => (
                  <option key={cat.id} value={cat.id}>
                    {cat.name}
                  </option>
                ))}
              </Select>
              {categories.length === 0 && !loading && (
                <p style={{ color: '#ff6b6b', fontSize: '0.9rem' }}>
                  Destek kategorileri yüklenemedi.
                </p>
              )}
            </div>
          </div>
          <div style={{ marginBottom: '15px' }}>
            <FormLabel>Konu</FormLabel>
            <Input
              type="text"
              value={formData.subject}
              onChange={(e) => setFormData({ ...formData, subject: e.target.value })}
              required
              maxLength={50}
            />
          </div>
          <div style={{ marginBottom: '15px' }}>
            <FormLabel>Açıklama</FormLabel>
            <Textarea
              rows={5}
              value={formData.description}
              onChange={(e) => setFormData({ ...formData, description: e.target.value })}
              required
            />
          </div>
          <div style={{ marginBottom: '15px' }}>
            <FormLabel>Ek Dosya</FormLabel>
            <FileInput
              type="file"
              onChange={handleFileChange}
              disabled={loading}
            />
            {formData.attachmentUrl && (
              <SuccessText>Dosya yüklendi: {file?.name}</SuccessText>
            )}
          </div>
          <div style={{ marginBottom: '15px' }}>
            <FormLabel>Öncelik</FormLabel>
            <Select
              value={formData.priority}
              onChange={(e) => setFormData({ ...formData, priority: e.target.value })}
              disabled={loading}
            >
              <option value="1">Düşük</option>
              <option value="2">Orta</option>
              <option value="3">Yüksek</option>
            </Select>
          </div>
          <Button
            whileHover={{ scale: 1.05 }}
            type="submit"
            disabled={types.length === 0 || categories.length === 0 || loading}
          >
            {loading ? 'Yükleniyor...' : 'Talep Oluştur'}
          </Button>
        </form>
      </Card>
    </Container>
  );
}

export default CreateSupportRequest;