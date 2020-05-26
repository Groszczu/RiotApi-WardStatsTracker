import React, { useState } from 'react';
import './SummonerForm.css';
import PlatformSelect from '../PlatformSelect/PlatformSelect';
import SubmitButton from '../SubmitButton/SubmitButton';
import SummonerNameInput from '../SummonerNameInput/SummonerNameInput';
import { withRouter } from 'react-router-dom';

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

export default withRouter(SummonerForm);