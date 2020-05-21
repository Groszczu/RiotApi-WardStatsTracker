import React, { useEffect, useState } from 'react';
import DataDragon from '../../../util/DataDragon';
import ChampionCaption from './ChampionCaption';
import ChampionIcon from './ChampionIcon';
import { useIsMountedRef } from '../../../hooks/hooks';

const ChampionFigure = ({ championId }) => {
  const [championName, setChampionName] = useState('');
  const [championImgUrl, setChampionImgUrl] = useState('');
  const isMountedRef = useIsMountedRef();

  useEffect(() => {
    async function setChampionData() {
      const championData = await DataDragon.getResource(DataDragon.RESOURCES.CHAMPIONS, championId);
      const imgUrl = await DataDragon.getResourceImgUrl(DataDragon.RESOURCES.CHAMPIONS, championId);

      if (isMountedRef.current) {
        setChampionName(championData.name || 'champion not found');
        setChampionImgUrl(imgUrl);
      }
    }

    setChampionData();
  }, [isMountedRef, setChampionName, setChampionImgUrl, championId]);

  return (
    <figure className="champion-figure">
      <ChampionIcon championImgUrl={championImgUrl} championName={championName} />
      <ChampionCaption championName={championName} />
    </figure>
  );
};

export default ChampionFigure;