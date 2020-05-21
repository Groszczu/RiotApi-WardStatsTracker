import React, { useState, createContext } from 'react';

export const SummonerContext = createContext();

export const SummonerProvider = (props) => {
  const [summoner, setSummoner] = useState({});

  return (
    <SummonerContext.Provider value={[summoner, setSummoner]}>
      {props.children}
    </SummonerContext.Provider>
  );
}