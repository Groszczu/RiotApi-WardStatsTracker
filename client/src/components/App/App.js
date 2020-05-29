import React from 'react';
import {BrowserRouter as Router, Route, Switch} from 'react-router-dom';
import './App.css';
import Home from '../Home/Home';
import AccountDetails from '../../containers/AccountDetails';
import Navbar from '../Navbar/Navbar';

const App = () => {
  return (
    <Router>
      <div className="App">
        <Navbar/>
        <main className="content container">
          <Switch>
            <Route exact path="/" component={Home}/>
            <Route exact path="/:platform/account/:summonerName" component={AccountDetails}/>
          </Switch>
        </main>
      </div>
    </Router>
  );
};

export default App;
