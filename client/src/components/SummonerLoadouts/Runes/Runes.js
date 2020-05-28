import React, {useEffect, useState} from 'react';
import CommunityDragon from '../../../util/CommunityDragon';
import RuneDetails from './RuneDetails';
import { useIsMountedRef } from '../../../hooks/hooks';

const Runes = ({ keystoneId, perkSubStyleId }) => {
  const [keystoneRune, setKeystoneRune] = useState({ data: {}, imgUrl: '' });
  const [perkSubStyle, setPerkSubStyle] = useState({ data: {}, imgUrl: '' });
  const isMountedRef = useIsMountedRef();

  useEffect(() => {
    async function setRunesData() {
      const keystoneData = await CommunityDragon.getPerk(keystoneId);
      const keystoneImgUrl = await CommunityDragon.getPerkImgUrl(keystoneData);
      const keystone = {
        data: keystoneData,
        imgUrl: keystoneImgUrl
      };

      const subStyleData = await CommunityDragon.getPerkStyle(perkSubStyleId);
      const subStyleImgUrl = await CommunityDragon.getPerkStyleImgUrl(subStyleData);
      const subStyle = {
        data: subStyleData,
        imgUrl: subStyleImgUrl
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