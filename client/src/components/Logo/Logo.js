import React from 'react';
import { Link } from 'react-router-dom';
import './Logo.css';

const Logo = () => {
  return (
    <Link to="/" className="logo">
      <h1>WardStatsTracker</h1>
    </Link>
  );
};

export default Logo;