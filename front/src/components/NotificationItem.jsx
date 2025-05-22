import React from 'react';
import styled from 'styled-components';
import { motion } from 'framer-motion';
import { FaSignInAlt, FaEnvelope, FaSync, FaBell } from 'react-icons/fa';


const Card = styled(motion.div)`
  background: #1a1a1a;
  border: 1px solid #00b4d8;
  border-radius: 10px;
  padding: 15px;
  margin-bottom: 15px;
  display: flex;
  align-items: center;
  opacity: ${props => (props.isRead ? 0.6 : 1)};
  transition: all 0.3s ease;
  position: relative;
  overflow: hidden;

  &:before {
    content: '';
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: linear-gradient(90deg, transparent, rgba(0, 255, 0, 0.1), transparent);
    animation: glitch 2s infinite;
  }

  @keyframes glitch {
    0% { transform: translate(0); }
    20% { transform: translate(-2px, 2px); }
    40% { transform: translate(2px, -2px); }
    60% { transform: translate(-1px, 1px); }
    80% { transform: translate(1px, -1px); }
    100% { transform: translate(0); }
  }
`;

const IconWrapper = styled.div`
  font-size: 1.5rem;
  color: #00ff00;
  margin-right: 15px;
`;

const Content = styled.div`
  flex: 1;
`;

const Title = styled.strong`
  color: #00ff00;
  font-size: 1.1rem;
`;

const Description = styled.p`
  color: #ffffff;
  font-size: 0.9rem;
  margin: 5px 0;
`;

const Timestamp = styled.small`
  color: #00b4d8;
  font-size: 0.8rem;
`;

const Button = styled(motion.button)`
  background: transparent;
  border: 1px solid #00ff00;
  color: #00ff00;
  padding: 8px 15px;
  border-radius: 8px;
  font-family: 'Fira Code', monospace;
  font-size: 0.9rem;
  margin-left: 10px;

  &:hover {
    background: #00ff00;
    color: #0a0a0a;
  }

  &:disabled {
    opacity: 0.5;
    cursor: not-allowed;
  }
`;

function NotificationItem({ notification, onMarkAsRead }) {
  const { id, type, message, isRead, createdAt } = notification;

  // Bildirim türüne göre ikon ve başlık belirleme
  const getNotificationDetails = () => {
    switch (type) {
      case 'login':
        return { icon: <FaSignInAlt />, title: 'Giriş Yapıldı' };
      case 'message_sent':
        return { icon: <FaEnvelope />, title: 'Mesaj Gönderildi' };
      case 'request_updated':
        return { icon: <FaSync />, title: 'Talep Güncellendi' };
      default:
        return { icon: <FaBell />, title: 'Bildirim' };
    }
  };

  const { icon, title } = getNotificationDetails();

  return (
    <Card
      isRead={isRead}
      initial={{ opacity: 0, y: 20 }}
      animate={{ opacity: 1, y: 0 }}
      transition={{ duration: 0.3 }}
    >
      <IconWrapper>{icon}</IconWrapper>
      <Content>
        <Title>{title}</Title>
        <Description>{message || 'Detaylı bilgi bulunamadı.'}</Description>
        <Timestamp>{new Date(createdAt).toLocaleString()}</Timestamp>
      </Content>
      {!isRead && (
        <Button
          whileHover={{ scale: 1.05 }}
          onClick={() => onMarkAsRead(id)}
        >
          Okundu
        </Button>
      )}
    </Card>
  );
}

export default NotificationItem;