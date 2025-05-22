import React, { useState, useEffect, useContext } from 'react';
import styled from 'styled-components';
import { motion } from 'framer-motion';
import { AuthContext } from '../context/AuthContext';
import NotificationItem from '../components/NotificationItem';

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

const Alert = styled(motion.div)`
  background: #ff6b6b;
  color: #ffffff;
  padding: 15px;
  border-radius: 10px;
  margin-bottom: 20px;
`;

function AdminNotifications() {
  const { user } = useContext(AuthContext);
  const [notifications, setNotifications] = useState([]);
  const [error, setError] = useState('');

  useEffect(() => {
    const fetchNotifications = async () => {
      try {
        const response = await api.get('/notification/by-user', { params: { userId: user.id } });
        setNotifications(response.data || []);
      } catch (err) {
        setError('Bildirimler yüklenirken hata.');
      }
    };
    if (user) fetchNotifications();
  }, [user]);

  const handleMarkAsRead = async (id) => {
    try {
      await api.put('/notification/mark-as-read', { id });
      setNotifications(
        notifications.map((notif) =>
          notif.id === id ? { ...notif, isRead: true } : notif
        )
      );
    } catch (err) {
      setError('Bildirim okundu olarak işaretlenirken hata.');
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
        Bildirimler
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
      {notifications.length > 0 ? (
        notifications.map((notif) => (
          <NotificationItem
            key={notif.id}
            notification={notif}
            onMarkAsRead={handleMarkAsRead}
          />
        ))
      ) : (
        <p style={{ textAlign: 'center', color: '#ffffff' }}>Henüz bildirim yok.</p>
      )}
    </Container>
  );
}

export default AdminNotifications;