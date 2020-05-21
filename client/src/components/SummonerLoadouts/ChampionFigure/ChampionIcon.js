import React from 'react';

const ChampionIcon = ({ championImgUrl, championName }) => {
  return (
    <img className="champion-icon" src={championImgUrl} alt={`${championName} icon`} />
  );
};

export default ChampionIcon;