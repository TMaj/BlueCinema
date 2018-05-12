import React from 'react'
import {TextField} from 'react-md'
import {Panel, Modal, Button, Label} from 'react-bootstrap'
import StepsComponent from './StepsComponent'

export default class Reservation extends React.Component{

    constructor(props, context) {
        super(props, context);
    
        this.state = {
          
        };
        

      }


    render(){
        return(
        <Modal show={this.props.show} onHide={this.props.handleClose}>
            <Modal.Header closeButton>
                <Modal.Title>Welcome</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <div>
                 <StepsComponent /> 
                </div>
            </Modal.Body>
        </Modal>);
    }
}