import React, { useEffect, useState } from 'react';
import CommunityDragon from '../../../util/CommunityDragon';
import RuneDetails from './RuneDetails';
import { useIsMountedRef } from '../../../hooks/hooks';

const Runes = ({ keystoneId, perkSubStyleId }) => {
  const [keystoneRune, setKeystoneRune] = useState({ data: {}, imgUrl: '' });
  const [perkSubStyle, setPerkSubStyle] = useState({ data: {}, imgUrl: '' });
  const isMountedRef = useIsMountedRef();

  useEffect(() => {
    async function setRunesData() {
      const keystone = {
        data: await CommunityDragon.getPerk(keystoneId),
        imgUrl: await CommunityDragon.getPerkImgUrl(keystoneId),
      };

      const subStyle = {
        data: await CommunityDragon.getPerkStyle(perkSubStyleId),
        imgUrl: await CommunityDragon.getPerkStyleImgUrl(perkSubStyleId),
      };

      if (isMountedRef.current) {
        setKeystoneRune(keystone);
        setPerkSubStyle(subStyle);
      }
    }

    setRunesData();
  }, [isMountedRef, setKeystoneRune, setPerkSubStyle, keystoneId, perkSubStyleId]);

  return (
    <div className="runes">
      <RuneDetails rune={keystoneRune} />
      <RuneDetails rune={perkSubStyle} />
    </div>
  );
};

export default Runes;