import React from 'react'
import {FormGroup, Button, ButtonGroup, FormControl, HelpBlock, ControlLabel,Panel,Well} from 'react-bootstrap'
import ApiService from '../services/ApiService'
import Auth from '../services/AuthService'

export default class BookingForm extends React.Component{
    
    constructor(props, context) {
        super(props, context);
    
        this.state = {
          value: '',
          email: Auth.getEmail()          
        };

        // if( Auth.isUserAuthenticated()){
        //   console.log('User is authenticated, email:' + Auth.getEmail());
        //   this.setState({email: Auth.getEmail()});
        // }        
      }

      onBook(){
        this.props.onBookFinish();
      }

      onPurchase(){
        this.props.onPurchase();
      }

      handleNameChange(e) {
        this.setState({ value: e.target.value });
      }

      handleEmailChange(e) {
        this.setState({ email: e.target.value });
      }

      render() {
        return (
          <form>
            <FormGroup  controlId="formBasicText">
              <ControlLabel>Name</ControlLabel>
              <FormControl
                type="text"
                value={this.state.value}
                onChange={this.handleNameChange.bind(this)}
              />
              <ControlLabel>Email</ControlLabel>
              <FormControl
                type="email"
                value={this.state.email}
                onChange={this.handleEmailChange.bind(this)}
              />
              <FormControl.Feedback />
            </FormGroup>
            <Well>
            <Button onClick={this.onBook.bind(this)}>Book</Button>
            <Button onClick={this.onPurchase.bind(this)}>Purchase</Button>
            </Well>

          </form>
        );
      }
  } 