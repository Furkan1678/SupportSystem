import React, { useContext } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import { AuthContext } from '../context/AuthContext';
import styled from 'styled-components';
import { FaHome, FaTicketAlt, FaFolder, FaLayerGroup, FaBell, FaUsers, FaSignOutAlt } from 'react-icons/fa';
import { motion } from 'framer-motion';

const Sidebar = styled.div`
  background: #1a1a1a;
  padding: 20px;
  min-height: 100vh;
  width: 250px;
  position: fixed;
  top: 0;
  left: 0;
  border-right: 1px solid #00ff00;
  box-shadow: 2px 0 5px rgba(0, 255, 0, 0.2);
`;

const Title = styled(motion.h3)`
  color: #00ff00;
  font-weight: 600;
  margin-bottom: 30px;
  font-size: 1.5rem;
  text-align: center;
`;

const Nav = styled.nav`
  display: flex;
  flex-direction: column;
  gap: 10px;
`;

const NavLink = styled(motion.div)`
  color: ${props => (props.active ? '#ff00ff' : '#ffffff')};
  font-weight: 500;
  padding: 10px 15px;
  background: ${props => (props.active ? 'rgba(255, 0, 255, 0.1)' : 'transparent')};
  border-radius: 8px;
  display: flex;
  align-items: center;
  gap: 10px;
  cursor: pointer;
  transition: all 0.3s ease;

  &:hover {
    background: rgba(255, 0, 255, 0.2);
    color: #ff00ff;
  }
`;

const LogoutButton = styled(NavLink)`
  margin-top: 20px;
  color: #ff6b6b;

  &:hover {
    color: #ffffff;
    background: #ff6b6b;
  }
`;

function AdminSidebar() {
  const { logout } = useContext(AuthContext);
  const location = useLocation();
  const navigate = useNavigate();

  const isActive = (path) => location.pathname === path;

  const links = [
    { path: '/admin-dashboard', icon: <FaHome />, label: 'Genel Bakış' },
    { path: '/admin-dashboard/requests', icon: <FaTicketAlt />, label: 'Destek Talepleri' },
    { path: '/admin-dashboard/categories', icon: <FaFolder />, label: 'Kategoriler' },
    { path: '/admin-dashboard/types', icon: <FaLayerGroup />, label: 'Destek Türleri' },
    { path: '/admin-dashboard/notifications', icon: <FaBell />, label: 'Bildirimler' },
    { path: '/admin-dashboard/users', icon: <FaUsers />, label: 'Kullanıcılar' },
  ];

  return (
    <Sidebar>
      <Title
        className="glitch"
        whileHover={{ scale: 1.05 }}
      >
        FSociety Panel
      </Title>
      <Nav>
        {links.map((link) => (
          <NavLink
            key={link.path}
            active={isActive(link.path)}
            onClick={() => navigate(link.path)}
            whileHover={{ scale: 1.05 }}
          >
            {link.icon}
            {link.label}
          </NavLink>
        ))}
        <LogoutButton
          onClick={logout}
          whileHover={{ scale: 1.05 }}
        >
          <FaSignOutAlt />
          Çıkış Yap
        </LogoutButton>
      </Nav>
    </Sidebar>
  );
}

export default AdminSidebar;