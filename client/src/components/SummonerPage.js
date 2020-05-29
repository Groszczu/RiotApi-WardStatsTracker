import SummonerDetails from "./SummonerDetails/SummonerDetails";
import React from "react";
import withErrorHandling from "./shared/hoc/withErrorHandling";
import withLoading from "./shared/hoc/withLoading";
import MatchList from "./MatchList/MatchList";
import MatchCard from "./MatchCard/MatchCard";

const SummonerPage = ({ summonerData }) => {
  return (
    <>
      <SummonerDetails summoner={summonerData} />
      <MatchList matches={
        summonerData.matchesWithDetails.map(match =>
          (<li key={match.gameId}>
            <MatchCard match={match} accountId={summonerData.accountId} />
          </li>))
      } />
    </>
  );
};

export default withErrorHandling(
  withLoading(SummonerPage)
);