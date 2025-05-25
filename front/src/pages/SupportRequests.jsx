import React, { useState, useEffect, useContext } from 'react';
import { useNavigate } from 'react-router-dom';
import styled from 'styled-components';
import { motion } from 'framer-motion';
import { AuthContext } from '../context/AuthContext';
import SupportRequestCard from '../components/SupportRequestCard';
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
  margin-bottom: 20px;
  text-transform: uppercase;
`;

const Button = styled(motion.button)`
  background: #00ff00;
  color: #0a0a0a;
  padding: 10px 20px;
  border: none;
  border-radius: 8px;
  font-weight: 500;
  font-family: 'Fira Code', monospace;
  margin-bottom: 20px;

  &:hover {
    background: #ff00ff;
    color: #ffffff;
  }
`;

const Alert = styled(motion.div)`
  background: #ff6b6b;
  color: #ffffff;
  padding: 15px;
  border-radius: 10px;
  margin-bottom: 20px;
`;

function SupportRequests() {
  const { user } = useContext(AuthContext);
  const navigate = useNavigate();
  const [requests, setRequests] = useState([]);
  const [error, setError] = useState('');

  useEffect(() => {
    if (!user) {
      navigate('/login');
      return;
    }
    const fetchRequests = async () => {
      try {
        const response = await api.get('/supportrequest/by-user', { params: { userId: user.id } });
        setRequests(response.data || []);
      } catch (err) {
        setError('Talepler yüklenirken hata.');
      }
    };
    fetchRequests();
  }, [user, navigate]);

  return (
    <Container>
      <Title
        className="glitch"
        initial={{ opacity: 0 }}
        animate={{ opacity: 1 }}
        transition={{ duration: 0.5 }}
      >
        Taleplerim
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
      <Button
        whileHover={{ scale: 1.05 }}
        onClick={() => navigate('/create-support-request')}
      >
        Yeni Talep Oluştur
      </Button>
      {requests.length > 0 ? (
        requests.map((req) => (
          <SupportRequestCard
            key={req.id}
            request={req}
            initial={{ opacity: 0, y: 20 }}
            animate={{ opacity: 1, y: 0 }}
            transition={{ duration: 0.3 }}
          />
        ))
      ) : (
        <p style={{ textAlign: 'center', color: '#ffffff' }}>Henüz destek talebiniz yok.</p>
      )}
    </Container>
  );
}

export default SupportRequests;