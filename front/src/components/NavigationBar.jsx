import React, { useContext, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { AuthContext } from '../context/AuthContext';
import styled from 'styled-components';
import { FaBars } from 'react-icons/fa';
import { motion } from 'framer-motion';

const Navbar = styled.nav`
  background: #1a1a1a;
  padding: 1rem 2rem;
  display: flex;
  justify-content: space-between;
  align-items: center;
  position: sticky;
  top: 0;
  z-index: 1000;
  box-shadow: 0 2px 5px rgba(0, 255, 0, 0.2);
`;

const Brand = styled(motion.div)`
  font-size: 1.5rem;
  font-weight: 600;
  color: #00ff00;
  cursor: pointer;
`;

const NavLinks = styled.div.attrs({
  shouldForwardProp: (prop) => prop !== 'expanded',
})`
  display: flex;
  align-items: center;
  gap: 1.5rem;

  @media (max-width: 768px) {
    display: ${props => (props.expanded ? 'flex' : 'none')};
    flex-direction: column;
    position: absolute;
    top: 60px;
    left: 0;
    right: 0;
    background: #1a1a1a;
    padding: 1rem;
  }
`;

const NavLink = styled(motion.a)`
  color: #ffffff;
  font-size: 1rem;
  font-weight: 500;
  transition: color 0.3s ease;

  &:hover {
    color: #ff00ff;
  }
`;

const NavButton = styled(motion.button)`
  background: transparent;
  border: 2px solid #00ff00;
  color: #00ff00;
  padding: 0.5rem 1.5rem;
  border-radius: 25px;
  font-weight: 500;

  &:hover {
    background: #00ff00;
    color: #0a0a0a;
  }
`;

const ToggleButton = styled.button`
  display: none;
  background: transparent;
  border: none;
  color: #00ff00;
  font-size: 1.5rem;

  @media (max-width: 768px) {
    display: block;
  }
`;

function NavigationBar() {
  const { user, logout } = useContext(AuthContext);
  const navigate = useNavigate();
  const [expanded, setExpanded] = useState(false);

  return (
    <Navbar>
      <Brand
        whileHover={{ scale: 1.1 }}
        onClick={() => navigate('/')}
      >
        FSociety
      </Brand>
      <ToggleButton onClick={() => setExpanded(!expanded)}>
        <FaBars />
      </ToggleButton>
      <NavLinks expanded={expanded.toString()}>
        {user ? (
          <>
            <NavLink
              whileHover={{ scale: 1.1 }}
              style={{ color: '#00b4d8' }}
            >
              Hoş geldin, {user.username}!
            </NavLink>
            {user.role === 'Admin' || user.role === 'SuperAdmin' ? (
              <NavLink
                whileHover={{ scale: 1.1 }}
                onClick={() => navigate('/admin-dashboard')}
              >
                Admin Paneli
              </NavLink>
            ) : (
              <>
                <NavLink
                  whileHover={{ scale: 1.1 }}
                  onClick={() => navigate('/support-requests')}
                >
                  Taleplerim
                </NavLink>
                <NavLink
                  whileHover={{ scale: 1.1 }}
                  onClick={() => navigate('/create-support-request')}
                >
                  Yeni Talep
                </NavLink>
                <NavLink
                  whileHover={{ scale: 1.1 }}
                  onClick={() => navigate('/notifications')}
                >
                  Bildirimler
                </NavLink>
              </>
            )}
            <NavButton
              whileHover={{ scale: 1.1 }}
              onClick={() => {
                logout();
                setExpanded(false);
              }}
            >
              Çıkış Yap
            </NavButton>
          </>
        ) : (
          <>
            <NavLink
              whileHover={{ scale: 1.1 }}
              onClick={() => navigate('/login')}
            >
              Giriş Yap
            </NavLink>
            <NavLink
              whileHover={{ scale: 1.1 }}
              onClick={() => navigate('/register')}
            >
              Kayıt Ol
            </NavLink>
          </>
        )}
      </NavLinks>
    </Navbar>
  );
}

export default NavigationBar;