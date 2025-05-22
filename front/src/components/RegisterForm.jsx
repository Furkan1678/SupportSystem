import React, { useState } from 'react';
import styled from 'styled-components';
import { motion } from 'framer-motion';

const Form = styled.form`
  display: flex;
  flex-direction: column;
  gap: 15px;
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

const Button = styled(motion.button)`
  background: #00ff00;
  color: #0a0a0a;
  padding: 12px;
  border: none;
  border-radius: 8px;
  font-weight: 500;
  font-family: 'Fira Code', monospace;

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
`;

function RegisterForm({ onSubmit, error }) {
  const [username, setUsername] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
    onSubmit(username, email, password);
  };

  return (
    <Form onSubmit={handleSubmit}>
      {error && (
        <Alert
          initial={{ opacity: 0 }}
          animate={{ opacity: 1 }}
          transition={{ duration: 0.3 }}
        >
          {error}
        </Alert>
      )}
      <div>
        <FormLabel>Kullanıcı Adı</FormLabel>
        <Input
          type="text"
          placeholder="Kullanıcı adınızı girin"
          value={username}
          onChange={(e) => setUsername(e.target.value)}
          required
        />
      </div>
      <div>
        <FormLabel>E-posta</FormLabel>
        <Input
          type="email"
          placeholder="E-posta adresinizi girin"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          required
        />
      </div>
      <div>
        <FormLabel>Şifre</FormLabel>
        <Input
          type="password"
          placeholder="Şifrenizi girin"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          required
        />
      </div>
      <Button
        whileHover={{ scale: 1.05 }}
        type="submit"
      >
        Kayıt Ol
      </Button>
    </Form>
  );
}

export default RegisterForm;