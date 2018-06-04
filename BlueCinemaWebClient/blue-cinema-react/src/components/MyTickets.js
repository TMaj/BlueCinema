import React from 'react'
import {ListGroup, ListGroupItem, Image,Button, DropdownButton, MenuItem, Well,Panel} from 'react-bootstrap'
import {Grid, Cell } from 'react-md' 
import ApiService from '../services/ApiService'
import Auth from '../services/AuthService'
import { isNull, isNullOrUndefined } from 'util';

export default class MyTickets extends React.Component{ 

    constructor(props, context) {
        super(props, context);
    
        this.state = {
            bookings: [this.createEmptyEntry()] 
        };

        ApiService.get('/bookings/user/'+ Auth.getUid(), (bookingsDtos)=>{
            let bookingsList = [];
            let iterator= 0;

            if(bookingsDtos.length != 0)
            this.setState({bookings: []});
            
            bookingsDtos.forEach(bookingDto => {
                ApiService.get('/seances/'+bookingDto.seanceId,(seanceDto)=>{ 
                    this.setState({bookings: [...this.state.bookings,this.createBookingEntry(bookingDto,seanceDto)]},()=>{console.log(this.state.bookings)});
                });
            });
            
        });
        
    }

    componentDidMount(){
        if (this.state.bookings.length === 0 || this.state.bookings ==='undefinied' ){
            this.setState({bookings: [this.createEmptyEntry()] });
        }
    }

    sortBookingEntryDesc(entry1, entry2){
        if (entry1.bookingTime > entry2.bookingTime) return -1;
        if (entry1.bookingTime < entry2.bookingTime) return 1;
      return 0;
    }

    createEmptyEntry(){
        return({ bookingEntry: <ListGroupItem> <h1> Your booking list is empty </h1> </ListGroupItem>  });
    }

    createPlaces(placesArray){
        let placesList= [];
        placesArray.forEach(place=>{ 
            placesList.push(" Row: " + Math.ceil(place/15) + " Place: " + place%15 + "  |");
        });

        return placesList;
    }

    cancelBooking(booking){
        console.log("Clicked booking id: " + booking.id);
        
        ApiService.delete('/bookings/' + booking.id,()=>{
            var index = this.state.bookings.map(b=>b.bookingId).indexOf(booking.id);
            console.log("Found booking index: " + index);

            if (index > -1) {               
                console.log("Removing booking");
                console.log(this.state.bookings.filter(b => b.bookingId !== booking.id));
                this.setState({bookings: this.state.bookings.filter(b => b.bookingId !== booking.id)});
            }
            
            console.log("Checking bookigs letngth: " + index);
            if (this.state.bookings.length === 0 || this.state.bookings ==='undefinied' ){
                this.setState({bookings: [this.createEmptyEntry()] });
            }
        }); 
    }

    createBookingEntry(booking,seance){          
        return(
            {
                bookingId: booking.id,
                bookingTime: new Date(booking.bookingTime),
                bookingEntry:              
                            <ListGroupItem>    
                                <Grid>
                                    <Cell>
                                        <Image src={"/img/".concat(seance.film.url)} width="200" height="250" />
                                    </Cell>
                                    <Cell>
                                        <Panel>
                                            <h2> {seance.film.title} </h2><br/>
                                            <h3> {seance.time} </h3><br/>
                                            <h4> {this.createPlaces(booking.bookedPlaces)} </h4><br/>
                                            Booking time: {booking.bookingTime} <br/> <br/>
                                            Reservation code:<b> {booking.id.substring(1, 8)} </b>                                      
                                        </Panel>
                                    </Cell>
                                    <Cell>
                                        <Button onClick={()=>{this.cancelBooking(booking)}}> Cancel booking </Button>
                                    </Cell>
                                </Grid>                 
                            </ListGroupItem>
            }    
        );
    }

    render(){
        return(
            <div>
            {this.state.bookings.sort(this.sortBookingEntryDesc).map(b => b.bookingEntry)}
            </div>
        );
    }
}

