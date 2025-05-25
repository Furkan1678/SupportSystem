import React, { useState, useContext } from 'react';
import { useNavigate } from 'react-router-dom';
import styled from 'styled-components';
import { motion } from 'framer-motion';
import { AuthContext } from '../context/AuthContext';
import RegisterForm from '../components/RegisterForm';

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

function Register() {
  const [error, setError] = useState('');
  const { register } = useContext(AuthContext);
  const navigate = useNavigate();

  const handleSubmit = async (username, email, password) => {
    try {
      await register(username, email, password);
      navigate('/login');
    } catch (err) {
      setError(err.message);
    }
  };

  return (
    <Container>
      <Card
        initial={{ opacity: 0, y: 50 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ duration: 0.5 }}
      >
        <Title className="glitch">Kayıt Ol</Title>
        <RegisterForm onSubmit={handleSubmit} error={error} />
      </Card>
    </Container>
  );
}

export default Register;