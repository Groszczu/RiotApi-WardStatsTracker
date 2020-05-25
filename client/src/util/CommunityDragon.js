import { generateResourceKey } from './KeyGenerator';

const CommunityDragon = {
  URI: 'https://raw.communitydragon.org/latest/plugins/rcp-be-lol-game-data/global/default/v1',
  DEFAULT_RUNE_IMG_URL: function(){ return `${this.URI}/perk-images/styles/runesicon.png` },

  async getPerk(perkId) {
    const perkKey = generateResourceKey('perk', perkId);
    const perkString = sessionStorage.getItem(perkKey);
    if (perkString) {
      return JSON.parse(perkString);
    }

    const endpoint = `${this.URI}/perks.json`;

    const perks = await fetch(endpoint);

    const perksJson = await perks.json();

    const perk = perksJson.find(p => p.id === perkId);
    if (perk) {
      sessionStorage.setItem(perkKey, JSON.stringify(perk));
      return perk;
    }
  },

  async getPerkStyle(perkStyleId) {
    const perkStyleKey = generateResourceKey('perkstyle', perkStyleId);

    const perkStyleString = sessionStorage.getItem(perkStyleKey);
    if (perkStyleString) {
      return JSON.parse(perkStyleString);
    }

    const endpoint = `${this.URI}/perkstyles.json`;

    const perkStyles = await fetch(endpoint);

    const perkStylesJson = await perkStyles.json();

    const perkStyle = perkStylesJson.styles.find(s => s.id === perkStyleId);
    if (perkStyle) {
      sessionStorage.setItem(perkStyleKey, JSON.stringify(perkStyle))
      return perkStyle;
    }
  },

  async getPerkImgUrl(perkId) {
    const perk = await this.getPerk(perkId);

    if (!perk) {
      return this.DEFAULT_RUNE_IMG_URL();
    }
    
    const pathMatch = perk.iconPath.match(/\/styles\/(?<style>\w+)\/(?<perkName>\w+)\/(?<imgFile>\w+\.png)/i);
    const { style, perkName, imgFile } = pathMatch.groups;
    return `${this.URI}/perk-images/styles/${style.toLowerCase()}/${perkName.toLowerCase()}/${imgFile.toLowerCase()}`;
  }, 

  async getPerkStyleImgUrl(perkStyleId) {
    const perkStyle = await this.getPerkStyle(perkStyleId);

    if (!perkStyle) {
      return this.DEFAULT_RUNE_IMG_URL();
    }

    const pathMatch = perkStyle.iconPath.match(/\/styles\/(?<imgFile>\w+\.png)/i);
    const { imgFile } = pathMatch.groups;
    return `${this.URI}/perk-images/styles/${imgFile.toLowerCase()}`;
  }
};

export default CommunityDragon;