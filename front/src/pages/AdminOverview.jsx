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

const StatCard = styled(motion.div)`
  background: #2a2a2a;
  border: 1px solid #00b4d8;
  border-radius: 10px;
  padding: 15px;
  text-align: center;
`;

const StatTitle = styled.h4`
  color: #00ff00;
  font-size: 1.2rem;
  margin-bottom: 10px;
`;

const StatValue = styled.p`
  color: #ffffff;
  font-size: 1.5rem;
  font-weight: 500;
`;

const Alert = styled(motion.div)`
  background: #ff6b6b;
  color: #ffffff;
  padding: 15px;
  border-radius: 10px;
  margin-bottom: 20px;
`;

function AdminOverview() {
  const [statusStats, setStatusStats] = useState({});
  const [error, setError] = useState('');

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await api.get('/supportrequest');
        const requests = response.data || [];
        const stats = requests.reduce((acc, req) => {
          const status = req.status === 0 ? 'Pending' :
                         req.status === 1 ? 'InProgress' :
                         req.status === 2 ? 'Completed' :
                         req.status === 3 ? 'Rejected' :
                         req.status === 4 ? 'OnHold' : 'Unknown';
          acc[status] = (acc[status] || 0) + 1;
          return acc;
        }, {});
        setStatusStats(stats);
      } catch (err) {
        setError(`Veriler yüklenirken hata: ${err.message}`);
      }
    };
    fetchData();
  }, []);

  return (
    <Container>
      <Title
        className="glitch"
        initial={{ opacity: 0 }}
        animate={{ opacity: 1 }}
        transition={{ duration: 0.5 }}
      >
        Genel Bakış
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
        <h4 style={{ color: '#00ff00', marginBottom: '20px' }}>Destek Talebi İstatistikleri</h4>
        <div style={{ display: 'flex', flexWrap: 'wrap', gap: '20px' }}>
          {Object.entries(statusStats).length > 0 ? (
            Object.entries(statusStats).map(([status, count], index) => (
              <StatCard
                key={status}
                initial={{ opacity: 0, y: 20 }}
                animate={{ opacity: 1, y: 0 }}
                transition={{ duration: 0.5, delay: index * 0.1 }}
                style={{ flex: '1', minWidth: '200px' }}
              >
                <StatTitle>{status}</StatTitle>
                <StatValue>{count} Talep</StatValue>
              </StatCard>
            ))
          ) : (
            <StatCard
              initial={{ opacity: 0, y: 20 }}
              animate={{ opacity: 1, y: 0 }}
              transition={{ duration: 0.5 }}
              style={{ flex: '1', minWidth: '200px' }}
            >
              <StatValue>Henüz istatistik yok.</StatValue>
            </StatCard>
          )}
        </div>
      </Card>
    </Container>
  );
}

export default AdminOverview;