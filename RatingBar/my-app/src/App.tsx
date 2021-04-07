import React from 'react';
import logo from './logo.svg';
import './App.css';
import { RatingBar } from './Components/rating-bar';

function App() {
  return (
    <div className="App">
      <RatingBar max={10} ratingValue={5}/>
    </div>
  );
}

export default App;
