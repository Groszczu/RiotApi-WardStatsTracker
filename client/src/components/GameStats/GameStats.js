import React from 'react';
import './GameStats.css';

const GameStats = ({stats}) => {
  const { kills, deaths, assists } = stats;
  const kda = calculateKda(kills, deaths, assists);

  return (
    <section className="game-stats">
      <p className="stats-ratio">{kills} / <span className="deaths-number">{deaths}</span> / {assists}</p>
      <p><em className="stats-kda">{kda}</em> KDA</p>
    </section>
  );
};

function calculateKda(kills, deaths, assists) {
  return deaths === 0 ? 'Perfect' : ((kills + assists) / deaths).toFixed(2) ;
}

export default GameStats;