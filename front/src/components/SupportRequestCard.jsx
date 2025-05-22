import React from 'react';
import { useNavigate } from 'react-router-dom';
import styled from 'styled-components';
import { motion } from 'framer-motion';

const Card = styled(motion.div)`
  background: #1a1a1a;
  border: 1px solid #00ff00;
  border-radius: 10px;
  padding: 20px;
  margin-bottom: 20px;
  box-shadow: 0 4px 12px rgba(0, 255, 0, 0.2);
  cursor: pointer;
`;

const Title = styled.h3`
  font-size: 1.5rem;
  font-weight: 600;
  color: #00ff00;
  margin-bottom: 10px;
`;

const Text = styled.p`
  color: #ffffff;
  font-size: 1rem;
  margin-bottom: 5px;

  a {
    color: #00b4d8;
    &:hover {
      color: #ff00ff;
    }
  }
`;

function SupportRequestCard({ request, ...motionProps }) {
  const navigate = useNavigate();
  const { id, subject, description, status, priority, createdAt, attachmentUrl } = request;

  const getPriorityLabel = (priority) => {
    switch (priority) {
      case 1: return 'Düşük';
      case 2: return 'Orta';
      case 3: return 'Yüksek';
      default: return 'Belirtilmemiş';
    }
  };

  return (
    <Card
      {...motionProps}
      whileHover={{ scale: 1.02 }}
      onClick={() => navigate(`/support-request/${id}`)}
    >
      <Title>{subject}</Title>
      <Text><strong>Açıklama:</strong> {description}</Text>
      <Text><strong>Durum:</strong> {status}</Text>
      <Text><strong>Öncelik:</strong> {getPriorityLabel(priority)}</Text>
      <Text><strong>Oluşturulma:</strong> {new Date(createdAt).toLocaleDateString()}</Text>
      {attachmentUrl && (
        <Text>
          <strong>Ek Dosya:</strong>{' '}
          <a href={attachmentUrl} target="_blank" rel="noopener noreferrer">
            Görüntüle
          </a>
        </Text>
      )}
    </Card>
  );
}

export default SupportRequestCard;