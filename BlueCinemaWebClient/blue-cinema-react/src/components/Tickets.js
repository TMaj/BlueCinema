import React from 'react'
import {Image,Button, DropdownButton, MenuItem, Well,Panel} from 'react-bootstrap'

import ApiService from '../services/ApiService'

export default class Tickets extends React.Component{

    constructor(props, context) {
        super(props, context);
    
        this.state = {
          ticketEntries: [],
          normalTickets: 0,
          discountTickets: 0,
          sum: 0
        };
    
      } 

      componentDidMount(){
        this.props.onPriceChange(this.state.ticketEntries.length*20 );
      }
      

      updateSum()
      {
        this.setState({sum: this.state.normalTickets* 20 + this.state.discountTickets*15});
      }

      onTicketChanged(type){
        console.log('Ticket set to '+type);

        this.setState((prevState, props) => ({
          sum: prevState.sum + (type==="discounted" ? -5 : + 5)
        }),()=>{this.props.onPriceChange(this.state.sum);console.log('Current sum: '+ this.state.sum)}); 

        // if(type==="discounted"){
        //   this.setState({
        //     sum: this.state.sum-20+15
        //   },()=>{console.log('current sum '+this.state.sum);this.props.onPriceChange(this.state.sum)});
        // }
        // else{
        //   this.setState({
        //     sum: this.state.sum+20-15
        //   },()=>{console.log('current sum '+this.state.sum);this.props.onPriceChange(this.state.sum)});
        // }
      }

      componentWillReceiveProps(nextProps){
        this.createTicketEntries(nextProps.tickets)
      }

      createTicketEntries(ticketNumbers){
          var aaa = [];
          ticketNumbers.forEach(element => {  
          aaa.push(<TicketEntry row={Math.ceil(element/15)} place={element%15} ticketType={"normal"} onTicketChanged={this.onTicketChanged.bind(this)}/>);
        });

        console.log('Setting the sum to '+aaa.length*20);
        this.setState({sum: aaa.length*20});        
        this.setState({ticketEntries: []});
        this.setState({ticketEntries: aaa});
      }
      

    render(){
        return(
            <div>
            <Well><h3>Chosen tickets</h3> <br/>  </Well>

            {this.state.ticketEntries}
          </div>
        );
    }
}

class TicketEntry extends React.Component{

  constructor(props, context) {
    super(props, context);

    this.state = {
      ticketType: this.props.ticketType
    };

  }

 handleSelect(eventKey){
  switch(eventKey) {
    case 1:
        if(this.state.ticketType ==="normal"){
          this.setState({ticketType: "discounted"});
          this.props.onTicketChanged("discounted");
        }
        break;
    case 2:
        if(this.state.ticketType ==="discounted"){
          this.setState({ticketType: "normal"});
          this.props.onTicketChanged("normal");
        }
        break;
      }
  }

  render(){
    return(
        <div>
          <Panel>
          <h4> <b> Row: {this.props.row}, Place: {this.props.place}</b> </h4> <h3><b>  Ticket: {this.state.ticketType} </b>   {this.state.ticketType==="normal" ? "20 pln":"15 pln" } </h3>
          <DropdownButton bsStyle={'primary'} title={'Bilet'} key={1} id={`dropdown-basic-primary`} onSelect={this.handleSelect.bind(this)}>
          <MenuItem eventKey={1}>Discounted</MenuItem>
          <MenuItem eventKey={2}>Normal</MenuItem>
          </DropdownButton>
       </Panel>
         </div>
    );
}
} 