import React, { Component } from 'react';
import portada from '../Images/home-start.png';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Peajes Electr�nicos</h1>
        <p>Welcome...</p>
            <img src={portada} alt="Portada" style={{ width: 1000, height: 600 }} />;
      </div>
    );
  }
}
