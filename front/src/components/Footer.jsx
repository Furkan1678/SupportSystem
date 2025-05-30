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
        © 2025 Destek Sistemi. Tüm hakları saklıdır. <br />
        Tasarım ve Geliştirme: <a href="mailto:furkankeskin1678@gmail.com">KESKİN</a> <a href="mailto:332361014@ogr.uludag.edu.tr">DEMİR</a> <a href="mailto:haticenalcaci987@gmail.com">NALÇACI</a> <a href="mailto:burakovc112@gmail.com">ÖVEÇ</a> <a href="mailto:ozcanmert72@gmail.com">ÖZCAN</a> <a href="mailto:eminbakir3453@gmail.com">BAKIR</a>
      </Text>
    </FooterContainer>
  );
}

export default Footer;