import React from 'react'
import {TextField} from 'react-md'
import {Panel, Modal, Button, Label} from 'react-bootstrap'

export default class RegisterModal extends React.Component{

    constructor(props, context) {
        super(props, context);
    
        this.state = {
          email: '',
          pswd1: '',
          pswd2: '',
          pswdError: false,
          pswdErrorText: ''
        };
        

      }

    onRegisterClicked(){
        this.props.handleRegister(this.state.email, this.state.pswd1, this.state.pswd2);
    }

    updateEmailValue(evt){
        this.setState({
            email: evt
          });
        
    }

    updatePswd1Value(evt){
        this.setState({
            pswd1: evt
          }, () => { this.checkForDifference() });
        
    }

    updatePswd2Value(evt){
        this.setState({
            pswd2: evt
          }, () => { this.checkForDifference() } );
        
    }

    checkForDifference(){

        this.setState({
            pswdError : false
        });

        if(this.state.pswd1!='' && this.state.pswd2!='' && !(this.state.pswd1 === this.state.pswd2)){
            this.setState({
                pswdError : true,
                pswdErrorText : 'Passwords dont match '
            });
        }
        else if(this.state.pswd1.length<6){
            this.setState({
                pswdError : true,
                pswdErrorText : 'Password needs at least 6 signs'
            });
        }
        else{
            
        }
    }

    render(){
        return(
        <Modal show={this.props.show} onHide={this.props.handleClose}>
            <Modal.Header closeButton>
                <Modal.Title>Welcome</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                    <TextField
                        id="floating-center-title"
                        label="Email"
                        type="email"
                        required
                        lineDirection="center"
                        placeholder="youremail@email.com"
                        className="md-cell md-cell--bottom"
                        errorText = "Invalid email"
                        onChange ={(evt)=>this.updateEmailValue(evt)}
                    />
                   
                    <TextField
                        id="floating-password"
                        label="Enter your password"
                        type="password"
                        required
                       
                        className="md-cell md-cell--bottom"
                        onChange ={(evt)=>this.updatePswd1Value(evt)}
                     />

                     <TextField
                        id="floating-password"
                        label="Confirm your password"
                        type="password"
                        required
                        error={this.state.pswdError}
                        errorText={this.state.pswdErrorText}
                        className="md-cell md-cell--bottom"
                        onChange ={(evt)=>this.updatePswd2Value(evt)}
                     />

            <Label bsStyle="warning"> {this.props.errorMessage}</Label>
            </Modal.Body>
            <Modal.Footer>
                <Button onClick={this.onRegisterClicked.bind(this)} >Register</Button>
            </Modal.Footer>
        </Modal>);
    }
}