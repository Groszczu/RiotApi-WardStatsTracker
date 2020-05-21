import React from 'react';
import './GameStats.css';

const GameStats = ({stats}) => {
  const kda = calculateKda(stats.kills, stats.deaths, stats.assists);

  return (
    <section className="game-stats">
      <p className="stats-ratio">{stats.kills} / <span className="deaths-number">{stats.deaths}</span> / {stats.assists}</p>
      <p><em className="stats-kda">{kda}</em> KDA</p>
    </section>
  );
};

function calculateKda(kills, deaths, assists) {
  return deaths === 0 ? 'Perfect' : ((kills + assists) / deaths).toFixed(2) ;
}

export default GameStats;