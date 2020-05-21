import React from 'react';
import './SummonerNameInput.css';

const SummonerNameInput = (props) => {
  const _handleChange = (event) => {
    props.onChange(event.target.value);
  }

  return (
      <input
        className="summoner-name-input"
        type="text"
        onChange={_handleChange}
        placeholder="Summoner name"
      />
  );
}

export default SummonerNameInput;