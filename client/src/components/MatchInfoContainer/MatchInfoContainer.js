import React from 'react';
import './MatchCardInfo.css';
import { useDataApi } from '../../hooks/hooks';
import MatchInfoDetails from './MatchInfoDetails';

const QUEUES_URL = 'https://static.developer.riotgames.com/docs/lol/queues.json';

const MatchInfoContainer = ({ match, isWin }) => {
  const [fetchState] = useDataApi(QUEUES_URL, []);

  let content;
  if (fetchState.isLoading) {
    content = 'Loading...';
  } else if (fetchState.isError) {
    content = 'Something went wrong';
  } else if (Array.isArray(fetchState.data) && fetchState.fetched) {
    const queueType = fetchState.data.find(q => q.queueId === match.queueId)?.description ?? 'Unknown game type';
    content = <MatchInfoDetails queueType={queueType} match={match} isWin={isWin} />
  }
  return (
    <section className="match-info">
      {content}
    </section>
  );
};


export default MatchInfoContainer;