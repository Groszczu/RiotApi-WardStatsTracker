import React from 'react';
import SummonerForm from '../SummonerForm/SummonerForm';
import Logo from '../Logo/Logo';
import './Navbar.css';

const Navbar = () => {
  return (
    <nav className="navbar">
      <Logo />
      <SummonerForm />
    </nav>
  );
};

export default Navbar;