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

const Button = styled(motion.button)`
  background: #ff6b6b;
  color: #ffffff;
  padding: 8px 15px;
  border: none;
  border-radius: 8px;
  font-family: 'Fira Code', monospace;

  &:hover {
    background: #ff00ff;
  }
`;

const Alert = styled(motion.div)`
  background: #ff6b6b;
  color: #ffffff;
  padding: 15px;
  border-radius: 10px;
  margin-bottom: 20px;
`;

function AdminUsers() {
  const [users, setUsers] = useState([]);
  const [error, setError] = useState('');

  useEffect(() => {
    const fetchUsers = async () => {
      try {
        const response = await api.get('/user');
        setUsers(response.data || []);
      } catch (err) {
        setError(`Kullanıcılar yüklenirken hata: ${err.message}`);
      }
    };
    fetchUsers();
  }, []);

  const handleDeleteUser = async (userId) => {
    if (window.confirm('Bu kullanıcıyı silmek istediğinizden emin misiniz?')) {
      try {
        await api.delete(`/user/${userId}`);
        setUsers(users.filter(user => user.id !== userId));
      } catch (err) {
        setError(`Kullanıcı silinirken hata: ${err.message}`);
      }
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
        Kullanıcılar
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
      <Card
        initial={{ opacity: 0, y: 50 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ duration: 0.5 }}
      >
        <h4 style={{ color: '#00ff00', marginBottom: '20px' }}>Tüm Kullanıcılar</h4>
        <Table>
          <thead>
            <tr>
              <Th>ID</Th>
              <Th>Kullanıcı Adı</Th>
              <Th>E-posta</Th>
              <Th>Rol</Th>
              <Th>İşlem</Th>
            </tr>
          </thead>
          <tbody>
            {users.length > 0 ? (
              users.map((user) => (
                <tr key={user.id}>
                  <Td>{user.id}</Td>
                  <Td>{user.username}</Td>
                  <Td>{user.email}</Td>
                  <Td>{user.role}</Td>
                  <Td>
                    <Button
                      whileHover={{ scale: 1.05 }}
                      onClick={() => handleDeleteUser(user.id)}
                    >
                      Sil
                    </Button>
                  </Td>
                </tr>
              ))
            ) : (
              <tr>
                <Td colSpan="5" style={{ textAlign: 'center' }}>
                    Henüz kullanıcı yok.
                  </Td>
                </tr>
              )}
            </tbody>
          </Table>
        </Card>
      </Container>
    );
  }
  
  export default AdminUsers;