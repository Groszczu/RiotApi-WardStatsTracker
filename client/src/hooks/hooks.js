import {useEffect, useReducer, useRef} from 'react';

export const useIsMountedRef = () => {
  const isMountedRef = useRef(null);
  useEffect(() => {
    isMountedRef.current = true;

    return () => isMountedRef.current = false;
  });

  return isMountedRef;
};

const dataFetchReducer = (state, action) => {
  switch (action.type) {
    case 'FETCH_INIT':
      return {
        ...state,
        isLoading: true,
        isError: false,
      };
    case 'FETCH_SUCCESS':
      return {
        ...state,
        isLoading: false,
        isError: false,
        data: action.payload,
      };
    case 'FETCH_FAILURE':
      return {
        ...state,
        isLoading: false,
        isError: true,
      };
    default:
      throw new Error(`dataFetchReducer action type ${action.type} is not supported`);
  }
};

const fetchDataReducer = (state, action) => {
  return {
    url: action,
    timestamp: Date.now()
  }
};

export const useDataApi = (initialUrl, initialData = null) => {
  const [fetchData, changeUrl] = useReducer(fetchDataReducer, {
    url: initialUrl,
    timestamp: Date.now(),
  });

  const [state, dispatch] = useReducer(dataFetchReducer, {
    isLoading: true,
    isError: false,
    data: initialData,
  });

  useEffect(() => {
    let cancelled = false;

    dispatch({type: 'FETCH_INIT'});
    fetch(fetchData.url)
      .then(response => {
        if (!response.ok) {
          throw new Error('Failed to fetch data');
        }
        return response.json();
      })
      .then(responseBody => {
        if (!cancelled) {
          dispatch({type: 'FETCH_SUCCESS', payload: responseBody});
        }
      })
      .catch(error => {
        if (!cancelled) {
          dispatch({type: 'FETCH_FAILURE'});
        }
      });

    return () => {
      cancelled = true;
    }
  }, [fetchData.url, fetchData.timestamp]);

  return [state, changeUrl];
};
