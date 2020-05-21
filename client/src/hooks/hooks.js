import { useEffect, useRef, useState, useReducer } from 'react';

export const useIsMountedRef = () => {
  const isMountedRef = useRef(null);
  useEffect(() => {
    isMountedRef.current = true;

    return () => isMountedRef.current = false;
  });

  return isMountedRef
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

export const useDataApi = (initialUrl, initialData) => {
  const [url, setUrl] = useState(initialUrl);

  const [state, dispatch] = useReducer(dataFetchReducer, {
    isLoading: false,
    isError: false,
    data: initialData,
  });

  useEffect(() => {
    let cancelled = false;

    const fetchData = async () => {
      dispatch({ type: 'FETCH_INIT' });
      try {
        const response = await fetch(url);

        if (!response.ok) {
          throw new Error('Failed to fetch data');
        }

        const responseBody = await response.json();

        if (!cancelled) {
          dispatch({ type: 'FETCH_SUCCESS', payload: responseBody });
        }
      } catch (error) {
        if (!cancelled) {
          dispatch({ type: 'FETCH_FAILURE' });
        }
      }
    }

    fetchData();

    return () => {
      cancelled = true;
    }
  }, [url]);

  return [state, setUrl];
}