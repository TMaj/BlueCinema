import React from 'react'
import {TextField} from 'react-md'
import {Panel, Modal, Button, Label} from 'react-bootstrap'
import ReservationWizard from './ReservationWizard'
import { bootstrapUtils } from 'react-bootstrap/lib/utils';

export default class ReservationModal extends React.Component{

    constructor(props, context) {
        super(props, context);
    
        this.state = {
          seanceId: this.props.seanceId,
          seanceTime: null,
          seanceTitle: null
        };
        
      }

      componentWillReceiveProps(nextProps){       
            this.setState({seanceTime:nextProps.seanceTime});        
      }    

    render(){
        return(        
        <Modal bsSize="lg" show={this.props.show} onHide={this.props.handleClose}>      
        <Modal.Header closeButton>
          <Modal.Title>Ticket reservation and purchase</Modal.Title>
          </Modal.Header>
          <Modal.Body ref='content'>                    
              <ReservationWizard seanceId={this.state.seanceId} seanceTime={this.state.seanceTime}/>
          </Modal.Body>
        </Modal>
        );
    }
}

