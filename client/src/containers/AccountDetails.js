import React, {useEffect} from 'react';
import {useDataApi} from "../hooks/hooks";
import Config from "../configuration";
import SummonerPage from "../components/SummonerPage";
import LoadingSpinner from "../components/LoadingSinner/LoadingSpinner";

const AccountDetails = ({match: pathMatch}) => {
  const platformId = pathMatch.params.platform;
  const summonerName = pathMatch.params.summonerName;
  const endpoint = `${Config.apiGateway.url}/${platformId}/summoners/${summonerName}?includeMatchDetails=true`;

  const [summonerFetchState, doFetch] = useDataApi(endpoint);

  useEffect(() => {
    doFetch(endpoint);
  }, [doFetch, endpoint])


  const { data: summonerData, isLoading, isError } = summonerFetchState;

  return <SummonerPage
    isError={isError}
    errorHandler={() => <h2 className={'centered'}>Error</h2>}
    isLoading={isLoading}
    loader={() => <LoadingSpinner />}
    summonerData={summonerData} />;
};



export default AccountDetails;