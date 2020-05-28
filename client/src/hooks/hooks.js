import {useEffect, useReducer, useRef, useState} from 'react';

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
        fetched: false,
        isError: false,
      };
    case 'FETCH_SUCCESS':
      return {
        ...state,
        isLoading: false,
        fetched: true,
        isError: false,
        data: action.payload,
      };
    case 'FETCH_FAILURE':
      return {
        ...state,
        isLoading: false,
        fetched: false,
        isError: true,
      };
    default:
      throw new Error(`dataFetchReducer action type ${action.type} is not supported`);
  }
};

export const useDataApi = (initialUrl, initialData = null) => {
  const [url, setUrl] = useState(initialUrl);

  const [state, dispatch] = useReducer(dataFetchReducer, {
    isLoading: false,
    fetched: false,
    isError: false,
    data: initialData,
  });

  useEffect(() => {
    let cancelled = false;

    dispatch({type: 'FETCH_INIT'});
    fetch(url)
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
  }, [url]);

  return [state, setUrl];
};
