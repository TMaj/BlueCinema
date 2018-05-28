import React from 'react'
import {Grid, Cell} from 'react-md'
import {ListGroup, ListGroupItem, Panel, Image, Tab, Tabs, Table} from 'react-bootstrap'
import ReservationModal from './ReservationModal'
import ApiService from '../services/ApiService'

export default class SeanceList extends React.Component {
    constructor(props, context) {
        super(props, context);
        
        this.state = {
            selectedTab: 1,
            filmsWithTimes: null,
            seanceInfoComponents: [],
            reservationModal : null,
            reservatonModalShow: false,
            films: []
        };
      }

      createSeanceInfo(filmTitle, filmDuration, filmDescription,url){        
        return(<FilmInfo title={filmTitle} description={filmDescription} duration={filmDuration} url={url} />)
    }

    componentDidMount(){
        ApiService.get('/seances/time?seanceDate=2018-03-15T16:30:00&filmId=a18e0cfe-3a2e-45d1-aec0-1415cfaf9b52', 
        (filmsList)=>{  
            this.setState({ filmsWithTimes : filmsList}, ()=> {console.log("Filmy z czasami"); console.log(this.state.filmsWithTimes[0].item2)}); 
            var filmy = [];
            var iterator = 0;
            filmsList.forEach(element => {               
                ApiService.get("/films/".concat(element.item2), (film)=>{ filmy.push(<ListGroupItem key={iterator++}><SeanceInfo title={film.title} seanceId={element.item1} seanceHours={element.item3} url={film.url} /></ListGroupItem>)})
            });
            
            this.setState({films : filmy}, ()=>{console.log('Filmy w state'); console.log(filmy); console.log(this.state.films); this.forceUpdate();});        
        });

    }

    render() {

        return( <div> 
                {this.createTabs()}
                <ListGroup>
                    {this.state.films}                    
                </ListGroup>
                </div>
         );
    }

    createTabs(){
        var d = new Date();

        var tabsList = [];
        tabsList.push(<Tab key={1} eventKey={1} title="Today"></Tab>);
        tabsList.push(<Tab key={2} eventKey={2} title="Tomorrow"></Tab>);

        var it = 2
        for  (let i = 2; i < 6; i++) {
            tabsList.push(<Tab key ={i+3} eventKey={it++} title={d.getDate()+i}></Tab>);
        } 

        return(<Tabs id={1} key={1}> {tabsList} </Tabs>)
    }
}


class SeanceInfo extends React.Component {
    constructor(props, context) {
        super(props, context);
        
        this.state = {
            seanceHours: this.props.seanceHours,
            seanceId : this.props.seanceId,
            seanceTime: null
        };
        ApiService.get("/seances/time?seanceDate=2018-03-15T16:30:00&filmId=a18e0cfe-3a2e-45d1-aec0-1415cfaf9b52")
      }

      getHoursRows(){
        var hoursRows = [];
        var it = 0;
        console.log("Hours array"); 
        console.log(this.state.seanceHours);
        this.state.seanceHours.forEach(hour=>{ 
            var dateTime = new Date(hour); 
            var time =dateTime.toLocaleTimeString();
            hoursRows.push(<tr onClick={ ()=>{ console.log('Clicked'); this.setState({ reservatonModalShow : true, seanceTime: time })}} key={it++}><td>{time}</td></tr>)});
        return hoursRows;        
      }
    

    createHoursTable(){
        return(
        <Table striped bordered condensed hover>
            <thead>
                <tr>
                <th>Hour</th>
                </tr>
            </thead>
            <tbody>
                {this.getHoursRows()}
            </tbody>
        </Table>
        );
    }
   
    hideReservationModal(){
        this.setState({reservatonModalShow : false});
    }

    render() {
        return(
        <Panel bsStyle="primary">            
            <Panel.Body>
            <Grid className="grid-example">
                <Cell>
                    <Image src={"/img/".concat(this.props.url)} alt="242x200" width="300" height="400" />            
                <div>
                    <h2>{this.props.title}</h2>
                </div>
                </Cell>
                <Cell>
                    {this.createHoursTable()}
                </Cell>                 
            </Grid>             
            <ReservationModal seanceId={this.state.seanceId} seanceTime={this.state.seanceTime} show={this.state.reservatonModalShow} handleClose={()=>this.hideReservationModal()} />
            </Panel.Body>         
        </Panel>        
        );
    }
}