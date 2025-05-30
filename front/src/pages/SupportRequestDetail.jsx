import React, { useState, useEffect, useContext } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import styled from 'styled-components';
import { motion } from 'framer-motion';
import { AuthContext } from '../context/AuthContext';
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
  margin-bottom: 20px;
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

const CardTitle = styled.h4`
  color: #00ff00;
  font-size: 1.5rem;
  font-weight: 600;
  margin-bottom: 15px;
`;

const CardText = styled.p`
  color: #ffffff;
  margin-bottom: 10px;

  a {
    color: #00ff00;
    &:hover {
      color: #ff00ff;
    }
  }
`;

const CommentCard = styled(Card)`
  background: #2a2a2a;
`;

const FormLabel = styled.label`
  color: #ffffff;
  font-weight: 500;
  margin-bottom: 10px;
  display: block;
`;

const Textarea = styled.textarea`
  width: 100%;
  padding: 10px;
  background: #2a2a2a;
  border: 1px solid #00b4d8;
  border-radius: 8px;
  color: #ffffff;
  font-family: 'Fira Code', monospace;
  resize: vertical;

  &:focus {
    outline: none;
    border-color: #ff00ff;
  }
`;

const Button = styled(motion.button)`
  background: #00ff00;
  color: #0a0a0a;
  padding: 12px 20px;
  border: none;
  border-radius: 8px;
  font-weight: 500;
  font-family: 'Fira Code', monospace;
  width: 100%;

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
  margin-bottom: 20px;
`;

const durumMap = {
  0: 'Bekliyor',
  1: 'İşlemde',
  2: 'Tamamlandı',
  3: 'İptal Edildi',
};

const oncelikMap = {
  0: 'Düşük',
  1: 'Orta',
  2: 'Yüksek',
  3: 'Acil',
};


function SupportRequestDetail() {
  const { user } = useContext(AuthContext);
  const { id } = useParams();
  const navigate = useNavigate();
  const [request, setRequest] = useState(null);
  const [comments, setComments] = useState([]);
  const [newComment, setNewComment] = useState('');
  const [error, setError] = useState('');

  useEffect(() => {
    if (!user) {
      navigate('/login');
      return;
    }
    const fetchData = async () => {
      try {
        const requestResponse = await api.get(`/supportrequest/${id}`);
        const commentsResponse = await api.get('/supportrequestcomment/by-support-request', {
          params: { supportRequestId: id },
        });
        setRequest(requestResponse.data);
        setComments(commentsResponse.data || []);
      } catch (err) {
        setError('Veriler yüklenirken hata.');
      }
    };
    fetchData();
  }, [user, id, navigate]);

  const handleAddComment = async (e) => {
    e.preventDefault();
    if (!newComment.trim()) return;
    try {
      const response = await api.post('/supportrequestcomment', {
        supportRequestId: id,
        userId: user.id,
        comment: newComment,
        isAdminComment: user.role === 'Admin' || user.role === 'SuperAdmin',
      });
      setComments([...comments, response.data]);
      setNewComment('');
    } catch (err) {
      setError('Yorum eklenirken hata.');
    }
  };

  if (!request) return null;

  return (
    <Container>
      <Title
        className="glitch"
        initial={{ opacity: 0 }}
        animate={{ opacity: 1 }}
        transition={{ duration: 0.5 }}
      >
        Talep Detayı
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
        <CardTitle>{request.subject}</CardTitle>
        <CardText>
          <strong>Açıklama:</strong> {request.description} <br />
          <strong>Durum:</strong> {durumMap[request.status]} <br />
          <strong>Öncelik:</strong> {oncelikMap[request.priority]} <br />
          <strong>Oluşturulma:</strong> {new Date(request.createdAt).toLocaleDateString()}
          {request.attachmentUrl && (
            <>
              <br />
              <strong>Ek Dosya:</strong>{' '}
              <a href={request.attachmentUrl} target="_blank" rel="noopener noreferrer">
                Görüntüle
              </a>
            </>
          )}
        </CardText>
      </Card>

      <h4 style={{ color: '#00ff00', margin: '20px 0' }}>Yorumlar</h4>
      {comments.length > 0 ? (
        comments.map((comment) => (
          <CommentCard
            key={comment.id}
            initial={{ opacity: 0, y: 20 }}
            animate={{ opacity: 1, y: 0 }}
            transition={{ duration: 0.3 }}
          >
            <CardText>
              <strong>{comment.isAdminComment ? 'Admin' : 'Kullanıcı'}</strong> ({comment.userId}): {comment.comment} <br />
              <small>{new Date(comment.createdAt).toLocaleString()}</small>
            </CardText>
          </CommentCard>
        ))
      ) : (
        <p style={{ textAlign: 'center', color: '#ffffff' }}>Henüz yorum yok.</p>
      )}

      <Card
        initial={{ opacity: 0, y: 50 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ duration: 0.5, delay: 0.2 }}
      >
        <form onSubmit={handleAddComment}>
          <FormLabel>Yeni Yorum</FormLabel>
          <Textarea
            rows={3}
            value={newComment}
            onChange={(e) => setNewComment(e.target.value)}
            placeholder="Yorumunuzu yazın..."
          />
          <Button
            whileHover={{ scale: 1.05 }}
            type="submit"
            style={{ marginTop: '15px' }}
          >
            Yorum Ekle
          </Button>
        </form>
      </Card>
    </Container>
  );
}

export default SupportRequestDetail;