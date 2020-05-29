import React from 'react';
import './SummonerLoadouts.css';
import ChampionFigure from './ChampionFigure/ChampionFigure';
import SummonerSpells from './SummonerSpells/SummonerSpells';
import Runes from './Runes/Runes';

const SummonerLoadouts = ({ participant, stats }) => {
  return (
    <section className="loadouts">
      <ChampionFigure championId={participant.championId} />
      <SummonerSpells spellIds={[participant.spell1Id, participant.spell2Id]} />
      <Runes keystoneId={stats.keystonePerk} perkSubStyleId={stats.perkSubStyle} />
    </section>
  );
};

export default SummonerLoadouts;