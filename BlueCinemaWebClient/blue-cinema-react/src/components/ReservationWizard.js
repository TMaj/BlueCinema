import React from 'react'
import {Tabs,Tab,Image,Button, ButtonGroup} from 'react-bootstrap'
import Room from './Room'
import Tickets from './Tickets'

import ApiService from '../services/ApiService'

export default class ReservationWizard extends React.Component{

    constructor(props, context) {
        super(props, context);
    
        this.state = {
          activeTab: 1,
          seanceId: this.props.seanceId,
          seanceTime: null,
          seanceTitle: null,
          seanceUrl: null
        };
        console.log(`/seances/${this.state.seanceId}`);
        ApiService.get(`/seances/${this.state.seanceId}`,(seance)=>{this.setState({seanceTitle : seance.film.title, seanceUrl: seance.film.url},()=>(console.log('tytul'+seance.film.title)))})
      }

      componentWillReceiveProps(nextProps){       
        this.setState({seanceTime:nextProps.seanceTime});       
      }

    render(){
        return(
            <div>
            <Tabs defaultActiveKey={1} activeKey ={this.state.activeTab} id="uncontrolled-tab-example">
                <Tab eventKey={1} title="Chosen seance details" disabled>
                    <h3><b>{this.state.seanceTitle} </b> {this.props.seanceTime} </h3>
                    <Image src={"/img/".concat(this.state.seanceUrl)} alt="242x200" width="300" height="400" /> 
                </Tab>
                <Tab eventKey={2} title="Seats choice" disabled>
                   <Room seanceTime={this.props.seanceTime} seanceTitle={this.state.seanceTitle}/>
                </Tab>
                <Tab eventKey={3} title="Tickets choice" disabled>
                    <Tickets/>
                </Tab>
                <Tab eventKey={4} title="Payment details" disabled>
                <Image src={"/img/dotpay.png"} alt="242x200" /> 
                </Tab>
            </Tabs>
            <ButtonGroup>
                <Button onClick={()=>{ if (this.state.activeTab>1) this.setState({activeTab: this.state.activeTab-1})}}>Previous</Button>               
                <Button onClick={()=>{if(this.state.activeTab<4) this.setState({activeTab: this.state.activeTab+1})}}>Next</Button>
            </ButtonGroup>
            </div>
        );
    }
}