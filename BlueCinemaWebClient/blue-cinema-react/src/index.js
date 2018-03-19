import React from 'react';
import ReactDOM from 'react-dom';
import {Button,Panel, ListGroupItem, ListGroup, Thumbnail, Image,Tabs, Tab, Nav, NavItem, Modal} from 'react-bootstrap'
import Img from 'react-image'
import {Grid, Cell, TextField} from 'react-md'
import UserPanel from './components/UserPanel'

const title = 'My Minimal React Webpack Babel Setup';
const thumbnaildir = "thumbnail.png"


class FilmsList extends React.Component {

    render() {
        return( <div> <ListGroup>
            <ListGroupItem>{this.createFilmInfo("Quo Vadis", 90, "A movie about ancient Rome")}</ListGroupItem>
            <ListGroupItem>{this.createFilmInfo("Spiderman", 120, "Adventures of a famous hero")}</ListGroupItem>
            <ListGroupItem>{this.createFilmInfo("Spiderman", 120, "Adventures of a famous hero")}</ListGroupItem>
            <ListGroupItem>{this.createFilmInfo("Silence of the Lambs", 110, "Horrifying story about serial killer")}</ListGroupItem>
            <ListGroupItem>{this.createFilmInfo("Avatar", 80, "Futuristic tales about blue civilization")}</ListGroupItem>
            <ListGroupItem>{this.createFilmInfo("Private Rayan", 150, "Touching history of a lost soldier")}</ListGroupItem>
            <ListGroupItem>{this.createFilmInfo("Troy", 90, "Famous clash between Greeks and Toyans")}</ListGroupItem>
            <ListGroupItem>{this.createFilmInfo("Wolf of Wallstreet", 100, "Leonardo Dicaprio in a terrific role")}</ListGroupItem>
            <ListGroupItem>{this.createFilmInfo("Matrix", 110, "Keanu Reaves fights armies of enemies on his own")}</ListGroupItem>
            </ListGroup>
          </div>);
    }

    createFilmInfo(filmTitle, filmDuration, filmDescription){
        return(<FilmInfo title={filmTitle} description={filmDescription} duration={filmDuration} />)
    }
  }
  
  class FilmInfo extends React.Component{
    render() {
        return(
        <Panel bsStyle="primary">            
            <Panel.Body><h4>{this.props.title}</h4> 
            <br/>
            <div>
            <Image src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT0ciPaU3nSmbO37vnngwfnyYW7ezmqNelcfWRFEirTO1oKB7xs" alt="242x200" />
            </div>
            <div>
                <h5>{this.props.duration} min</h5>
                <br/>
                {this.props.description}
            </div>
            
            </Panel.Body>
        </Panel>
        );
    }
  }

  class TopPanel extends React.Component{
      
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
                this.props.onChangePanel(<FilmsList/>);
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

class MainPanel extends React.Component{
    render(){
        return(
            <Panel bsStyle="primary">            
                <Panel.Body> 
                {this.props.body}
                </Panel.Body>                            
            </Panel>
        );
    }
}
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
                        <Img src="img/BlueCinemaLogo.png" width="80%" height="100%"/>
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
  <MainApp/>,
  document.getElementById('app')
);