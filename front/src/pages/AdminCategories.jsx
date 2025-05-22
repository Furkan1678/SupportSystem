    import React, { useState, useEffect } from 'react';
import styled from 'styled-components';
import { motion } from 'framer-motion';
import api from '../services/api';

const Container = styled.div`
  padding: 30px;
  background: #0a0a0a;
  min-height: 100vh;
`;

const Title = styled(motion.h2)`
  font-size: 2.5rem;
  font-weight: 600;
  color: #00ff00;
  text-align: center;
  margin-bottom: 30px;
  text-transform: uppercase;
`;

const Card = styled(motion.div)`
  background: #1a1a1a;
  border: 1px solid #00ff00;
  border-radius: 15px;
  padding: 20px;
  margin-bottom: 20px;
  box-shadow: 0 4px 12px rgba(0, 255, 0, 0.2);
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

const Button = styled(motion.button)`
  background: #00ff00;
  color: #0a0a0a;
  padding: 10px 20px;
  border: none;
  border-radius: 8px;
  font-weight: 500;
  font-family: 'Fira Code', monospace;

  &:hover {
    background: #ff00ff;
    color: #ffffff;
  }
`;

const Table = styled.table`
  width: 100%;
  background: #1a1a1a;
  border: 1px solid #00ff00;
  border-radius: 10px;
  overflow: hidden;
`;

const Th = styled.th`
  background: #00b4d8;
  color: #ffffff;
  padding: 15px;
  text-align: left;
`;

const Td = styled.td`
  padding: 15px;
  color: #ffffff;
  border-top: 1px solid #00ff00;
`;

const Alert = styled(motion.div)`
  background: #ff6b6b;
  color: #ffffff;
  padding: 15px;
  border-radius: 10px;
  margin-bottom: 20px;
`;

function AdminCategories() {
  const [categories, setCategories] = useState([]);
  const [newCategory, setNewCategory] = useState({ name: '', description: '' });
  const [error, setError] = useState('');

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await api.get('/supportcategory');
        setCategories(response.data || []);
      } catch (err) {
        setError(`Kategoriler yüklenirken hata: ${err.message}`);
      }
    };
    fetchData();
  }, []);

  const handleAddCategory = async (e) => {
    e.preventDefault();
    try {
      const response = await api.post('/supportcategory', newCategory);
      setCategories([...categories, response.data]);
      setNewCategory({ name: '', description: '' });
    } catch (err) {
      setError(`Kategori eklenirken hata: ${err.message}`);
    }
  };

  return (
    <Container>
      <Title
        className="glitch"
        initial={{ opacity: 0 }}
        animate={{ opacity: 1 }}
        transition={{ duration: 0.5 }}
      >
        Kategoriler
      </Title>
      {error && (
        <Alert
          initial={{ opacity: 0 }}
          animate={{ opacity: 1 }}
          transition={{ duration: 0.3 }}
        >
          {error}
        </Alert>
      )}
      <div style={{ display: 'flex', gap: '20px', flexWrap: 'wrap' }}>
        <Card
          initial={{ opacity: 0, y: 50 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ duration: 0.5 }}
          style={{ flex: '1', minWidth: '300px' }}
        >
          <h4 style={{ color: '#00ff00', marginBottom: '20px' }}>Yeni Kategori Ekle</h4>
          <form onSubmit={handleAddCategory}>
            <div style={{ marginBottom: '15px' }}>
              <FormLabel>Kategori Adı</FormLabel>
              <Input
                type="text"
                value={newCategory.name}
                onChange={(e) => setNewCategory({ ...newCategory, name: e.target.value })}
                required
              />
            </div>
            <div style={{ marginBottom: '15px' }}>
              <FormLabel>Açıklama</FormLabel>
              <Textarea
                rows={3}
                value={newCategory.description}
                onChange={(e) => setNewCategory({ ...newCategory, description: e.target.value })}
                required
              />
            </div>
            <Button
              whileHover={{ scale: 1.05 }}
              type="submit"
            >
              Kategori Ekle
            </Button>
          </form>
        </Card>
        <Card
          initial={{ opacity: 0, y: 50 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ duration: 0.5, delay: 0.2 }}
          style={{ flex: '1', minWidth: '300px' }}
        >
          <h4 style={{ color: '#00ff00', marginBottom: '20px' }}>Mevcut Kategoriler</h4>
          <Table>
            <thead>
              <tr>
                <Th>ID</Th>
                <Th>Ad</Th>
                <Th>Açıklama</Th>
              </tr>
            </thead>
            <tbody>
              {categories.length > 0 ? (
                categories.map((cat) => (
                  <tr key={cat.id}>
                    <Td>{cat.id}</Td>
                    <Td>{cat.name}</Td>
                    <Td>{cat.description}</Td>
                  </tr>
                ))
              ) : (
                <tr>
                  <Td colSpan="3" style={{ textAlign: 'center' }}>
                    Henüz kategori yok.
                  </Td>
                </tr>
              )}
            </tbody>
          </Table>
        </Card>
      </div>
    </Container>
  );
}

export default AdminCategories;