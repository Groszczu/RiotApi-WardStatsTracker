import React from 'react';
import './PlatformSelect.css';

const PlatformSelect = (props) => {

  const _handleChange = (event) => {
    props.onChange(event.target.value);
  }
  
  return (
    <select className="platform-dropdown" onChange={_handleChange} defaultValue="Platform">
      <option disabled>Platform</option>
      <option value="eun1">EUNE</option>
      <option value="euw1">EUW</option>
    </select>
  );
}

export default PlatformSelect;