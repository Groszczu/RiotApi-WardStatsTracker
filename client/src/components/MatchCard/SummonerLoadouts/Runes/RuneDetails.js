import React from 'react';

const RuneDetails = ({ rune }) => {
  return (
    <div className="perk-img-container">
      <img className="perk-img" src={rune.imgUrl} alt={`rune ${rune.data ? rune.data.name : 'unknown'} img`} />
    </div>
  );
};

export default RuneDetails;