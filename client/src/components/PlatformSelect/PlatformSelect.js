import React from 'react';
import './PlatformSelect.css';

const PlatformSelect = (props) => {

  const _handleChange = (event) => {
    props.onChange(event.target.value);
  }
  
  return (
    <select className="platform-dropdown" onChange={_handleChange} defaultValue="Platform">
      <option disabled>Platform</option>
      {props.platforms.map(p => <option key={p.platformMoniker} value={p.platformMoniker}>{p.platformName}</option>)}
    </select>
  );
}

export default PlatformSelect;