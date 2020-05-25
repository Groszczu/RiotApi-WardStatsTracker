import React from 'react';
import {BrowserRouter as Router, Route, Switch} from 'react-router-dom';
import './App.css';
import Home from '../Home/Home';
import AccountDetails from '../AccountDetails/AccountDetails';
import Navbar from '../Navbar/Navbar';

const App = () => {
  return (
    <Router>
      <div className="App">
        <Navbar/>
        <main className="content">
          <Switch>
            <Route exact path="/" component={Home}/>
            <Route exact path="/:platform/account/:summonerName"
                   render={(props) => <AccountDetails {...props} timestamp={Date.now()}/>}
            />
          </Switch>
        </main>
      </div>
    </Router>
  );
};

export default App;
