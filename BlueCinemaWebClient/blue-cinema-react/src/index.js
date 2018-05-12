import React from 'react';
import ReactDOM from 'react-dom';
import Img from 'react-image'
import {Grid, Cell} from 'react-md'
import UserPanel from './components/UserPanel'
import ApiService from './services/ApiService'
import FilmsList from './components/FilmsList'
import MainPanel from './components/MainPanel'
import TopPanel from './components/TopPanel'
import {BrowserRouter} from 'react-router-dom'
import {Link} from 'react-router-dom'

 class MainApp extends React.Component{

    constructor(props) {
        super(props);
        this.state = {
            mainPanelElement : "LOL"
        };
        this.onChangeMainPanelElement = this.onChangeMainPanelElement.bind(this);
      }

      onChangeMainPanelElement(element){
            this.setState({
                mainPanelElement : element
            })
      }
    
    render(){
          return(
            <div>        
                <Grid className="grid-example">
                    <Cell>
                        <Link to='/'><Img src="img/BlueCinemaLogo.png" width="80%" height="100%"/></Link>
                    </Cell>
                    <Cell></Cell>
                    <Cell>
                       <UserPanel/>
                    </Cell>                    
                </Grid>                        
                <TopPanel selected={1} onChangePanel={this.onChangeMainPanelElement}/> 
                <MainPanel body={this.state.mainPanelElement}/>
            </div>
          );
      }
  }

ReactDOM.render(
  <BrowserRouter>  
  <MainApp/>
  </BrowserRouter>,
  document.getElementById('app')
);