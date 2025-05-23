import React from 'react';
import { useNavigate } from 'react-router-dom';
import styled from 'styled-components';
import { motion } from 'framer-motion';

const Container = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  min-height: 100vh;
  background: #0a0a0a;
  padding: 20px;
`;

const Card = styled(motion.div)`
  max-width: 600px;
  width: 100%;
  background: #1a1a1a;
  border: 1px solid #00ff00;
  border-radius: 15px;
  padding: 40px;
  box-shadow: 0 4px 12px rgba(0, 255, 0, 0.2);
  text-align: center;
`;

const Title = styled(motion.h2)`
  font-size: 3rem;
  font-weight: 600;
  color: #ff6b6b;
  margin-bottom: 20px;
  text-transform: uppercase;
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
  font-family: 'Fira Code', monospace;

  &:hover {
    background: #ff00ff;
    color: #ffffff;
  }
`;

function NotFound() {
  const navigate = useNavigate();

  return (
    <Container>
      <Card
        initial={{ opacity: 0, y: 50 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ duration: 0.5 }}
      >
        <Title className="glitch">404 - Erişim Engellendi</Title>
        <Text>
          Aradığın dosya sistemde yok. Ana sunucuya dönmek ister misin?
        </Text>
        <Button
          whileHover={{ scale: 1.1 }}
          onClick={() => navigate('/')}
        >
          Ana Sayfaya Dön
        </Button>
      </Card>
    </Container>
  );
}

export default NotFound;