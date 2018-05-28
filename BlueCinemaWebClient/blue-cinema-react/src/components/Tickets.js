import React from 'react'
import {Image,Button, DropdownButton, MenuItem} from 'react-bootstrap'

import ApiService from '../services/ApiService'

export default class Tickets extends React.Component{

    constructor(props, context) {
        super(props, context);
    
        this.state = {
         
        };
      }

      componentWillReceiveProps(nextProps){       

      }

    render(){
        return(
            <div>
            <DropdownButton
            bsStyle={'primary'}
            title={'Bilet'}
            key={1}
            id={`dropdown-basic-primary`}
          >
            <MenuItem eventKey="1">Ulgowy</MenuItem>
            <MenuItem eventKey="2">Normalny</MenuItem>
            <MenuItem divider />
            <MenuItem eventKey="3">Zniżkowy</MenuItem>
          </DropdownButton>

          <DropdownButton
            bsStyle={'primary'}
            title={'Liczba'}
            key={2}
            id={`dropdown-basic-primary`}
          >
            <MenuItem eventKey="1">1</MenuItem>
            <MenuItem eventKey="2">2</MenuItem>
            <MenuItem eventKey="3">3</MenuItem>
            <MenuItem eventKey="4">4</MenuItem>
          </DropdownButton>
          </div>
        );
    }
}