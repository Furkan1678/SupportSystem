import { createGlobalStyle } from 'styled-components';

const GlobalStyles = createGlobalStyle`
  * {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
  }

  body {
    font-family: 'Fira Code', monospace;
    background: #0a0a0a;
    color: #ffffff;
    overflow-x: hidden;
  }

  a {
    color: #00ff00;
    text-decoration: none;
    transition: color 0.3s ease;
  }

  a:hover {
    color: #ff00ff;
  }

  .glitch {
    position: relative;
    animation: glitch 1s infinite alternate;
  }

  @keyframes glitch {
    0% { transform: translate(0); }
    20% { transform: translate(-2px, 2px); }
    40% { transform: translate(2px, -2px); }
    60% { transform: translate(-1px, 1px); }
    80% { transform: translate(1px, -1px); }
    100% { transform: translate(0); }
  }

  button {
    font-family: 'Fira Code', monospace;
    cursor: pointer;
    transition: all 0.3s ease;
  }
`;

export default GlobalStyles;