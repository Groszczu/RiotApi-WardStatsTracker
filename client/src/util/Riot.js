
const generateSummonerKey = (platformMoniker, summonerName) => {
  return `${summonerName.toUpperCase()}#${platformMoniker.toUpperCase()}`;
}

const generateQueueTypeKey = (queueId) => {
  return `queue#${queueId}`;
}

const Riot = {
  async getAccountId(platformMoniker, summonerName) {
    const summonerKey = generateSummonerKey(platformMoniker, summonerName);
    return sessionStorage.getItem(summonerKey)
      || (await this.getSummonerAndCacheAccountId(platformMoniker, summonerName)).accountId;
  },

  async getMatchHistory(platformMoniker, accountId, count = 10) {
    const endpoint = `/api/${platformMoniker}/matches/by-account/${accountId}`;

    const matchHistory = await fetch(endpoint);

    const matchHistoryJson = await matchHistory.json();

    return matchHistoryJson.matches.slice(0, count);
  },

  async getMatchDetails(platformMoniker, matchId) {
    const endpoint = `/api/${platformMoniker}/matches/${matchId}`;

    const matchDetails = await fetch(endpoint);

    const matchDetailsJson = await matchDetails.json();

    return matchDetailsJson;
  },

  async getSummonerAndCacheAccountId(platformMoniker, summonerName) {
    const endpoint = `/api/${platformMoniker}/summoners/${summonerName}`;

    const response = await fetch(endpoint);

    const summonerObject = await response.json();

    if (summonerObject.accountId) {
      sessionStorage.setItem(generateSummonerKey(platformMoniker, summonerName), summonerObject.accountId)

      return summonerObject;
    }
  },

  async getQueueType(queueId) {
    const queueTypeKey = generateQueueTypeKey(queueId);
    let queueType = sessionStorage.getItem(queueTypeKey);
    if (queueType) return queueType;

    const endpoint = 'https://static.developer.riotgames.com/docs/lol/queues.json';

    const queues = await fetch(endpoint);

    const queuesJson = await queues.json();

    queueType = queuesJson.find(q => q.queueId === queueId).description;
    sessionStorage.setItem(queueTypeKey, queueType);

    return queueType;
  },
}

export default Riot;