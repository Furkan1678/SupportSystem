import React from 'react';
import styled from 'styled-components';
import { motion } from 'framer-motion';

const FooterContainer = styled.footer`
  background: #1a1a1a;
  padding: 20px;
  text-align: center;
  border-top: 1px solid #00ff00;
`;

const Text = styled(motion.p)`
  color: #ffffff;
  font-size: 0.9rem;
  margin: 0;

  a {
    color: #00ff00;
    transition: color 0.3s ease;

    &:hover {
      color: #ff00ff;
    }
  }
`;

function Footer() {
  return (
    <FooterContainer>
      <Text
        whileHover={{ scale: 1.05 }}
      >
        © 2025 FSociety. Tüm hakları saklıdır. <br />
        Tasarım ve Geliştirme: <a href="mailto:fsociety@ornek.com">FSociety Ekibi</a>
      </Text>
    </FooterContainer>
  );
}

export default Footer;