import React from 'react';
import MatchInfoContainer from '../MatchInfoContainer/MatchInfoContainer';
import './MatchCard.css';
import SummonerLoadouts from '../SummonerLoadouts/SummonerLoadouts';
import GameStats from '../GameStats/GameStats';
import {useDataApi} from "../../hooks/hooks";

const MatchCard = ({ match, accountId }) => {
  const [ matchFetchState ] = useDataApi(`https://localhost:5001/${match.platformId}/matches/${match.gameId}`)

  const getParticipant = (match, accountId) => {
    return match.participants.find(p => p.identity.accountId === accountId);
  };

  if (!matchFetchState.fetched) {
    return <></>;
  }

  const matchDetails = matchFetchState.data;
  const participant = getParticipant(matchDetails, accountId);
  const stats = participant.stats;

  return (
    <div className={`card match-card ${stats.win ? 'victory-card' : 'defeat-card'}`}>
      <MatchInfoContainer match={matchDetails} isWin={stats.win} />
      <SummonerLoadouts participant={participant} stats={stats} />
      <GameStats stats={stats} />
    </div>
  );
};

export default MatchCard;