import React from 'react';
import './LoadingSpinner.css';

const LoadingSpinner = ({width = '5em', height = '5em'}) => {
  const style ={
    width: width,
    height: height
  };

  return (
    <div className={'loading-spinner'} style={style} />
  );
}

export default LoadingSpinner;