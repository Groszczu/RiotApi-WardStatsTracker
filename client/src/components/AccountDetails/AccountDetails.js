import React, {useEffect, useState} from 'react';
import SummonerDetails from '../SummonerDetails/SummonerDetails';
import MatchList from '../MatchList/MatchList';
import {useDataApi} from "../../hooks/hooks";
import MatchCard from "../MatchCard/MatchCard";

const AccountDetails = ({match: pathMatch}) => {

  const platformId = pathMatch.params.platform;
  const summonerName = pathMatch.params.summonerName;

  const [summonerFetchState] = useDataApi(`https://localhost:5001/${platformId}/summoners/${summonerName}?includeMatches=true`);
  const [summoner, setSummoner] = useState(null);

  useEffect(() => {
    if (summonerFetchState.fetched) {
      setSummoner({...summonerFetchState.data});
    }
  }, [setSummoner, summonerFetchState]);

  if (!summonerFetchState.fetched || !summoner) {
    return <div>Loading...</div>
  }

  const {name, matches, accountId} = summoner;
  const matchCards = matches.map(match => (
    <li key={match.gameId}>
      <MatchCard match={match} accountId={accountId}/>
    </li>
  ));

  return (
    <div>
      <SummonerDetails summonerName={name}/>
      <MatchList matches={matchCards}/>
    </div>
  );
}

export default AccountDetails;