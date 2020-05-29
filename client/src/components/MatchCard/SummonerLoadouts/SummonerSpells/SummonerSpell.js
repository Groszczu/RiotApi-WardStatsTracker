import React from 'react';
import PropTypes from 'prop-types';

const SummonerSpell = ({ spell }) => {
  return (
    <img className="summoner-spell-img" src={spell.imgUrl} alt={`spell ${spell.data.name} img`} />
  );
};

SummonerSpell.propTypes = {
  spell: PropTypes.object.isRequired,
};

export default SummonerSpell;