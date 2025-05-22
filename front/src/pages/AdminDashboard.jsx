import React, { useContext, useEffect } from 'react';
import { useNavigate, Outlet } from 'react-router-dom';
import styled from 'styled-components';
import { AuthContext } from '../context/AuthContext';
import AdminSidebar from '../components/AdminSidebar';

const Container = styled.div`
  display: flex;
  min-height: 100vh;
  background: #0a0a0a;
`;

const Content = styled.div`
  margin-left: 250px;
  padding: 30px;
  flex: 1;
`;

function AdminDashboard() {
  const { user } = useContext(AuthContext);
  const navigate = useNavigate();

  useEffect(() => {
    if (!user || (user.role !== 'Admin' && user.role !== 'SuperAdmin')) {
      navigate('/');
    }
  }, [user, navigate]);

  return (
    <Container>
      <AdminSidebar />
      <Content>
        <Outlet />
      </Content>
    </Container>
  );
}

export default AdminDashboard;