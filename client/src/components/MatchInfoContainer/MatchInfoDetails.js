import React from 'react';

const MatchInfoDetails = ({ queueType, match, isWin }) => {
  return (
    <>
      <em>{queueType}</em>
      <p>{getMatchDate(match.gameCreation)}</p>
      {isWin ? <p className="victory-tag">Victory</p> : <p className="defeat-tag">Defeat</p>}
      <p>{calculateMatchDuration(match.gameDuration)}</p>
    </>
  );
};

function getMatchDate(matchTimestamp) {
  const currDate = Date.now();
  const diffInMilliseconds = currDate - matchTimestamp;

  const diffInMinutes = Math.floor(diffInMilliseconds / 60000);
  return generateMatchDateMessage(diffInMinutes);
}

function generateMatchDateMessage(timeInMinutes) {
  let unit;
  let quantity;
  if (timeInMinutes < 60) {
    // minutes
    unit = 'minute';
    quantity = timeInMinutes;
  } else if (timeInMinutes < 60 * 24) {
    // hours
    unit = 'hour';
    quantity = Math.floor(timeInMinutes / 60);
  } else {
    // days
    unit = 'day';
    quantity = Math.floor(timeInMinutes / (60 * 24));
  }

  if (quantity !== 1) {
    unit += 's';
  }

  return `${quantity} ${unit} ago`;
}

function calculateMatchDuration(durationInSeconds) {
  const minutes = Math.floor(durationInSeconds / 60);
  const secondsLeft = durationInSeconds % 60;
  return `${minutes}m ${secondsLeft}s`;
}

export default MatchInfoDetails;