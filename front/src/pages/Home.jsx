import React, { useContext } from 'react';
import { useNavigate } from 'react-router-dom';
import { AuthContext } from '../context/AuthContext';
import styled from 'styled-components';
import { motion } from 'framer-motion';

const Container = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  min-height: 100vh;
  background: linear-gradient(135deg, #0a0a0a, #1a1a1a);
  padding: 20px;
`;

const Card = styled(motion.div)`
  max-width: 800px;
  padding: 40px;
  background: #1a1a1a;
  border: 1px solid #00ff00;
  border-radius: 15px;
  box-shadow: 0 4px 12px rgba(0, 255, 0, 0.2);
  text-align: center;
`;

const Title = styled(motion.h1)`
  font-size: 3.5rem;
  font-weight: 700;
  color: #00ff00;
  margin-bottom: 20px;
`;

const Text = styled.p`
  font-size: 1.2rem;
  color: #ffffff;
  margin-bottom: 30px;
`;

const Button = styled(motion.button)`
  background: #00ff00;
  color: #0a0a0a;
  padding: 12px 30px;
  border: none;
  border-radius: 25px;
  font-weight: 500;

  &:hover {
    background: #ff00ff;
    color: #ffffff;
  }
`;

function Home() {
  const { user } = useContext(AuthContext);
  const navigate = useNavigate();

  return (
    <Container>
      <Card
        initial={{ opacity: 0, y: 50 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ duration: 0.5 }}
      >
        <Title className="glitch">FSociety</Title>
        <Text>
          Sistemimizi hack'le! Taleplerini oluştur, takip et ve bildirimlerini anlık yönet.
        </Text>
        <Button
          whileHover={{ scale: 1.1 }}
          onClick={() => navigate(user ? (user.role === 'Admin' || user.role === 'SuperAdmin' ? '/admin-dashboard' : '/support-requests') : '/login')}
        >
          {user ? (user.role === 'Admin' || user.role === 'SuperAdmin' ? 'Admin Paneli' : 'Taleplerim') : 'Giriş Yap'}
        </Button>
      </Card>
    </Container>
  );
}

export default Home;