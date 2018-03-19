import React from 'react'
import {TextField, Button, SVGIcon } from 'react-md'
import {Panel, Modal} from 'react-bootstrap'
import LoginModal from './LoginModal'
import RegisterModal from './RegisterModal'

export default class UserPanel extends React.Component{
    constructor(props, context) {
        super(props, context);
    
        this.handleShowLogin = this.handleShowLogin.bind(this);
        this.handleCloseLogin = this.handleCloseLogin.bind(this);
        this.handleCloseRegister = this.handleCloseRegister.bind(this);
        this.handleShowRegister = this.handleShowRegister.bind(this);
    
        this.state = {
          showLogin: false,
          showRegister: false
        };
      }
    
      handleCloseLogin() {
        this.setState({ showLogin: false });
      }
    
      handleShowLogin() {
        this.setState({ showLogin: true });
      }

      handleCloseRegister() {
        this.setState({ showRegister: false });
      }
    
      handleShowRegister() {
        this.setState({ showRegister: true });
      }
    

    render(){
        return(     
            <Panel >
                <Panel.Body>                    
                    <Button flat primary swapTheming onClick={this.handleShowLogin} >Log in</Button>
                    <br/>
                    <Button flat primary  onClick={this.handleShowRegister} >Register</Button>
                    <LoginModal show={this.state.showLogin} handleClose={this.handleCloseLogin} />
                    <RegisterModal show={this.state.showRegister} handleClose={this.handleCloseRegister} />
                </Panel.Body>
            </Panel>
        );
    }
}