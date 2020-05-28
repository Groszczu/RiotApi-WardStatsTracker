const dev = {
  apiGateway: {
    url: 'https://localhost:5001'
  }
};

const production = {
  apiGateway: {
    url: ''
  }
};

const config = process.env.NODE_ENV === 'development' ? dev : production;

export default config;
