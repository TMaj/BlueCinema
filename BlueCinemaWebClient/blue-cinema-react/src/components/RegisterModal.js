import React from 'react'
import {TextField} from 'react-md'
import {Panel, Modal, Button} from 'react-bootstrap'

export default class RegisterModal extends React.Component{

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
                    />
                   
                    <TextField
                        id="floating-password"
                        label="Enter your password"
                        type="password"
                        required
                        className="md-cell md-cell--bottom"
                     />

                     <TextField
                        id="floating-password"
                        label="Confirm your password"
                        type="password"
                        required
                        className="md-cell md-cell--bottom"
                     />

                   
            </Modal.Body>
            <Modal.Footer>
                <Button flat primary swapTheming onClick={this.handleShow} >Register</Button>
            </Modal.Footer>
        </Modal>);
    }
}