import React from 'react';
import './MatchList.css';

const MatchList = ({ matches }) => {
  return (
    <ul className="match-list container">
      {matches}
    </ul>
  );
}

export default MatchList;