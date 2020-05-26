import React, {useEffect, useState} from 'react';
import './SummonerDetails.css';
import {useIsMountedRef} from "../../hooks/hooks";
import DataDragon from "../../util/DataDragon";

const SummonerDetails = ({ summoner }) => {
  const [iconImgUrl, setIconImgUrl] = useState('');
  const isMountedRef = useIsMountedRef();

  useEffect(() => {
    const fetchIcon = async () => {
      const iconData = await DataDragon.getResource(DataDragon.RESOURCES.ICONS, summoner.profileIconId)
      const iconImgUrl = await DataDragon.getResourceImgUrl(iconData);
      if (isMountedRef.current) {
        setIconImgUrl(iconImgUrl);
      }
    };

    fetchIcon();
  }, [summoner, setIconImgUrl, isMountedRef])

  return (
    <section className="card summoner-details">
      <img className="profile-icon" src={iconImgUrl} alt="profile icon" />
      <h1 className="summoner-name">{summoner.name}</h1>
      <h2>{summoner.leagues.map(league => (<div key={league.leagueId}><h3>{`${league.tier} ${league.rank}`}</h3></div>))}</h2>
    </section>);
}

export default SummonerDetails;