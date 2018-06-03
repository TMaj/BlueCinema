import React from 'react'
import {Well,Tabs,Tab,Image,Button, ButtonGroup} from 'react-bootstrap'
import Room from './Room'
import Tickets from './Tickets'
import PaymentForm from './PaymentForm'
import BookingForm from './BookingForm'
import ApiService from '../services/ApiService'
import Auth from '../services/AuthService'

export default class ReservationWizard extends React.Component{

    constructor(props, context) {
        super(props, context);
    
        this.state = {
          activeTab: 1,
          seanceId: this.props.seanceId,
          seanceTime: null,
          seanceTitle: null,
          seanceUrl: null,
          bookedPlaces: [],
          disabledPlaces: [],
          price: 0,
          bookingFinished: false    
        };
        console.log(`/seances/${this.state.seanceId}`);
        ApiService.get(`/seances/${this.state.seanceId}`,(seance)=>{this.setState({seanceTitle : seance.film.title, seanceUrl: seance.film.url, disabledPlaces: seance.bookedPlaces},
            ()=>(console.log('tytul'+seance.film.title+' zajete miejsca'+ this.state.disabledPlaces) ))});
            
      }

      componentWillReceiveProps(nextProps){       
        this.setState({seanceTime:nextProps.seanceTime});       
      }

      onBookFinish(){
        ApiService.post('/bookings', { seanceId: this.state.seanceId, bought: false, bookedPlaces: this.state.bookedPlaces, userId: Auth.getUid(), email: Auth.getEmail() },
            ()=>(this.setState({bookingFinished: true})));
      }

      onBooking(booked, id){
          if(booked){
              this.setState({ bookedPlaces : [...this.state.bookedPlaces, id], price: (this.state.bookedPlaces.length+1)*20},()=>{console.log(this.state.bookedPlaces)});
          }
          else{
              var array = [... this.state.bookedPlaces];
              array.splice(array.indexOf(id),1);
              this.setState({ bookedPlaces : array , price: array.length*20 });
          }

         
          console.log('Highest call');
          console.log(booked);
          console.log(id);
      }

      onPriceChange(newPrice){
          this.setState({price: newPrice});
      }

    render(){
        if(this.state.bookingFinished)
        {
            return(
            <Well> <div> <Image src="img/ok.png" width="100" height="100" /> <h2> <b> Booking Successfull </b> </h2> <br/>  </div>
            <br/><br/><br/> <h3><b>{this.state.seanceTitle} </b> {this.props.seanceTime} </h3> <br/>
            <h2>Price: {this.state.price} pln</h2>
            </Well>);
        }
        else

        return(            
            <div>
            <Tabs defaultActiveKey={1} activeKey ={this.state.activeTab} id="uncontrolled-tab-example">
                <Tab eventKey={1} title="Chosen seance details" disabled>
                    <h3><b>{this.state.seanceTitle} </b> {this.props.seanceTime} </h3>
                    <Image src={"/img/".concat(this.state.seanceUrl)} alt="242x200" width="300" height="400" /> 
                </Tab>
                <Tab eventKey={2} title="Seats choice" disabled>
                   <Room seanceTime={this.props.seanceTime} seanceTitle={this.state.seanceTitle} onBooking={this.onBooking.bind(this)} disabledPlaces={this.state.disabledPlaces}/>
                </Tab>
                <Tab eventKey={3} title="Tickets choice" disabled>
                    <Tickets tickets={this.state.bookedPlaces} onPriceChange={this.onPriceChange.bind(this)}/>
                </Tab>
                <Tab eventKey={4} title="Credentials" disabled>
                    <BookingForm onBookFinish={this.onBookFinish.bind(this)} onPurchase={()=>{if(this.state.activeTab<5) this.setState({activeTab: this.state.activeTab+1})}}/>
                </Tab>
                <Tab eventKey={5} title="Payment details" disabled>
                    <Image src={"/img/dotpay.png"} alt="242x200" /> 
                    <PaymentForm />
                </Tab>
            </Tabs>
            <ButtonGroup>
                <Button onClick={()=>{ if (this.state.activeTab>1) this.setState({activeTab: this.state.activeTab-1})}}>Previous</Button>               
                <Button onClick={()=>{if(this.state.activeTab<5) this.setState({activeTab: this.state.activeTab+1})}}>Next</Button>
            </ButtonGroup>
            </div>
        );
    }
}