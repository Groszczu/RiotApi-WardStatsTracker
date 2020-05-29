import React from 'react';
import QueueTypeResolver from './QueueTypeResolver';
import './MatchCard.css';
import SummonerLoadouts from '../SummonerLoadouts/SummonerLoadouts';
import GameStats from './GameStats/GameStats';
import MatchDetails from "./MatchDetails/MatchDetails";

const MatchCard = ({ match, accountId }) => {
  const getParticipant = (match, accountId) => {
    return match.participants.find(p => p.identity.accountId === accountId);
  };

  const participant = getParticipant(match, accountId);
  const stats = participant.stats;
  const { kills, deaths, assists } = stats;

  return (
    <div className={`card match-card ${stats.win ? 'victory-card' : 'defeat-card'}`}>
      <QueueTypeResolver queueId={match.queueId} render={
        (queueType) => (
         <MatchDetails queueType={queueType} gameCreation={match.gameCreation} gameDuration={match.gameDuration} isWin={stats.win} />
        )} />
      <SummonerLoadouts participant={participant} stats={stats} />
      <GameStats kills={kills} deaths={deaths} assists={assists} />
    </div>
  );
};

export default MatchCard;