import React from 'react'
import { TextField } from 'react-md'
import { Panel, Modal, Button, Label } from 'react-bootstrap'

export default class LoginModal extends React.Component{
    constructor(props, context) {
        super(props, context);
    
        this.state = {
          login: '',
          password: ''
        };
      }

    onLogInClicked(){
        this.props.handleLogIn(this.state.login, this.state.password);
    }    

    updateLoginValue(evt){
        this.setState({
            login: evt
          });
        
    }

    updatePasswordValue(evt){
        this.setState({
            password: evt
          });        
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
                onChange ={(evt)=>this.updateLoginValue(evt)}
                />

                <TextField
                id="floating-password"
                label="Enter your password"
                type="password"
                required
                className="md-cell md-cell--bottom"
                onChange ={(evt)=>this.updatePasswordValue(evt)}
                />

            <Label bsStyle="warning"> {this.props.errorMessage}</Label>
           
            </Modal.Body>
            <Modal.Footer>
                  <Button onClick={this.onLogInClicked.bind(this)}>Log in</Button>
            </Modal.Footer>
        </Modal>);
    }
}