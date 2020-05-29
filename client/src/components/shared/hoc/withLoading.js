import React from 'react';

const withLoading = (Cmp) =>
  ({ isLoading, loader, ...otherProps}) => {
  if (isLoading) {
    return loader();
  }
  return <Cmp {...otherProps} />;
}

export default withLoading;