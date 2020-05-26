import React, {useEffect, useState} from 'react';
import PropTypes from 'prop-types';
import DataDragon from '../../../util/DataDragon';
import SummonerSpell from './SummonerSpell';
import {useIsMountedRef} from '../../../hooks/hooks';

const SummonerSpells = ({spellIds}) => {
  const [spells, setSpells] = useState([]);
  const isMountedRef = useIsMountedRef();

  useEffect(() => {
    async function setSpellsData() {
      const spellsData = await Promise.all(
        spellIds.map(async (spellId) => {
          const spell = await DataDragon.getResource(DataDragon.RESOURCES.SUMMONER_SPELLS, spellId);
          const imgUrl = await DataDragon.getResourceImgUrl(spell);
          return {
            data: spell,
            imgUrl: imgUrl,
          }
        })
      );

      if (isMountedRef.current) {
        setSpells(spellsData);
      }
    }

    setSpellsData();
  }, [isMountedRef, setSpells, spellIds]);

  return (
    <div className="summoner-spells">
      {spells.map(s => <SummonerSpell key={s.data.id} spell={s}/>)}
    </div>
  );
};

SummonerSpells.propTypes = {
  spellIds: PropTypes.array.isRequired,
};

export default SummonerSpells;