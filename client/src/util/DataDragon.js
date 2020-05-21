import { generateResourceKey } from './KeyGenerator';

const DataDragon = {
  async getResource(resourceType, resourceId) {
    const resourceKey = generateResourceKey(resourceType, resourceId);
    let resourceString = sessionStorage.getItem(resourceKey);
    if (resourceString) {
      const resource = JSON.parse(resourceString);
      return resource;
    }

    const version = await this._getLatestVersion();

    const endpoint = `https://ddragon.leagueoflegends.com/cdn/${version}/data/en_US/${resourceType}.json`;

    const response = await fetch(endpoint);

    const responseJson = await response.json();

    const data = Object.values(responseJson.data);

    const resource = data.find(r => Number(r.key) === resourceId);
    sessionStorage.setItem(resourceKey, JSON.stringify(resource));

    return resource;
  },

  async getResourceImgUrl(resourceType, resourceId) {
    const resourceData = await this.getResource(resourceType, resourceId);
    const iconPath = resourceData.image.full;
    const version = await this._getLatestVersion();

    const imgCatalog = DataDragon.IMAGES[resourceType];

    return `https://ddragon.leagueoflegends.com/cdn/${version}/img/${imgCatalog}/${iconPath}`;
  },

  async _getLatestVersion() {
    const versionEndpoint = 'https://ddragon.leagueoflegends.com/api/versions.json';
    const versions = await fetch(versionEndpoint);
    const versionsJson = await versions.json();
    return versionsJson[0];
  }
};

DataDragon.RESOURCES = {
  CHAMPIONS: 'champion',
  SUMMONER_SPELLS: 'summoner',
};
DataDragon.IMAGES = {
  'champion': 'champion',
  'summoner': 'spell'
};


export default DataDragon;