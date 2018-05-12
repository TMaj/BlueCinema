import React from 'react';
import ReactDOM from 'react-dom';
import {Button,Panel, ListGroupItem, ListGroup, Thumbnail, Image,Tabs, Tab, Nav, NavItem, Modal, Grid, Row, Col} from 'react-bootstrap'
import Img from 'react-image'
import {TextField, Paper} from 'react-md'
import ApiService from '../services/ApiService'

export default class FilmsList extends React.Component {
    constructor(props, context) {
        super(props, context);
        
        this.state = {
          filmComponents: [] ,
          login: '',
          password: ''
        };
        
        ApiService.get('/films', (filmsList)=>{ console.log(filmsList); this.setState({ filmComponents : this.createFilmsList(filmsList)}) });        
      }
 
    render() {

        return( <div> 
                <ListGroup>
                {this.state.filmComponents}
                </ListGroup>
                </div>
         );
    }

    createFilmsList(filmsList){
        var filmComponents = [];
        var key = 0;
        filmsList.forEach(element => {
            filmComponents.push(<ListGroupItem key={key++}>{this.createFilmInfo(element.title, element.duration, element.description, element.url)}</ListGroupItem>)
        });
        return filmComponents;
    }

    createFilmInfo(filmTitle, filmDuration, filmDescription,url){        
        return(<FilmInfo title={filmTitle} description={filmDescription} duration={filmDuration} url={url} />)
    }
  }
  
  class FilmInfo extends React.Component{
    render() {
        return(
        <Panel bsStyle="primary">            
            <Panel.Body><h3><strong>{this.props.title}</strong></h3>

            <Grid>
                <Row className="show-grid">
                    <Col xs={6} md={4}>
                    <div>
                    <Image src={"/img/".concat(this.props.url)} alt="242x200"  width="300" height="400"/>
                    </div>
                    <div>
                        <h5>{this.props.duration} min</h5>                        
                    </div>
                    </Col>
                    <Col xs={6} md={4}>
                    <div>                       
                    {this.props.description}
                    <br/>
                    Lorem ipsum dolor sit amet, consectetuer adipiscing elit. 
                    Donec hendrerit tempor tellus. Donec pretium posuere tellus.
                    Proin quam nisl, tincidunt et, mattis eget, convallis nec, purus. 
                    Cum sociis natoque penatibus et magnis dis parturient montes,
                    nascetur ridiculus mus. Nulla posuere.
                    </div>
                    </Col>
                </Row>
            </Grid>         
            </Panel.Body>
        </Panel>
        );
    }
  }