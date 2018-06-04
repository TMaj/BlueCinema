import React from 'react'
import {Image,Button, DropdownButton, MenuItem, Well,Panel} from 'react-bootstrap'
import ApiService from '../services/ApiService'

export default class PaymentForm extends React.Component{
 
    render(){
        return(
            <div>
            <Well>
                 <Button onClick={()=>this.props.onPurchase(true)}>Purchase</Button>
            </Well>
            </div>
        );
    }
}