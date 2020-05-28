import React, { useState } from 'react';
import './SummonerForm.css';
import { withRouter } from 'react-router-dom';
import searchIcon from "../../images/search-icon.png";

const SummonerForm = (props) => {
  const [summonerName, setSummonerName] = useState('');
  const [platform, setPlatform] = useState('');

  const _onSubmit = (e) => {
    e.preventDefault();
    if (!platform || !summonerName) {
      return;
    }

    props.history.push(`/${platform}/account/${summonerName}`);
  }

  return (
    <form className="summoner-search" onSubmit={_onSubmit}>
      <PlatformSelect onChange={setPlatform} />
      <SummonerNameInput onChange={setSummonerName} />
      <SubmitButton className={!summonerName || !platform ? 'link-disabled' : ''} />
    </form>
  );
}

const PlatformSelect = (props) => {
  const _handleChange = (event) => {
    props.onChange(event.target.value);
  }

  return (
    <select className="platform-dropdown" onChange={_handleChange} defaultValue="Platform">
      <option disabled>Platform</option>
      <option value="eun1">EUNE</option>
      <option value="euw1">EUW</option>
    </select>
  );
};

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
};

const SubmitButton = (props) => {
  return (
    <button
      className={`submit-btn ${props.className}`}
      type="submit">
      <img className="search-icon" src={searchIcon} alt="search" />
    </button>
  );
};

export default withRouter(SummonerForm);