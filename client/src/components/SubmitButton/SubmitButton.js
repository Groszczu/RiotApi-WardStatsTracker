import React from 'react';
import searchIcon from '../../images/search-icon.png';

const SubmitButton = (props) => {
  return (
    <button
      className={`submit-btn ${props.className}`}
      type="submit">
      <img className="search-icon" src={searchIcon} alt="search" />
    </button>
  );
}

export default SubmitButton;