import React from 'react'
import {Image,Button, DropdownButton, MenuItem, Well,Panel} from 'react-bootstrap'
import Cards from 'react-credit-cards'
import 'react-credit-cards/es/styles-compiled.css'

import ApiService from '../services/ApiService'

export default class PaymentForm extends React.Component{
 
    render(){
        return(
            <div>
                <Cards 
                number={123141242142}
                name={"R R Romanowski"}
                expiry={"12/21"}
                cvc={"212"}
                focused={true}></Cards>
            </div>
        );
    }
}