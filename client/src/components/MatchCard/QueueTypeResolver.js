import React from 'react';
import './MatchDetails/MatchDetails.css';
import {useDataApi} from '../../hooks/hooks';

const QUEUES_URL = 'https://static.developer.riotgames.com/docs/lol/queues.json';

const QueueTypeResolver = ({ queueId, render }) => {
  const [fetchState] = useDataApi(QUEUES_URL, []);

  const queueType = fetchState.data.find(q => q.queueId === queueId)?.description || 'Unknown game type';

  return (
    <section className="match-info">
      {fetchState.isLoading
        ? null
        : render(queueType)}
    </section>
  );
};

export default QueueTypeResolver;