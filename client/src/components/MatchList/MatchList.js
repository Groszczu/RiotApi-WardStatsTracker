import React from 'react';
import MatchCard from '../MatchCard/MatchCard';
import './MatchList.css';

const MatchList = (props) => {
  return (
    <ul className="match-list container">
      {props.matches.map(m => (
        <li key={m.gameId}>
          <MatchCard match={m} />
        </li>))}
    </ul>
  );
}

export default MatchList;