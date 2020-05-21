import React, { useEffect, useState } from 'react';
import SummonerDetails from '../SummonerDetails/SummonerDetails';
import MatchList from '../MatchList/MatchList';
import Riot from '../../util/Riot';
import { useIsMountedRef } from '../../hooks/hooks';

const AccountDetails = ({ match: pathMatch, timestamp }) => {
  const platformMoniker = pathMatch.params.platform;
  const summonerName = pathMatch.params.summonerName;

  const [matches, setMatches] = useState([]);
  const [name, setName] = useState('');
  const [accFound, setAccFound] = useState(true);

  const isMountedRef = useIsMountedRef();

  useEffect(() => {
    async function fetchMatches() {
      let summonerData;
      let matchesDetails;
      let matchHistory;
      try {
        summonerData = await Riot.getSummonerAndCacheAccountId(platformMoniker, summonerName);
        const accountId = summonerData.accountId;
        matchHistory = await Riot.getMatchHistory(platformMoniker, accountId);
        matchesDetails = await Promise.all(
          matchHistory.map(
            async (m) => await Riot.getMatchDetails(platformMoniker, m.gameId)
          )
        );
      } catch (error) {
        if (isMountedRef.current) {
          setAccFound(false);
        }
        return;
      }

      if (isMountedRef.current) {
        setAccFound(true);
      }

      const matchHistoryWithDetails = matchHistory.map(m => Object.assign(m, matchesDetails.find(d => m.gameId === d.gameId)));

      if (isMountedRef.current) {
        setName(summonerData.name);
        setMatches(matchHistoryWithDetails);
      }
    }

    fetchMatches();
  }, [isMountedRef, platformMoniker, summonerName, setMatches, setName, setAccFound, timestamp]);


  if (accFound) {
    return (
      <div>
        <SummonerDetails summonerName={name} />
        <MatchList matches={matches} />
      </div>
    );
  }

  return <h1>Summoner not found</h1>;
}

export default AccountDetails;