import {generateResourceKey} from './KeyGenerator';

const DataDragon = {
  URI: 'https://ddragon.leagueoflegends.com',

  async getResource(resourceType, resourceId) {
    const resourceKey = generateResourceKey('dd', resourceType);
    const resourcesString = sessionStorage.getItem(resourceKey);
    let resources;
    if (!resourcesString) {
      const version = await this._getLatestVersion();

      const endpoint = `${this.URI}/cdn/${version}/data/en_US/${resourceType}.json`;

      const response = await fetch(endpoint);

      if (!response.ok)
        return null;

      resources = await response.json();
      sessionStorage.setItem(resourceKey, JSON.stringify(resources));
    } else {
      resources = JSON.parse(resourcesString);
    }

    const data = Object.values(resources.data);

    return data.find(r => Number(r.key) === resourceId || Number(r.id) === resourceId);
  },

  async getResourceImgUrl(resource) {
    const iconPath = resource.image.full;
    const imgCatalog = resource.image.group;

    const version = await this._getLatestVersion();

    return `${this.URI}/cdn/${version}/img/${imgCatalog}/${iconPath}`;
  },

  async _getLatestVersion() {
    const versionsKey = generateResourceKey('dd', 'versions');
    let version = sessionStorage.getItem(versionsKey);
    if (version) {
      return version;
    }

    const versionEndpoint = `${this.URI}/api/versions.json`;
    const versions = await fetch(versionEndpoint);
    const versionsJson = await versions.json();
    const latestVersion = versionsJson[0];
    if (latestVersion) sessionStorage.setItem(versionsKey, latestVersion);
    return latestVersion;
  }
};

DataDragon.RESOURCES = {
  CHAMPIONS: 'champion',
  SUMMONER_SPELLS: 'summoner',
  ICONS: 'profileicon'
};

export default DataDragon;