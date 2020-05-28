import {generateResourceKey} from "./KeyGenerator";

const CommunityDragon = {
  URI: 'https://raw.communitydragon.org/latest/plugins/rcp-be-lol-game-data/global/default/v1',
  DEFAULT_RUNE_IMG_URL: function(){ return `${this.URI}/perk-images/styles/runesicon.png` },

  async getPerk(perkId) {
    const perksKey = generateResourceKey('cd', 'perks');
    const perksString = sessionStorage.getItem(perksKey);
    let perksJson;
    if (!perksString) {
      console.log('fetching perks');
      const endpoint = `${this.URI}/perks.json`;
      const perks = await fetch(endpoint);

      if (!perks.ok)
        return null;

      perksJson = await perks.json();
      sessionStorage.setItem(perksKey, JSON.stringify(perksJson));
    } else {
      perksJson = JSON.parse(perksString);
    }

    return perksJson.find(p => p.id === perkId) || null;
  },

  async getPerkStyle(perkStyleId) {
    const stylesKey = generateResourceKey('cd', 'perkstyles');
    const stylesString = sessionStorage.getItem(stylesKey);
    let stylesJson;
    if (!stylesString) {
      console.log('fetching perk styles');
      const endpoint = `${this.URI}/perkstyles.json`;
      const perkStyles = await fetch(endpoint);

      if (!perkStyles.ok)
        return null;

      stylesJson = await perkStyles.json();
      sessionStorage.setItem(stylesKey, JSON.stringify(stylesJson));
    } else {
      stylesJson = JSON.parse(stylesString);
    }

    return stylesJson.styles.find(s => s.id === perkStyleId) || null;
  },

  async getPerkImgUrl(perk) {
    if (!perk) {
      return this.DEFAULT_RUNE_IMG_URL();
    }
    
    const pathMatch = perk.iconPath.match(/\/styles\/(?<style>\w+)\/(?<perkName>\w+)\/(?<imgFile>\w+\.png)/i);
    const { style, perkName, imgFile } = pathMatch.groups;
    return `${this.URI}/perk-images/styles/${style.toLowerCase()}/${perkName.toLowerCase()}/${imgFile.toLowerCase()}`;
  }, 

  async getPerkStyleImgUrl(perkStyle) {
    if (!perkStyle) {
      return this.DEFAULT_RUNE_IMG_URL();
    }

    const pathMatch = perkStyle.iconPath.match(/\/styles\/(?<imgFile>\w+\.png)/i);
    const { imgFile } = pathMatch.groups;
    return `${this.URI}/perk-images/styles/${imgFile.toLowerCase()}`;
  }
};

export default CommunityDragon;