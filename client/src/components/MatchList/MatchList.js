import React from 'react';
import './MatchList.css';

const MatchList = ({ matches }) => {
  return (
    <ul className="match-list">
      {matches.length > 0 ? matches : <li><h2>No matches registered</h2></li>}
    </ul>
  );
}

export default MatchList;