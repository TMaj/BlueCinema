import React from 'react';
import ReactDOM from 'react-dom';
import {Button,Panel, ListGroupItem, ListGroup, Thumbnail, Image,Tabs, Tab, Nav, NavItem, Modal} from 'react-bootstrap'
import Img from 'react-image'
import {Grid, Cell, TextField} from 'react-md'

export default class FilmsList extends React.Component { 
    render() {

        return( <div> 
                <ListGroup>
                {this.createFilmsList(this.props.filmsList)}
                </ListGroup>
                </div>
         );
    }

    createFilmsList(filmsList){
        var filmComponents = [];
        var key = 0;
        filmsList.forEach(element => {
            filmComponents.push(<ListGroupItem key={key++}>{this.createFilmInfo(element.title, element.duration, element.description)}</ListGroupItem>)
        });
        return filmComponents;
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