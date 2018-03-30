import React from 'react'
import {TextField, Button, SVGIcon } from 'react-md'
import {Panel, Modal, Label} from 'react-bootstrap'
import LoginModal from './LoginModal'
import RegisterModal from './RegisterModal'
import ApiService from '../services/ApiService'
import AuthService from '../services/AuthService'

export default class UserPanel extends React.Component{
    constructor(props, context) {
        super(props, context);
    
        this.handleShowLogin = this.handleShowLogin.bind(this);
        this.handleCloseLogin = this.handleCloseLogin.bind(this);
        this.handleCloseRegister = this.handleCloseRegister.bind(this);
        this.handleShowRegister = this.handleShowRegister.bind(this);
        this.handleLogIn = this.handleLogIn.bind(this);
        this.handleLogOut = this.handleLogOut.bind(this);
        this.handleRegister = this.handleRegister.bind(this);

        this.state = {
          userLoggedIn : AuthService.isUserAuthenticated(),
          showLogin: false,
          showRegister: false,
          errorMessage: '',
          userEmail: AuthService.getEmail()
        };
      }
    
      handleCloseLogin() {
        this.setState({ showLogin: false, errorMessage: '' });
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
      
      handleLogIn(email, password){        
        ApiService.logIn(email,
                         password,
                         ()=>{ this.setState({userLoggedIn: true, showLogin: false, errorMessage: '', userEmail: email}) },
                         (error)=>{ console.log('ustawiam error w state'); this.setState({errorMessage : error})});        
      }

      handleRegister(email, password, rePassword){
        ApiService.register(email, 
                            password, 
                            rePassword,
                            ()=>{ this.setState({showRegister: false}); this.handleLogIn(email, password)},
                            (error)=>{ console.log('ustawiam error w state'); this.setState({errorMessage : error}) }
        )
      }

      handleLogOut(){
         AuthService.deauthenticateUser();
         this.setState({userLoggedIn : false}, () => { this.forceUpdate();} );        
      }

    render(){

      if (!this.state.userLoggedIn){
        return(     
          <Panel>
              <Panel.Body>                    
                  <Button flat primary swapTheming onClick={this.handleShowLogin} >Log in</Button>
                  <br/>
                  <Button flat primary  onClick={this.handleShowRegister} >Register</Button>
                  <LoginModal show={this.state.showLogin} handleClose={this.handleCloseLogin} handleLogIn={this.handleLogIn} errorMessage={this.state.errorMessage}/>
                  <RegisterModal show={this.state.showRegister} handleClose={this.handleCloseRegister} handleRegister={this.handleRegister} errorMessage={this.state.errorMessage}/>
              </Panel.Body>
          </Panel>
        );
      }
      else{
        return( 
          <Panel >
            <Panel.Body>                    
               <h2> <Label bsStyle="primary">{this.state.userEmail}</Label> </h2>
               <br/>
               <Button flat primary swapTheming onClick={this.handleLogOut} >Log out</Button>
            </Panel.Body>
          </Panel>
        );
      }
        
    }
}