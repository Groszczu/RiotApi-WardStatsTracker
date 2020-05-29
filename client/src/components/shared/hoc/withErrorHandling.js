import React from 'react';

const withErrorHandling = (Cmp) =>
  ({ isError, errorHandler, ...otherProps }) => {
  if (isError) {
    return errorHandler();
  }
  return <Cmp {...otherProps} />;
}

export default withErrorHandling;