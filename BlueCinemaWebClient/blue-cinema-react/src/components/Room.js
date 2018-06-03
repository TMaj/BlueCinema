import React from 'react'
import {Well} from 'react-bootstrap'

export default class Room extends React.Component {

  constructor(props, context) {
    super(props, context);

    this.state = {      
      onBooking: this.props.onBooking,
      disabledPlaces: this.props.disabledPlaces,
      placesArray : []
    };


   }


   componentWillReceiveProps(nextProps){       
    this.setState({disabledPlaces:nextProps.disabledPlaces},()=>(
      console.log('Disabled places in room ' + this.state.disabledPlaces)
    ));       
  }

   onBooking(booked,id){
     this.state.onBooking(booked,id);
   }

    renderPlace(i,enabled, id) {
  
      if(this.state.disabledPlaces.includes(id))
      {        
        let place = <Place value={i} enabled={false} id={id} key={id} onBooking={this.onBooking.bind(this)}/>;
        return place;
      }
      else
      {
        let place = <Place value={i} enabled={true} id={id} key={id} onBooking={this.onBooking.bind(this)}/>;
        return place;
      }
    }

    renderRows(rowsNumber){

     var rows = [];
     let rowsWidth=15;

     for (let i = 0; i < rowsNumber; i++){
       rows.push(

        <div className="board-row" key={i}>
        <div> <b>{i+1}</b></div>
          {this.renderPlace(1,true,i*15+1)}
          {this.renderPlace(2,true,i*15+2)}
          {this.renderPlace(3,true,i*15+3)}
          {this.renderPlace(4,true,i*15+4)}
          {this.renderPlace(5,true,i*15+5)}
          {this.renderPlace(6,true,i*15+6)}
          {this.renderPlace(7,true,i*15+7)}
          {this.renderPlace(8,true,i*15+8)}
          {this.renderPlace(9,true,i*15+9)}  
          {this.renderPlace(10,true,i*15+10)}
          {this.renderPlace(11,true,i*15+11)}
          {this.renderPlace(12,true,i*15+12)}
          {this.renderPlace(13,true,i*15+13)}
          {this.renderPlace(14,true,i*15+14)}
          {this.renderPlace(15,true,i*15+15)}       
        </div>
       )
     }
     return (rows);
    }
     
    
  
    render() {
      const status = <b> {this.props.seanceTitle + ' ' + this.props.seanceTime} </b>;
  
      return (
        <div>
        
        <style type="text/css">{`
        .board-row:after {
            clear: both;
            content: "";
            display: table;
          }
        `}
        </style>
        
        <div>         
          <Well/>
          {this.renderRows(10)}           
        </div>
        </div>
      );
    }
  }

  class Place extends React.Component {
    constructor(props, context) {
      super(props, context);
  
      this.state = {
        id : this.props.id,
        value : this.props.value,
        enabled: this.props.enabled,
        booked: false,
        color: this.props.enabled ? 'white' : 'gray',
        onBooking: this.props.onBooking
      };
    }

    componentWillReceiveProps(nextProps){
      if (!nextProps.enabled)
      {
        this.setState({enabled:nextProps.enabled, color: 'gray' });
      }     
    }

    handleClick() {
      if (!this.state.enabled){
        return;
      }
      this.setState(prevState => ({
        booked: !prevState.booked,
        color: prevState.booked ? 'white' : 'green'
      }),()=>{this.state.onBooking(this.state.booked,this.state.id)});
    }

    render() {
      const divStyle = {
            backgroundColor: this.state.color,
            border: '1px solid #999',
            float: 'left',
            fontSize: '24px',
            fontWeight: 'bold',
            lineHeight: '34px',
            height: '34px',
            marginRight: '-1px',
            marginTop: '-1px',
            padding: '0',
            textAlign: 'center',
            width: '34px'
      };

      return (
        <div>
        <button style={divStyle} onClick={this.handleClick.bind(this)}>
          {this.props.value} 
        </button>
        </div>
      );
    }
  }