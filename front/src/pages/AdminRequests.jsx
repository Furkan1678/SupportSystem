import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
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

const Table = styled.table`
  width: 100%;
  background: #1a1a1a;
  border: 1px solid #00ff00;
  border-radius: 10px;
  overflow: hidden;
`;

const Th = styled.th`
  background: #00b4d8;
  color: #ffffff;
  padding: 15px;
  text-align: left;
`;

const Td = styled.td`
  padding: 15px;
  color: #ffffff;
  border-top: 1px solid #00ff00;
`;

const Select = styled.select`
  padding: 8px;
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
  background: transparent;
  color: #00ff00;
  border: none;
  font-family: 'Fira Code', monospace;

  &:hover {
    color: #ff00ff;
  }
`;

const Alert = styled(motion.div)`
  background: #ff6b6b;
  color: #ffffff;
  padding: 15px;
  border-radius: 10px;
  margin-bottom: 20px;
`;

function AdminRequests() {
  const navigate = useNavigate();
  const [supportRequests, setSupportRequests] = useState([]);
  const [error, setError] = useState('');

  const statusMapping = {
    Pending: 0,
    InProgress: 1,
    Completed: 2,
    Rejected: 3,
    OnHold: 4,
  };

  const reverseStatusMapping = {
    0: 'Pending',
    1: 'InProgress',
    2: 'Completed',
    3: 'Rejected',
    4: 'OnHold',
  };

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await api.get('/supportrequest');
        const requests = response.data.map(req => ({
          ...req,
          status: reverseStatusMapping[req.status] || req.status || 'Pending',
        })) || [];
        setSupportRequests(requests);
      } catch (err) {
        setError(`Veriler yüklenirken hata: ${err.message}`);
      }
    };
    fetchData();
  }, []);

  const handleStatusChange = async (id, newStatus) => {
    try {
      await api.put('/supportrequest/status', { id, status: statusMapping[newStatus] });
      setSupportRequests(supportRequests.map(req =>
        req.id === id ? { ...req, status: newStatus } : req
      ));
    } catch (err) {
      setError(`Durum güncellenirken hata: ${err.message}`);
    }
  };

  const getPriorityLabel = (priority) => {
    switch (priority) {
      case 1: return 'Düşük';
      case 2: return 'Orta';
      case 3: return 'Yüksek';
      default: return 'Belirtilmemiş';
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
        Destek Talepleri
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
        <h4 style={{ color: '#00ff00', marginBottom: '20px' }}>Tüm Talepler</h4>
        <Table>
          <thead>
            <tr>
              <Th>ID</Th>
              <Th>Konu</Th>
              <Th>Kullanıcı ID</Th>
              <Th>Durum</Th>
              <Th>Öncelik</Th>
              <Th>Ek Dosya</Th>
              <Th>İşlem</Th>
            </tr>
          </thead>
          <tbody>
            {supportRequests.length > 0 ? (
              supportRequests.map((req) => (
                <tr key={req.id}>
                  <Td>{req.id}</Td>
                  <Td>{req.subject || 'Konu Yok'}</Td>
                  <Td>{req.userId || 'Bilinmiyor'}</Td>
                  <Td>{req.status || 'Belirtilmemiş'}</Td>
                  <Td>{getPriorityLabel(req.priority)}</Td>
                  <Td>
                    {req.attachmentUrl ? (
                      <a href={req.attachmentUrl} target="_blank" rel="noopener noreferrer" style={{ color: '#00ff00' }}>
                        Dosyayı Görüntüle
                      </a>
                    ) : (
                      'Ek Dosya Yok'
                    )}
                  </Td>
                  <Td>
                    <Select
                      value={req.status || 'Pending'}
                      onChange={(e) => handleStatusChange(req.id, e.target.value)}
                    >
                      <option value="Pending">Beklemede</option>
                      <option value="InProgress">İşleme Alındı</option>
                      <option value="Completed">Tamamlandı</option>
                      <option value="Rejected">Reddedildi</option>
                      <option value="OnHold">Bekletiliyor</option>
                    </Select>
                    <Button
                      whileHover={{ scale: 1.05 }}
                      onClick={() => navigate(`/support-request/${req.id}`)}
                    >
                      Detay
                    </Button>
                  </Td>
                </tr>
              ))
            ) : (
              <tr>
                <Td colSpan="7" style={{ textAlign: 'center' }}>
                  Henüz destek talebi yok.
                </Td>
              </tr>
            )}
          </tbody>
        </Table>
      </Card>
    </Container>
  );
}

export default AdminRequests;