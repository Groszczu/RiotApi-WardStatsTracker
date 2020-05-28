import React, {useEffect} from 'react';
import SummonerDetails from '../SummonerDetails/SummonerDetails';
import MatchList from '../MatchList/MatchList';
import {useDataApi} from "../../hooks/hooks";
import MatchCard from "../MatchCard/MatchCard";
import Config from "../../configuration";

const AccountDetails = ({match: pathMatch}) => {
  const platformId = pathMatch.params.platform;
  const summonerName = pathMatch.params.summonerName;
  const endpoint = `${Config.apiGateway.url}/${platformId}/summoners/${summonerName}`;

  const [summonerFetchState, doFetch] = useDataApi(endpoint);

  useEffect(() => {
    doFetch(endpoint);
  }, [doFetch, endpoint])

  if (summonerFetchState.isError) {
    return <h2 className="centered">Summoner not found</h2>
  }

  if (!summonerFetchState.fetched) {
    return <h2 className="centered">Loading...</h2>
  }

  const summoner = summonerFetchState.data;
  const {matches, accountId} = summoner;
  const matchCards = matches.map(match => (
    <li key={match.gameId}>
      <MatchCard match={match} accountId={accountId}/>
    </li>
  ));

  return (
    <>
      <SummonerDetails summoner={summoner}/>
      <MatchList matches={matchCards}/>
    </>
  );
}

export default AccountDetails;