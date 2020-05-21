import React from 'react';
import MatchInfoContainer from '../MatchInfoContainer/MatchInfoContainer';
import './MatchCard.css';
import SummonerLoadouts from '../SummonerLoadouts/SummonerLoadouts';
import GameStats from '../GameStats/GameStats';

const MatchCard = ({ match }) => {
  const getParticipant = () => {
    const participant = match.participants.find(p => p.championId === match.champion);
    return participant;
  };

  const participant = getParticipant();
  const stats = participant.stats;

  return (
    <div className={`match-card ${stats.win ? 'victory-card' : 'defeat-card'}`}>
      <MatchInfoContainer match={match} isWin={stats.win} />
      <SummonerLoadouts participant={participant} stats={stats} />
      <GameStats stats={stats} />
    </div>
  );
};

export default MatchCard;