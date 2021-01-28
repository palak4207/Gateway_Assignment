import React from 'react';
import './App.css';
import Header from './Header/Header';
import Body from './Body/Body';
import Footer from './Footer/Footer';

function App() {
  return (
    <React.Fragment>
    <div className="App">
     <Header/>
     <Body/>
     <Footer/>
    </div>
    </React.Fragment>
  );
}

export default App;
