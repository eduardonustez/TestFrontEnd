import React, { Component } from 'react';
import ReactDOM from "react-dom";
import Popup from 'reactjs-popup';
import CrearVehiculo from "./CrearVehiculoModal";

export class ProjectData extends Component {
  static displayName = ProjectData.name;

  constructor (props) {
    super(props);
    this.state = { projects: [], loading: true };

      fetch('api/SampleData/ObtenerProyectos')
      .then(response => response.json())
      .then(data => {
          this.setState({ projects: data, loading: false });
      });
  }

  static renderProjectsTable (projects) {
      return (
      <table className='table table-striped'>
        <thead>
          <tr>
            <th>Nombre</th>
            <th>Ubicación</th>
          </tr>
        </thead>
        <tbody>
          {projects.map(project =>
            <tr key={project.id}>
                  <td>{project.projectName}</td>
                  <td>{project.location}</td>
            </tr>
          )}
        </tbody>
              </table>
    );
    }
  

  render () {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
          : ProjectData.renderProjectsTable(this.state.projects);
     return (
      <div>
        <h1>Proyectos</h1>
        <p>This component demonstrates fetching data from the server.</p>
             <div className="App">
                 <Popup modal trigger={<button>Nuevo Vehiculo</button>}>
                     {close => <CrearVehiculo close={close} />}
                 </Popup>
             </div>
             {contents}
      </div>
    );
  }
}
//const rootElement = document.getElementById("root");
//ReactDOM.render(<ProjectData />, rootElement);
