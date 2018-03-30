import React from 'react';
import ReactDOM from 'react-dom';
import {Panel, Nav, NavItem} from 'react-bootstrap'
import ApiService from '../services/ApiService'
import FilmsList from './FilmsList'

 export default class TopPanel extends React.Component{
      
    constructor(props) {
        super(props);
        this.state = {
            activeKey : 1
        };
        this.handleSelect = this.handleSelect.bind(this);
      }

      handleSelect(eventKey) {
        switch(eventKey) {
            case 1:
                ApiService.get('/films', (filmsList)=>{ console.log(filmsList); this.props.onChangePanel(<FilmsList filmsList={filmsList}/>);});
               
                this.setState({
                    activeKey : 1
                });
                break;
            case 2:
                this.props.onChangePanel("Seances");
                this.setState({
                    activeKey : 2
                });
                break;
            case 3:
                this.props.onChangePanel("Information");
                this.setState({
                    activeKey : 3
                });           
        } 
      }

      render(){
          return(            
                <Nav bsStyle="pills" activeKey={this.state.activeKey} onSelect={this.handleSelect} >
                    <NavItem eventKey={1}>
                        Films
                    </NavItem>
                    <NavItem eventKey={2}>
                        Seances
                    </NavItem>
                    <NavItem eventKey={3}>
                        Information
                    </NavItem>
                </Nav>
            )
      }
  }
