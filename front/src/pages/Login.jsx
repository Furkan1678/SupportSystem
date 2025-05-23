import React, { useState, useContext } from 'react';
import styled from 'styled-components';
import { motion } from 'framer-motion';
import { AuthContext } from '../context/AuthContext';
import LoginForm from '../components/LoginForm';
import { toast } from 'react-toastify';

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
  max-width: 500px;
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

function Login() {
  const [error, setError] = useState('');
  const { login } = useContext(AuthContext);

  const handleSubmit = async (username, password) => {
    try {
      await login(username, password);
      toast.success('Girişiniz başarıyla yapıldı!', { position: "top-right", autoClose: 3000 });
    } catch (err) {
      setError(err.message);
      toast.error('Giriş başarısız: ' + err.message, { position: "top-right", autoClose: 3000 });
    }
  };

  return (
    <Container>
      <Card
        initial={{ opacity: 0, y: 50 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ duration: 0.5 }}
      >
        <Title className="glitch">Giriş Yap</Title>
        <LoginForm onSubmit={handleSubmit} error={error} />
      </Card>
    </Container>
  );
}

export default Login;